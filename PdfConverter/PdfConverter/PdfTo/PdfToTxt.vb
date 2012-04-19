Imports org.pdfbox.pdmodel
Imports org.pdfbox.util
Imports System.IO
Imports System.Text

Public Class PdfToTxt

    ''' <summary>
    ''' all the converted text into string
    ''' </summary>
    ''' <param name="pdfFile">the path of PDF file</param>
    ''' <returns>string contains the converted text</returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function ToString(ByVal pdfFile As FileInfo) As String
        Dim tmpStr As String = Nothing
        Try
            Dim doc As PDDocument = PDDocument.load(pdfFile.FullName)
            Dim pdfStripper As PDFTextStripper = New PDFTextStripper()
            tmpStr = pdfStripper.getText(doc)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return tmpStr
    End Function

    ''' <summary>
    ''' all the converted text into new txt file
    ''' </summary>
    ''' <param name="pdfFile">the path of PDF file</param>
    ''' <param name="txtFile">txt file contains the converted text</param>
    ''' <remarks></remarks>
    Public Shared Sub ToNewTxt(ByVal pdfFile As FileInfo, ByVal txtFile As FileInfo)
        Dim tmpStr As String = ToString(pdfFile)
        Using sWriter As StreamWriter = New StreamWriter(txtFile.FullName, False, Encoding.Unicode)
            sWriter.Write(tmpStr)
        End Using
    End Sub
End Class
