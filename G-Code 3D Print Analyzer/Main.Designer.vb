<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ofdgCodeFile = New System.Windows.Forms.OpenFileDialog()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.rtbSource = New System.Windows.Forms.RichTextBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnInterpret = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rtbInterpreted = New System.Windows.Forms.RichTextBox()
        Me.lblPrompt = New System.Windows.Forms.Label()
        Me.glc3DView = New OpenTK.GLControl()
        Me.hsbCameraX = New System.Windows.Forms.HScrollBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.hsbCameraY = New System.Windows.Forms.HScrollBar()
        Me.hsbCameraZ = New System.Windows.Forms.HScrollBar()
        Me.btnDebug = New System.Windows.Forms.Button()
        Me.optDrawAll = New System.Windows.Forms.RadioButton()
        Me.optDrawOne = New System.Windows.Forms.RadioButton()
        Me.optDrawFromTo = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.hsbTargetZ = New System.Windows.Forms.HScrollBar()
        Me.hsbTargetY = New System.Windows.Forms.HScrollBar()
        Me.hsbTargetX = New System.Windows.Forms.HScrollBar()
        Me.hsbCameraZoom = New System.Windows.Forms.HScrollBar()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.chbAutotgt = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.nudBacklashX = New System.Windows.Forms.NumericUpDown()
        Me.nudBacklashY = New System.Windows.Forms.NumericUpDown()
        Me.nudBacklashZ = New System.Windows.Forms.NumericUpDown()
        Me.optColorSolid = New System.Windows.Forms.RadioButton()
        Me.optColorLayers = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.hsbTo = New System.Windows.Forms.HScrollBar()
        Me.hsbFrom = New System.Windows.Forms.HScrollBar()
        Me.hsbSingleLayer = New System.Windows.Forms.HScrollBar()
        Me.lblDrawOne = New System.Windows.Forms.Label()
        Me.lblDrawFrom = New System.Windows.Forms.Label()
        Me.lblDrawTo = New System.Windows.Forms.Label()
        Me.chbThickLines = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chbSlow = New System.Windows.Forms.CheckBox()
        Me.optColorRainbow = New System.Windows.Forms.RadioButton()
        Me.chbBacklashON = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.nudBacklashE = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnResetCam = New System.Windows.Forms.Button()
        Me.btnSaveCode = New System.Windows.Forms.Button()
        Me.rtbCompensated = New System.Windows.Forms.RichTextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.optCompensated = New System.Windows.Forms.RadioButton()
        Me.optInterpreted = New System.Windows.Forms.RadioButton()
        Me.optSource = New System.Windows.Forms.RadioButton()
        Me.btnCompensate = New System.Windows.Forms.Button()
        Me.sfdgCompensated = New System.Windows.Forms.SaveFileDialog()
        Me.lblCameraX = New System.Windows.Forms.Label()
        Me.lblCameraY = New System.Windows.Forms.Label()
        Me.lblCameraZ = New System.Windows.Forms.Label()
        Me.lblCameraFOV = New System.Windows.Forms.Label()
        Me.lblTargetX = New System.Windows.Forms.Label()
        Me.lblTargetY = New System.Windows.Forms.Label()
        Me.lblTargetZ = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.chbFlat = New System.Windows.Forms.CheckBox()
        Me.optConical = New System.Windows.Forms.RadioButton()
        Me.optCylinder = New System.Windows.Forms.RadioButton()
        Me.chbTransparent = New System.Windows.Forms.CheckBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.hsbFilament = New System.Windows.Forms.HScrollBar()
        Me.lblFilament = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.hsbNozzle = New System.Windows.Forms.HScrollBar()
        Me.lblNozzle = New System.Windows.Forms.Label()
        Me.chbSimFlow = New System.Windows.Forms.CheckBox()
        CType(Me.nudBacklashX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudBacklashY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudBacklashZ, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.nudBacklashE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofdgCodeFile
        '
        Me.ofdgCodeFile.FileName = "OpenFileDialog1"
        '
        'btnLoad
        '
        Me.btnLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnLoad.Location = New System.Drawing.Point(12, 750)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnLoad.Size = New System.Drawing.Size(113, 23)
        Me.btnLoad.TabIndex = 0
        Me.btnLoad.Text = "Load g-Code"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'rtbSource
        '
        Me.rtbSource.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rtbSource.Location = New System.Drawing.Point(15, 47)
        Me.rtbSource.Name = "rtbSource"
        Me.rtbSource.ReadOnly = True
        Me.rtbSource.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rtbSource.Size = New System.Drawing.Size(255, 687)
        Me.rtbSource.TabIndex = 1
        Me.rtbSource.Text = ""
        Me.rtbSource.Visible = False
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(933, 750)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "Exit"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnInterpret
        '
        Me.btnInterpret.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInterpret.Enabled = False
        Me.btnInterpret.Location = New System.Drawing.Point(781, 13)
        Me.btnInterpret.Name = "btnInterpret"
        Me.btnInterpret.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnInterpret.Size = New System.Drawing.Size(94, 23)
        Me.btnInterpret.TabIndex = 4
        Me.btnInterpret.Text = "Interpret g-Code"
        Me.btnInterpret.UseVisualStyleBackColor = True
        Me.btnInterpret.Visible = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(671, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(94, 27)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "G-Code 3D Print Analyzer" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Koh Joo Beng" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Rev 2.0  22 Sep 2015"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'rtbInterpreted
        '
        Me.rtbInterpreted.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rtbInterpreted.Location = New System.Drawing.Point(12, 47)
        Me.rtbInterpreted.Name = "rtbInterpreted"
        Me.rtbInterpreted.ReadOnly = True
        Me.rtbInterpreted.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rtbInterpreted.Size = New System.Drawing.Size(258, 687)
        Me.rtbInterpreted.TabIndex = 6
        Me.rtbInterpreted.Text = ""
        '
        'lblPrompt
        '
        Me.lblPrompt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPrompt.ForeColor = System.Drawing.Color.Blue
        Me.lblPrompt.Location = New System.Drawing.Point(418, 750)
        Me.lblPrompt.Name = "lblPrompt"
        Me.lblPrompt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPrompt.Size = New System.Drawing.Size(347, 23)
        Me.lblPrompt.TabIndex = 8
        Me.lblPrompt.Text = "Load a file containing G-code to begin."
        Me.lblPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'glc3DView
        '
        Me.glc3DView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.glc3DView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.glc3DView.BackColor = System.Drawing.Color.White
        Me.glc3DView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.glc3DView.Location = New System.Drawing.Point(285, 48)
        Me.glc3DView.Margin = New System.Windows.Forms.Padding(4)
        Me.glc3DView.Name = "glc3DView"
        Me.glc3DView.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.glc3DView.Size = New System.Drawing.Size(480, 686)
        Me.glc3DView.TabIndex = 9
        Me.glc3DView.VSync = False
        '
        'hsbCameraX
        '
        Me.hsbCameraX.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.hsbCameraX.Location = New System.Drawing.Point(811, 75)
        Me.hsbCameraX.Maximum = 300
        Me.hsbCameraX.Minimum = -300
        Me.hsbCameraX.Name = "hsbCameraX"
        Me.hsbCameraX.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.hsbCameraX.Size = New System.Drawing.Size(164, 22)
        Me.hsbCameraX.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(885, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Camera"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'hsbCameraY
        '
        Me.hsbCameraY.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.hsbCameraY.Location = New System.Drawing.Point(811, 97)
        Me.hsbCameraY.Maximum = 300
        Me.hsbCameraY.Minimum = -300
        Me.hsbCameraY.Name = "hsbCameraY"
        Me.hsbCameraY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.hsbCameraY.Size = New System.Drawing.Size(164, 22)
        Me.hsbCameraY.TabIndex = 10
        '
        'hsbCameraZ
        '
        Me.hsbCameraZ.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.hsbCameraZ.Location = New System.Drawing.Point(811, 119)
        Me.hsbCameraZ.Maximum = 300
        Me.hsbCameraZ.Minimum = -300
        Me.hsbCameraZ.Name = "hsbCameraZ"
        Me.hsbCameraZ.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.hsbCameraZ.Size = New System.Drawing.Size(164, 22)
        Me.hsbCameraZ.TabIndex = 10
        '
        'btnDebug
        '
        Me.btnDebug.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDebug.Location = New System.Drawing.Point(881, 13)
        Me.btnDebug.Name = "btnDebug"
        Me.btnDebug.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnDebug.Size = New System.Drawing.Size(113, 23)
        Me.btnDebug.TabIndex = 12
        Me.btnDebug.Text = "Debug"
        Me.btnDebug.UseVisualStyleBackColor = True
        Me.btnDebug.Visible = False
        '
        'optDrawAll
        '
        Me.optDrawAll.AutoSize = True
        Me.optDrawAll.Checked = True
        Me.optDrawAll.Location = New System.Drawing.Point(17, 22)
        Me.optDrawAll.Name = "optDrawAll"
        Me.optDrawAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optDrawAll.Size = New System.Drawing.Size(36, 17)
        Me.optDrawAll.TabIndex = 13
        Me.optDrawAll.TabStop = True
        Me.optDrawAll.Text = "All"
        Me.optDrawAll.UseVisualStyleBackColor = True
        '
        'optDrawOne
        '
        Me.optDrawOne.AutoSize = True
        Me.optDrawOne.Location = New System.Drawing.Point(17, 41)
        Me.optDrawOne.Name = "optDrawOne"
        Me.optDrawOne.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optDrawOne.Size = New System.Drawing.Size(83, 17)
        Me.optDrawOne.TabIndex = 13
        Me.optDrawOne.Text = "Single Layer"
        Me.optDrawOne.UseVisualStyleBackColor = True
        '
        'optDrawFromTo
        '
        Me.optDrawFromTo.AutoSize = True
        Me.optDrawFromTo.Location = New System.Drawing.Point(17, 60)
        Me.optDrawFromTo.Name = "optDrawFromTo"
        Me.optDrawFromTo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optDrawFromTo.Size = New System.Drawing.Size(64, 17)
        Me.optDrawFromTo.TabIndex = 13
        Me.optDrawFromTo.Text = "From-To"
        Me.optDrawFromTo.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(799, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(14, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "X"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(799, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(14, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Y"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(799, 124)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(14, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Z"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(799, 245)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(14, 13)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Z"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(799, 223)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(14, 13)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Y"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(799, 201)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(14, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "X"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(885, 178)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(44, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Target"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'hsbTargetZ
        '
        Me.hsbTargetZ.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.hsbTargetZ.Location = New System.Drawing.Point(811, 242)
        Me.hsbTargetZ.Maximum = 300
        Me.hsbTargetZ.Minimum = -300
        Me.hsbTargetZ.Name = "hsbTargetZ"
        Me.hsbTargetZ.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.hsbTargetZ.Size = New System.Drawing.Size(164, 22)
        Me.hsbTargetZ.TabIndex = 15
        '
        'hsbTargetY
        '
        Me.hsbTargetY.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.hsbTargetY.Location = New System.Drawing.Point(811, 220)
        Me.hsbTargetY.Maximum = 300
        Me.hsbTargetY.Minimum = -300
        Me.hsbTargetY.Name = "hsbTargetY"
        Me.hsbTargetY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.hsbTargetY.Size = New System.Drawing.Size(164, 22)
        Me.hsbTargetY.TabIndex = 16
        '
        'hsbTargetX
        '
        Me.hsbTargetX.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.hsbTargetX.Location = New System.Drawing.Point(811, 198)
        Me.hsbTargetX.Maximum = 300
        Me.hsbTargetX.Minimum = -300
        Me.hsbTargetX.Name = "hsbTargetX"
        Me.hsbTargetX.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.hsbTargetX.Size = New System.Drawing.Size(164, 22)
        Me.hsbTargetX.TabIndex = 17
        '
        'hsbCameraZoom
        '
        Me.hsbCameraZoom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.hsbCameraZoom.Location = New System.Drawing.Point(811, 141)
        Me.hsbCameraZoom.Maximum = 170
        Me.hsbCameraZoom.Minimum = 1
        Me.hsbCameraZoom.Name = "hsbCameraZoom"
        Me.hsbCameraZoom.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.hsbCameraZoom.Size = New System.Drawing.Size(164, 22)
        Me.hsbCameraZoom.TabIndex = 10
        Me.hsbCameraZoom.Value = 10
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(778, 146)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(34, 13)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "Zoom"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chbAutotgt
        '
        Me.chbAutotgt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chbAutotgt.AutoSize = True
        Me.chbAutotgt.Checked = True
        Me.chbAutotgt.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbAutotgt.Location = New System.Drawing.Point(795, 178)
        Me.chbAutotgt.Name = "chbAutotgt"
        Me.chbAutotgt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chbAutotgt.Size = New System.Drawing.Size(68, 17)
        Me.chbAutotgt.TabIndex = 22
        Me.chbAutotgt.Text = "Auto Aim"
        Me.chbAutotgt.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(24, 46)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(14, 13)
        Me.Label13.TabIndex = 21
        Me.Label13.Text = "X"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(24, 66)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(14, 13)
        Me.Label14.TabIndex = 20
        Me.Label14.Text = "Y"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(24, 88)
        Me.Label15.Name = "Label15"
        Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label15.Size = New System.Drawing.Size(14, 13)
        Me.Label15.TabIndex = 19
        Me.Label15.Text = "Z"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nudBacklashX
        '
        Me.nudBacklashX.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudBacklashX.DecimalPlaces = 3
        Me.nudBacklashX.ForeColor = System.Drawing.Color.Red
        Me.nudBacklashX.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.nudBacklashX.Location = New System.Drawing.Point(44, 42)
        Me.nudBacklashX.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudBacklashX.Name = "nudBacklashX"
        Me.nudBacklashX.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.nudBacklashX.Size = New System.Drawing.Size(70, 20)
        Me.nudBacklashX.TabIndex = 23
        Me.nudBacklashX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'nudBacklashY
        '
        Me.nudBacklashY.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudBacklashY.DecimalPlaces = 3
        Me.nudBacklashY.ForeColor = System.Drawing.Color.Green
        Me.nudBacklashY.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.nudBacklashY.Location = New System.Drawing.Point(44, 62)
        Me.nudBacklashY.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudBacklashY.Name = "nudBacklashY"
        Me.nudBacklashY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.nudBacklashY.Size = New System.Drawing.Size(70, 20)
        Me.nudBacklashY.TabIndex = 23
        Me.nudBacklashY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'nudBacklashZ
        '
        Me.nudBacklashZ.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudBacklashZ.DecimalPlaces = 3
        Me.nudBacklashZ.ForeColor = System.Drawing.Color.Blue
        Me.nudBacklashZ.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.nudBacklashZ.Location = New System.Drawing.Point(44, 82)
        Me.nudBacklashZ.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudBacklashZ.Name = "nudBacklashZ"
        Me.nudBacklashZ.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.nudBacklashZ.Size = New System.Drawing.Size(70, 20)
        Me.nudBacklashZ.TabIndex = 23
        Me.nudBacklashZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'optColorSolid
        '
        Me.optColorSolid.AutoSize = True
        Me.optColorSolid.Location = New System.Drawing.Point(6, 43)
        Me.optColorSolid.Name = "optColorSolid"
        Me.optColorSolid.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optColorSolid.Size = New System.Drawing.Size(48, 17)
        Me.optColorSolid.TabIndex = 13
        Me.optColorSolid.Text = "Solid"
        Me.optColorSolid.UseVisualStyleBackColor = True
        '
        'optColorLayers
        '
        Me.optColorLayers.AutoSize = True
        Me.optColorLayers.Checked = True
        Me.optColorLayers.Location = New System.Drawing.Point(6, 62)
        Me.optColorLayers.Name = "optColorLayers"
        Me.optColorLayers.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optColorLayers.Size = New System.Drawing.Size(56, 17)
        Me.optColorLayers.TabIndex = 13
        Me.optColorLayers.TabStop = True
        Me.optColorLayers.Text = "Layers"
        Me.optColorLayers.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.hsbTo)
        Me.GroupBox1.Controls.Add(Me.hsbFrom)
        Me.GroupBox1.Controls.Add(Me.optDrawFromTo)
        Me.GroupBox1.Controls.Add(Me.optDrawOne)
        Me.GroupBox1.Controls.Add(Me.optDrawAll)
        Me.GroupBox1.Controls.Add(Me.hsbSingleLayer)
        Me.GroupBox1.Controls.Add(Me.lblDrawOne)
        Me.GroupBox1.Controls.Add(Me.lblDrawFrom)
        Me.GroupBox1.Controls.Add(Me.lblDrawTo)
        Me.GroupBox1.Location = New System.Drawing.Point(781, 422)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox1.Size = New System.Drawing.Size(227, 141)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Layers/Lines to Draw"
        '
        'hsbTo
        '
        Me.hsbTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.hsbTo.LargeChange = 1
        Me.hsbTo.Location = New System.Drawing.Point(26, 106)
        Me.hsbTo.Maximum = 1
        Me.hsbTo.Minimum = 1
        Me.hsbTo.Name = "hsbTo"
        Me.hsbTo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.hsbTo.Size = New System.Drawing.Size(167, 22)
        Me.hsbTo.TabIndex = 19
        Me.hsbTo.Value = 1
        Me.hsbTo.Visible = False
        '
        'hsbFrom
        '
        Me.hsbFrom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.hsbFrom.LargeChange = 1
        Me.hsbFrom.Location = New System.Drawing.Point(26, 84)
        Me.hsbFrom.Maximum = 1
        Me.hsbFrom.Minimum = 1
        Me.hsbFrom.Name = "hsbFrom"
        Me.hsbFrom.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.hsbFrom.Size = New System.Drawing.Size(167, 22)
        Me.hsbFrom.TabIndex = 19
        Me.hsbFrom.Value = 1
        Me.hsbFrom.Visible = False
        '
        'hsbSingleLayer
        '
        Me.hsbSingleLayer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.hsbSingleLayer.LargeChange = 1
        Me.hsbSingleLayer.Location = New System.Drawing.Point(26, 61)
        Me.hsbSingleLayer.Maximum = 1
        Me.hsbSingleLayer.Minimum = 1
        Me.hsbSingleLayer.Name = "hsbSingleLayer"
        Me.hsbSingleLayer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.hsbSingleLayer.Size = New System.Drawing.Size(167, 22)
        Me.hsbSingleLayer.TabIndex = 18
        Me.hsbSingleLayer.Value = 1
        Me.hsbSingleLayer.Visible = False
        '
        'lblDrawOne
        '
        Me.lblDrawOne.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDrawOne.AutoSize = True
        Me.lblDrawOne.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lblDrawOne.Location = New System.Drawing.Point(190, 65)
        Me.lblDrawOne.Name = "lblDrawOne"
        Me.lblDrawOne.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDrawOne.Size = New System.Drawing.Size(25, 13)
        Me.lblDrawOne.TabIndex = 14
        Me.lblDrawOne.Text = "100"
        Me.lblDrawOne.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblDrawOne.Visible = False
        '
        'lblDrawFrom
        '
        Me.lblDrawFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDrawFrom.AutoSize = True
        Me.lblDrawFrom.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lblDrawFrom.Location = New System.Drawing.Point(191, 87)
        Me.lblDrawFrom.Name = "lblDrawFrom"
        Me.lblDrawFrom.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDrawFrom.Size = New System.Drawing.Size(25, 13)
        Me.lblDrawFrom.TabIndex = 14
        Me.lblDrawFrom.Text = "100"
        Me.lblDrawFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblDrawFrom.Visible = False
        '
        'lblDrawTo
        '
        Me.lblDrawTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDrawTo.AutoSize = True
        Me.lblDrawTo.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lblDrawTo.Location = New System.Drawing.Point(191, 109)
        Me.lblDrawTo.Name = "lblDrawTo"
        Me.lblDrawTo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDrawTo.Size = New System.Drawing.Size(25, 13)
        Me.lblDrawTo.TabIndex = 14
        Me.lblDrawTo.Text = "100"
        Me.lblDrawTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblDrawTo.Visible = False
        '
        'chbThickLines
        '
        Me.chbThickLines.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chbThickLines.AutoSize = True
        Me.chbThickLines.Location = New System.Drawing.Point(11, 19)
        Me.chbThickLines.Name = "chbThickLines"
        Me.chbThickLines.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chbThickLines.Size = New System.Drawing.Size(42, 17)
        Me.chbThickLines.TabIndex = 22
        Me.chbThickLines.Text = "ON"
        Me.chbThickLines.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.chbSlow)
        Me.GroupBox2.Controls.Add(Me.optColorRainbow)
        Me.GroupBox2.Controls.Add(Me.optColorLayers)
        Me.GroupBox2.Controls.Add(Me.optColorSolid)
        Me.GroupBox2.Location = New System.Drawing.Point(920, 282)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox2.Size = New System.Drawing.Size(88, 134)
        Me.GroupBox2.TabIndex = 25
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Draw Colors"
        '
        'chbSlow
        '
        Me.chbSlow.AutoSize = True
        Me.chbSlow.Location = New System.Drawing.Point(6, 19)
        Me.chbSlow.Name = "chbSlow"
        Me.chbSlow.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chbSlow.Size = New System.Drawing.Size(49, 17)
        Me.chbSlow.TabIndex = 27
        Me.chbSlow.Text = "Slow"
        Me.chbSlow.UseVisualStyleBackColor = True
        Me.chbSlow.Visible = False
        '
        'optColorRainbow
        '
        Me.optColorRainbow.AutoSize = True
        Me.optColorRainbow.Location = New System.Drawing.Point(6, 84)
        Me.optColorRainbow.Name = "optColorRainbow"
        Me.optColorRainbow.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optColorRainbow.Size = New System.Drawing.Size(67, 17)
        Me.optColorRainbow.TabIndex = 13
        Me.optColorRainbow.Text = "Rainbow"
        Me.optColorRainbow.UseVisualStyleBackColor = True
        '
        'chbBacklashON
        '
        Me.chbBacklashON.AutoSize = True
        Me.chbBacklashON.Checked = True
        Me.chbBacklashON.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbBacklashON.Location = New System.Drawing.Point(6, 19)
        Me.chbBacklashON.Name = "chbBacklashON"
        Me.chbBacklashON.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chbBacklashON.Size = New System.Drawing.Size(99, 17)
        Me.chbBacklashON.TabIndex = 26
        Me.chbBacklashON.Text = "Simulation ON?"
        Me.chbBacklashON.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.chbBacklashON)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.nudBacklashE)
        Me.GroupBox3.Controls.Add(Me.nudBacklashZ)
        Me.GroupBox3.Controls.Add(Me.nudBacklashX)
        Me.GroupBox3.Controls.Add(Me.nudBacklashY)
        Me.GroupBox3.Location = New System.Drawing.Point(781, 282)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox3.Size = New System.Drawing.Size(129, 134)
        Me.GroupBox3.TabIndex = 27
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Backlash"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(24, 109)
        Me.Label17.Name = "Label17"
        Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label17.Size = New System.Drawing.Size(14, 13)
        Me.Label17.TabIndex = 19
        Me.Label17.Text = "E"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nudBacklashE
        '
        Me.nudBacklashE.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudBacklashE.DecimalPlaces = 3
        Me.nudBacklashE.ForeColor = System.Drawing.Color.Orange
        Me.nudBacklashE.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.nudBacklashE.Location = New System.Drawing.Point(44, 103)
        Me.nudBacklashE.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudBacklashE.Name = "nudBacklashE"
        Me.nudBacklashE.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.nudBacklashE.Size = New System.Drawing.Size(70, 20)
        Me.nudBacklashE.TabIndex = 23
        Me.nudBacklashE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.SlateGray
        Me.Label3.Location = New System.Drawing.Point(284, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(388, 34)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Rt-Click - rotate around Target, Lt-Click - rotate Camera, Shf-Lt-Click - Pan, Wh" &
    "eel - Zoom"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'btnResetCam
        '
        Me.btnResetCam.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnResetCam.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetCam.Location = New System.Drawing.Point(781, 50)
        Me.btnResetCam.Name = "btnResetCam"
        Me.btnResetCam.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnResetCam.Size = New System.Drawing.Size(38, 20)
        Me.btnResetCam.TabIndex = 29
        Me.btnResetCam.Text = "Reset"
        Me.btnResetCam.UseVisualStyleBackColor = True
        '
        'btnSaveCode
        '
        Me.btnSaveCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSaveCode.Enabled = False
        Me.btnSaveCode.Location = New System.Drawing.Point(287, 750)
        Me.btnSaveCode.Name = "btnSaveCode"
        Me.btnSaveCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnSaveCode.Size = New System.Drawing.Size(113, 23)
        Me.btnSaveCode.TabIndex = 30
        Me.btnSaveCode.Text = "Save Comp"
        Me.btnSaveCode.UseVisualStyleBackColor = True
        '
        'rtbCompensated
        '
        Me.rtbCompensated.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rtbCompensated.Location = New System.Drawing.Point(12, 46)
        Me.rtbCompensated.Name = "rtbCompensated"
        Me.rtbCompensated.ReadOnly = True
        Me.rtbCompensated.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rtbCompensated.Size = New System.Drawing.Size(258, 687)
        Me.rtbCompensated.TabIndex = 31
        Me.rtbCompensated.Text = ""
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.optCompensated)
        Me.GroupBox4.Controls.Add(Me.optInterpreted)
        Me.GroupBox4.Controls.Add(Me.optSource)
        Me.GroupBox4.Location = New System.Drawing.Point(15, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox4.Size = New System.Drawing.Size(254, 35)
        Me.GroupBox4.TabIndex = 32
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Show"
        '
        'optCompensated
        '
        Me.optCompensated.AutoSize = True
        Me.optCompensated.Enabled = False
        Me.optCompensated.Location = New System.Drawing.Point(158, 12)
        Me.optCompensated.Name = "optCompensated"
        Me.optCompensated.Size = New System.Drawing.Size(90, 17)
        Me.optCompensated.TabIndex = 1
        Me.optCompensated.Text = "Compensated"
        Me.optCompensated.UseVisualStyleBackColor = True
        '
        'optInterpreted
        '
        Me.optInterpreted.AutoSize = True
        Me.optInterpreted.Checked = True
        Me.optInterpreted.Enabled = False
        Me.optInterpreted.Location = New System.Drawing.Point(72, 12)
        Me.optInterpreted.Name = "optInterpreted"
        Me.optInterpreted.Size = New System.Drawing.Size(76, 17)
        Me.optInterpreted.TabIndex = 1
        Me.optInterpreted.TabStop = True
        Me.optInterpreted.Text = "Interpreted"
        Me.optInterpreted.UseVisualStyleBackColor = True
        '
        'optSource
        '
        Me.optSource.AutoSize = True
        Me.optSource.Enabled = False
        Me.optSource.Location = New System.Drawing.Point(7, 12)
        Me.optSource.Name = "optSource"
        Me.optSource.Size = New System.Drawing.Size(59, 17)
        Me.optSource.TabIndex = 0
        Me.optSource.Text = "Source"
        Me.optSource.UseVisualStyleBackColor = True
        '
        'btnCompensate
        '
        Me.btnCompensate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCompensate.Enabled = False
        Me.btnCompensate.Location = New System.Drawing.Point(154, 750)
        Me.btnCompensate.Name = "btnCompensate"
        Me.btnCompensate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCompensate.Size = New System.Drawing.Size(116, 23)
        Me.btnCompensate.TabIndex = 4
        Me.btnCompensate.Text = "Compensate Code"
        Me.btnCompensate.UseVisualStyleBackColor = True
        '
        'lblCameraX
        '
        Me.lblCameraX.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCameraX.AutoSize = True
        Me.lblCameraX.ForeColor = System.Drawing.Color.Red
        Me.lblCameraX.Location = New System.Drawing.Point(978, 80)
        Me.lblCameraX.Name = "lblCameraX"
        Me.lblCameraX.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCameraX.Size = New System.Drawing.Size(25, 13)
        Me.lblCameraX.TabIndex = 14
        Me.lblCameraX.Text = "100"
        Me.lblCameraX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCameraY
        '
        Me.lblCameraY.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCameraY.AutoSize = True
        Me.lblCameraY.ForeColor = System.Drawing.Color.Green
        Me.lblCameraY.Location = New System.Drawing.Point(978, 102)
        Me.lblCameraY.Name = "lblCameraY"
        Me.lblCameraY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCameraY.Size = New System.Drawing.Size(25, 13)
        Me.lblCameraY.TabIndex = 14
        Me.lblCameraY.Text = "100"
        Me.lblCameraY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCameraZ
        '
        Me.lblCameraZ.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCameraZ.AutoSize = True
        Me.lblCameraZ.ForeColor = System.Drawing.Color.Blue
        Me.lblCameraZ.Location = New System.Drawing.Point(978, 124)
        Me.lblCameraZ.Name = "lblCameraZ"
        Me.lblCameraZ.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCameraZ.Size = New System.Drawing.Size(25, 13)
        Me.lblCameraZ.TabIndex = 14
        Me.lblCameraZ.Text = "100"
        Me.lblCameraZ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCameraFOV
        '
        Me.lblCameraFOV.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCameraFOV.AutoSize = True
        Me.lblCameraFOV.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lblCameraFOV.Location = New System.Drawing.Point(978, 146)
        Me.lblCameraFOV.Name = "lblCameraFOV"
        Me.lblCameraFOV.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCameraFOV.Size = New System.Drawing.Size(25, 13)
        Me.lblCameraFOV.TabIndex = 14
        Me.lblCameraFOV.Text = "100"
        Me.lblCameraFOV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTargetX
        '
        Me.lblTargetX.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTargetX.AutoSize = True
        Me.lblTargetX.ForeColor = System.Drawing.Color.Red
        Me.lblTargetX.Location = New System.Drawing.Point(978, 201)
        Me.lblTargetX.Name = "lblTargetX"
        Me.lblTargetX.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTargetX.Size = New System.Drawing.Size(25, 13)
        Me.lblTargetX.TabIndex = 14
        Me.lblTargetX.Text = "100"
        Me.lblTargetX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTargetY
        '
        Me.lblTargetY.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTargetY.AutoSize = True
        Me.lblTargetY.ForeColor = System.Drawing.Color.Green
        Me.lblTargetY.Location = New System.Drawing.Point(978, 223)
        Me.lblTargetY.Name = "lblTargetY"
        Me.lblTargetY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTargetY.Size = New System.Drawing.Size(25, 13)
        Me.lblTargetY.TabIndex = 14
        Me.lblTargetY.Text = "100"
        Me.lblTargetY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTargetZ
        '
        Me.lblTargetZ.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTargetZ.AutoSize = True
        Me.lblTargetZ.ForeColor = System.Drawing.Color.Blue
        Me.lblTargetZ.Location = New System.Drawing.Point(978, 245)
        Me.lblTargetZ.Name = "lblTargetZ"
        Me.lblTargetZ.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTargetZ.Size = New System.Drawing.Size(25, 13)
        Me.lblTargetZ.TabIndex = 14
        Me.lblTargetZ.Text = "100"
        Me.lblTargetZ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.chbFlat)
        Me.GroupBox5.Controls.Add(Me.optConical)
        Me.GroupBox5.Controls.Add(Me.optCylinder)
        Me.GroupBox5.Controls.Add(Me.chbTransparent)
        Me.GroupBox5.Controls.Add(Me.Label16)
        Me.GroupBox5.Controls.Add(Me.hsbFilament)
        Me.GroupBox5.Controls.Add(Me.lblFilament)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.hsbNozzle)
        Me.GroupBox5.Controls.Add(Me.lblNozzle)
        Me.GroupBox5.Controls.Add(Me.chbSimFlow)
        Me.GroupBox5.Controls.Add(Me.chbThickLines)
        Me.GroupBox5.Location = New System.Drawing.Point(781, 569)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox5.Size = New System.Drawing.Size(226, 129)
        Me.GroupBox5.TabIndex = 33
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Thick Lines"
        '
        'chbFlat
        '
        Me.chbFlat.AutoSize = True
        Me.chbFlat.Checked = True
        Me.chbFlat.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbFlat.Enabled = False
        Me.chbFlat.Location = New System.Drawing.Point(11, 83)
        Me.chbFlat.Name = "chbFlat"
        Me.chbFlat.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chbFlat.Size = New System.Drawing.Size(43, 17)
        Me.chbFlat.TabIndex = 33
        Me.chbFlat.Text = "Flat"
        Me.chbFlat.UseVisualStyleBackColor = True
        '
        'optConical
        '
        Me.optConical.AutoSize = True
        Me.optConical.Checked = True
        Me.optConical.Enabled = False
        Me.optConical.Location = New System.Drawing.Point(21, 62)
        Me.optConical.Name = "optConical"
        Me.optConical.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optConical.Size = New System.Drawing.Size(60, 17)
        Me.optConical.TabIndex = 31
        Me.optConical.TabStop = True
        Me.optConical.Text = "Conical"
        Me.optConical.UseVisualStyleBackColor = True
        '
        'optCylinder
        '
        Me.optCylinder.AutoSize = True
        Me.optCylinder.Enabled = False
        Me.optCylinder.Location = New System.Drawing.Point(21, 42)
        Me.optCylinder.Name = "optCylinder"
        Me.optCylinder.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optCylinder.Size = New System.Drawing.Size(62, 17)
        Me.optCylinder.TabIndex = 32
        Me.optCylinder.Text = "Cylinder"
        Me.optCylinder.UseVisualStyleBackColor = True
        '
        'chbTransparent
        '
        Me.chbTransparent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chbTransparent.AutoSize = True
        Me.chbTransparent.Checked = True
        Me.chbTransparent.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbTransparent.Enabled = False
        Me.chbTransparent.Location = New System.Drawing.Point(11, 106)
        Me.chbTransparent.Name = "chbTransparent"
        Me.chbTransparent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chbTransparent.Size = New System.Drawing.Size(83, 17)
        Me.chbTransparent.TabIndex = 29
        Me.chbTransparent.Text = "Transparent"
        Me.chbTransparent.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Enabled = False
        Me.Label16.Location = New System.Drawing.Point(113, 82)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(63, 13)
        Me.Label16.TabIndex = 28
        Me.Label16.Text = "Filament dia"
        '
        'hsbFilament
        '
        Me.hsbFilament.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.hsbFilament.Enabled = False
        Me.hsbFilament.LargeChange = 1
        Me.hsbFilament.Location = New System.Drawing.Point(99, 96)
        Me.hsbFilament.Maximum = 300
        Me.hsbFilament.Minimum = 100
        Me.hsbFilament.Name = "hsbFilament"
        Me.hsbFilament.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.hsbFilament.Size = New System.Drawing.Size(94, 22)
        Me.hsbFilament.TabIndex = 27
        Me.hsbFilament.Value = 175
        '
        'lblFilament
        '
        Me.lblFilament.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFilament.AutoSize = True
        Me.lblFilament.Enabled = False
        Me.lblFilament.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lblFilament.Location = New System.Drawing.Point(192, 100)
        Me.lblFilament.Name = "lblFilament"
        Me.lblFilament.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFilament.Size = New System.Drawing.Size(28, 13)
        Me.lblFilament.TabIndex = 26
        Me.lblFilament.Text = "1.75"
        Me.lblFilament.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Enabled = False
        Me.Label12.Location = New System.Drawing.Point(114, 40)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 13)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Nozzle dia"
        '
        'hsbNozzle
        '
        Me.hsbNozzle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.hsbNozzle.Enabled = False
        Me.hsbNozzle.LargeChange = 1
        Me.hsbNozzle.Location = New System.Drawing.Point(100, 54)
        Me.hsbNozzle.Maximum = 10
        Me.hsbNozzle.Minimum = 1
        Me.hsbNozzle.Name = "hsbNozzle"
        Me.hsbNozzle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.hsbNozzle.Size = New System.Drawing.Size(94, 22)
        Me.hsbNozzle.TabIndex = 24
        Me.hsbNozzle.Value = 3
        '
        'lblNozzle
        '
        Me.lblNozzle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNozzle.AutoSize = True
        Me.lblNozzle.Enabled = False
        Me.lblNozzle.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lblNozzle.Location = New System.Drawing.Point(193, 58)
        Me.lblNozzle.Name = "lblNozzle"
        Me.lblNozzle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblNozzle.Size = New System.Drawing.Size(22, 13)
        Me.lblNozzle.TabIndex = 23
        Me.lblNozzle.Text = "0.3"
        Me.lblNozzle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chbSimFlow
        '
        Me.chbSimFlow.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chbSimFlow.AutoSize = True
        Me.chbSimFlow.Enabled = False
        Me.chbSimFlow.Location = New System.Drawing.Point(99, 19)
        Me.chbSimFlow.Name = "chbSimFlow"
        Me.chbSimFlow.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chbSimFlow.Size = New System.Drawing.Size(91, 17)
        Me.chbSimFlow.TabIndex = 22
        Me.chbSimFlow.Text = "Simulate Flow"
        Me.chbSimFlow.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1022, 797)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.btnSaveCode)
        Me.Controls.Add(Me.btnResetCam)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.chbAutotgt)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.hsbTargetZ)
        Me.Controls.Add(Me.hsbTargetY)
        Me.Controls.Add(Me.hsbTargetX)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblCameraFOV)
        Me.Controls.Add(Me.lblTargetZ)
        Me.Controls.Add(Me.lblTargetY)
        Me.Controls.Add(Me.lblCameraZ)
        Me.Controls.Add(Me.lblTargetX)
        Me.Controls.Add(Me.lblCameraY)
        Me.Controls.Add(Me.lblCameraX)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnDebug)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.hsbCameraZoom)
        Me.Controls.Add(Me.hsbCameraZ)
        Me.Controls.Add(Me.hsbCameraY)
        Me.Controls.Add(Me.hsbCameraX)
        Me.Controls.Add(Me.glc3DView)
        Me.Controls.Add(Me.lblPrompt)
        Me.Controls.Add(Me.rtbInterpreted)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCompensate)
        Me.Controls.Add(Me.btnInterpret)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.rtbSource)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.rtbCompensated)
        Me.Name = "frmMain"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Text = "G-Code 3D Print Analyzer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.nudBacklashX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudBacklashY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudBacklashZ, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.nudBacklashE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ofdgCodeFile As OpenFileDialog
    Friend WithEvents btnLoad As Button
    Friend WithEvents rtbSource As RichTextBox
    Friend WithEvents btnOK As Button
    Friend WithEvents btnInterpret As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents rtbInterpreted As RichTextBox
    Friend WithEvents lblPrompt As Label
    Friend WithEvents glc3DView As OpenTK.GLControl
    Friend WithEvents hsbCameraX As HScrollBar
    Friend WithEvents Label2 As Label
    Friend WithEvents hsbCameraY As HScrollBar
    Friend WithEvents hsbCameraZ As HScrollBar
    Friend WithEvents btnDebug As Button
    Friend WithEvents optDrawAll As RadioButton
    Friend WithEvents optDrawOne As RadioButton
    Friend WithEvents optDrawFromTo As RadioButton
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents hsbTargetZ As HScrollBar
    Friend WithEvents hsbTargetY As HScrollBar
    Friend WithEvents hsbTargetX As HScrollBar
    Friend WithEvents hsbCameraZoom As HScrollBar
    Friend WithEvents Label11 As Label
    Friend WithEvents chbAutotgt As CheckBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents nudBacklashX As NumericUpDown
    Friend WithEvents nudBacklashY As NumericUpDown
    Friend WithEvents nudBacklashZ As NumericUpDown
    Friend WithEvents optColorSolid As RadioButton
    Friend WithEvents optColorLayers As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents optColorRainbow As RadioButton
    Friend WithEvents chbBacklashON As CheckBox
    Friend WithEvents hsbSingleLayer As HScrollBar
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents hsbTo As HScrollBar
    Friend WithEvents hsbFrom As HScrollBar
    Friend WithEvents chbSlow As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnResetCam As Button
    Friend WithEvents btnSaveCode As Button
    Friend WithEvents rtbCompensated As RichTextBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents optCompensated As RadioButton
    Friend WithEvents optInterpreted As RadioButton
    Friend WithEvents optSource As RadioButton
    Friend WithEvents btnCompensate As Button
    Friend WithEvents sfdgCompensated As SaveFileDialog
    Friend WithEvents lblCameraX As Label
    Friend WithEvents lblCameraY As Label
    Friend WithEvents lblCameraZ As Label
    Friend WithEvents lblCameraFOV As Label
    Friend WithEvents lblTargetX As Label
    Friend WithEvents lblTargetY As Label
    Friend WithEvents lblTargetZ As Label
    Friend WithEvents lblDrawOne As Label
    Friend WithEvents lblDrawFrom As Label
    Friend WithEvents lblDrawTo As Label
    Friend WithEvents chbThickLines As CheckBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Label16 As Label
    Friend WithEvents hsbFilament As HScrollBar
    Friend WithEvents lblFilament As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents hsbNozzle As HScrollBar
    Friend WithEvents lblNozzle As Label
    Friend WithEvents chbTransparent As CheckBox
    Friend WithEvents chbSimFlow As CheckBox
    Friend WithEvents Label17 As Label
    Friend WithEvents nudBacklashE As NumericUpDown
    Friend WithEvents optConical As RadioButton
    Friend WithEvents optCylinder As RadioButton
    Friend WithEvents chbFlat As CheckBox
End Class
