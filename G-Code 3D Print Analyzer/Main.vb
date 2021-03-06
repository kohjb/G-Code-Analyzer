﻿Imports System.Text
Imports System.IO
Imports OpenTK
Imports OpenTK.Graphics
Imports OpenTK.Graphics.OpenGL

Public Class frmMain

    Dim blnGLLoaded As Boolean = False      'To indicate that the Graphics Screen is loaded.
    Dim blngCodeLoaded As Boolean = False   'To indicate whether gCode file has been loaded
    Public Structure gcLine     'Structure for gCode line. 
        Public Text As String   'Line of text
        Public Token As String  'The G-Code Token for the line (eg. G1, M28, etc)
        Public Params As String 'The parameters of the G-Code (e.g. X62 Y74)
        Public Color As Color   'Color of the text
        Public Location As Integer  'Location within the Textbox
        Public Length As Integer    'Length of this text
        Public X As Single     'Coords
        Public Y As Single
        Public Z As Single
        Public E As Single
    End Structure
    Dim mygCode(10) As gcLine     'the Array number is the line. 0 is not used.
    Dim mygLine, mygLines As Integer          'The line to draw the gCode till, and all the lines in the gCode file

    'Set 3D Params
    Dim CameraPos As Vector3
    Dim TargetPos As Vector3
    Dim CameraUp As Vector3

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
                rtbSource.LoadFile(ofdgCodeFile.FileName, RichTextBoxStreamType.PlainText)
                btnInterpret.Enabled = True
                chbSource.Enabled = True
                blngCodeLoaded = True
                lblPrompt.Text = "Loading file : " & ofdgCodeFile.FileName & " ......"
                tmpcolor = lblPrompt.ForeColor
                lblPrompt.ForeColor = Color.Red
                Application.DoEvents()
                InterpretCode()
                lblPrompt.ForeColor = tmpcolor
                lblPrompt.Text = "Loaded file : " & ofdgCodeFile.FileName & "."
                glc3DView.Invalidate()
                'DrawgCode()
            Catch Ex As Exception
                MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)
            Finally
                ' Check this again, since we need to make sure we didn't throw an exception on open. 
                'If (gCodeStream IsNot Nothing) Then
                '    gCodeStream.Close()
                'End If
            End Try
        End If
    End Sub

    Private Sub glc3DView_Load(sender As Object, e As EventArgs) Handles glc3DView.Load
        'Debug.Print("GL Cleared")
        blnGLLoaded = True
    End Sub

    Private Sub glc3DView_Paint(sender As Object, e As PaintEventArgs) Handles glc3DView.Paint
        If (Not blnGLLoaded) Then Return
        'Clear Buffers
        GL.Clear(ClearBufferMask.ColorBufferBit Or ClearBufferMask.DepthBufferBit)  'Clear Color and Depth buffers
        GL.ClearColor(Color.Black)
        SetupViewport()

        'DrawPyramid()
        DrawAxes()
        If blngCodeLoaded Then
            DrawgCode(e)
        End If

        'Sync and Swap
        GraphicsContext.CurrentContext.VSync = True 'Caps frame rate as to not over run GPU
        glc3DView.SwapBuffers() 'Takes from the 'GL' and puts into control

    End Sub

    Private Sub SetupViewport()
        'Setup the Graphics Viewport
        Dim w As Integer = glc3DView.Width
        Dim h As Integer = glc3DView.Height
        CameraPos = New Vector3(150, 30, 25)
        TargetPos = New Vector3(50, 80, 0)
        CameraUp = New Vector3(0, 0, 1)

        Dim perspective As Matrix4 = Matrix4.CreatePerspectiveFieldOfView(10 * Math.PI / 180, w / h, 1, 10000) 'Setup Perspective (fov, aspect ratio, zNear, zFar)
        GL.MatrixMode(MatrixMode.Projection)
        GL.LoadIdentity()
        GL.LoadMatrix(perspective)
        'GL.Ortho(0, w, 0, h, 0, 10) 'Setup Orthographic Projection, bottom left is 0,0 (left, right, bottom, top, zmin, zmax) - zmin is furthest away

        Dim lookat As Matrix4 = Matrix4.LookAt(CameraPos, TargetPos, CameraUp) 'Setup camera (eye3d, target3d, Up3d)
        GL.MatrixMode(MatrixMode.Modelview) 'Load Camera
        GL.LoadIdentity()
        GL.LoadMatrix(lookat)
        GL.Viewport(0, 0, w, h) 'Size of window
        GL.Enable(EnableCap.DepthTest) 'Enable correct Z Drawings
        GL.DepthFunc(DepthFunction.Less) 'Enable correct Z Drawings

        GL.Viewport(0, 0, w, h)  ' Viewport (bottom left, top right)
    End Sub

    Private Sub DrawgCode(e As PaintEventArgs)
        'Read the gCode and draw lines as needed

        Dim curX, curY, curZ, curE As Single
        Dim lastX, lastY, lastZ, lastE As Single
        Dim blnAbsoluteMode As Boolean = True
        Dim nstart, nend As Integer
        Dim zcolor, zcolor2 As Color
        'Dim p As Pen

        If optDrawAll.Checked Then
            nend = mygLines
            nstart = 1
        Else
            If optDrawOne.Checked Then
                nend = mygLine
                nstart = nend
            Else
                nend = mygLine
                nstart = 1
            End If
        End If
        For i = nstart To nend    'mygCode.Length - 1
            'How to show screen update so that it doesn't wait too long?

            With mygCode(i)
                'Debug.Write(.Token & " : " & .Params)
                Select Case .Token
                    Case "G1"   'Move X, Y, Z, E
                        If .X = -999 Then curX = lastX Else curX = .X
                        If .Y = -999 Then curY = lastY Else curY = .Y
                        If .Z = -999 Then curZ = lastZ Else curZ = .Z
                        If .E = -999 Then curE = lastE Else curE = .E
                        If .Params.Contains("Z") Then
                            zcolor = Color.FromArgb(RGB(CInt(Int(256 * Rnd())), CInt(Int(256 * Rnd())), CInt(Int(256 * Rnd()))))
                            zcolor2 = Color.FromArgb(RGB(255, zcolor.G, zcolor.B))
                        End If
                        If .Params.Contains("E") Then
                            'p.Color = zcolor
                            'DrawLine(New Vector3(lastX, lastY, lastZ), New Vector3(curX, curY, curZ), zcolor)                            
                            DrawLine(New Vector3(lastX, lastY, lastZ), New Vector3(curX, curY, curZ), zcolor, zcolor2)
                        End If
                        lastX = curX
                        lastY = curY
                        lastZ = curZ
                        lastE = curE
                    'Case "G21"   'Set to mm
                    Case "G28"      'Home axes
                        curX = 0
                        curY = 0
                        curZ = 0
                        lastX = 0
                        lastY = 0
                        lastZ = 0
                    Case "G90"   'Use absolute coordinates mode
                        blnAbsoluteMode = True
                    Case "G92"   'Set current position to coords
                        'KJB Need to check if value is not set, then should not assign.
                        If .X = -999 Then curX = lastX Else curX = .X
                        If .Y = -999 Then curY = lastY Else curY = .Y
                        If .Z = -999 Then curZ = lastZ Else curZ = .Z
                        If .E = -999 Then curE = lastE Else curE = .E
                        lastX = curX
                        lastY = curY
                        lastZ = curZ
                        lastE = curE                    'Case "M82"   'Use absolute distances for extrusion
                    'Case "M84"  'Disable Motors
                    'Case "M106"     'Fan ON
                    'Case "M107"     'Fan Off
                    'Case "M104"     'Set Extruder Temp
                    'Case "M109"     'Set and Wait for Extruder to reach Temp
                    'Case "M140"     'Set Bed Temp
                    'Case "M190"     'Set and Wait for Bed to reach Temp

                    Case Else

                End Select
                'Debug.WriteLine(" (" & curX & ", " & curY & ", " & curZ & ") - (" & lastX & ", " & lastY & ", " & lastZ & ")")


            End With
        Next
    End Sub

    Private Sub DrawLine(Pt1 As Vector3, Pt2 As Vector3, c1 As Color, c2 As Color)
        'Draw line
        'Debug.Write(" Line :  (" & Pt1(0) & ", " & Pt1(1) & ", " & Pt1(2) & ") - (" & Pt2(0) & ", " & Pt2(1) & ", " & Pt2(2) & ")")
        GL.Begin(BeginMode.Lines)
        GL.Color3(c1)
        GL.Vertex3(Pt1)
        GL.Color3(c2)
        GL.Vertex3(Pt2)
        GL.End()
    End Sub

    Private Sub DrawArrow(Pt1 As Vector3, Pt2 As Vector3, c As Color)
        'Draw an arrow line from Pt1 to Pt2

        Dim Midpoint, m2, m3 As Vector3
        Dim Arrowlen As Single

        If Vector3.Equals(Pt1, Pt2) Then Exit Sub

        Midpoint = New Vector3((Pt1.X + Pt2.X) / 2, (Pt1.Y + Pt2.Y) / 2, (Pt1.Z + Pt2.Z) / 2)
        Arrowlen = (Vector3.Sub(Pt1, Pt2)).Length / 5
        m2 = Vector3.Cross(Pt1, Pt2).Normalized
        m2 = Vector3.Multiply(m2, Arrowlen)
        m2 = Vector3.Add(Midpoint, m2)
        DrawLine(Pt1, Pt2, c, c)
        DrawLine(Midpoint, m2, c, c)

        'DrawLine()


    End Sub

    Private Sub DrawAxes()
        'Draw X, Y, Z Axis
        GL.Begin(BeginMode.Lines)
        'Face 1
        GL.Color3(Color.Red)
        GL.Vertex3(0, 0, 0)
        GL.Vertex3(1000, 0, 0)
        GL.Color3(Color.Green)
        GL.Vertex3(0, 0, 0)
        GL.Vertex3(0, 1000, 0)
        GL.Color3(Color.Blue)
        GL.Vertex3(0, 0, 0)
        GL.Vertex3(0, 0, 1000)
        GL.End()

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Application.Exit()
    End Sub

    Private Sub btnInterpret_Click(sender As Object, e As EventArgs) Handles btnInterpret.Click
        glc3DView.Invalidate()
    End Sub

    Private Sub InterpretCode()
        'Number the lines of Text
        Dim txtAll As String = rtbSource.Text
        Dim sbline As New StringBuilder
        Dim linenum As Integer = 1
        Dim myline As String
        Dim Curlocation As Integer = 0    'Current location in the textbox
        Dim newline, strToken() As String

        rtbInterpreted.Clear()
        For Each myline In txtAll.Split(ControlChars.Lf)
            If linenum > mygCode.Length - 1 Then
                ReDim Preserve mygCode(mygCode.Length + 10)
            End If
            With mygCode(linenum)
                .Text = myline.ToString
                newline = linenum & " : " & myline & ControlChars.Lf

                .Location = Curlocation
                .Length = newline.Length + 0
                Curlocation += .Length

                If .Text = "" Or Strings.Left(.Text, 1) = ";" Then     'Remark or empty line
                    .Color = Color.LightGray
                    .Token = ";"
                Else
                    strToken = Strings.Split(.Text, " ", 2)     'Return token in 1st in array, remainder in 2nd, onwards
                    .Token = strToken(0)
                    If strToken.Length > 1 Then
                        .Params = strToken(1)
                    End If
                    .Color = mygColor(.Token)

                End If

            End With

            sbline.Append(newline)
            linenum = linenum + 1
            mygLines = linenum
            mygLine = mygLine
        Next
        rtbInterpreted.Text = sbline.ToString

        For i = 1 To linenum - 1
            With mygCode(i)
                rtbInterpreted.Select(.Location, .Length)
                rtbInterpreted.SelectionColor = .Color
                Select Case .Token
                    Case "G1"   'Move Commands
                        strToken = .Params.Split(" ")
                        .X = -999 : .Y = -999 : .Z = -999 : .E = -999   'Set to default NA
                        For j = 0 To strToken.Length - 1
                            If Strings.Left(strToken(j), 1) = "X" Then
                                .X = Strings.Mid(strToken(j), 2)
                            End If
                            If Strings.Left(strToken(j), 1) = "Y" Then
                                .Y = Strings.Mid(strToken(j), 2)
                            End If
                            If Strings.Left(strToken(j), 1) = "Z" Then
                                .Z = Strings.Mid(strToken(j), 2)
                            End If
                        Next
                    Case "G92" 'Set current position to coords
                        strToken = .Params.Split(" ")
                        .X = -999 : .Y = -999 : .Z = -999 : .E = -999   'Set to default NA
                        For j = 0 To strToken.Length - 1
                            If Strings.Left(strToken(j), 1) = "X" Then
                                .X = Strings.Mid(strToken(j), 2)
                            End If
                            If Strings.Left(strToken(j), 1) = "Y" Then
                                .Y = Strings.Mid(strToken(j), 2)
                            End If
                            If Strings.Left(strToken(j), 1) = "Z" Then
                                .Z = Strings.Mid(strToken(j), 2)
                            End If
                        Next
                End Select
            End With
        Next
    End Sub

    Private Function mygColor(myToken As String) As Color
        'Return the color code for the token
        Dim cMove, cMajor, cTemp, cUnknown, cCommand As Color

        'Set default colors
        cMove = Color.Green
        cMajor = Color.Blue
        cTemp = Color.Red
        cUnknown = Color.Yellow
        cCommand = Color.Fuchsia

        Select Case myToken
            Case "G1"   'Move X, Y, Z, E
                mygColor = cMove
            Case "G21"   'Set to mm
                mygColor = cCommand
            Case "G28"      'Home axes
                mygColor = cMajor
            Case "G90"   'Use absolute coordinates mode
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

    Private Sub chbSource_CheckedChanged(sender As Object, e As EventArgs) Handles chbSource.CheckedChanged
        'Toggle the visibility of the Source text of Interpreted text
        If chbSource.Checked Then
            rtbSource.Visible = True
            rtbInterpreted.Visible = False
        Else
            rtbSource.Visible = False
            rtbInterpreted.Visible = True
        End If
    End Sub

    Private Sub rtbInterpreted_MouseClick(sender As Object, e As MouseEventArgs) Handles rtbInterpreted.MouseClick
        'Display help text when a row is clicked

        'Select row of text that is clicked
        Dim box = DirectCast(sender, RichTextBox)
        Dim index = box.GetCharIndexFromPosition(e.Location)
        Dim line = box.GetLineFromCharIndex(index)
        Dim lineStart = box.GetFirstCharIndexFromLine(line)
        Dim lineEnd = box.GetFirstCharIndexFromLine(line + 1) - 1
        box.SelectionStart = lineStart
        box.SelectionLength = lineEnd - lineStart

        Dim strNumber() As String
        strNumber = Strings.Split(box.SelectedText, " ", 2)     'Return the Line Number in strNumber(0)
        mygLine = strNumber(0)
        DisplayHelp(mygCode(mygLine).Token)
        glc3DView.Invalidate()


    End Sub

    Private Sub DisplayHelp(myToken As String)
        'Display help text based on token
        Select Case myToken
            Case ";"    'Remarks
                lblPrompt.Text = "Remarks"
            Case "G1"   'Move X, Y, Z, E
                lblPrompt.Text = "Move X, Y, Z, E"
            Case "G21"   'Set to mm
                lblPrompt.Text = "Set to mm"
            Case "G28"      'Home axes
                lblPrompt.Text = "Home specified axes, or all axes if not specified"
            Case "G90"   'Use absolute coordinates mode
                lblPrompt.Text = "Use absolute coordinates mode"
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
            Case "M140"     'Set Bed Temp
                lblPrompt.Text = "Set Bed Temp, don't wait for temp to be reached"
            Case "M190"     'Set and Wait for Bed to reach Temp
                lblPrompt.Text = "Set and Wait for Bed to reach Temp"

            Case Else
                lblPrompt.Text = "Unknown Token : " & myToken
        End Select

    End Sub

    Private Sub glc3DView_MouseClick(sender As Object, e As MouseEventArgs) Handles glc3DView.MouseClick
        'xTrans += 1
        'Debug.Print(xTrans)
        glc3DView.Invalidate()
    End Sub

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

    Private Sub hsbCameraX_Scroll(sender As Object, e As ScrollEventArgs) Handles hsbCameraX.Scroll, hsbCameraY.Scroll, hsbCameraZ.Scroll
        CameraPos = New Vector3(hsbCameraX.Value, hsbCameraY.Value, hsbCameraZ.Value)
    End Sub

    Private Sub btnDebug_Click(sender As Object, e As EventArgs) Handles btnDebug.Click

    End Sub
End Class

' KJB Todo: Interpret Relative mode. Interpret Extrusion as thickness of line. Indicate direction of print. Enable Backlash.
