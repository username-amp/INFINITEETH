Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Imports System.Windows.Forms

Public Class SessionForm
    Dim con As MySqlConnection = New MySqlConnection("server=localhost;username=root;password=;database=infiniteeth")
    Public cmd As MySqlCommand
    Public da As MySqlDataAdapter
    Public dt As New DataTable
    Dim dr As MySqlDataReader


    Private Sub SessionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadSessionsFromDatabase()
        Guna2DateTimePicker1.Format = DateTimePickerFormat.Custom
        Guna2DateTimePicker1.CustomFormat = "hh:mm tt"
        Guna2DateTimePicker1.ShowUpDown = True
    End Sub

    Private Sub LoadSessionsFromDatabase()
        Dim selectQuery As String = "SELECT * FROM session"
        Using adapter As New MySqlDataAdapter(selectQuery, con)
            dt = New DataTable()
            adapter.Fill(dt)
        End Using

        DataGridView1.DataSource = dt
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            InsertSessionIntoDatabase()
        Catch ex As Exception
            MessageBox.Show("Error inserting data: " & ex.Message)
        End Try
    End Sub

    Private Sub InsertSessionIntoDatabase()
        con.Open()
        Dim query As String = "INSERT INTO session (dentistName, clientName, service, date, time, day_of_week) VALUES (@dentist, @client, @service, @date, @time, @day)"
        cmd = New MySqlCommand(query, con)
        cmd.Parameters.AddWithValue("@dentist", txtdentist.Text)
        cmd.Parameters.AddWithValue("@client", txtclient.Text)
        cmd.Parameters.AddWithValue("@service", txtservice.Text)
        cmd.Parameters.AddWithValue("@date", DateTimePicker1.Value.Date)

        Dim formattedTime As String = Guna2DateTimePicker1.Value.ToString("hh:mm tt")
        cmd.Parameters.AddWithValue("@time", formattedTime)

        Dim selectedDay As String = DateTimePicker1.Value.DayOfWeek.ToString()
        cmd.Parameters.AddWithValue("@day", selectedDay)
        cmd.ExecuteNonQuery()
        con.Close()

        LoadSessionsFromDatabase()

        MessageBox.Show("Data inserted successfully.")
    End Sub


    Private Sub Guna2Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel1.Paint

    End Sub
End Class
