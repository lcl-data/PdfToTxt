Imports System.Windows.Forms
Imports System.IO

Class MainWindow

    Private Sub BrowseButton_Click(sender As Object, e As RoutedEventArgs)
        Using openFileDialog1 As OpenFileDialog = New OpenFileDialog()
            openFileDialog1.InitialDirectory = "c:\"
            openFileDialog1.Filter = "PDF files (*.pdf)|*.pdf"
            openFileDialog1.FilterIndex = 2
            openFileDialog1.RestoreDirectory = True

            If openFileDialog1.ShowDialog() = Forms.DialogResult.OK Then
                pathOfFile = New FileInfo(openFileDialog1.FileName)
            End If
        End Using

        Me.LoadedPathTextBox.Text = pathOfFile.FullName
    End Sub

    Private showInNewTxt As Boolean = False
    Private pathOfFile As FileInfo = Nothing

    Private Sub ShowTextRadioButton_Checked(sender As Object, e As RoutedEventArgs)
        UpdateTextOfShowYourChoiseTextBlock(Strings.UserTextForDescribeShowInHere)
        showInNewTxt = False
    End Sub

    Private Sub ShowInNewTxtRadioButton_Checked(sender As Object, e As RoutedEventArgs)
        UpdateTextOfShowYourChoiseTextBlock(Strings.UserTextForDescribeShowInNewTxt)
        showInNewTxt = True
    End Sub

    Private Sub UpdateTextOfShowYourChoiseTextBlock(str As String)
        Me.ShowYourChoiseTextBlock.Text = str
    End Sub

    Private Sub StartButton_Click(sender As Object, e As RoutedEventArgs)
        If showInNewTxt Then
            Dim txtFile As String = Path.GetTempFileName()
            PdfToTxt.ToNewTxt(pathOfFile, New FileInfo(txtFile))
            Process.Start("notepad", txtFile)
        Else
            Me.AllText.Text = PdfToTxt.ToString(pathOfFile)
            Me.AllText.Visibility = Windows.Visibility.Visible
        End If

    End Sub
End Class
