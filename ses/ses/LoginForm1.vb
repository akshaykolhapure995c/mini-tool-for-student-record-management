Public Class LoginForm1
    Dim con As New ADODB.Connection
    Dim rs As New ADODB.Recordset

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        rs.Open("Select * from idp", con, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        If StrReverse(rs.Fields("tid").Value) = PasswordTextBox.Text Then
            Me.Close()
            MDIParent1.Visible = True
        Else
            MsgBox("Invalid password.", vbCritical, "Error")
            PasswordTextBox.Focus()
            PasswordTextBox.Text = ""
        End If
        rs.Close()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub LoginForm1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        con.Open("dsn=ses")
    End Sub

End Class
