Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Guna2GradientButton1_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton1.Click
        If TextBox1.Text = "" OrElse TextBox2.Text = "" Then
            MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Dim username As String = "admin"
        Dim password As String = "admin"

        If username = TextBox1.Text AndAlso password = TextBox2.Text Then
            Me.Hide()
            Main.Show()
            TextBox1.Text = ""

            TextBox2.Text = ""
        Else
            MsgBox("Invalid")
        End If
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Me.Close()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

End Class
