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


    Private Sub DisplayDentists()
        Try
            ' Fetch data from the database
            Dim query As String = "SELECT fullname, email, workingdayhours, serviceoffered, specialization FROM dentist"
            da = New MySqlDataAdapter(query, con)
            dt = New DataTable
            da.Fill(dt)

            ' Bind DataTable to DataGridView
            DataGridView1.DataSource = dt
        Catch ex As Exception

            MsgBox(ex.Message)
        Finally

        End Try
    End Sub

    Private Sub RefreshData()

        DataGridView1.DataSource = Nothing

        DisplayDentists()
    End Sub

    Private Sub btnSubmit_Click_1(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            ' SQL query
            Dim query As String
            query = "INSERT INTO dentist(fullname, email, workingdayhours, serviceoffered, specialization) VALUES (@fullname, @email, @workingdayhours, @serviceoffered, @specialization)"
            cmd = New MySqlCommand(query, con)


            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@fullname", txtfullname.Text)
            cmd.Parameters.AddWithValue("@email", txtemail.Text)
            cmd.Parameters.AddWithValue("@workingdayhours", txtworkdayhours.Text)
            cmd.Parameters.AddWithValue("@serviceoffered", txtserviceOffered.Text)
            cmd.Parameters.AddWithValue("@specialization", txtSpecialization.Text)

            con.Open()
            cmd.ExecuteNonQuery()

            ' Display a success message
            MsgBox("Inserted successfully")

            ' Clear the textboxes after insertion
            txtfullname.Clear()
            txtemail.Clear()
            txtworkdayhours.Clear()
            txtserviceOffered.Clear()
            txtSpecialization.Clear()
            'tangina tagal ampota bilisan potaaa taenamo vb.net parang gagooo
            RefreshData()
        Catch ex As Exception
            ' Display an error message if an exception occurs
            MsgBox(ex.Message)
        Finally
            ' Close the connection if it's still open
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub
End Class
