Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Windows.Forms
Public Class SessionAppointment
    Dim con As MySqlConnection = New MySqlConnection("server=localhost;username=root;password=new_password;database=infiniteeth")
    Public cmd As MySqlCommand
    Public da As MySqlDataAdapter
    Public dt As New DataTable
    Dim dr As MySqlDataReader
    Private appointmentDate As Date

    Private ReadOnly selectedDate As Date

    Public Sub New(selectedDate As Date)
        InitializeComponent()
        Me.selectedDate = selectedDate.Date
    End Sub


    Private Sub SessionAppointment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna2DateTimePicker1.Format = DateTimePickerFormat.Custom
        Guna2DateTimePicker1.CustomFormat = "hh:mm tt"
        Guna2DateTimePicker1.ShowUpDown = True

        Guna2DateTimePicker2.Format = DateTimePickerFormat.Custom
        Guna2DateTimePicker2.CustomFormat = "hh:mm tt"
        Guna2DateTimePicker2.ShowUpDown = True
        LoadDropdownData()
    End Sub
    Private Sub LoadDropdownData()
        Dim dentistNames As List(Of String) = getDentist()
        cbDentist.DataSource = dentistNames

        Dim clientNames As List(Of String) = getClient()
        cbClient.DataSource = clientNames

        Dim serviceOffered As List(Of String) = getServices()
        cbServices.DataSource = serviceOffered
    End Sub

    Private Function CheckAppointmentConflicts() As Boolean
        Dim hasConflict As Boolean = False
        Try
            Dim selectedDate As Date = Me.selectedDate
            Dim startTime As Date = Guna2DateTimePicker1.Value
            Dim endTime As Date = Guna2DateTimePicker2.Value

            Dim connectionString As String = "server=localhost;username=root;password=new_password;database=infiniteeth"
            Dim selectQuery As String = "SELECT COUNT(*) FROM session WHERE date = @date AND ((StartTime < @endTime AND EndTime > @startTime) OR (StartTime >= @startTime AND StartTime < @endTime) OR (EndTime > @startTime AND EndTime <= @endTime))"

            Using con As New MySqlConnection(connectionString)
                Using cmd As New MySqlCommand(selectQuery, con)
                    cmd.Parameters.AddWithValue("@date", selectedDate)
                    cmd.Parameters.AddWithValue("@startTime", startTime.TimeOfDay)
                    cmd.Parameters.AddWithValue("@endTime", endTime.TimeOfDay)
                    con.Open()
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    hasConflict = (count > 0)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error checking appointment conflicts: " & ex.Message)
        End Try

        Return hasConflict
    End Function

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            If Not CheckAppointmentConflicts() Then
                InsertSessionIntoDatabase()
                Dim sessionForm As SessionForm = Application.OpenForms.OfType(Of SessionForm)().FirstOrDefault()
                If sessionForm IsNot Nothing Then
                    sessionForm.LoadData()
                End If
                Me.Close()
            Else
                MessageBox.Show("There is a conflict with an existing appointment. Please choose a different time.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error inserting data: " & ex.Message)
        End Try
    End Sub

    Private Sub InsertSessionIntoDatabase()
        Try
            con.Open()
            Dim query As String = "INSERT INTO session (dentistName, clientName, service, date, StartTime, EndTime) VALUES (@dentist, @client, @service, @date, @StartTime, @EndTime)"
            cmd = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@dentist", cbDentist.SelectedItem)
            cmd.Parameters.AddWithValue("@client", cbClient.SelectedItem)
            cmd.Parameters.AddWithValue("@service", cbServices.SelectedItem)

            Dim selectedDateOnly As Date = selectedDate.Date
            cmd.Parameters.AddWithValue("@date", selectedDateOnly)

            Dim StartTime As String = Guna2DateTimePicker1.Value.ToString("hh:mm tt")
            Dim EndTime As String = Guna2DateTimePicker2.Value.ToString("hh:mm tt")

            cmd.Parameters.AddWithValue("@StartTime", StartTime)
            cmd.Parameters.AddWithValue("@EndTime", EndTime)

            cmd.ExecuteNonQuery()
            MsgBox("SCHEDULE CREATED")

            con.Close()
        Catch ex As Exception
            MessageBox.Show("Error inserting data: " & ex.Message)
        End Try
    End Sub




    Private Function getDentist() As List(Of String)
        Dim connectionString As String = "server=localhost;user=root;password=new_password;database=infiniteeth"
        Dim dentistNames As New List(Of String)

        Using con As New MySqlConnection(connectionString)
            Dim query As String = "SELECT fullname FROM dentist"
            Dim cmd As New MySqlCommand(query, con)

            con.Open()
            Using dr As MySqlDataReader = cmd.ExecuteReader()
                While dr.Read()
                    dentistNames.Add(dr.GetString(0))
                End While
            End Using
        End Using
        Return dentistNames
    End Function

    Private Function getClient() As List(Of String)
        Dim connectionString As String = "server=localhost;user=root;password=new_password;database=infiniteeth"
        Dim clientNames As New List(Of String)

        Using con As New MySqlConnection(connectionString)
            Dim query As String = "SELECT Client_Name FROM pendingappointments"
            Dim cmd As New MySqlCommand(query, con)

            con.Open()
            Using dr As MySqlDataReader = cmd.ExecuteReader()
                While dr.Read()
                    clientNames.Add(dr.GetString(0))
                End While
            End Using
        End Using
        Return clientNames
    End Function

    Private Function getServices() As List(Of String)
        Dim connectionString As String = "server=localhost;user=root;password=new_password;database=infiniteeth"
        Dim serviceOffered As New List(Of String)

        Using con As New MySqlConnection(connectionString)
            Dim query As String = "SELECT serviceoffered FROM dentist"
            Dim cmd As New MySqlCommand(query, con)

            con.Open()
            Using dr As MySqlDataReader = cmd.ExecuteReader()
                While dr.Read()
                    serviceOffered.Add(dr.GetString(0))
                End While
            End Using
        End Using
        Return serviceOffered
    End Function

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click

        SessionForm.Show()
        Me.Hide()

    End Sub
End Class