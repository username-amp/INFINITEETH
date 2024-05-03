Imports MySql.Data.MySqlClient

Public Class DoctorForm
    ' Connection object for MySQL database
    Dim con As MySqlConnection = New MySqlConnection("server=localhost;username=root;password=;database=infiniteeth")

    ' Command object for executing SQL commands
    Public cmd As MySqlCommand

    ' Data adapter for filling DataTable
    Public da As MySqlDataAdapter

    ' DataTable to hold retrieved data
    Public dt As New DataTable

    ' Data reader for executing queries and reading data
    Dim dr As MySqlDataReader

    ' Event handler for the form load event
    Private Sub DoctorForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Call the DisplayDentists method when the form loads
        DisplayDentists()
    End Sub

    ' Method to display dentists' information in DataGridView
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
            ' Display an error message if an exception occurs
            MsgBox(ex.Message)
        Finally
            ' No need to close the connection here
        End Try
    End Sub

    ' Method to refresh the displayed data
    Private Sub RefreshData()
        ' Clear the existing data displayed in DataGridView
        DataGridView1.DataSource = Nothing

        ' Call the method to display dentists' information again
        DisplayDentists()
    End Sub

    Private Sub btnSubmit_Click_1(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            ' SQL query to insert a new dentist record
            Dim query As String
            query = "INSERT INTO dentist(fullname, email, workingdayhours, serviceoffered, specialization) VALUES (@fullname, @email, @workingdayhours, @serviceoffered, @specialization)"
            cmd = New MySqlCommand(query, con)

            ' Clear existing parameters and set new values
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@fullname", txtfullname.Text)
            cmd.Parameters.AddWithValue("@email", txtemail.Text)
            cmd.Parameters.AddWithValue("@workingdayhours", txtworkdayhours.Text)
            cmd.Parameters.AddWithValue("@serviceoffered", txtserviceOffered.Text)
            cmd.Parameters.AddWithValue("@specialization", txtSpecialization.Text)

            ' Execute the command to insert the record
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
