Public Class Form1
    Dim con As New ADODB.Connection
    Dim rs As New ADODB.Recordset
    Dim a As String
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        con.Open("dsn=ses")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If IsNumeric(TextBox4.Text) Then
            rs.Open("select * from stud_entry where roll_no='" & TextBox1.Text & "'", con, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

            If rs.EOF Then

                rs.AddNew()
                rs.Fields("roll_no").Value = TextBox1.Text
                rs.Fields("gender").Value = ComboBox2.Text
                rs.Fields("full_name").Value = TextBox2.Text
                rs.Fields("address").Value = TextBox3.Text
                rs.Fields("branch").Value = ComboBox1.Text
                rs.Fields("contact_no").Value = TextBox4.Text
                rs.Fields("email_id").Value = TextBox5.Text
                rs.Fields("yr").Value = ComboBox3.Text
                rs.Fields("photo").Value = OpenFileDialog1.FileName
                rs.Update()
                MsgBox("Record added succesfully.", MsgBoxStyle.Information)
            Else
                MsgBox("Duplicate enroll")
            End If

            rs.Close()

            TextBox1.Text = ""
            ComboBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            ComboBox2.Text = ""
            ComboBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            PictureBox1.ImageLocation = ""
        Else
            MsgBox("Fill roll number properly.", vbCritical, "Error")
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
             PictureBox1.ImageLocation = OpenFileDialog1.FileName
        Else
            MsgBox("Select file.")
        End If
    End Sub
End Class