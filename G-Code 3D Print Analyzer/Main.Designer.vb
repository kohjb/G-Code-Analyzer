﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.chbSource = New System.Windows.Forms.CheckBox()
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
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.nudBacklashX = New System.Windows.Forms.NumericUpDown()
        Me.nudBacklashY = New System.Windows.Forms.NumericUpDown()
        Me.nudBacklashZ = New System.Windows.Forms.NumericUpDown()
        Me.optColorSolid = New System.Windows.Forms.RadioButton()
        Me.optColorLayers = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.optColorRainbow = New System.Windows.Forms.RadioButton()
        CType(Me.nudBacklashX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudBacklashY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudBacklashZ, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofdgCodeFile
        '
        Me.ofdgCodeFile.FileName = "OpenFileDialog1"
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(12, 12)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnLoad.Size = New System.Drawing.Size(113, 23)
        Me.btnLoad.TabIndex = 0
        Me.btnLoad.Text = "Load g-Code"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'rtbSource
        '
        Me.rtbSource.Location = New System.Drawing.Point(15, 47)
        Me.rtbSource.Name = "rtbSource"
        Me.rtbSource.Size = New System.Drawing.Size(255, 511)
        Me.rtbSource.TabIndex = 1
        Me.rtbSource.Text = ""
        Me.rtbSource.Visible = False
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(847, 574)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnInterpret
        '
        Me.btnInterpret.Enabled = False
        Me.btnInterpret.Location = New System.Drawing.Point(15, 574)
        Me.btnInterpret.Name = "btnInterpret"
        Me.btnInterpret.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnInterpret.Size = New System.Drawing.Size(113, 23)
        Me.btnInterpret.TabIndex = 4
        Me.btnInterpret.Text = "Interpret g-Code"
        Me.btnInterpret.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(828, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(94, 27)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "G-Code 3D Print Analyzer" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Koh Joo Beng" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Rev 1.0  4 Aug 2015"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'rtbInterpreted
        '
        Me.rtbInterpreted.Location = New System.Drawing.Point(12, 47)
        Me.rtbInterpreted.Name = "rtbInterpreted"
        Me.rtbInterpreted.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rtbInterpreted.Size = New System.Drawing.Size(258, 511)
        Me.rtbInterpreted.TabIndex = 6
        Me.rtbInterpreted.Text = ""
        Me.rtbInterpreted.WordWrap = False
        '
        'chbSource
        '
        Me.chbSource.AutoSize = True
        Me.chbSource.Enabled = False
        Me.chbSource.Location = New System.Drawing.Point(158, 17)
        Me.chbSource.Name = "chbSource"
        Me.chbSource.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chbSource.Size = New System.Drawing.Size(90, 17)
        Me.chbSource.TabIndex = 7
        Me.chbSource.Text = "Show Source"
        Me.chbSource.UseVisualStyleBackColor = True
        '
        'lblPrompt
        '
        Me.lblPrompt.ForeColor = System.Drawing.Color.Blue
        Me.lblPrompt.Location = New System.Drawing.Point(134, 574)
        Me.lblPrompt.Name = "lblPrompt"
        Me.lblPrompt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPrompt.Size = New System.Drawing.Size(707, 23)
        Me.lblPrompt.TabIndex = 8
        Me.lblPrompt.Text = "Load a file containing G-code to begin."
        Me.lblPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'glc3DView
        '
        Me.glc3DView.BackColor = System.Drawing.Color.White
        Me.glc3DView.Location = New System.Drawing.Point(285, 48)
        Me.glc3DView.Margin = New System.Windows.Forms.Padding(4)
        Me.glc3DView.Name = "glc3DView"
        Me.glc3DView.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.glc3DView.Size = New System.Drawing.Size(637, 510)
        Me.glc3DView.TabIndex = 9
        Me.glc3DView.VSync = False
        '
        'hsbCameraX
        '
        Me.hsbCameraX.Location = New System.Drawing.Point(968, 75)
        Me.hsbCameraX.Maximum = 300
        Me.hsbCameraX.Minimum = -300
        Me.hsbCameraX.Name = "hsbCameraX"
        Me.hsbCameraX.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.hsbCameraX.Size = New System.Drawing.Size(184, 22)
        Me.hsbCameraX.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(1042, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Camera"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'hsbCameraY
        '
        Me.hsbCameraY.Location = New System.Drawing.Point(968, 97)
        Me.hsbCameraY.Maximum = 300
        Me.hsbCameraY.Minimum = -300
        Me.hsbCameraY.Name = "hsbCameraY"
        Me.hsbCameraY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.hsbCameraY.Size = New System.Drawing.Size(184, 22)
        Me.hsbCameraY.TabIndex = 10
        '
        'hsbCameraZ
        '
        Me.hsbCameraZ.Location = New System.Drawing.Point(968, 119)
        Me.hsbCameraZ.Maximum = 300
        Me.hsbCameraZ.Minimum = -300
        Me.hsbCameraZ.Name = "hsbCameraZ"
        Me.hsbCameraZ.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.hsbCameraZ.Size = New System.Drawing.Size(184, 22)
        Me.hsbCameraZ.TabIndex = 10
        '
        'btnDebug
        '
        Me.btnDebug.Location = New System.Drawing.Point(1038, 13)
        Me.btnDebug.Name = "btnDebug"
        Me.btnDebug.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnDebug.Size = New System.Drawing.Size(113, 23)
        Me.btnDebug.TabIndex = 12
        Me.btnDebug.Text = "Debug"
        Me.btnDebug.UseVisualStyleBackColor = True
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
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(956, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(14, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "X"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(956, 99)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(14, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Y"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(956, 121)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(14, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Z"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(956, 245)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(14, 13)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Z"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(956, 223)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(14, 13)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Y"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(956, 201)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(14, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "X"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(1042, 178)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(44, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Target"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'hsbTargetZ
        '
        Me.hsbTargetZ.Enabled = False
        Me.hsbTargetZ.Location = New System.Drawing.Point(968, 242)
        Me.hsbTargetZ.Maximum = 300
        Me.hsbTargetZ.Minimum = -300
        Me.hsbTargetZ.Name = "hsbTargetZ"
        Me.hsbTargetZ.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.hsbTargetZ.Size = New System.Drawing.Size(184, 22)
        Me.hsbTargetZ.TabIndex = 15
        '
        'hsbTargetY
        '
        Me.hsbTargetY.Enabled = False
        Me.hsbTargetY.Location = New System.Drawing.Point(968, 220)
        Me.hsbTargetY.Maximum = 300
        Me.hsbTargetY.Minimum = -300
        Me.hsbTargetY.Name = "hsbTargetY"
        Me.hsbTargetY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.hsbTargetY.Size = New System.Drawing.Size(184, 22)
        Me.hsbTargetY.TabIndex = 16
        '
        'hsbTargetX
        '
        Me.hsbTargetX.Enabled = False
        Me.hsbTargetX.Location = New System.Drawing.Point(968, 198)
        Me.hsbTargetX.Maximum = 300
        Me.hsbTargetX.Minimum = -300
        Me.hsbTargetX.Name = "hsbTargetX"
        Me.hsbTargetX.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.hsbTargetX.Size = New System.Drawing.Size(184, 22)
        Me.hsbTargetX.TabIndex = 17
        '
        'hsbCameraZoom
        '
        Me.hsbCameraZoom.Location = New System.Drawing.Point(968, 141)
        Me.hsbCameraZoom.Maximum = 170
        Me.hsbCameraZoom.Minimum = 1
        Me.hsbCameraZoom.Name = "hsbCameraZoom"
        Me.hsbCameraZoom.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.hsbCameraZoom.Size = New System.Drawing.Size(184, 22)
        Me.hsbCameraZoom.TabIndex = 10
        Me.hsbCameraZoom.Value = 10
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(935, 143)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(34, 13)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "Zoom"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chbAutotgt
        '
        Me.chbAutotgt.AutoSize = True
        Me.chbAutotgt.Checked = True
        Me.chbAutotgt.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbAutotgt.Location = New System.Drawing.Point(938, 178)
        Me.chbAutotgt.Name = "chbAutotgt"
        Me.chbAutotgt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chbAutotgt.Size = New System.Drawing.Size(82, 17)
        Me.chbAutotgt.TabIndex = 22
        Me.chbAutotgt.Text = "Auto Target"
        Me.chbAutotgt.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(955, 282)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(121, 13)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "Backlash Simulation"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(955, 302)
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
        Me.Label14.Location = New System.Drawing.Point(955, 322)
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
        Me.Label15.Location = New System.Drawing.Point(955, 344)
        Me.Label15.Name = "Label15"
        Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label15.Size = New System.Drawing.Size(14, 13)
        Me.Label15.TabIndex = 19
        Me.Label15.Text = "Z"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nudBacklashX
        '
        Me.nudBacklashX.DecimalPlaces = 3
        Me.nudBacklashX.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.nudBacklashX.Location = New System.Drawing.Point(975, 298)
        Me.nudBacklashX.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudBacklashX.Name = "nudBacklashX"
        Me.nudBacklashX.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.nudBacklashX.Size = New System.Drawing.Size(75, 20)
        Me.nudBacklashX.TabIndex = 23
        Me.nudBacklashX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'nudBacklashY
        '
        Me.nudBacklashY.DecimalPlaces = 3
        Me.nudBacklashY.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.nudBacklashY.Location = New System.Drawing.Point(975, 318)
        Me.nudBacklashY.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudBacklashY.Name = "nudBacklashY"
        Me.nudBacklashY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.nudBacklashY.Size = New System.Drawing.Size(75, 20)
        Me.nudBacklashY.TabIndex = 23
        Me.nudBacklashY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'nudBacklashZ
        '
        Me.nudBacklashZ.DecimalPlaces = 3
        Me.nudBacklashZ.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.nudBacklashZ.Location = New System.Drawing.Point(975, 338)
        Me.nudBacklashZ.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudBacklashZ.Name = "nudBacklashZ"
        Me.nudBacklashZ.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.nudBacklashZ.Size = New System.Drawing.Size(75, 20)
        Me.nudBacklashZ.TabIndex = 23
        Me.nudBacklashZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'optColorSolid
        '
        Me.optColorSolid.AutoSize = True
        Me.optColorSolid.Location = New System.Drawing.Point(6, 19)
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
        Me.optColorLayers.Location = New System.Drawing.Point(6, 38)
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
        Me.GroupBox1.Controls.Add(Me.optDrawFromTo)
        Me.GroupBox1.Controls.Add(Me.optDrawOne)
        Me.GroupBox1.Controls.Add(Me.optDrawAll)
        Me.GroupBox1.Location = New System.Drawing.Point(942, 472)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox1.Size = New System.Drawing.Size(108, 85)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Layers to Draw"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.optColorRainbow)
        Me.GroupBox2.Controls.Add(Me.optColorLayers)
        Me.GroupBox2.Controls.Add(Me.optColorSolid)
        Me.GroupBox2.Location = New System.Drawing.Point(1064, 472)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox2.Size = New System.Drawing.Size(88, 85)
        Me.GroupBox2.TabIndex = 25
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Draw Colors"
        '
        'optColorRainbow
        '
        Me.optColorRainbow.AutoSize = True
        Me.optColorRainbow.Location = New System.Drawing.Point(6, 60)
        Me.optColorRainbow.Name = "optColorRainbow"
        Me.optColorRainbow.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optColorRainbow.Size = New System.Drawing.Size(67, 17)
        Me.optColorRainbow.TabIndex = 13
        Me.optColorRainbow.Text = "Rainbow"
        Me.optColorRainbow.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1179, 621)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.nudBacklashZ)
        Me.Controls.Add(Me.nudBacklashY)
        Me.Controls.Add(Me.nudBacklashX)
        Me.Controls.Add(Me.chbAutotgt)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.hsbTargetZ)
        Me.Controls.Add(Me.hsbTargetY)
        Me.Controls.Add(Me.hsbTargetX)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnDebug)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.hsbCameraZoom)
        Me.Controls.Add(Me.hsbCameraZ)
        Me.Controls.Add(Me.hsbCameraY)
        Me.Controls.Add(Me.hsbCameraX)
        Me.Controls.Add(Me.glc3DView)
        Me.Controls.Add(Me.lblPrompt)
        Me.Controls.Add(Me.chbSource)
        Me.Controls.Add(Me.rtbInterpreted)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnInterpret)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.rtbSource)
        Me.Controls.Add(Me.btnLoad)
        Me.Name = "frmMain"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Text = "G-Code 3D Print Analyzer"
        CType(Me.nudBacklashX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudBacklashY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudBacklashZ, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
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
    Friend WithEvents chbSource As CheckBox
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
    Friend WithEvents Label12 As Label
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
End Class
