'KJB 12 Aug 2015 Rev 1.1

Imports System.Text
Imports System.IO
'Imports System.Windows.Input
Imports OpenTK
Imports OpenTK.Graphics
Imports OpenTK.Graphics.OpenGL
Imports Microsoft.VisualBasic.Strings

Public Class frmMain
#Region "Dims"
    Dim blnGLLoaded As Boolean = False      'To indicate that the Graphics Screen is loaded.
    Dim blngCodeLoaded As Boolean = False   'To indicate whether gCode file has been loaded
    Dim blnManualMode As Boolean = True     'To indicate that a Human is "touching" controls instead of progammatically

    Public Structure gcLine     'Structure for gCode line. 
        Public Text As String   'Line of text
        Public Token As String  'The G-Code Token for the line (eg. G1, M28, etc)
        Public Params As String 'The parameters of the G-Code (e.g. X62 Y74)
        Public Line As Integer      'The linenumber that this gcode is displayed on in the TextBox.
        Public Layer As Integer     'The Layer that this gCode is on
        Public Color As Color   'Color of the Interpreted text
        Public Location As Integer  'Location within the RichTextbox
        Public Length As Integer    'Length of this text 
        Public VectorNum As Integer 'gVector index to which this line ENDS the vector.
        Public X, Y, Z As Single     'Logical Coords
        Public E As Single           'Extrusion coord
        Public F As Single           'Speed of print coord
        Public BX, BY, BZ As Single  'Backlash-compensated coords
        Public BE As Single          'Backlash-compensated Extrusion coord
    End Structure

    Public Structure gVectors   'Structure of Line Vectors
        Public p1, p2 As Vector3    'Start and end point of physical vector (with backlash comp)
        Public l1, l2 As Vector3    'Start and end point of logical vector
        Public c1, c2 As Color      'Start and end colors of vector, corresponding to p1, p2
        Public el1, el2, ep1, ep2 As Single     'Extrusion value at start and end of the vector - el=logical, ep=physical (w backlash)
        Public Layer As Integer     'The Layer that this vector is logically printing on
        Public gLineNum1, gLineNum2 As Integer  'The line numbers (Start and end) of the gCode that this vector was created from.
    End Structure

    Dim mygCode(10) As gcLine     'the Array number is the line. 0 is not used.
    Dim mygLine, mygLines As Integer          'The line to draw the gCode till, and all the lines in the gCode file
    Dim mygLayers As Integer         'Total Layers
    Dim blnAbsoluteMode As Boolean = True   'Absolute or Relative Mode flag
    Dim nstart, nend As Integer             'Start and End Layers of gCode to draw
    'Dim blgCode(10) as gcLine      'Array of backlash compensated gCode

    Dim lvectors(10) As gVectors    'Array of vectors - that constructs the printout
    Dim myVectors As Integer        'Number of line segments/vectors

    'Set 3D Params
    Dim CameraPos As Vector4
    Dim CameraFOV As Single
    Dim TargetPos As Vector4
    Dim TgtXMin, TgtXMax, TgtYMin, TgtYMax, TgtZMin, TgtZMax As Single
    Dim CameraUp As Vector4
    Dim ViewportX, ViewportY As Integer     'The bottom left of the viewport

    'Backlash Params 
    Dim BacklashXmin, BacklashXmax, BacklashYmin, BacklashYMax, BacklashZMin, BacklashZMax, BacklashEMin, BacklashEMax As Single
    Dim curX, curY, curZ, curE As Single        'These are the logical positions (numbers in the computer - where the computer thinks it wants to go to...)
    Dim lastX, lastY, lastZ, lastE As Single    'These are the logical position of the previous position (where the computer thinks it was at)
    Dim PhysX, PhysY, PhysZ, PhysE As Single    'These are the physical positions (where the physical head should go)
    Dim PrevX, PrevY, PrevZ, PrevE As Single    'These are the physical position of the previous position (where the head actually is)
