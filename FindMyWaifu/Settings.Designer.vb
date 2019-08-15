<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
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
        Me.components = New System.ComponentModel.Container()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.RadioButton6 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.ComboTheme = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.fai_chibi = New System.Windows.Forms.RadioButton()
        Me.hap_chibi = New System.Windows.Forms.RadioButton()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chbiPreview = New System.Windows.Forms.PictureBox()
        Me.def_chibi = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.BtnSaveExit = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.chbiPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(336, 256)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.Button7)
        Me.TabPage1.Controls.Add(Me.Button6)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(328, 230)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LinkLabel1)
        Me.GroupBox1.Controls.Add(Me.RadioButton6)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(204, 142)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Bahasa"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(2, 117)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(196, 13)
        Me.LinkLabel1.TabIndex = 3
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Tidak ada bahasa yang anda temukan?"
        '
        'RadioButton6
        '
        Me.RadioButton6.AutoSize = True
        Me.RadioButton6.Enabled = False
        Me.RadioButton6.Location = New System.Drawing.Point(15, 66)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Size = New System.Drawing.Size(60, 17)
        Me.RadioButton6.TabIndex = 3
        Me.RadioButton6.TabStop = True
        Me.RadioButton6.Text = "Custom"
        Me.RadioButton6.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(15, 19)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(71, 17)
        Me.RadioButton1.TabIndex = 1
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Indonesia"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(15, 42)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(59, 17)
        Me.RadioButton2.TabIndex = 2
        Me.RadioButton2.Text = "English"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(218, 13)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(102, 23)
        Me.Button7.TabIndex = 13
        Me.Button7.Text = "Reset Nama"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(218, 42)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(102, 23)
        Me.Button6.TabIndex = 8
        Me.Button6.Text = "Reset Setup"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.CheckBox1)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.Button5)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(328, 230)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Database"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(36, 40)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(236, 17)
        Me.CheckBox1.TabIndex = 3
        Me.CheckBox1.Text = "Automatic Update, when Internet connected"
        Me.ToolTip1.SetToolTip(Me.CheckBox1, "Jika diaktifkan, program akan freeze sebentar saat memulai")
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(35, 153)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Label6"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(33, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Update Program"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(35, 105)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Databases"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(216, 148)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 0
        Me.Button5.Text = "Edit"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.ComboTheme)
        Me.TabPage3.Controls.Add(Me.GroupBox2)
        Me.TabPage3.Controls.Add(Me.Label2)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(328, 230)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Theme"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'ComboTheme
        '
        Me.ComboTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboTheme.FormattingEnabled = True
        Me.ComboTheme.Location = New System.Drawing.Point(85, 19)
        Me.ComboTheme.Name = "ComboTheme"
        Me.ComboTheme.Size = New System.Drawing.Size(121, 21)
        Me.ComboTheme.TabIndex = 14
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.fai_chibi)
        Me.GroupBox2.Controls.Add(Me.hap_chibi)
        Me.GroupBox2.Controls.Add(Me.ComboBox2)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.def_chibi)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 59)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(312, 165)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Chibi Preview"
        '
        'fai_chibi
        '
        Me.fai_chibi.AutoSize = True
        Me.fai_chibi.Location = New System.Drawing.Point(167, 101)
        Me.fai_chibi.Name = "fai_chibi"
        Me.fai_chibi.Size = New System.Drawing.Size(41, 17)
        Me.fai_chibi.TabIndex = 16
        Me.fai_chibi.Text = "Fail"
        Me.fai_chibi.UseVisualStyleBackColor = True
        '
        'hap_chibi
        '
        Me.hap_chibi.AutoSize = True
        Me.hap_chibi.Location = New System.Drawing.Point(167, 78)
        Me.hap_chibi.Name = "hap_chibi"
        Me.hap_chibi.Size = New System.Drawing.Size(56, 17)
        Me.hap_chibi.TabIndex = 15
        Me.hap_chibi.Text = "Happy"
        Me.hap_chibi.UseVisualStyleBackColor = True
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.Enabled = False
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(167, 28)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(139, 21)
        Me.ComboBox2.TabIndex = 14
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chbiPreview)
        Me.GroupBox3.Location = New System.Drawing.Point(7, 18)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(154, 131)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Preview"
        '
        'chbiPreview
        '
        Me.chbiPreview.Location = New System.Drawing.Point(20, 17)
        Me.chbiPreview.Name = "chbiPreview"
        Me.chbiPreview.Size = New System.Drawing.Size(108, 106)
        Me.chbiPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.chbiPreview.TabIndex = 0
        Me.chbiPreview.TabStop = False
        '
        'def_chibi
        '
        Me.def_chibi.AutoSize = True
        Me.def_chibi.Checked = True
        Me.def_chibi.Location = New System.Drawing.Point(167, 55)
        Me.def_chibi.Name = "def_chibi"
        Me.def_chibi.Size = New System.Drawing.Size(59, 17)
        Me.def_chibi.TabIndex = 12
        Me.def_chibi.TabStop = True
        Me.def_chibi.Text = "Default"
        Me.def_chibi.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Tema"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(263, 262)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(61, 23)
        Me.Button4.TabIndex = 0
        Me.Button4.Text = "Update"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Enabled = False
        Me.BtnSave.Location = New System.Drawing.Point(12, 262)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 1
        Me.BtnSave.Text = "Save"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'BtnSaveExit
        '
        Me.BtnSaveExit.Enabled = False
        Me.BtnSaveExit.Location = New System.Drawing.Point(93, 262)
        Me.BtnSaveExit.Name = "BtnSaveExit"
        Me.BtnSaveExit.Size = New System.Drawing.Size(117, 23)
        Me.BtnSaveExit.TabIndex = 2
        Me.BtnSaveExit.Text = "Save And Close"
        Me.BtnSaveExit.UseVisualStyleBackColor = True
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(336, 297)
        Me.Controls.Add(Me.BtnSaveExit)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Button4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Settings"
        Me.ShowInTaskbar = False
        Me.Text = "Settings"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.chbiPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents BtnSave As Button
    Friend WithEvents BtnSaveExit As Button
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Button5 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Button7 As Button
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Label2 As Label
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RadioButton6 As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents fai_chibi As RadioButton
    Friend WithEvents hap_chibi As RadioButton
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents def_chibi As RadioButton
    Friend WithEvents chbiPreview As PictureBox
    Friend WithEvents ComboTheme As ComboBox
End Class
