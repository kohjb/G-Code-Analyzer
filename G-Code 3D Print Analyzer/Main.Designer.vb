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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.optDrawFromTo = New System.Windows.Forms.RadioButton()
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
        Me.Label1.Size = New System.Drawing.Size(94, 27)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "G-Code 3D Print Analyzer" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Koh Joo Beng" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Rev 1.0  4 Aug 2015"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'rtbInterpreted
        '
        Me.rtbInterpreted.Location = New System.Drawing.Point(12, 47)
        Me.rtbInterpreted.Name = "rtbInterpreted"
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
        Me.lblPrompt.Size = New System.Drawing.Size(707, 23)
        Me.lblPrompt.TabIndex = 8
        Me.lblPrompt.Text = "Load a file containing G-code to begin."
        Me.lblPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'glc3DView
        '
        Me.glc3DView.BackColor = System.Drawing.Color.White
        Me.glc3DView.Location = New System.Drawing.Point(285, 48)
        Me.glc3DView.Name = "glc3DView"
        Me.glc3DView.Size = New System.Drawing.Size(637, 510)
        Me.glc3DView.TabIndex = 9
        Me.glc3DView.VSync = False
        '
        'hsbCameraX
        '
        Me.hsbCameraX.Location = New System.Drawing.Point(952, 75)
        Me.hsbCameraX.Name = "hsbCameraX"
        Me.hsbCameraX.Size = New System.Drawing.Size(184, 22)
        Me.hsbCameraX.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(952, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Camera"
        '
        'hsbCameraY
        '
        Me.hsbCameraY.Location = New System.Drawing.Point(952, 97)
        Me.hsbCameraY.Name = "hsbCameraY"
        Me.hsbCameraY.Size = New System.Drawing.Size(184, 22)
        Me.hsbCameraY.TabIndex = 10
        '
        'hsbCameraZ
        '
        Me.hsbCameraZ.Location = New System.Drawing.Point(952, 119)
        Me.hsbCameraZ.Name = "hsbCameraZ"
        Me.hsbCameraZ.Size = New System.Drawing.Size(184, 22)
        Me.hsbCameraZ.TabIndex = 10
        '
        'btnDebug
        '
        Me.btnDebug.Location = New System.Drawing.Point(1054, 13)
        Me.btnDebug.Name = "btnDebug"
        Me.btnDebug.Size = New System.Drawing.Size(113, 23)
        Me.btnDebug.TabIndex = 12
        Me.btnDebug.Text = "Debug"
        Me.btnDebug.UseVisualStyleBackColor = True
        '
        'optDrawAll
        '
        Me.optDrawAll.AutoSize = True
        Me.optDrawAll.Checked = True
        Me.optDrawAll.Location = New System.Drawing.Point(952, 192)
        Me.optDrawAll.Name = "optDrawAll"
        Me.optDrawAll.Size = New System.Drawing.Size(36, 17)
        Me.optDrawAll.TabIndex = 13
        Me.optDrawAll.TabStop = True
        Me.optDrawAll.Text = "All"
        Me.optDrawAll.UseVisualStyleBackColor = True
        '
        'optDrawOne
        '
        Me.optDrawOne.AutoSize = True
        Me.optDrawOne.Location = New System.Drawing.Point(952, 215)
        Me.optDrawOne.Name = "optDrawOne"
        Me.optDrawOne.Size = New System.Drawing.Size(83, 17)
        Me.optDrawOne.TabIndex = 13
        Me.optDrawOne.Text = "Single Layer"
        Me.optDrawOne.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(952, 176)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Layers to Draw:"
        '
        'optDrawFromTo
        '
        Me.optDrawFromTo.AutoSize = True
        Me.optDrawFromTo.Location = New System.Drawing.Point(952, 238)
        Me.optDrawFromTo.Name = "optDrawFromTo"
        Me.optDrawFromTo.Size = New System.Drawing.Size(64, 17)
        Me.optDrawFromTo.TabIndex = 13
        Me.optDrawFromTo.Text = "From-To"
        Me.optDrawFromTo.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1179, 621)
        Me.Controls.Add(Me.optDrawFromTo)
        Me.Controls.Add(Me.optDrawOne)
        Me.Controls.Add(Me.optDrawAll)
        Me.Controls.Add(Me.btnDebug)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
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
        Me.Text = "G-Code 3D Print Analyzer"
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
    Friend WithEvents Label3 As Label
    Friend WithEvents optDrawFromTo As RadioButton
End Class
