<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAbout
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.YoutubeLink = New System.Windows.Forms.PictureBox()
        Me.GithubLink = New System.Windows.Forms.PictureBox()
        Me.InstagramLink = New System.Windows.Forms.PictureBox()
        Me.TwitterLink = New System.Windows.Forms.PictureBox()
        Me.FacebookLink = New System.Windows.Forms.PictureBox()
        CType(Me.YoutubeLink, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GithubLink, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InstagramLink, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TwitterLink, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FacebookLink, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Find My Waifu"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Label2"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(131, 233)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Cek Update"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Dibuat oleh"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(120, 143)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "2019 © yansaan"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "yansaan"
        '
        'YoutubeLink
        '
        Me.YoutubeLink.Cursor = System.Windows.Forms.Cursors.Hand
        Me.YoutubeLink.Image = Global.FindMyWaifu.My.Resources.Resources.icons8_youtube_play_480px_2
        Me.YoutubeLink.Location = New System.Drawing.Point(134, 173)
        Me.YoutubeLink.Name = "YoutubeLink"
        Me.YoutubeLink.Size = New System.Drawing.Size(25, 34)
        Me.YoutubeLink.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.YoutubeLink.TabIndex = 8
        Me.YoutubeLink.TabStop = False
        '
        'GithubLink
        '
        Me.GithubLink.Cursor = System.Windows.Forms.Cursors.Hand
        Me.GithubLink.Image = Global.FindMyWaifu.My.Resources.Resources.icons8_github_512px_4
        Me.GithubLink.Location = New System.Drawing.Point(178, 173)
        Me.GithubLink.Name = "GithubLink"
        Me.GithubLink.Size = New System.Drawing.Size(25, 34)
        Me.GithubLink.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.GithubLink.TabIndex = 8
        Me.GithubLink.TabStop = False
        '
        'InstagramLink
        '
        Me.InstagramLink.Cursor = System.Windows.Forms.Cursors.Hand
        Me.InstagramLink.Image = Global.FindMyWaifu.My.Resources.Resources.icons8_instagram_new_filled_500px_4
        Me.InstagramLink.Location = New System.Drawing.Point(92, 173)
        Me.InstagramLink.Name = "InstagramLink"
        Me.InstagramLink.Size = New System.Drawing.Size(25, 34)
        Me.InstagramLink.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.InstagramLink.TabIndex = 8
        Me.InstagramLink.TabStop = False
        '
        'TwitterLink
        '
        Me.TwitterLink.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TwitterLink.Image = Global.FindMyWaifu.My.Resources.Resources.icons8_twitter_208px_3
        Me.TwitterLink.Location = New System.Drawing.Point(51, 173)
        Me.TwitterLink.Name = "TwitterLink"
        Me.TwitterLink.Size = New System.Drawing.Size(25, 34)
        Me.TwitterLink.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.TwitterLink.TabIndex = 8
        Me.TwitterLink.TabStop = False
        '
        'FacebookLink
        '
        Me.FacebookLink.Cursor = System.Windows.Forms.Cursors.Hand
        Me.FacebookLink.Image = Global.FindMyWaifu.My.Resources.Resources.icons8_facebook_208px_7
        Me.FacebookLink.Location = New System.Drawing.Point(13, 173)
        Me.FacebookLink.Name = "FacebookLink"
        Me.FacebookLink.Size = New System.Drawing.Size(25, 34)
        Me.FacebookLink.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.FacebookLink.TabIndex = 8
        Me.FacebookLink.TabStop = False
        '
        'FrmAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(215, 268)
        Me.Controls.Add(Me.YoutubeLink)
        Me.Controls.Add(Me.GithubLink)
        Me.Controls.Add(Me.InstagramLink)
        Me.Controls.Add(Me.TwitterLink)
        Me.Controls.Add(Me.FacebookLink)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmAbout"
        Me.ShowInTaskbar = False
        Me.Text = "About"
        CType(Me.YoutubeLink, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GithubLink, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InstagramLink, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TwitterLink, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FacebookLink, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents FacebookLink As PictureBox
    Friend WithEvents TwitterLink As PictureBox
    Friend WithEvents InstagramLink As PictureBox
    Friend WithEvents YoutubeLink As PictureBox
    Friend WithEvents GithubLink As PictureBox
End Class
