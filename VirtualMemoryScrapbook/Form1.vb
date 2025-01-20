Imports System.IO
Imports System.Drawing
Imports System.Collections.Generic
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class VMS
    'variables
    Private photos As New List(Of String)()
    Private captions As New List(Of String)()
    Private currentSlideIndex As Integer = 0
    Private photoCaptions As New Dictionary(Of String, String)

    Private Sub VMS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbThemes.Items.AddRange(New String() {"Light Theme", "Dark Theme", "Custom Color"})
        cmbThemes.SelectedIndex = 0
    End Sub

    Private Sub btnAddPhoto_Click(sender As Object, e As EventArgs) Handles btnAddPhoto.Click
        ' Create an OpenFileDialog to select an image
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
        openFileDialog.Title = "Select a Photo to Add"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim filePath As String = openFileDialog.FileName

            Try
                ' Load the image into the PictureBox
                pbPhoto.Image = Drawing.Image.FromFile(filePath)
                pbPhoto.SizeMode = PictureBoxSizeMode.Zoom

                ' Prompt for a caption
                Dim caption As String = InputBox("Enter a caption for this photo:", "Add Caption")

                ' Add the file path and caption to the dictionary
                photoCaptions(filePath) = caption

                ' Update the ListBox to show captions
                lstPhotos.Items.Add($"{Path.GetFileName(filePath)}")

                photos.Add(filePath)
                captions.Add(caption)

                txtCaption.Text = caption
            Catch ex As Exception
                MessageBox.Show("An error occurred while loading the image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnCaption_Click(sender As Object, e As EventArgs) Handles btnCaption.Click
        Dim index As Integer = lstPhotos.SelectedIndex
        If index >= 0 Then
            Dim selectedFilePath As String = photos(index)

            ' Ensure the selected file path is valid
            If Not String.IsNullOrEmpty(selectedFilePath) AndAlso File.Exists(selectedFilePath) Then
                ' Get the current caption or default to an empty string if not found
                Dim currentCaption As String = If(photoCaptions.ContainsKey(selectedFilePath), photoCaptions(selectedFilePath), "")
                Dim newCaption As String = InputBox("Enter a new caption for this photo:", "Update Caption", currentCaption)

                ' Update the caption if a new value is provided
                If Not String.IsNullOrEmpty(newCaption) Then
                    photoCaptions(selectedFilePath) = newCaption
                    captions(index) = newCaption
                    txtCaption.Text = newCaption
                End If
            Else
                MessageBox.Show("The selected file path is invalid or does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("No photo is selected. Please select a photo first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub lstPhotos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstPhotos.SelectedIndexChanged
        ' Display the selected photo and its caption
        Dim index As Integer = lstPhotos.SelectedIndex
        If index >= 0 Then
            Dim selectedFilePath As String = photos(index)

            ' Check if the file path is valid and exists
            If Not String.IsNullOrEmpty(selectedFilePath) AndAlso File.Exists(selectedFilePath) Then
                pbPhoto.Image = Drawing.Image.FromFile(selectedFilePath)
                pbPhoto.SizeMode = PictureBoxSizeMode.Zoom
                txtCaption.Text = captions(index)
            Else
                MessageBox.Show($"The file at '{selectedFilePath}' could not be found or is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                pbPhoto.Image = Nothing
                txtCaption.Clear()
            End If
        End If
    End Sub

    Private Sub btnDelPhoto_Click(sender As Object, e As EventArgs) Handles btnDelPhoto.Click
        Dim index As Integer = lstPhotos.SelectedIndex
        If index >= 0 Then
            photos.RemoveAt(index)
            captions.RemoveAt(index)
            lstPhotos.Items.RemoveAt(index)

            ' Check if there are photos left in the list
            If lstPhotos.Items.Count > 0 Then
                ' Select the first photo in the list
                lstPhotos.SelectedIndex = 0
            Else
                ' Clear the picture box and caption if no photos are left
                pbPhoto.Image = Nothing
                txtCaption.Clear()
            End If
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Using saveFile As New SaveFileDialog()
            saveFile.Filter = "Scrapbook Files (*.sbk)|*.sbk"
            If saveFile.ShowDialog() = DialogResult.OK Then
                Dim sbkFilePath = saveFile.FileName
                Dim sbkDirectory = Path.GetDirectoryName(sbkFilePath)
                Dim photosFolder = Path.Combine(sbkDirectory, "photos")

                ' Create the photos folder if it doesn't exist
                If Not Directory.Exists(photosFolder) Then
                    Directory.CreateDirectory(photosFolder)
                End If

                ' Save the scrapbook file
                Using writer As New StreamWriter(sbkFilePath)
                    For i = 0 To photos.Count - 1
                        ' Copy photo to the "photos" folder
                        Dim photoFileName = Path.GetFileName(photos(i))
                        Dim destinationPath = Path.Combine(photosFolder, photoFileName)

                        ' Ensure the file isn't overwritten unnecessarily
                        If Not File.Exists(destinationPath) Then
                            File.Copy(photos(i), destinationPath)
                        End If

                        ' Write the relative path and caption to the scrapbook file
                        writer.WriteLine($"photos\{photoFileName}|{captions(i)}")
                    Next
                End Using

                MessageBox.Show("Scrapbook saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Using
    End Sub


    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Using openFile As New OpenFileDialog()
            openFile.Filter = "Scrapbook Files (*.sbk)|*.sbk"
            If openFile.ShowDialog() = DialogResult.OK Then
                Dim sbkFilePath = openFile.FileName
                Dim sbkDirectory = Path.GetDirectoryName(sbkFilePath)

                photos.Clear()
                captions.Clear()
                lstPhotos.Items.Clear()

                ' Read the scrapbook file
                Using reader As New StreamReader(sbkFilePath)
                    While Not reader.EndOfStream
                        Dim line = reader.ReadLine()
                        Dim parts = line.Split("|"c)

                        ' Construct full photo path from the relative path
                        Dim relativePhotoPath = parts(0)
                        Dim fullPhotoPath = Path.Combine(sbkDirectory, relativePhotoPath)

                        If File.Exists(fullPhotoPath) Then
                            photos.Add(fullPhotoPath)
                            captions.Add(parts(1))
                            lstPhotos.Items.Add(Path.GetFileName(fullPhotoPath))
                        Else
                            MessageBox.Show($"Photo '{relativePhotoPath}' not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    End While
                End Using

                ' Select the first photo if available
                If photos.Count > 0 Then
                    lstPhotos.SelectedIndex = 0
                End If

                MessageBox.Show("Scrapbook loaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Using
    End Sub


    Private Sub cmbThemes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbThemes.SelectedIndexChanged
        Select Case cmbThemes.SelectedItem.ToString()
            Case "Light Theme"
                Me.BackColor = Color.White
                lstPhotos.BackColor = Color.LightGray
            Case "Dark Theme"
                Me.BackColor = Color.Black
                lstPhotos.BackColor = Color.DarkGray
                lstPhotos.ForeColor = Color.White
            Case "Custom Color"
                Using colorDialog As New ColorDialog()
                    If colorDialog.ShowDialog() = DialogResult.OK Then
                        Me.BackColor = colorDialog.Color
                    End If
                End Using
        End Select
    End Sub

    Private Sub btnSlideshow_Click(sender As Object, e As EventArgs) Handles btnSlideshow.Click
        If photos.Count > 0 Then
            currentSlideIndex = 0
            slideshowTimer.Start()
        Else
            MessageBox.Show("No photos available for slideshow.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub slideshowTimer_Tick(sender As Object, e As EventArgs) Handles slideshowTimer.Tick
        If currentSlideIndex < photos.Count Then
            pbPhoto.Image = Drawing.Image.FromFile(photos(currentSlideIndex))
            txtCaption.Text = captions(currentSlideIndex)
            currentSlideIndex += 1
        Else
            slideshowTimer.Stop()
            MessageBox.Show("Slideshow finished.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnPDF_Click(sender As Object, e As EventArgs) Handles btnPDF.Click
        Using saveFile As New SaveFileDialog()
            saveFile.Filter = "PDF Files (*.pdf)|*.pdf"
            If saveFile.ShowDialog() = DialogResult.OK Then
                Dim doc As New Document()
                PdfWriter.GetInstance(doc, New FileStream(saveFile.FileName, FileMode.Create))
                doc.Open()

                For i = 0 To photos.Count - 1
                    ' Add image
                    Dim img As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(photos(i))
                    img.ScaleToFit(500.0F, 500.0F)
                    doc.Add(img)

                    ' Add caption
                    doc.Add(New Paragraph(captions(i)) With {.Alignment = Element.ALIGN_CENTER})
                    doc.Add(New Paragraph(" ")) ' Add spacing
                Next

                doc.Close()
                MessageBox.Show("PDF Exported Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Using

    End Sub
End Class
