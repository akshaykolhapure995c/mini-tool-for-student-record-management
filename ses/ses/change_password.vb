Public Class change_password
    Dim con As New ADODB.Connection
    Dim rs As New ADODB.Recordset
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Then
            MsgBox("Enter old password. ", vbInformation, "Message")
            TextBox1.Focus()
        Else
            If TextBox2.Text <> TextBox3.Text Then
                MsgBox("Comfirmation failed.", vbCritical, "Message")
                TextBox3.Focus()
            Else
                rs.Open("Select * from idp", con,ADODB.CursorTypeEnum.adOpenDynamic,ADODB.LockTypeEnum.adLockOptimistic)
                rs.Fields("tid").Value = StrReverse(TextBox2.Text)
                rs.Update()
                MsgBox("Changed successfully", vbExclamation, "Message")
                rs.Close()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub change_password_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
        con.Close()
        'MDIParent1.Enabled = True
    End Sub

    Private Sub change_password_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        con.Open("dsn=ses")
    End Sub

    Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        rs.Open("Select * from idp", con, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.Fields("tid").Value <> StrReverse(TextBox1.Text) Then
            MsgBox("Enter valid old password.", vbCritical, "Message")
            TextBox1.Focus()
        End If
        rs.Close()
    End Sub
End Class