#End Region

    Private Sub glc3DView_Load(sender As Object, e As EventArgs) Handles glc3DView.Load
        'Debug.Print("GL Cleared")
        blnGLLoaded = True
        Redraw()
    End Sub

    Private Sub glc3DView_Paint(sender As Object, e As PaintEventArgs) Handles glc3DView.Paint
        If (Not blnGLLoaded) Then Return

        'blnManualMode = False   'Program is doing stuff
        'Debug.Print("Paint..." & DateTime.Now)
        'Clear Buffers
        GL.Clear(ClearBufferMask.ColorBufferBit Or ClearBufferMask.DepthBufferBit)  'Clear Color and Depth buffers
        GL.ClearColor(Color.Black)

        SetupViewport()

        'Sync and Swap
        GraphicsContext.CurrentContext.VSync = True 'Caps frame rate as to not over run GPU        
        'GraphicsContext.SwapInterval
        glc3DView.SwapBuffers() 'Takes from the 'GL' and puts into control

        'blnManualMode = True    'Program has stopped doing stuff
    End Sub

    Private Sub RawtoInterpreted()
        'Routine to take the Source Text, parse and place in array, and load them to Interpreted Text, assign color
        Dim txtAll As String = rtbSource.Text
        Dim sbline As New StringBuilder
        Dim linenum As Integer = 1
        Dim myline As String
        Dim Curlocation As Integer = 0    'Current location in the textbox
        Dim newline, strToken(), tmpText As String

        rtbInterpreted.Clear()  'Clear the interpreted RichTextBox

        For Each myline In txtAll.Split(ControlChars.Lf)
            If linenum > mygCode.Length - 1 Then    'Increase the array if needed
                ReDim Preserve mygCode(mygCode.Length + 10)
            End If
            With mygCode(linenum)       'Load the text into the array
                .Text = myline.ToString
                newline = linenum & " : " & myline & ControlChars.Lf

                .Location = Curlocation
                .Length = newline.Length + 0
                Curlocation += .Length

                If .Text = "" Or Strings.Left(.Text, 1) = ";" Then     'Remark or empty line
                    .Token = ";"
                Else
                    'Remove remarks from the line
                    tmpText = Trim(.Text)
                    If tmpText.Contains(";") Then
                        tmpText = Trim(Strings.Left(.Text, InStr(.Text, ";") - 1))
                    End If
                    strToken = Strings.Split(tmpText, " ", 2)     'Return token in 1st in array, remainder in 2nd, onwards
                    .Token = strToken(0)
                    If strToken.Length > 1 Then
                        .Params = strToken(1)
                    Else
                        .Params = ""
                    End If
                End If
                .Color = mygColor(.Token)

            End With

            sbline.Append(newline)
            linenum += 1

            Application.DoEvents()      'Attend to System events if any

        Next
        mygLines = linenum - 1  'The last populated line
        mygLine = mygLines
        hsbFrom.Maximum = mygLines
        hsbFrom.Value = 1
        hsbTo.Maximum = mygLines
        hsbTo.Value = hsbTo.Maximum / 2

        rtbInterpreted.Text = sbline.ToString

        'Now assign the line in the rtb that the gcode appears in - takes care of line wraps, etc. Colorize the lines
        For i = 1 To mygLines
            With mygCode(i)
                .Line = rtbInterpreted.GetLineFromCharIndex(.Location)
                rtbInterpreted.Select(.Location, .Length)
                rtbInterpreted.SelectionColor = .Color
            End With
        Next
    End Sub

    Private Sub ProcessLayers()
        'Determine which lines contain which layers of print. Assign -999 to XYZEF if it is undefined.

        Dim currentlayer As Integer = 0     'The current layer number
        Dim currentZ As Single = 0          'The current Z height of the print - do not count if no real print
        Dim lastZ As Single = 0             'The last Z height that the gCode commanded.
        Dim strToken() As String

        For i = 1 To mygLines
            With mygCode(i)
                Select Case .Token
                    Case "G1", "G0"   'Move Commands
                        'ReDim strToken(10)
                        strToken = .Params.Split(" ")
                        .X = -999 : .Y = -999 : .Z = -999 : .E = -999 : .F = -999   'Set to default NA
                        .BX = -999 : .BY = -999 : .BZ = -999 : .BE = -999
                        For j = 0 To strToken.Length - 1
                            Select Case Strings.Left(strToken(j), 1)
                                Case ";"                                    'Terminate for/next as soon as a remark is seen.
                                    Exit For
                                Case "X"
                                    .X = Strings.Mid(strToken(j), 2)
                                Case "Y"
                                    .Y = Strings.Mid(strToken(j), 2)
                                Case "Z"
                                    .Z = Mid(strToken(j), 2)
                                    lastZ = .Z
                                Case "E"
                                    .E = Mid(strToken(j), 2)
                                Case "F"
                                    .F = Mid(strToken(j), 2)
                                Case ""    'Ignore this
                                Case Else
                                    MessageBox.Show("G0/1 Error token: " & Strings.Left(strToken(j), 1) & " on line " & i)
                            End Select
                        Next
                        If .E >= 0 And (.X <> -999 Or .Y <> -999 Or .Z <> -999) Then
                            'This is the requirement for a valid Line Extrusion/3D Print command - not just spitting, recoiling, etc. 
                            If lastZ > currentZ Then
                                currentlayer += 1
                                currentZ = lastZ
                            End If
                        End If
                    Case "G92" 'Set current position to coords
                        strToken = .Params.Split(" ")
                        .X = -999 : .Y = -999 : .Z = -999 : .E = -999 : .F = -999   'Set to default NA
                        For j = 0 To strToken.Length - 1
                            Select Case Strings.Left(strToken(j), 1)
                                Case ";"                                    'Terminate for/next as soon as a remark is seen.
                                    Exit For
                                Case "X"
                                    .X = Strings.Mid(strToken(j), 2)
                                Case "Y"
                                    .Y = Strings.Mid(strToken(j), 2)
                                Case "Z"
                                    .Z = Mid(strToken(j), 2)
                                    lastZ = .Z
                                Case "E"
                                    .E = Mid(strToken(j), 2)
                                Case "F"
                                    .F = Mid(strToken(j), 2)
                                Case Else
                                    MessageBox.Show("G92 Error token: " & Strings.Left(strToken(j), 1) & " on line " & i)
                            End Select
                        Next
                End Select
                .Layer = currentlayer
            End With

            Application.DoEvents()      'Attend to System events if any

        Next
        mygLayers = currentlayer
        hsbSingleLayer.Maximum = mygLayers
        hsbSingleLayer.Value = 1
        nend = mygLayers
    End Sub

    Private Sub ProcessVectors()
        'Vector drawing and Backlash Compensation
        'Sub to take gCode and build the Logical Line Vectors - what the gCode "thinks" it is printing. 
        'And the Physical Vectors - what the printer actually prints.

        lastX = 0 : lastY = 0 : lastZ = 0 : lastE = 0
        'Assign starting backlash values. 
        BacklashXmin = 0 : BacklashXmax = nudBacklashX.Value : BacklashYmin = 0 : BacklashYMax = nudBacklashY.Value : BacklashZMin = 0 : BacklashZMax = nudBacklashZ.Value
        BacklashEMin = 0 : BacklashEMax = 0
        myVectors = 0
        Dim myPrevgLineNum = 0

        For i = 1 To mygLines
            With mygCode(i)
                .VectorNum = -999
                Select Case .Token
                    Case "G1", "G0"   'Move X, Y, Z, E
                        If .X = -999 Then
                            curX = lastX
                        Else
                            If blnAbsoluteMode Then curX = .X Else curX = lastX + .X
                        End If
                        If .Y = -999 Then
                            curY = lastY
                        Else
                            If blnAbsoluteMode Then curY = .Y Else curY = lastY + .Y
                        End If
                        If .Z = -999 Then
                            curZ = lastZ
                        Else
                            If blnAbsoluteMode Then curZ = .Z Else curZ = lastZ + .Z
                        End If
                        If .E = -999 Then
                            curE = lastE
                        Else
                            If blnAbsoluteMode Then curE = .E Else curE = lastE + .E
                        End If

                        'Apply backlash effects
                        '  E.g. for X movement
                        '  If CurX between BacklashXMin and Xmax, no change to PhysicalX
                        '  If CurX > BacklashXMax, PhysicalX += CurX - BacklashXMax, BacklashXMax = CurX
                        '  if CurX < BacklashXMin, PhysicalX -= BacklashXMin - CurX, BacklashXMin = CurX 
                        '
                        'Compensation for backlash
                        CalcBacklash(curX, PhysX, BacklashXmin, BacklashXmax, nudBacklashX.Value)
                        CalcBacklash(curY, PhysY, BacklashYmin, BacklashYMax, nudBacklashY.Value)
                        CalcBacklash(curZ, PhysZ, BacklashZMin, BacklashZMax, nudBacklashZ.Value)
                        CalcBacklash(curE, PhysE, BacklashEMin, BacklashEMax, nudBacklashE.Value)   'No Backlash for E for now

                        'Assign backlash compensated values
                        If curX <> PhysX Then
                            .BX = curX + (curX - PhysX)
                        End If
                        If curY <> PhysY Then
                            .BY = curY + (curY - PhysY)
                        End If
                        If curZ <> PhysZ Then
                            .BZ = curZ + (curZ - PhysZ)
                        End If
                        If curE <> PhysE Then
                            .BE = curE + (curE - PhysE)
                        End If

                        'Create Vector only when there is some valid Line Extrusion/3D Print command - not just spitting, recoiling, etc.
                        If .E >= 0 And (.X <> -999 Or .Y <> -999 Or .Z <> -999) Then
                            myVectors += 1
                            If myVectors > lvectors.Length - 1 Then    'Increase the array if needed
                                ReDim Preserve lvectors(lvectors.Length + 10)
                            End If

                            With lvectors(myVectors)
                                .l1 = New Vector3(lastX, lastY, lastZ)
                                .l2 = New Vector3(curX, curY, curZ)
                                .p1 = New Vector3(PrevX, PrevY, PrevZ)
                                .p2 = New Vector3(PhysX, PhysY, PhysZ)
                                .Layer = mygCode(i).Layer
                                .gLineNum1 = myPrevgLineNum
                                .gLineNum2 = i
                                .el1 = lastE
                                .el2 = curE
                                .ep1 = PrevE
                                .ep2 = PhysE
                            End With
                            .VectorNum = myVectors
                        End If
                        lastX = curX
                        PrevX = PhysX
                        lastY = curY
                        PrevY = PhysY
                        lastZ = curZ
                        PrevZ = PhysZ
                        lastE = curE
                        PrevE = PhysE
                        myPrevgLineNum = i
                    'Case "G21"   'Set to mm
                    Case "G28"      'Home axes
                        curX = 0 : lastX = 0
                        BacklashXmin = curX
                        BacklashXmax = BacklashXmin + nudBacklashX.Value
                        PhysX = BacklashXmax
                        curY = 0 : lastY = 0
                        BacklashYmin = curY
                        BacklashYMax = BacklashYmin + nudBacklashY.Value
                        PhysY = BacklashYMax
                        curZ = 0 : lastZ = 0
                        BacklashZMin = curZ
                        BacklashZMax = BacklashZMin + nudBacklashZ.Value
                        PhysZ = BacklashZMax
                        PrevX = PhysX
                        PrevY = PhysY
                        PrevZ = PhysZ
                        myPrevgLineNum = i
                    Case "G90"   'Use absolute coordinates mode
                        blnAbsoluteMode = True
                    Case "G91"   'Use relative coordinates mode
                        blnAbsoluteMode = False
                    Case "G92"   'Set current position to coords
                        If .X = -999 Then       '-999 implies not set
                            curX = lastX
                        Else
                            BacklashXmax = (BacklashXmax - curX) + .X
                            BacklashXmin = .X - (curX - BacklashXmin)
                            curX = .X
                            PhysX = curX
                        End If
                        If .Y = -999 Then
                            curY = lastY
                        Else
                            BacklashYMax = (BacklashYMax - curY) + .Y
                            BacklashYmin = .Y - (curY - BacklashYmin)
                            curY = .Y
                            PhysY = curY
                        End If
                        If .Z = -999 Then
                            curZ = lastZ
                        Else
                            BacklashZMax = (BacklashZMax - curZ) + .Z
                            BacklashZMin = .Z - (curZ - BacklashZMin)
                            curZ = .Z
                            PhysZ = curZ
                        End If
                        If .E = -999 Then
                            curE = lastE
                        Else
                            BacklashEMax = (BacklashEMax - curE) + .E
                            BacklashEMin = .E - (curE - BacklashEMin)
                            curE = .E
                            PhysE = curE
                        End If
                        lastX = curX
                        PrevX = PhysX
                        lastY = curY
                        PrevY = PhysY
                        lastZ = curZ
                        PrevZ = PhysZ
                        lastE = curE
                        PrevE = PhysE
                        myPrevgLineNum = i
                    'Case "M82"   'Use absolute distances for extrusion
                    'Case "M84"  'Disable Motors
                    'Case "M106"     'Fan ON
                    'Case "M107"     'Fan Off
                    'Case "M104"     'Set Extruder Temp
                    'Case "M109"     'Set and Wait for Extruder to reach Temp
                    'Case "M140"     'Set Bed Temp
                    'Case "M190"     'Set and Wait for Bed to reach Temp
                    Case Else
                End Select


            End With

            Application.DoEvents()      'Attend to System events if any

            'Debug.Print(i & " : " & mygCode(i).Text)
        Next

    End Sub

    Private Sub CalcBacklash(ByRef curN As Single, ByRef physN As Single, ByRef BacklashMin As Single, ByRef BacklashMax As Single, Backlash As Single)
        '  If CurX between BacklashXmin and Xmax, Move to CurX + 1 will have no effect in PhysX
        '  To move +1 in PhysX, must move CurX to CurX + 1 + (BacklashXMax - CurX)
        '  To move -1 in PhysX, must move CurX to CurX - 1 - (CurX - BacklashXMin)
        If curN > BacklashMax Then
            physN += curN - BacklashMax
            BacklashMax = curN
            BacklashMin = BacklashMax - Backlash
        ElseIf curN < BacklashMin Then
            physN -= BacklashMin - curN
            BacklashMin = curN
            BacklashMax = BacklashMin + Backlash
        End If
    End Sub

    Private Sub InterpretCode()
        blnManualMode = False   'Program is doing stuff

        'Interpret the Raw Code
        lblPrompt.ForeColor = Color.Red
        lblPrompt.Text = "Parsing Raw File ..."
        RawtoInterpreted()      'take the Source Text, parse and place in array, and load them to Interpreted Text, assign color 

        lblPrompt.Text = "Processing Layers ..."
        ProcessLayers()         'Determine which lines contain which layers of print. Assign XYZEF params to each line

        lblPrompt.Text = "Processing Vectors ..."
        ProcessVectors() 'take gCode and build the Logical and Physical Line Vectors

        lblPrompt.ForeColor = Color.Blue
        lblPrompt.Text = "Ready."

        blnManualMode = True    'Program has stopped doing stuff
    End Sub

    Private Sub CreateCompensated()
        'Routine to create the Compensated code

        Dim sbline As New StringBuilder
        Dim strToken() As String

        'Write Backlash-Compensated code to rtbCompensated
        For i = 1 To mygLines
            With mygCode(i)
                Select Case .Token
                    Case "G0", "G1"       'Move X, Y, Z, E
                        'Process compensation only when there is some valid Line Extrusion/3D Print command - not just spitting, recoiling, etc.
                        If (.E <> -999 Or .X <> -999 Or .Y <> -999 Or .Z <> -999) Then
                            sbline.Append("G1 ")
                            strToken = .Params.Split(" ")           'Split params into individual words
                            For j = 0 To strToken.Length - 1
                                Select Case Strings.Left(strToken(j), 1)
                                    Case ";"                        'Terminate for/next as soon as a remark is seen.
                                        sbline.Append(strToken(j))
                                        Exit For
                                    Case "X"
                                        If .BX = -999 Then
                                            sbline.Append(Strings.Left(strToken(j), 1) & .X)
                                        Else
                                            sbline.Append(Strings.Left(strToken(j), 1) & .BX)
                                        End If
                                    Case "Y"
                                        If .BY = -999 Then
                                            sbline.Append(Strings.Left(strToken(j), 1) & .Y)
                                        Else
                                            sbline.Append(Strings.Left(strToken(j), 1) & .BY)
                                        End If
                                    Case "Z"
                                        If .BZ = -999 Then
                                            sbline.Append(Strings.Left(strToken(j), 1) & .Z)
                                        Else
                                            sbline.Append(Strings.Left(strToken(j), 1) & .BZ)
                                        End If
                                    Case "E"                        'Ignore E Compensation for now
                                        If .BE = -999 Then
                                            sbline.Append(Strings.Left(strToken(j), 1) & .E)
                                        Else
                                            sbline.Append(Strings.Left(strToken(j), 1) & .BE)
                                        End If
                                    Case "F"                        'No F Compensation 
                                        sbline.Append(Strings.Left(strToken(j), 1) & .F)
                                    Case Else

                                End Select
                                sbline.Append(" ")
                            Next
                            sbline.Append(ControlChars.Lf)
                        Else
                            sbline.Append(.Text & ControlChars.Lf)
                        End If
                    Case ";", "M82", "M84", "M104", "M106", "M109", "M107", "M140", "M190", "G21", "G28", "G90", "G92"
                        'Non-backlash gcode
                        sbline.Append(.Text & ControlChars.Lf)
                    Case Else
                        'Debug.Print(i & " :  " & mygCode(i).Text)
                End Select
            End With
        Next

        'Put Compensated text into rtbCompensated
        rtbCompensated.Text = sbline.ToString
        sbline.Clear()

    End Sub

    Private Function mygColor(myToken As String) As Color
        'Return the color code for the token
        Dim cMove, cMajor, cTemp, cUnknown, cCommand, cComment As Color

        'Set default colors
        cMove = Color.Green
        cMajor = Color.Blue
        cTemp = Color.Red
        cUnknown = Color.Yellow
        cCommand = Color.Fuchsia
        cComment = Color.Black

        Select Case myToken
            Case ";"
                mygColor = cComment
            Case "T0"   'Select Tool 0"
                mygColor = cCommand
            Case "G1", "G0"   'Move X, Y, Z, E
                mygColor = cMove
            Case "G21"   'Set to mm
                mygColor = cCommand
            Case "G28"      'Home axes
                mygColor = cMajor
            Case "G29"      'Detailed Z-Probe, probes the bed at 3 points. 
                mygColor = cMajor
            Case "G90"   'Use absolute coordinates mode
                mygColor = cCommand
            Case "G91"   'Use relative coordinates mode
                mygColor = cCommand
            Case "G92"   'Set current position to coords
                mygColor = cCommand

            Case "M82"   'Use absolute distances for extrusion
                mygColor = cCommand
            Case "M84"  'Disable Motors
                mygColor = cMajor
            Case "M106" 'Fan ON
                mygColor = cMajor
            Case "M107"     'Fan Off
                mygColor = cMajor
            Case "M104"     'Set Extruder Temp
                mygColor = cTemp
            Case "M109"     'Set and Wait for Extruder to reach Temp
                mygColor = cTemp
            Case "M117"     'Disaply Message. 
                mygColor = cCommand
            Case "M140"     'Set Bed Temp
                mygColor = cTemp
            Case "M190"     'Set and Wait for Bed to reach Temp
                mygColor = cTemp

            Case Else
                mygColor = cUnknown
                Debug.Print("Unknown code : " & myToken)
                'Color.FromArgb(RGB(CInt(Int(256 * Rnd())), CInt(Int(256 * Rnd())), CInt(Int(256 * Rnd()))))
        End Select
    End Function

    Private Sub SetupViewport()
        'Setup the Graphics Viewport
        Dim w As Integer = glc3DView.Width
        Dim h As Integer = glc3DView.Height
        Dim perspective, lookat As Matrix4


        CameraPos.Xyz = New Vector3(hsbCameraX.Value, hsbCameraY.Value, hsbCameraZ.Value)
        TargetPos = New Vector4(hsbTargetX.Value, hsbTargetY.Value, hsbTargetZ.Value, 0)

        lookat = Matrix4.LookAt(CameraPos.Xyz, TargetPos.Xyz, CameraUp.Xyz) 'Setup camera (eye3d, target3d, Up3d)
        GL.MatrixMode(MatrixMode.Modelview) 'Load Camera
        GL.LoadIdentity()
        GL.LoadMatrix(lookat)

        perspective = Matrix4.CreatePerspectiveFieldOfView(hsbCameraZoom.Value * Math.PI / 180, w / h, 1, 10000) 'Setup Perspective (fov, aspect ratio, zNear, zFar)
        GL.MatrixMode(MatrixMode.Projection)
        GL.LoadIdentity()
        GL.LoadMatrix(perspective)
        'GL.Ortho(0, w, 0, h, 2000, -2000) 'Setup Orthographic Projection, bottom left is 0,0 (left, right, bottom, top, zmin, zmax) - zmin is furthest away

        DrawAxes()
        If blngCodeLoaded Then
            If chbSlow.Checked Then
                glc3DView.SwapBuffers()
                GL.Clear(ClearBufferMask.ColorBufferBit Or ClearBufferMask.DepthBufferBit)  'Clear Color and Depth buffers
                GL.ClearColor(Color.Black)
                glc3DView.SwapBuffers()
                chbSlow.Checked = False 'Reset slow mo 
            End If
            If chbTransparent.Checked Then
                GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.One)    'These 2 lines for alpha transparency
                GL.Enable(EnableCap.Blend)
            End If
            DrawVectors()       'Draw in 3D space, Determines target and its bounds
            If chbTransparent.Checked Then GL.Disable(EnableCap.Blend)

            If chbAutotgt.Checked Then
                    hsbTargetX.Value = (TgtXMax + TgtXMin) / 2
                    hsbTargetY.Value = (TgtYMax + TgtYMin) / 2
                    hsbTargetZ.Value = (TgtZMax + TgtZMin) / 2
                End If
            End If

            GL.Viewport(ViewportX, ViewportY, w, h) 'Size of window
        GL.Enable(EnableCap.DepthTest) 'Enable correct Z Drawings
        GL.DepthFunc(DepthFunction.Less) 'Enable correct Z Drawings

        'GL.Viewport(ViewportX, ViewportY, w, h)  ' Viewport (bottom left, top right)
    End Sub

    Private Sub DrawVectors()
        'Read the vectors and draw logical or physical lines as needed
        'Also draw vectors as thick lines with volume or just lines

        Dim pt1, pt2 As Vector3
        Dim e1, e2 As Single
        Dim zcolor1, zcolor2 As Color
        Dim l As Integer
        Dim trn As Integer  'Transparency required

        'For radius sim
        Dim vl, nd As Single    'vl=Vector length, nd=nozzle diameter
        Dim el, fd, fr As Single        'el = extrusion lengh, fd=filament diameter, fr=feedrate

        'lblPrompt.ForeColor = Color.Red
        'lblPrompt.Text = "Drawing ..."

        'Reset the Target Boundaries
        TgtXMin = 999 : TgtXMax = -999 : TgtYMin = 999 : TgtYMax = -999 : TgtZMin = 999 : TgtZMax = -999

        'Loop through layers
        For i = 1 To myVectors      'This is also altered by the option buttons for all, one, or From-To
            'Determine color to draw the layer/lines
            If optDrawAll.Checked Or optDrawOne.Checked Then
                l = lvectors(i).Layer
            ElseIf optDrawFromTo.Checked Then
                l = lvectors(i).gLineNum2
            End If
            If l >= nstart And l <= nend Then
                If chbTransparent.Checked Then
                    trn = 0
                Else
                    trn = 255
                End If
                If optColorRainbow.Checked Then
                    If l Mod 2 = 0 Then
                        zcolor1 = Color.FromArgb(trn, 0, 255, 0)
                        'zcolor1 = Color.FromArgb(RGB(0, 255, 0))
                        zcolor2 = Color.FromArgb(trn, 255, 0, 0)
                    Else
                        zcolor1 = Color.FromArgb(trn, 0, 0, 255)
                        zcolor2 = Color.FromArgb(trn, 255, 255, 0)
                    End If
                ElseIf optColorLayers.Checked Then
                    If l Mod 2 = 0 Then
                        zcolor1 = Color.FromArgb(trn, 224, 224, 0)
                        zcolor2 = Color.FromArgb(trn, 224, 224, 0)
                    Else
                        zcolor1 = Color.FromArgb(trn, 0, 192, 192)
                        zcolor2 = Color.FromArgb(trn, 0, 192, 192)
                    End If
                Else
                    zcolor1 = Color.FromArgb(trn, 128, 128, 128)
                    zcolor2 = Color.FromArgb(trn, 128, 128, 128)
                End If

                If chbBacklashON.Checked Then
                    'Set points to physical points
                    pt1 = lvectors(i).p1
                    pt2 = lvectors(i).p2
                    e1 = lvectors(i).ep1
                    e2 = lvectors(i).ep2
                Else
                    'Set to logical points
                    pt1 = lvectors(i).l1
                    pt2 = lvectors(i).l2
                    e1 = lvectors(i).el1
                    e2 = lvectors(i).el2
                End If

                'zcolor = Color.FromArgb(RGB(CInt(Int(256 * Rnd())), CInt(Int(256 * Rnd())), CInt(Int(256 * Rnd()))))

                If chbThickLines.Checked Then
                    If chbFlat.Checked Then
                        'DrawFlat(New Vector3(10, 10, 0.3), New Vector3(20, 20, 0.3), nd / 2, nd / 2, zcolor1, zcolor2)
                        DrawFlat(pt1, pt2, nd / 2, nd / 2, zcolor1, zcolor2)
                    Else
                        'DrawCylinder(New Vector3(10, 30, 10), New Vector3(20, 20, 20), 0.1, 0.1, zcolor1, zcolor2, 16)
                        'DrawCylinder(New Vector3(83.799, 77.859, 0), New Vector3(72.141, 66.202, 0), 0.1, 0.1, zcolor1, zcolor2, 16)

                        'Calculate r1 and r2 based on nozzle, filament, speed, extrusion. Extrusion must be calculated as the difference from previous E value.
                        'diameter at nozzle = filament diameter * Sqrt( Extrusion length / Printed Length )
                        'Current algorithm ignores the actual nozzle diameter.
                        el = e2 - e1
                        vl = Vector3.Subtract(pt1, pt2).Length
                        fd = hsbFilament.Value / 100
                        nd = fd * Math.Sqrt(el / vl)
                        DrawThick(pt1, pt2, nd / 2, nd / 2, zcolor1, zcolor2, 16)
                    End If
                Else
                    DrawLine(pt1, pt2, zcolor1, zcolor2)
                End If
                If chbSlow.Checked Then     'Slow down the animation by pausing
                    'System.Threading.Thread.Sleep(100)
                    glc3DView.SwapBuffers()
                    glc3DView.SwapBuffers()
                End If

                'Get Bounds for Viewport
                TgtXMin = Math.Min(TgtXMin, Math.Min(pt1.X, pt2.X))
                TgtXMax = Math.Max(TgtXMax, Math.Max(pt1.X, pt2.X))
                TgtYMin = Math.Min(TgtYMin, Math.Min(pt1.Y, pt2.Y))
                TgtYMax = Math.Max(TgtYMax, Math.Max(pt1.Y, pt2.Y))
                TgtZMin = Math.Min(TgtZMin, Math.Min(pt1.Z, pt2.Z))
                TgtZMax = Math.Max(TgtZMax, Math.Max(pt1.Z, pt2.Z))

                'Application.DoEvents()      'Attend to System events if any
            End If
        Next
        'lblPrompt.ForeColor = Color.Blue
        'lblPrompt.Text = "Ready."
    End Sub

    Private Sub DrawFlat(Pt1 As Vector3, Pt2 As Vector3, r1 As Single, r2 As Single, c1 As Color, c2 As Color)
        'Draw Flat outlines in Z space

        Dim theta As Double
        Dim vertices As New List(Of Vector3)
        Dim x, y, z, d, s1, s2 As Single
        Dim tx, rx, ry, rz As Matrix4
        Dim px, ux, vt As Vector3
        Dim pl, pr, p1, p2, p3, p4 As Vector2       'Left and right perpendicualr vectors, and 4 sides of Quad.
        Dim h, ax, ay, az As Single

        px = Vector3.Subtract(Pt2, Pt1)     'Create Vector of the From - To points
        h = px.Length                       'Length of the Vector
        ux = px.Normalized                  'Create Unit Vector of From-To
        d = Math.Sqrt(ux.Y ^ 2 + ux.Z ^ 2)  'Get the hypoteneuse of the unit vector projected on the YZ plane
        ry = New Matrix4(d, 0, -ux.X, 0, 0, 1, 0, 0, ux.X, 0, d, 0, 0, 0, 0, 1) 'Create the Y rotation Matrix
        rx = New Matrix4(1, 0, 0, 0, 0, ux.Z / d, -ux.Y / d, 0, 0, ux.Y / d, ux.Z / d, 0, 0, 0, 0, 1) 'Create the X rotation matrix
        tx = Matrix4.CreateTranslation(Pt1)     'Create the Translation back to proper location

        If chbSimFlow.Checked Then      'Simulate the Flow of the filament through the nozzle, and at speed, and length.
            s1 = r1
            s2 = r2
        Else
            s1 = hsbNozzle.Value / 10
            If optConical.Checked Then
                s2 = s1 * 0.5
            ElseIf optCylinder.Checked Then
                s2 = s1
            End If
        End If

        pl = px.Xy.PerpendicularLeft.Normalized
        pl.Scale(s1 / 2, s1 / 2)
        p1 = Vector2.Add(Pt1.Xy, pl)
        p2 = Vector2.Subtract(Pt1.Xy, pl)

        pr = px.Xy.PerpendicularLeft.Normalized
        pr.Scale(s2 / 2, s2 / 2)
        p3 = Vector2.Subtract(Pt2.Xy, pr)
        p4 = Vector2.Add(Pt2.Xy, pr)

        GL.Begin(BeginMode.Quads)
        GL.Color3(c1)
        GL.Vertex3(p1.X, p1.Y, Pt1.Z)
        GL.Vertex3(p2.X, p2.Y, Pt1.Z)
        GL.Color3(c2)
        GL.Vertex3(p3.X, p3.Y, Pt2.Z)
        GL.Vertex3(p4.X, p4.Y, Pt2.Z)
        GL.End()
    End Sub

    Private Sub DrawThick(Pt1 As Vector3, Pt2 As Vector3, r1 As Single, r2 As Single, c1 As Color, c2 As Color, ns As Integer)
        'Draw cylinder from Pt1 to Pt2 with radius beginning with r1 to r2, and color c1 to c2, ns segments
        'Start by creating a vertical cylinder located at Z. Then rotate the cylinder by rotating in Y, then X to align with P1-P2, then translating to P1

        Dim theta As Double
        Dim vertices As New List(Of Vector3)
        Dim x, y, z, d, s1, s2 As Single
        Dim tx, rx, ry, rz As Matrix4
        Dim px, ux, vt As Vector3
        Dim h, ax, ay, az As Single

        px = Vector3.Subtract(Pt2, Pt1)     'Create Vector of the From - To points
        h = px.Length                       'Length of the Vector
        ux = px.Normalized                  'Create Unit Vector of From-To
        d = Math.Sqrt(ux.Y ^ 2 + ux.Z ^ 2)  'Get the hypoteneuse of the unit vector projected on the YZ plane
        ry = New Matrix4(d, 0, -ux.X, 0, 0, 1, 0, 0, ux.X, 0, d, 0, 0, 0, 0, 1) 'Create the Y rotation Matrix
        rx = New Matrix4(1, 0, 0, 0, 0, ux.Z / d, -ux.Y / d, 0, 0, ux.Y / d, ux.Z / d, 0, 0, 0, 0, 1) 'Create the X rotation matrix
        tx = Matrix4.CreateTranslation(Pt1)     'Create the Translation back to proper location

        If chbSimFlow.Checked Then      'Simulate the Flow of the filament through the nozzle, and at speed, and length.
            s1 = r1
            s2 = r2
        Else
            s1 = hsbNozzle.Value / 10
            If optConical.Checked Then
                s2 = s1 * 0.5
            ElseIf optCylinder.Checked Then
                s2 = s1
            End If
        End If
        For l = 0 To 1
            For s = 0 To ns - 1
                theta = (s / (ns - 1) * 2 * Math.PI)
                x = (s1 * (1 - l) + s2 * l) * Math.Cos(theta)   'Choose r1 or r2 depending on layer
                y = (s1 * (1 - l) + s2 * l) * Math.Sin(theta)
                z = h * l
                vt = New Vector3(x, y, z)

                'Rotate around z - Not needed since we have a cylinder.
                'vt = Vector3.Transform(vt, rz)

                'Rotate around y
                vt = Vector3.Transform(vt, ry)

                If d <> 0 Then  'If d=0, means the vector is already in the x direction, so no rotation in x needed.
                    'Rotate around x
                    vt = Vector3.Transform(vt, rx)
                End If
                'Translate to final position
                vt = Vector3.Transform(vt, tx)

                vertices.Add(vt)
            Next
        Next

        Dim indices As New List(Of Integer)
        For x = 0 To ns - 2
            indices.Add(x)
            indices.Add(x + ns)
            indices.Add(x + ns + 1)

            indices.Add(x + ns + 1)
            indices.Add(x + 1)
            indices.Add(x)
        Next

        GL.Begin(BeginMode.Triangles)
        For Each i In indices
            If i < ns Then
                GL.Color3(c1)
            Else
                GL.Color3(c2)
            End If
            GL.Vertex3(vertices(i))
        Next
        GL.End()

        'Determine normal


        'Determine length
        'Vector3.Length(Pt1, Pt2)

        'Draw cylinder vertically first, then transform to correct position

        'Delete buffers to clean up
    End Sub

    Private Sub DrawLine(Pt1 As Vector3, Pt2 As Vector3, c1 As Color, c2 As Color)
        'Draw line from Pt1 to Pt2 in colors C1 to C2
        'Debug.Write(" Line :  (" & Pt1(0) & ", " & Pt1(1) & ", " & Pt1(2) & ") - (" & Pt2(0) & ", " & Pt2(1) & ", " & Pt2(2) & ")")
        GL.Begin(BeginMode.Lines)
        GL.Color3(c1)
        GL.Vertex3(Pt1)
        GL.Color3(c2)
        GL.Vertex3(Pt2)
        GL.End()
    End Sub

    Private Sub DrawAxes()
        Dim nEnd As Integer = 150
        Dim nGrid As Integer = 10

        'Draw X, Y, Z Axis. Cube
        GL.Begin(BeginMode.Lines)
        'Face 1
        GL.Color3(Color.Red)
        GL.Vertex3(0, 0, 0)
        GL.Vertex3(nEnd, 0, 0)
        GL.Color3(Color.Green)
        GL.Vertex3(0, 0, 0)
        GL.Vertex3(0, nEnd, 0)
        GL.Color3(Color.Blue)
        GL.Vertex3(0, 0, 0)
        GL.Vertex3(0, 0, nEnd)
        'Draw Verticals
        GL.Color3(Color.DarkBlue)
        GL.Vertex3(nEnd, 0, 0)
        GL.Vertex3(nEnd, 0, nEnd)
        GL.Vertex3(0, nEnd, 0)
        GL.Vertex3(0, nEnd, nEnd)
        GL.Vertex3(nEnd, nEnd, 0)
        GL.Vertex3(nEnd, nEnd, nEnd)
        'Draw Top Plane
        GL.Color3(Color.DarkRed)
        GL.Vertex3(0, 0, nEnd)
        GL.Vertex3(nEnd, 0, nEnd)
        GL.Vertex3(0, nEnd, nEnd)
        GL.Vertex3(nEnd, nEnd, nEnd)
        GL.Color3(Color.DarkGreen)
        GL.Vertex3(0, 0, nEnd)
        GL.Vertex3(0, nEnd, nEnd)
        GL.Vertex3(nEnd, 0, nEnd)
        GL.Vertex3(nEnd, nEnd, nEnd)

        'Draw Horizontal and Vertical Grid on Ground plane
        For x = nGrid To nEnd Step nGrid
            GL.Color3(Color.DarkRed)
            GL.Vertex3(0, x, 0)
            GL.Vertex3(nEnd, x, 0)
            GL.Color3(Color.DarkGreen)
            GL.Vertex3(x, 0, 0)
            GL.Vertex3(x, nEnd, 0)
        Next

        GL.End()

    End Sub

    Private Sub Redraw()
        glc3DView.Invalidate()
        glc3DView.Update()
        'glc3DView.Focus()

    End Sub

    Private Sub DisplayHelp(myToken As String)
        'Display help text based on token
        Select Case myToken
            Case ";"    'Remarks
                lblPrompt.Text = "Remarks"
            Case "T0"       'Select Tool 0
                lblPrompt.Text = "Select Tool number"
            Case "G1", "G0"   'Move X, Y, Z, E
                lblPrompt.Text = "Move X, Y, Z, E"
            Case "G21"   'Set to mm
                lblPrompt.Text = "Set to mm"
            Case "G28"      'Home axes
                lblPrompt.Text = "Home specified axes, or all axes if not specified"
            Case "G29"      'Detailed Z-Probe, probes the bed at 3 points. 
                lblPrompt.Text = "Detailed Z-Probe, probes the bed at 3 points."
            Case "G90"   'Use absolute coordinates mode
                lblPrompt.Text = "Use absolute coordinates mode"
            Case "G91"   'Use relative coordinates mode
                lblPrompt.Text = "Use relative coordinates mode"
            Case "G92"   'Set current position to coords
                lblPrompt.Text = "Set current position to specified coords"

            Case "M82"   'Use absolute distances for extrusion
                lblPrompt.Text = "Use absolute distances for extrusion"
            Case "M84"  'Disable Motors
                lblPrompt.Text = "Disable Motors"
            Case "M106" 'Fan ON
                lblPrompt.Text = "Fan On"
            Case "M107"     'Fan Off
                lblPrompt.Text = "Fan Off"
            Case "M104"     'Set Extruder Temp
                lblPrompt.Text = "Set Extruder Temp, don't wait for temp to be reached"
            Case "M109"     'Set and Wait for Extruder to reach Temp
                lblPrompt.Text = "Set and Wait for Extruder to reach Temp"
            Case "M117"     'Dispay Message
                lblPrompt.Text = "Display Message"
            Case "M140"     'Set Bed Temp
                lblPrompt.Text = "Set Bed Temp, don't wait for temp to be reached"
            Case "M190"     'Set and Wait for Bed to reach Temp
                lblPrompt.Text = "Set and Wait for Bed to reach Temp"

            Case Else
                lblPrompt.Text = "Unknown Token : " & myToken
        End Select

    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        blnManualMode = False   'Program is doing stuff
        'Set up Perspectives
        hsbCameraX.Value = 185 : hsbCameraY.Value = 75 : hsbCameraZ.Value = 75
        CameraPos = New Vector4(hsbCameraX.Value, hsbCameraY.Value, hsbCameraZ.Value, 1)
        hsbCameraZoom.Value = 90
        CameraFOV = hsbCameraZoom.Value

        hsbTargetX.Value = 75 : hsbTargetY.Value = 75 : hsbTargetZ.Value = 0
        TargetPos = New Vector4(hsbTargetX.Value, hsbTargetY.Value, hsbTargetZ.Value, 0)
        TgtXMin = 150 : TgtXMax = 0 : TgtYMin = 150 : TgtYMax = 0 : TgtZMin = 150 : TgtZMax = 0

        CameraUp = New Vector4(0, 0, 1, 1)
        ViewportX = 0 : ViewportY = 0

        nstart = 1 : nend = 0   'Reset the start and end drawing layers
        blnManualMode = True    'Program has stopped doing stuff
    End Sub

