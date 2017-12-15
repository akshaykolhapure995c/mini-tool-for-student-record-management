Public Class report_card
    Dim con As New ADODB.Connection
    Dim rs As New ADODB.Recordset
    Dim rs2 As New ADODB.Recordset
    
    Private Sub report_card_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        con.Open("dsn=ses")
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Not IsNumeric(TextBox1.Text) Then
            MsgBox("Enter proper roll number.", vbInformation, "Message")
        Else
            rs.Open("Select * from exam_details where rn='" & TextBox1.Text & "'", con, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
            If rs.EOF Then
                MsgBox("Record not found.", vbCritical, "Message")
                TextBox1.Text = ""
            Else
                Label3.Text = rs.Fields("f_name").Value
                Label4.Text = rs.Fields("brnch").Value
                Label6.Text = rs.Fields("yr").Value
                Label8.Text = rs.Fields("addrss").Value
                Label11.Text = rs.Fields("contact").Value
                Label16.Text = rs.Fields("subj1").Value
                Label17.Text = rs.Fields("subj2").Value
                Label18.Text = rs.Fields("subj3").Value
                Label19.Text = rs.Fields("subj4").Value
                Label21.Text = rs.Fields("subj5").Value
                Label23.Text = rs.Fields("subj6").Value
                Label24.Text = rs.Fields("score").Value
                Label26.Text = rs.Fields("percentages").Value
                rs2.Open("Select * from stud_entry where roll_no='" & TextBox1.Text & "'", con, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                PictureBox1.ImageLocation = rs2.Fields("photo").Value
                rs2.Close()
                If Val(Label26.Text) < 70 Then
                    Label28.Text = "B"
                End If
            End If
            rs.Close()
        End If
    End Sub
End Class