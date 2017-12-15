Public Class stud_edit
    Dim con As New ADODB.Connection
    Dim rs As New ADODB.Recordset
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If IsNumeric(TextBox4.Text) Then
            rs.Open("Select * from stud_entry where roll_no='" & TextBox1.Text & "'", con, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
            rs.Fields("full_name").Value = TextBox2.Text
            rs.Fields("branch").Value = ComboBox1.Text
            rs.Fields("gender").Value = ComboBox2.Text
            rs.Fields("address").Value = TextBox3.Text
            rs.Fields("yr").Value = ComboBox3.Text
            rs.Fields("contact_no").Value = TextBox4.Text
            rs.Fields("email_id").Value = TextBox5.Text
            'rs.Fields("photo").Value = OpenFileDialog1.FileName
            rs.Update()
            MsgBox("Record edited succesfully.", MsgBoxStyle.Information)
            rs.Close()
        Else
            MsgBox("Fill roll number properly.", vbCritical, "Error")
        End If

    End Sub

    Private Sub stud_edit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        con.Open("dsn=ses")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Not IsNumeric(TextBox1.Text) Then
            MsgBox("Enter proper roll number.", vbInformation, "Message")
        Else
            rs.Open("Select * from stud_entry where roll_no='" & TextBox1.Text & "'", con, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
            If rs.EOF Then
                MsgBox("Record not found.", vbCritical, "Message")
            Else
                TextBox2.Text = rs.Fields("full_name").Value
                ComboBox1.Text = rs.Fields("branch").Value
                ComboBox2.Text = rs.Fields("gender").Value
                TextBox3.Text = rs.Fields("address").Value
                ComboBox3.Text = rs.Fields("yr").Value
                TextBox4.Text = rs.Fields("contact_no").Value
                TextBox5.Text = rs.Fields("email_id").Value
                PictureBox1.ImageLocation = rs.Fields("photo").Value
            End If
            rs.Close()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox1.Text = ""
        ComboBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        PictureBox1.ImageLocation = ""
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub
End Class