#Region "UI Interaction section ************************************************************************************************"
    Public IsDragging As Boolean = False
    Public IsRightButton As Boolean = False
    Public isLeftButton As Boolean = False
    Public StartPoint, FirstPoint, LastPoint As Point

    Private Sub btnDebug_Click(sender As Object, e As EventArgs) Handles btnDebug.Click
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Dim tmpcolor As Color

        'ofdgCodeFile.InitialDirectory = "C:\KJB\Draw\3D"
        ofdgCodeFile.InitialDirectory = "C:\KJB\Draw\3D\Blender\Sherline"
        ofdgCodeFile.Filter = "gcode files (*.gcode)|*.gcode|All files (*.*)|*.*"
        ofdgCodeFile.FilterIndex = 1
        ofdgCodeFile.FileName = ""
        ofdgCodeFile.RestoreDirectory = True

        If ofdgCodeFile.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                'Read file to Textbox
                lblPrompt.Text = "Loading file : " & ofdgCodeFile.FileName & " ......"
                Application.DoEvents()
                rtbSource.LoadFile(ofdgCodeFile.FileName, RichTextBoxStreamType.PlainText)

            Catch Ex As Exception
                MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)
            Finally
                ' Check this again, since we need to make sure we didn't throw an exception on open. 
                'If (gCodeStream IsNot Nothing) Then
                '    gCodeStream.Close()
                'End If
            End Try
            Application.DoEvents()
            btnInterpret.Enabled = True
            optSource.Enabled = True
            optInterpreted.Enabled = True
            'optCompensated.Enabled = True
            'btnSaveCode.Enabled = True
            blngCodeLoaded = True
            tmpcolor = lblPrompt.ForeColor
            lblPrompt.ForeColor = Color.Red
            lblPrompt.Text = "Interpreting file : " & ofdgCodeFile.FileName & "."

            InterpretCode()             'Take the lines of code....
            optDrawAll_CheckedChanged(sender, e)

            lblPrompt.ForeColor = tmpcolor
            lblPrompt.Text = "Loaded file : " & ofdgCodeFile.FileName & ". " & mygLayers & " Layers."
            Redraw()
        End If
    End Sub

    Private Sub btnSaveCode_Click(sender As Object, e As EventArgs) Handles btnSaveCode.Click
        'Save backlash compensated gCode

        sfdgCompensated.InitialDirectory = ofdgCodeFile.InitialDirectory
        sfdgCompensated.Filter = ofdgCodeFile.Filter     ' "gcode files (*.gcode)|*.gcode|All files (*.*)|*.*"
        sfdgCompensated.FilterIndex = 1
        sfdgCompensated.AddExtension = True
        sfdgCompensated.FileName = ofdgCodeFile.SafeFileName
        sfdgCompensated.RestoreDirectory = True

        If sfdgCompensated.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                'Read file to Textbox
                lblPrompt.Text = "Saving file : " & sfdgCompensated.FileName & " ......"
                Application.DoEvents()
                rtbCompensated.SaveFile(sfdgCompensated.FileName, RichTextBoxStreamType.PlainText)
            Catch Ex As Exception
                MessageBox.Show("Cannot save file to disk. Original error: " & Ex.Message)
            Finally
                ' Check this again, since we need to make sure we didn't throw an exception on open. 
                'If (gCodeStream IsNot Nothing) Then
                '    gCodeStream.Close()
                'End If
            End Try
            Application.DoEvents()
            lblPrompt.Text = "Saved file : " & sfdgCompensated.FileName
        End If
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Application.Exit()
    End Sub

    Private Sub btnInterpret_Click(sender As Object, e As EventArgs) Handles btnInterpret.Click
        InterpretCode()
        Redraw()
    End Sub

    Private Sub btnCompensate_Click(sender As Object, e As EventArgs) Handles btnCompensate.Click
        'Read Interpreted Code and create compensated code in rtbCompensated
        lblPrompt.ForeColor = Color.Red
        lblPrompt.Text = "Creating Backlash Compensated Code..."
        Application.DoEvents()
        CreateCompensated()

        lblPrompt.ForeColor = Color.Blue
        lblPrompt.Text = "Ready."

    End Sub

    Private Sub btnResetCam_Click(sender As Object, e As EventArgs) Handles btnResetCam.Click
        'Reset the Camera position and View
        hsbCameraX.Value = 185 : hsbCameraY.Value = 74 : hsbCameraZ.Value = 63
        CameraPos = New Vector4(hsbCameraX.Value, hsbCameraY.Value, hsbCameraZ.Value, 1)
        hsbCameraZoom.Value = 90
        CameraFOV = hsbCameraZoom.Value
        chbAutotgt.Checked = True

        Redraw()
    End Sub

    Private Sub chbAutotgt_CheckedChanged(sender As Object, e As EventArgs) Handles chbAutotgt.CheckedChanged
        If blnManualMode Then
            If chbAutotgt.Checked Then
                blnManualMode = False
                Redraw()
                blnManualMode = True
            End If
        End If
    End Sub

    Private Sub chbBacklashON_CheckedChanged(sender As Object, e As EventArgs) Handles chbBacklashON.CheckedChanged
        nudBacklashX_ValueChanged(sender, e)
    End Sub

    Private Sub chbThickLines_CheckedChanged(sender As Object, e As EventArgs) Handles chbThickLines.CheckedChanged, chbSimFlow.CheckedChanged
        If chbThickLines.Checked Then
            optCylinder.Enabled = True
            optConical.Enabled = True
            chbFlat.Enabled = True
            chbTransparent.Enabled = True
            hsbFilament.Enabled = True
            hsbNozzle.Enabled = True
            chbSimFlow.Enabled = True
        Else
            optCylinder.Enabled = False
            optConical.Enabled = False
            chbFlat.Enabled = False
            chbTransparent.Enabled = False
            hsbFilament.Enabled = False
            hsbNozzle.Enabled = False
            chbSimFlow.Enabled = False
        End If
        If blnManualMode Then
            blnManualMode = False
            Redraw()
            blnManualMode = True
        End If
    End Sub

    Private Sub chbFlat_CheckedChanged(sender As Object, e As EventArgs) Handles chbFlat.CheckedChanged, chbTransparent.CheckedChanged
        If blnManualMode Then
            blnManualMode = False
            Redraw()
            blnManualMode = True
        End If
    End Sub

    Private Sub optConical_CheckedChanged(sender As Object, e As EventArgs) Handles optConical.CheckedChanged, optCylinder.CheckedChanged
        If blnManualMode Then
            blnManualMode = False
            Redraw()
            blnManualMode = True
        End If
    End Sub

    Private Sub glc3DView_MouseDown(sender As Object, e As MouseEventArgs) Handles glc3DView.MouseDown
        StartPoint = glc3DView.PointToScreen(New Point(e.X, e.Y))
        FirstPoint = StartPoint
        IsDragging = True
        If e.Button = MouseButtons.Right Then
            IsRightButton = True
            isLeftButton = False
        ElseIf e.Button = MouseButtons.Left Then
            IsRightButton = False
            isLeftButton = True
        End If
    End Sub

    Private Sub glc3DView_MouseClick(sender As Object, e As MouseEventArgs) Handles glc3DView.MouseClick
        'xTrans += 1
        'Debug.Print(xTrans)
        Redraw()
    End Sub

    Private Sub glc3DView_MouseUp(sender As Object, e As MouseEventArgs) Handles glc3DView.MouseUp
        IsDragging = False
    End Sub

    Private Sub glc3DView_MouseMove(sender As Object, e As MouseEventArgs) Handles glc3DView.MouseMove

        If IsDragging Then

            blnManualMode = False

            'Dim blnShiftKeyDown As Boolean
            'blnShiftKeyDown = ((Control.ModifierKeys And Keys.Shift) = Keys.Shift)

            If IsRightButton Then   'Rotate around target
                Dim dTheta, Theta, ThetaZ, dX, dY, dZ, dR, dRz As Single
                Dim blnDraw As Boolean = False
                Dim EndPoint As Point = glc3DView.PointToScreen(New Point(e.X, e.Y))
                Dim Sensitivity As Integer     'The number of degrees to move with each mouse move
                'Debug.Print(EndPoint.X & ", " & EndPoint.Y)

                'Amount of X movement = amount of degrees of rotation in horizontal plane
                dTheta = EndPoint.X - StartPoint.X
                If dTheta <> 0 Then
                    Dim RotateZ, TranslateTgt, TranslateOrg As Matrix4
                    Sensitivity = -1
                    dTheta = dTheta * Sensitivity * Math.PI / 180
                    RotateZ = Matrix4.CreateRotationZ(dTheta)
                    TranslateTgt = Matrix4.CreateTranslation(-TargetPos.X, -TargetPos.Y, -TargetPos.Z)
                    TranslateOrg = Matrix4.CreateTranslation(TargetPos.X, TargetPos.Y, TargetPos.Z)
                    'Translate World to Target as origin, then rotate Camera about Z, then Translate World back to Target.
                    CameraPos = Vector4.Transform(CameraPos, TranslateTgt)
                    CameraPos = Vector4.Transform(CameraPos, RotateZ)
                    CameraPos = Vector4.Transform(CameraPos, TranslateOrg)

                    blnDraw = True
                End If

                'Amount of Y movement = amount of degrees of rotation in vertical plane
                dTheta = EndPoint.Y - StartPoint.Y
                If dTheta <> 0 Then
                    Sensitivity = 1

                    dX = CameraPos.X - TargetPos.X
                    dY = CameraPos.Y - TargetPos.Y
                    dZ = CameraPos.Z - TargetPos.Z
                    dR = Math.Sqrt(dX ^ 2 + dY ^ 2) 'Horizontal radius
                    Theta = Math.Atan2(dX, dY)

                    dRz = Math.Sqrt(dR ^ 2 + dZ ^ 2)    '3D radius
                    ThetaZ = Math.Atan2(dZ, dR)

                    'Now increase Theta by the new angle
                    ThetaZ += dTheta * Sensitivity * Math.PI / 180
                    If ThetaZ > 80 * Math.PI / 180 Then ThetaZ = 80 * Math.PI / 180
                    If ThetaZ < -80 * Math.PI / 180 Then ThetaZ = -80 * Math.PI / 180
                    dR = dRz * Math.Cos(ThetaZ)
                    dX = dR * Math.Sin(Theta)
                    dY = dR * Math.Cos(Theta)
                    dZ = dRz * Math.Sin(ThetaZ)

                    'Now calculate the new Camera position
                    CameraPos.X = dX + TargetPos.X
                    CameraPos.Y = dY + TargetPos.Y
                    CameraPos.Z = dZ + TargetPos.Z

                    blnDraw = True
                End If

                If blnDraw Then     'Draw if needed
                    hsbCameraX.Value = Math.Max(Math.Min(CameraPos.X, hsbCameraX.Maximum), hsbCameraX.Minimum)
                    hsbCameraY.Value = CameraPos.Y
                    hsbCameraZ.Value = CameraPos.Z
                    Redraw()
                End If

                StartPoint = EndPoint
                LastPoint = EndPoint

            ElseIf isLeftButton Then    'Pan camera left right up down
                Dim dTheta, Theta, ThetaZ, dX, dY, dZ, dR, dRz As Double
                Dim blnDraw As Boolean = False
                Dim EndPoint As Point = glc3DView.PointToScreen(New Point(e.X, e.Y))
                Dim Sensitivity As Single     'The number of degrees to move with each mouse move
                'Debug.Print(EndPoint.X & ", " & EndPoint.Y)

                chbAutotgt.Checked = False

                'Amount of X movement = amount of degrees of rotation in horizontal plane
                dTheta = EndPoint.X - StartPoint.X
                If dTheta <> 0 Then
                    Sensitivity = 0.18 / 59 * hsbCameraZoom.Value + 0.0169
                    'Get vector from camera to target
                    dX = TargetPos.X - CameraPos.X
                    dY = TargetPos.Y - CameraPos.Y
                    dZ = TargetPos.Z - CameraPos.Z
                    dR = Math.Sqrt(dX ^ 2 + dY ^ 2) 'Horizontal radius
                    Theta = Math.Atan2(dY, dX)      'Angle from Camera to Target

                    'Now increase Theta by the new angle
                    Theta += dTheta * Sensitivity * Math.PI / 180
                    dX = dR * Math.Cos(Theta)
                    dY = dR * Math.Sin(Theta)
                    'dZ = dZ    'no change to dZ

                    'Now calculate the new Camera position
                    TargetPos.X = dX + CameraPos.X
                    TargetPos.Y = dY + CameraPos.Y
                    TargetPos.Z = dZ + CameraPos.Z

                    blnDraw = True
                End If

                'Amount of Y movement = amount of degrees of rotation in vertical plane
                dTheta = EndPoint.Y - StartPoint.Y
                If dTheta <> 0 Then
                    Sensitivity = 0.18 / 59 * hsbCameraZoom.Value + 0.0169
                    dX = TargetPos.X - CameraPos.X
                    dY = TargetPos.Y - CameraPos.Y
                    dZ = TargetPos.Z - CameraPos.Z
                    dR = Math.Sqrt(dX ^ 2 + dY ^ 2) 'Horizontal radius
                    Theta = Math.Atan2(dY, dX)      'Angle from Camera to Target

                    dRz = Math.Sqrt(dR ^ 2 + dZ ^ 2)    '3D radius
                    ThetaZ = Math.Atan2(dZ, dR)

                    'Now increase Theta by the new angle
                    ThetaZ += dTheta * Sensitivity * Math.PI / 180
                    If ThetaZ > 80 * Math.PI / 180 Then ThetaZ = 80 * Math.PI / 180
                    If ThetaZ < -80 * Math.PI / 180 Then ThetaZ = -80 * Math.PI / 180
                    dR = dRz * Math.Cos(ThetaZ)
                    dX = dR * Math.Cos(Theta)
                    dY = dR * Math.Sin(Theta)
                    dZ = dRz * Math.Sin(ThetaZ)

                    'Now calculate the new Camera position
                    TargetPos.X = dX + CameraPos.X
                    TargetPos.Y = dY + CameraPos.Y
                    TargetPos.Z = dZ + CameraPos.Z

                    blnDraw = True
                End If

                If blnDraw Then     'Draw if needed
                    hsbTargetX.Value = TargetPos.X
                    hsbTargetY.Value = TargetPos.Y
                    hsbTargetZ.Value = TargetPos.Z
                    Redraw()
                End If

                StartPoint = EndPoint
                LastPoint = EndPoint
            End If

            blnManualMode = True
        End If
    End Sub

    Private Sub glc3DView_MouseWheel(sender As Object, e As MouseEventArgs) Handles glc3DView.MouseWheel
        'Debug.Print("MouseWheel..." & DateTime.Now)
        If blnManualMode Then
            blnManualMode = False
            If e.Delta < 0 Then
                If CameraFOV < 10 Then
                    CameraFOV += 1
                Else
                    CameraFOV += 10
                End If
                If CameraFOV > 170 Then CameraFOV = 170
            ElseIf e.Delta > 0 Then
                If CameraFOV > 10 Then
                    CameraFOV -= 10
                Else
                    CameraFOV -= 1
                End If
                If CameraFOV < 1 Then CameraFOV = 1
            End If
            hsbCameraZoom.Value = CameraFOV
            Redraw()
            blnManualMode = True
        End If
    End Sub

    Private Sub glc3DView_MouseHover(sender As Object, e As EventArgs) Handles glc3DView.MouseHover
        If Not glc3DView.Focused Then
            glc3DView.Focus()
        End If
    End Sub

    Private Sub hsbCameraX_ValueChanged(sender As Object, e As EventArgs) Handles hsbCameraX.ValueChanged, hsbCameraY.ValueChanged, hsbCameraZ.ValueChanged, hsbCameraZoom.ValueChanged
        If blnManualMode Then
            blnManualMode = False
            Redraw()
            blnManualMode = True
        End If
        lblCameraX.Text = hsbCameraX.Value
        lblCameraY.Text = hsbCameraY.Value
        lblCameraZ.Text = hsbCameraZ.Value
        lblCameraFOV.Text = hsbCameraZoom.Value
    End Sub

    Private Sub hsbTargetZ_ValueChanged(sender As Object, e As EventArgs) Handles hsbTargetX.ValueChanged, hsbTargetY.ValueChanged, hsbTargetZ.ValueChanged
        'TargetPos = New Vector4(hsbTargetX.Value, hsbTargetY.Value, hsbTargetZ.Value, 0)
        If blnManualMode Then
            blnManualMode = False
            chbAutotgt.Checked = False      'Uncheck autoaim since user is moving target point.
            Redraw()
            blnManualMode = True
        End If
        lblTargetX.Text = hsbTargetX.Value
        lblTargetY.Text = hsbTargetY.Value
        lblTargetZ.Text = hsbTargetZ.Value
    End Sub

    Private Sub hsbSingleLayer_ValueChanged(sender As Object, e As EventArgs) Handles hsbSingleLayer.ValueChanged
        If optDrawOne.Checked Then
            nstart = hsbSingleLayer.Value
            nend = nstart
            lblPrompt.Text = "Layer = " & nstart

            If blnManualMode Then       'Select the rows in rtbInterpreted
                blnManualMode = False

                Dim i, lineStart, lineEnd, charStart, charEnd As Integer
                i = 1
                While mygCode(i).Layer < nstart
                    i += 1
                End While
                lineStart = mygCode(i).Line
                While (mygCode(i).Layer = nstart) And i <= mygLines
                    i += 1
                End While
                lineEnd = mygCode(i - 1).Line
                charStart = rtbInterpreted.GetFirstCharIndexFromLine(lineStart)
                charEnd = rtbInterpreted.GetFirstCharIndexFromLine(lineEnd + 1) - 1
                rtbInterpreted.SelectionStart = charStart
                rtbInterpreted.SelectionLength = charEnd - charStart
                rtbInterpreted.Focus()
                Redraw()

                blnManualMode = True
            End If
        End If
        lblDrawOne.Text = hsbSingleLayer.Value
    End Sub

    Private Sub hsbFrom_ValueChanged(sender As Object, e As EventArgs) Handles hsbFrom.ValueChanged
        If hsbFrom.Value > hsbTo.Value Then hsbTo.Value = hsbFrom.Value
        If optDrawFromTo.Checked Then
            Dim charStart, charEnd As Integer
            nstart = hsbFrom.Value
            lblPrompt.Text = "Draw lines from : " & nstart & " to " & nend
            If blnManualMode Then 'Modify selection in rtbInterpreted if this was manually adjusted.
                blnManualMode = False
                charStart = rtbInterpreted.GetFirstCharIndexFromLine(mygCode(hsbFrom.Value).Line)
                charEnd = rtbInterpreted.GetFirstCharIndexFromLine(mygCode(hsbTo.Value).Line + 1) - 1
                rtbInterpreted.SelectionStart = charStart
                rtbInterpreted.SelectionLength = charEnd - rtbInterpreted.SelectionStart
                rtbInterpreted.Focus()
            End If

            Redraw()
        End If
        lblDrawFrom.Text = hsbFrom.Value
    End Sub

    Private Sub hsbTo_ValueChanged(sender As Object, e As EventArgs) Handles hsbTo.ValueChanged
        If hsbTo.Value < hsbFrom.Value Then hsbFrom.Value = hsbTo.Value
        If optDrawFromTo.Checked Then
            Dim charEnd As Integer
            nend = hsbTo.Value
            lblPrompt.Text = "Draw lines from : " & nstart & " to " & nend
            If blnManualMode Then 'Modify selection in rtbInterpreted if this was manually adjusted.
                blnManualMode = False
                charEnd = rtbInterpreted.GetFirstCharIndexFromLine(mygCode(hsbTo.Value).Line + 1) - 1
                rtbInterpreted.SelectionLength = charEnd - rtbInterpreted.SelectionStart
                rtbInterpreted.Focus()
                blnManualMode = True
            End If

            Redraw()
        End If
        lblDrawTo.Text = hsbTo.Value
    End Sub

    Private Sub hsbNozzle_ValueChanged(sender As Object, e As EventArgs) Handles hsbNozzle.ValueChanged
        lblNozzle.Text = hsbNozzle.Value / 10
        Redraw()
    End Sub

    Private Sub hsbFilament_ValueChanged(sender As Object, e As EventArgs) Handles hsbFilament.ValueChanged
        lblFilament.Text = hsbFilament.Value / 100
        Redraw()
    End Sub

    Private Sub nudBacklashX_ValueChanged(sender As Object, e As EventArgs) Handles nudBacklashX.ValueChanged, nudBacklashY.ValueChanged, nudBacklashZ.ValueChanged, nudBacklashE.ValueChanged
        If (nudBacklashX.Value <> 0 Or nudBacklashY.Value <> 0 Or nudBacklashZ.Value <> 0 Or nudBacklashE.Value <> 0) And blnManualMode Then
            blnManualMode = False
            ProcessVectors()
            Redraw()
            btnCompensate.Enabled = True
            optCompensated.Enabled = True
            btnSaveCode.Enabled = True
            blnManualMode = True
        Else
            btnCompensate.Enabled = False
            optCompensated.Enabled = False
            btnSaveCode.Enabled = False
        End If
    End Sub

    Private Sub optColorSolid_CheckedChanged(sender As Object, e As EventArgs) Handles optColorSolid.CheckedChanged, optColorLayers.CheckedChanged, optColorRainbow.CheckedChanged
        Redraw()
    End Sub

    Private Sub optDrawAll_CheckedChanged(sender As Object, e As EventArgs) Handles optDrawAll.CheckedChanged
        If optDrawAll.Checked Then
            nend = myVectors    'Set start and end to all vectors
            nstart = 1
            lblPrompt.Text = "Drawing All Layers"

            rtbInterpreted.SelectionLength = 0
            rtbInterpreted.SelectionStart = 0

            Redraw()
        End If
    End Sub

    Private Sub optDrawOne_CheckedChanged(sender As Object, e As EventArgs) Handles optDrawOne.CheckedChanged
        If optDrawOne.Checked Then      'Reposition option button based on visibility
            hsbSingleLayer.Visible = True
            lblDrawOne.Visible = True
            optDrawFromTo.Top = hsbSingleLayer.Bottom + (optDrawOne.Top - optDrawAll.Bottom)

            hsbSingleLayer_ValueChanged(sender, e)

            'nstart = hsbSingleLayer.Value
            'nend = nstart
            'lblPrompt.Text = "Layer = " & nstart
            'glc3DView.Invalidate()
        Else
            hsbSingleLayer.Visible = False
            lblDrawOne.Visible = False
            optDrawFromTo.Top = optDrawOne.Bottom + (optDrawOne.Top - optDrawAll.Bottom)
        End If
    End Sub

    Private Sub optDrawFromTo_CheckedChanged(sender As Object, e As EventArgs) Handles optDrawFromTo.CheckedChanged
        If optDrawFromTo.Checked Then
            hsbFrom.Visible = True
            hsbTo.Visible = True
            lblDrawFrom.Visible = True
            lblDrawTo.Visible = True

            hsbFrom.Top = optDrawFromTo.Bottom + (optDrawOne.Top - optDrawAll.Bottom)
            hsbTo.Top = hsbFrom.Bottom + (optDrawOne.Top - optDrawAll.Bottom)
            If blngCodeLoaded Then
                nend = hsbTo.Value
                nstart = hsbFrom.Value
                If blnManualMode Then 'Modify selection in rtbInterpreted if this was manually adjusted.
                    Dim charStart, charEnd As Integer
                    blnManualMode = False
                    charStart = rtbInterpreted.GetFirstCharIndexFromLine(hsbFrom.Value)
                    charEnd = rtbInterpreted.GetFirstCharIndexFromLine(hsbTo.Value + 1) - 1
                    rtbInterpreted.SelectionStart = charStart
                    rtbInterpreted.SelectionLength = charEnd - rtbInterpreted.SelectionStart
                    rtbInterpreted.Focus()
                    blnManualMode = True
                End If
            End If
            lblPrompt.Text = "Draw lines from : " & nstart & " to " & nend
            Redraw()
        Else
            hsbFrom.Visible = False
            hsbTo.Visible = False
            lblDrawFrom.Visible = False
            lblDrawTo.Visible = False
        End If
    End Sub

    Private Sub optSource_CheckedChanged(sender As Object, e As EventArgs) Handles optSource.CheckedChanged, optInterpreted.CheckedChanged, optCompensated.CheckedChanged
        If optSource.Checked Then
            rtbSource.Visible = True
            rtbInterpreted.Visible = False
            rtbCompensated.Visible = False
        ElseIf optInterpreted.Checked Then
            rtbSource.Visible = False
            rtbInterpreted.Visible = True
            rtbCompensated.Visible = False
        Else
            rtbSource.Visible = False
            rtbInterpreted.Visible = False
            rtbCompensated.Visible = True
        End If
    End Sub

    Private Sub rtbInterpreted_MouseUp(sender As Object, e As MouseEventArgs) Handles rtbInterpreted.MouseUp
        'Display help text when a row is clicked

        'Select row of text that is clicked
        Dim box = DirectCast(sender, RichTextBox)
        'Dim index = box.GetCharIndexFromPosition(e.Location)
        Dim lineStart As Integer
        Dim lineEnd As Integer
        Dim charStart As Integer
        Dim charEnd As Integer

        blnManualMode = False

        optDrawFromTo.Checked = True        'Turn on Draw From-To Option

        lineStart = box.GetLineFromCharIndex(box.SelectionStart)
        charStart = box.GetFirstCharIndexFromLine(lineStart)

        If box.SelectionLength = 0 Then
            lineEnd = lineStart
        Else
            lineEnd = box.GetLineFromCharIndex(box.SelectionStart + box.SelectionLength)
        End If
        charEnd = box.GetFirstCharIndexFromLine(lineEnd + 1) - 1
        box.SelectionStart = charStart
        box.SelectionLength = charEnd - charStart

        Dim strNumber() As String
        strNumber = Strings.Split(box.SelectedText, " ", 2)     'Return the Line Number in strNumber(0)
        mygLine = strNumber(0)

        hsbFrom.Value = mygLine
        hsbTo.Value = lineEnd - lineStart + nstart     'Assume there's no skipped lines? Dangerous

        DisplayHelp(mygCode(mygLine).Token)
        lblPrompt.Text = "Line:" & mygLine & " Layer:" & mygCode(mygLine).Layer & "  -  " & lblPrompt.Text

        Redraw()

        blnManualMode = True
    End Sub

    Private Sub rtbInterpreted_MouseHover(sender As Object, e As EventArgs) Handles rtbInterpreted.MouseHover
        If Not rtbInterpreted.Focused Then
            rtbInterpreted.Focus()
        End If
    End Sub

