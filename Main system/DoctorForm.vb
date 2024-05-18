Imports MySql.Data.MySqlClient

Public Class DoctorForm

    Dim con As MySqlConnection = New MySqlConnection("server=localhost;username=root;password=;database=infiniteeth")
    Public cmd As MySqlCommand
    Public da As MySqlDataAdapter
    Public dt As New DataTable
    Dim dr As MySqlDataReader

    Private Sub DoctorForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DisplayDentists()
    End Sub

    Private Sub DisplayDentists(Optional searchQuery As String = "")
        Try
            Dim query As String = "SELECT fullname, email, workingdayhours, serviceoffered, specialization FROM dentist"
            If Not String.IsNullOrEmpty(searchQuery) Then
                query &= " WHERE fullname LIKE @search OR email LIKE @search OR workingdayhours LIKE @search OR serviceoffered LIKE @search OR specialization LIKE @search"
            End If

            cmd = New MySqlCommand(query, con)
            If Not String.IsNullOrEmpty(searchQuery) Then
                cmd.Parameters.AddWithValue("@search", "%" & searchQuery & "%")
            End If

            da = New MySqlDataAdapter(cmd)
            dt = New DataTable
            da.Fill(dt)
            DataGridView1.DataSource = dt
            For Each column As DataGridViewColumn In DataGridView1.Columns
                column.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        DisplayDentists(txtSearch.Text)
    End Sub



    Private Sub RefreshData()
        DataGridView1.DataSource = Nothing
        DisplayDentists()
    End Sub

    Private Sub btnSubmit_Click_1(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            Dim query As String = "INSERT INTO dentist(fullname, email, workingdayhours, serviceoffered, specialization) VALUES (@fullname, @email, @workingdayhours, @serviceoffered, @specialization)"
            cmd = New MySqlCommand(query, con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@fullname", txtfullname.Text)
            cmd.Parameters.AddWithValue("@email", txtemail.Text)
            cmd.Parameters.AddWithValue("@workingdayhours", txtworkdayhours.Text)
            cmd.Parameters.AddWithValue("@serviceoffered", txtserviceOffered.Text)
            cmd.Parameters.AddWithValue("@specialization", txtSpecialization.Text)
            con.Open()
            cmd.ExecuteNonQuery()
            MsgBox("Inserted successfully")

            txtfullname.Clear()
            txtemail.Clear()
            txtworkdayhours.Clear()
            txtserviceOffered.Clear()
            txtSpecialization.Clear()

            RefreshData()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub
End Class
