<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VMS
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
        Me.pbPhoto = New System.Windows.Forms.PictureBox()
        Me.txtCaption = New System.Windows.Forms.TextBox()
        Me.lstPhotos = New System.Windows.Forms.ListBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.btnAddPhoto = New System.Windows.Forms.Button()
        Me.btnDelPhoto = New System.Windows.Forms.Button()
        Me.ofdPhoto = New System.Windows.Forms.OpenFileDialog()
        Me.cmbThemes = New System.Windows.Forms.ComboBox()
        Me.btnSlideshow = New System.Windows.Forms.Button()
        Me.slideshowTimer = New System.Windows.Forms.Timer(Me.components)
        Me.btnPDF = New System.Windows.Forms.Button()
        Me.btnCaption = New System.Windows.Forms.Button()
        CType(Me.pbPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbPhoto
        '
        Me.pbPhoto.Location = New System.Drawing.Point(12, 12)
        Me.pbPhoto.Name = "pbPhoto"
        Me.pbPhoto.Size = New System.Drawing.Size(300, 300)
        Me.pbPhoto.TabIndex = 0
        Me.pbPhoto.TabStop = False
        '
        'txtCaption
        '
        Me.txtCaption.Location = New System.Drawing.Point(12, 318)
        Me.txtCaption.Multiline = True
        Me.txtCaption.Name = "txtCaption"
        Me.txtCaption.ReadOnly = True
        Me.txtCaption.Size = New System.Drawing.Size(300, 26)
        Me.txtCaption.TabIndex = 1
        '
        'lstPhotos
        '
        Me.lstPhotos.FormattingEnabled = True
        Me.lstPhotos.ItemHeight = 20
        Me.lstPhotos.Location = New System.Drawing.Point(361, 46)
        Me.lstPhotos.Name = "lstPhotos"
        Me.lstPhotos.Size = New System.Drawing.Size(189, 184)
        Me.lstPhotos.TabIndex = 2
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(361, 247)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(189, 38)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Save Scrapbook"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(361, 291)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(189, 38)
        Me.btnLoad.TabIndex = 4
        Me.btnLoad.Text = "Load Scrapbook"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'btnAddPhoto
        '
        Me.btnAddPhoto.Location = New System.Drawing.Point(12, 351)
        Me.btnAddPhoto.Name = "btnAddPhoto"
        Me.btnAddPhoto.Size = New System.Drawing.Size(145, 30)
        Me.btnAddPhoto.TabIndex = 5
        Me.btnAddPhoto.Text = "Add Photo"
        Me.btnAddPhoto.UseVisualStyleBackColor = True
        '
        'btnDelPhoto
        '
        Me.btnDelPhoto.Location = New System.Drawing.Point(167, 351)
        Me.btnDelPhoto.Name = "btnDelPhoto"
        Me.btnDelPhoto.Size = New System.Drawing.Size(145, 30)
        Me.btnDelPhoto.TabIndex = 6
        Me.btnDelPhoto.Text = "Delete Photo"
        Me.btnDelPhoto.UseVisualStyleBackColor = True
        '
        'ofdPhoto
        '
        Me.ofdPhoto.FileName = "odfPhoto"
        '
        'cmbThemes
        '
        Me.cmbThemes.FormattingEnabled = True
        Me.cmbThemes.Location = New System.Drawing.Point(361, 12)
        Me.cmbThemes.Name = "cmbThemes"
        Me.cmbThemes.Size = New System.Drawing.Size(189, 28)
        Me.cmbThemes.TabIndex = 8
        Me.cmbThemes.Text = "change theme"
        '
        'btnSlideshow
        '
        Me.btnSlideshow.Location = New System.Drawing.Point(361, 335)
        Me.btnSlideshow.Name = "btnSlideshow"
        Me.btnSlideshow.Size = New System.Drawing.Size(189, 38)
        Me.btnSlideshow.TabIndex = 9
        Me.btnSlideshow.Text = "Start Slideshow"
        Me.btnSlideshow.UseVisualStyleBackColor = True
        '
        'slideshowTimer
        '
        Me.slideshowTimer.Interval = 2000
        '
        'btnPDF
        '
        Me.btnPDF.Location = New System.Drawing.Point(361, 379)
        Me.btnPDF.Name = "btnPDF"
        Me.btnPDF.Size = New System.Drawing.Size(189, 38)
        Me.btnPDF.TabIndex = 10
        Me.btnPDF.Text = "Export to PDF"
        Me.btnPDF.UseVisualStyleBackColor = True
        '
        'btnCaption
        '
        Me.btnCaption.Location = New System.Drawing.Point(12, 387)
        Me.btnCaption.Name = "btnCaption"
        Me.btnCaption.Size = New System.Drawing.Size(300, 30)
        Me.btnCaption.TabIndex = 11
        Me.btnCaption.Text = "Update Caption"
        Me.btnCaption.UseVisualStyleBackColor = True
        '
        'VMS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(593, 429)
        Me.Controls.Add(Me.btnCaption)
        Me.Controls.Add(Me.btnPDF)
        Me.Controls.Add(Me.btnSlideshow)
        Me.Controls.Add(Me.cmbThemes)
        Me.Controls.Add(Me.btnDelPhoto)
        Me.Controls.Add(Me.btnAddPhoto)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lstPhotos)
        Me.Controls.Add(Me.txtCaption)
        Me.Controls.Add(Me.pbPhoto)
        Me.Name = "VMS"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Virtual Memory Scrapbook"
        CType(Me.pbPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pbPhoto As PictureBox
    Friend WithEvents txtCaption As TextBox
    Friend WithEvents lstPhotos As ListBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnLoad As Button
    Friend WithEvents btnAddPhoto As Button
    Friend WithEvents btnDelPhoto As Button
    Friend WithEvents ofdPhoto As OpenFileDialog
    Friend WithEvents cmbThemes As ComboBox
    Friend WithEvents btnSlideshow As Button
    Friend WithEvents slideshowTimer As Timer
    Friend WithEvents btnPDF As Button
    Friend WithEvents btnCaption As Button
End Class
