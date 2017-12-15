Public Class exam_details
    Dim con As New ADODB.Connection
    Dim rs As New ADODB.Recordset

    Private Sub exam_details_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        con.Open("dsn=ses")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Not IsNumeric(TextBox1.Text) Then
            MsgBox("Enter proper roll number.", vbInformation, "Message")
        Else
            rs.Open("Select * from stud_entry where roll_no='" & TextBox1.Text & "'", con, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
            If rs.EOF Then
                MsgBox("Record not found.", vbCritical, "Message")
            Else
                Label3.Text = rs.Fields("full_name").Value
                Label4.Text = rs.Fields("branch").Value
                Label6.Text = rs.Fields("yr").Value
                Label8.Text = rs.Fields("address").Value
                Label27.Text = rs.Fields("contact_no").Value
                PictureBox1.ImageLocation = rs.Fields("photo").Value
            End If
            rs.Close()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        rs.Open("select * from exam_details ", con, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs.AddNew()
        rs.Fields("rn").Value = TextBox1.Text
        rs.Fields("f_name").Value = Label3.Text
        rs.Fields("brnch").Value = Label4.Text
        rs.Fields("yr").Value = Label6.Text
        rs.Fields("addrss").Value = Label8.Text
        rs.Fields("contact").Value = Label27.Text
        rs.Fields("nameofexamm").Value = ComboBox1.Text
        rs.Fields("subj1").Value = TextBox2.Text
        rs.Fields("subj2").Value = TextBox3.Text
        rs.Fields("subj3").Value = TextBox4.Text
        rs.Fields("subj4").Value = TextBox5.Text
        rs.Fields("subj5").Value = TextBox6.Text
        rs.Fields("subj6").Value = TextBox7.Text
        rs.Fields("score").Value = TextBox8.Text
        rs.Fields("percentages").Value = TextBox9.Text
        MsgBox("Record added succesfully.", MsgBoxStyle.Information)
        rs.Update()
        rs.Close()

        TextBox1.Text = ""
        Label3.Text = ""
        Label4.Text = ""
        Label6.Text = ""
        Label8.Text = ""
        ComboBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        TextBox8.Text = Val(TextBox2.Text) + Val(TextBox3.Text) + Val(TextBox4.Text) + Val(TextBox5.Text) + Val(TextBox6.Text) + Val(TextBox7.Text)
        TextBox9.Text = (Val(TextBox8.Text) * 100) / (600)
    End Sub

    Private Sub TextBox2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.LostFocus
        If Val(TextBox2.Text) > 100 Then
            MsgBox("Enter marks less than 100.", vbCritical, "Message")
            TextBox2.Text = ""
            TextBox2.Focus()
        End If
       
    End Sub

    Private Sub TextBox3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.LostFocus
        If Val(TextBox3.Text) > 100 Then
            MsgBox("Enter marks less than 100.", vbCritical, "Message")
            TextBox3.Text = ""
            TextBox3.Focus()
        End If
       
    End Sub

    Private Sub TextBox4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox4.LostFocus
        If Val(TextBox4.Text) > 100 Then
            MsgBox("Enter marks less than 100.", vbCritical, "Message")
            TextBox4.Text = ""
            TextBox4.Focus()
        End If

    End Sub
    Private Sub TextBox5_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox5.LostFocus
        If Val(TextBox5.Text) > 100 Then
            MsgBox("Enter marks less than 100.", vbCritical, "Message")
            TextBox5.Text = ""
            TextBox5.Focus()
        End If

    End Sub
    Private Sub TextBox6_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox6.LostFocus
        If Val(TextBox6.Text) > 100 Then
            MsgBox("Enter marks less than 100.", vbCritical, "Message")
            TextBox6.Text = ""
            TextBox6.Focus()
        End If

    End Sub
    Private Sub TextBox7_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox7.LostFocus
        If Val(TextBox7.Text) > 100 Then
            MsgBox("Enter marks less than 100.", vbCritical, "Message")
            TextBox7.Text = ""
            TextBox7.Focus()
        End If

    End Sub
End Class
