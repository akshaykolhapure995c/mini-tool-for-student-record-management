Imports System.IO

Public Class backup
    Dim openDialog As New OpenFileDialog()
    Dim saveDialog As New SaveFileDialog()

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If openDialog.ShowDialog() = Windows.Forms.DialogResult.OK AndAlso saveDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If File.Exists(openDialog.FileName) Then
                File.Copy(openDialog.FileName, saveDialog.FileName)
                MsgBox("File backed up succesfully.", MsgBoxStyle.Information)
            End If
        End If
    End Sub

    Private Sub FolderBrowserDialog1_HelpRequest(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub backup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        saveDialog.CheckFileExists = False
        saveDialog.CheckPathExists = True
        saveDialog.FileName = Date.Now.ToString("yyyyMMdd") & ".mdb"
        saveDialog.Filter = "Microsoft Access Database (*.mdb)|*.mdb"
        saveDialog.RestoreDirectory = True
    End Sub
End Class