#End Region

#Region "Samples"

    Private Sub DrawQuad()
        GL.Begin(BeginMode.Quads)
        'Face 1
        GL.Color3(Color.Red)
        GL.Vertex3(75, 0, 0)
        GL.Color3(Color.Green)
        GL.Vertex3(0, 75, 0)
        GL.Color3(Color.Blue)
        GL.Vertex3(0, 0, 75)
        GL.Color3(Color.White)
        GL.Vertex3(0, 0, 0)
        GL.End()
    End Sub

    Private Sub DrawPyramid()
        'This is an example of a 3D Pyramid drawing
        'First Clear Buffers
        'GL.Clear(ClearBufferMask.ColorBufferBit)
        'GL.Clear(ClearBufferMask.DepthBufferBit)

        ''Basic Setup for viewing
        'Dim perspective As Matrix4 = Matrix4.CreatePerspectiveFieldOfView(1.04, 4 / 3, 1, 10000) 'Setup Perspective
        'GL.MatrixMode(MatrixMode.Projection) 'Load Perspective
        'GL.LoadIdentity()   'Wipes the Matrix and replaces with an Identity matrix
        'GL.LoadMatrix(perspective)  'Sets the Matrix

        'Dim lookat As Matrix4 = Matrix4.LookAt(100, 20, 0, 0, 0, 0, 0, 1, 0) 'Setup camera
        'GL.MatrixMode(MatrixMode.Modelview) 'Load Camera
        'GL.LoadIdentity()
        'GL.LoadMatrix(lookat)
        'GL.Viewport(0, 0, glc3DView.Width, glc3DView.Height) 'Size of window
        'GL.Enable(EnableCap.DepthTest) 'Enable correct Z Drawings
        'GL.DepthFunc(DepthFunction.Less) 'Enable correct Z Drawings

        'Rotating
        GL.Rotate(0, 0, 0, 1)   'Rotate (angle, 3dAxes)
        GL.Rotate(0, 0, 1, 0)

        'Draw pyramid, Y is up, Z is twards you, X is left and right
        'Vertex goes (X,Y,Z)
        GL.Begin(BeginMode.Triangles)
        'Face 1
        GL.Color3(Color.Red)
        GL.Vertex3(50, 0, 0)
        GL.Color3(Color.White)
        GL.Vertex3(0, 25, 0)
        GL.Color3(Color.Blue)
        GL.Vertex3(0, 0, 50)
        'Face 2
        GL.Color3(Color.Green)
        GL.Vertex3(-50, 0, 0)
        GL.Color3(Color.White)
        GL.Vertex3(0, 25, 0)
        GL.Color3(Color.Blue)
        GL.Vertex3(0, 0, 50)
        'Face 3
        GL.Color3(Color.Red)
        GL.Vertex3(50, 0, 0)
        GL.Color3(Color.White)
        GL.Vertex3(0, 25, 0)
        GL.Color3(Color.Blue)
        GL.Vertex3(0, 0, -50)
        'Face 4
        GL.Color3(Color.Green)
        GL.Vertex3(-50, 0, 0)
        GL.Color3(Color.White)
        GL.Vertex3(0, 25, 0)
        GL.Color3(Color.Blue)
        GL.Vertex3(0, 0, -50)

        'Finish the begin mode with "end"
        GL.End()

        ''Finally...
        'GraphicsContext.CurrentContext.VSync = True 'Caps frame rate as to not over run GPU
        'glc3DView.SwapBuffers() 'Takes from the 'GL' and puts into control
    End Sub

    Private Sub Test()
        Dim myMatrix4 As Matrix4
        Dim myVector4 As Vector4
        Dim myTransformedVector4 As Vector4

        myTransformedVector4 = Vector4.Transform(myVector4, myMatrix4)

    End Sub

    'http://pastebin.com/3eC3WwRS
    'Sample in C#
    'Using System;
    'Using System.Collections.Generic;
    'Using System.ComponentModel;
    'Using System.Data;
    'Using System.Drawing;
    'Using System.Linq;
    'Using System.Text;
    'Using System.Threading.Tasks;
    'Using System.Windows.Forms;

    'Using OpenTK;
    'Using OpenTK.Graphics;
    'Using OpenTK.Graphics.OpenGL;
    'Using OpenTK.Platform;

    'Namespace PointCloudForm
    '{
    '    Partial Public Class Main_Form :    Form
    '    {
    '        int vbo_id;
    '        int vbo_size;
    '        Matrix4 modelview, projection;
    '        uint frameNum;

    '        Const int CloudSize = 48;
    '        Const float pointSize = 0.01F;
    '        Const bool HighQuality = True;
    '        Public Main_Form()
    '        {
    '            InitializeComponent();
    '        }

    '        Private void Main_Form_Load(Object sender, EventArgs e)
    '        {

    '        }

    '        Private void Main_Form_Resize(Object sender, EventArgs e)
    '        {
    '            SetupViewport();
    '            glControl.Invalidate();
    '        }

    '        Private void glControl_Load(Object sender, EventArgs e)
    '        {
    '            glControl.MouseMove += New MouseEventHandler(glControl_MouseMove);
    '            glControl.MouseWheel += New MouseEventHandler(glControl_MouseWheel);

    '            GL.ClearColor(Color.DarkSlateGray); // Yey! .NET Colors can be used directly!
    '            GL.PointSize(pointSize);
    '            GL.Color3(1f, 1f, 1f); // Points Color
    '            SetupViewport();
    '        }

    '        Private void SetupViewport()
    '        {
    '            If (this.WindowState == FormWindowState.Minimized) Return;
    '            glControl.Width = this.Width - 32;
    '            glControl.Height = this.Height - 80;
    '            Frame_label.Location = New Point(glControl.Width / 2, glControl.Height + 25);
    '            GL.MatrixMode(MatrixMode.Projection);
    '            //GL.LoadIdentity();
    '            GL.Ortho(0, glControl.Width, 0, glControl.Height, -1, 1); // Bottom-left corner pixel has coordinate (0, 0)
    '            GL.Viewport(0, 0, glControl.Width, glControl.Height); // Use all of the glControl painting area
    '            GL.Enable(EnableCap.DepthTest);

    '            // Improve visual quality at the expense of performance
    '            If (HighQuality)
    '            {
    '                int max_size;
    '                GL.GetInteger(GetPName.PointSizeMax, out max_size);
    '                GL.Enable(EnableCap.PointSmooth);
    '            }

    '            // Imagine that the cloud Is a bool[CloudSize, CloudSize, CloudSize] array.
    '            // This code translates the point cloud into vertex coordinates
    '            var vertices = New Vector3[CloudSize * CloudSize * CloudSize];
    '            int index = 0;
    '            For (int i = 0; i < CloudSize; i++)
    '                For (int j = 0; j < CloudSize; j++)
    '                    For (int k = 0; k < CloudSize; k++)
    '                        If (Math.Sqrt(i * i + j * j + k * k) < CloudSize) // Point cloud shaped Like a sphere
    '                        {
    '                            vertices[index++] = New Vector3(
    '                                -CloudSize / 2 + i,
    '                                -CloudSize / 2 + j,
    '                                -CloudSize / 2 + k);
    '                        }

    '            // Load those vertex coordinates into a VBO
    '            vbo_size = vertices.Length; // Necessary for rendering later on
    '            GL.GenBuffers(1, out vbo_id);
    '            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo_id);
    '            GL.BufferData(BufferTarget.ArrayBuffer,
    '                          New IntPtr(vertices.Length * BlittableValueType.StrideOf(vertices)),
    '                          vertices, BufferUsageHint.StaticDraw);

    '            float aspect_ratio = this.Width / (float)this.Height;
    '            projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, aspect_ratio, 1, 1024);
    '            GL.MatrixMode(MatrixMode.Projection);
    '            GL.LoadMatrix(ref projection);
    '        }

    '        Private void glControl_Paint(Object sender, PaintEventArgs e)
    '        {
    '            GL.Clear(ClearBufferMask.ColorBufferBit |
    '                     ClearBufferMask.DepthBufferBit |
    '                     ClearBufferMask.StencilBufferBit);

    '            If (HighQuality)
    '            {
    '                GL.PointParameter(PointParameterName.PointDistanceAttenuation,
    '                    New float[] { 0, 0, (float)Math.Pow(1 / (projection.M11 * Width / 2), 2) });
    '            }

    '            modelview = Matrix4.LookAt(0f, 20f, -200f + zoomFactor, 0, 0, 0, 0.0f, 1.0f, 0.0f);
    '            var aspect_ratio = Width / (float)Height;
    '            projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver6, aspect_ratio, 1, 512);

    '            GL.MatrixMode(MatrixMode.Projection);
    '            GL.LoadMatrix(ref projection);
    '            GL.MatrixMode(MatrixMode.Modelview);
    '            GL.LoadMatrix(ref modelview);
    '            GL.Rotate(angleY, 1.0f, 0, 0);
    '            GL.Rotate(angleX, 0, 1.0f, 0);
    '            //GL.Translate(panX, panY, 0f);

    '            // To draw a VBO
    '            // 1) Ensure that the VertexArray client state Is enabled.
    '            // 2) Bind the vertex And element buffer handles.
    '            // 3) Set up the data pointers (vertex, normal, color) according to your vertex format.

    '            GL.EnableClientState(ArrayCap.VertexArray);
    '            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo_id);
    '            GL.VertexPointer(3, VertexPointerType.Float, Vector3.SizeInBytes, New IntPtr(0));
    '            GL.DrawArrays(PrimitiveType.Points, 0, vbo_size);

    '            glControl.SwapBuffers();

    '            Frame_label.Text = "Frame: " + frameNum++;
    '        }

    '        #Region GLControl. Mouse Event handlers
    '        Private int _mouseStartX = 0;
    '        Private int _mouseStartY = 0;
    '        Private float angleX = 0;
    '        Private float angleY = 0;
    '        Private float panX = 0;
    '        Private float panY = 0;

    '        Private void glControl_MouseMove(Object sender, MouseEventArgs e)
    '        {
    '            If (e.Button == MouseButtons.Right)
    '            {
    '                angleX += (e.X - _mouseStartX);
    '                angleY -= (e.Y - _mouseStartY);

    '                this.Cursor = Cursors.Cross;

    '                glControl.Invalidate();
    '            }
    '            If (e.Button == MouseButtons.Left)
    '            {
    '                panX += (e.X - _mouseStartX);
    '                panY -= (e.Y - _mouseStartY);
    '                GL.Viewport((int)panX, (int)panY, glControl.Width, glControl.Height); // Use all of the glControl painting area
    '                this.Cursor = Cursors.Hand;
    '                glControl.Invalidate();
    '            }
    '            _mouseStartX = e.X;
    '            _mouseStartY = e.Y;
    '        }

    '        float zoomFactor;
    '        Private void glControl_MouseWheel(Object sender, MouseEventArgs e)
    '        {
    '            If (e.Delta > 0) zoomFactor += 7F;
    '            Else zoomFactor -= 7F;
    '            glControl.Invalidate();
    '        }
    '        #endregion        

    '        Private void glControl_MouseUp(Object sender, MouseEventArgs e)
    '        {
    '            this.Cursor = Cursors.Default;
    '        }
    '    }
    '}

#End Region

End Class

' KJB Todo: Interpret Relative mode. Interpret Extrusion as thickness of line. Indicate direction of print. Enable Backlash.
