Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Windows.Forms

Public Class SessionForm
    Dim con As MySqlConnection = New MySqlConnection("server=localhost;username=root;password=new_password;database=infiniteeth")
    Public cmd As MySqlCommand
    Public da As MySqlDataAdapter
    Public dt As New DataTable
    Dim dr As MySqlDataReader

    Private Sub SessionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
        AddHandler MonthCalendar1.DateSelected, AddressOf MonthCalendar1_DateSelected
    End Sub

    Public Sub LoadData()
        Try
            Dim selectQuery As String = "SELECT dentistName, clientName, service, date, DATE_FORMAT(StartTime, '%h:%i %p') AS StartTime, DATE_FORMAT(EndTime, '%h:%i %p') AS EndTime FROM session"
            Using adapter As New MySqlDataAdapter(selectQuery, con)
                dt = New DataTable()
                adapter.Fill(dt)
            End Using
            For Each row As DataRow In dt.Rows
                Dim dateString As String = row("date").ToString()
                Dim dateValue As DateTime
                If DateTime.TryParseExact(dateString, {"M/d/yyyy h:mm:ss tt", "M/d/yyyy"}, CultureInfo.InvariantCulture, DateTimeStyles.None, dateValue) Then
                    row("date") = dateValue
                Else
                    MessageBox.Show("Error parsing date: " & dateString)
                End If
            Next

            DataGridView1.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message)
        End Try
    End Sub


    Private Sub MonthCalendar1_DateSelected(sender As Object, e As DateRangeEventArgs)
        DateTimePicker1.Value = MonthCalendar1.SelectionStart
        Dim selectedDate As Date = MonthCalendar1.SelectionStart
        Dim existingAppointments As Boolean = CheckExistingAppointments(selectedDate)

        If existingAppointments Then
            Dim result As DialogResult = MessageBox.Show("There are existing appointments on this date. Do you still want to create a new appointment?", "Confirm", MessageBoxButtons.YesNo)

            If result = DialogResult.Yes Then
                Dim sessionAppointment As New SessionAppointment(selectedDate)
                sessionAppointment.ShowDialog()
            End If
        Else
            Dim sessionAppointment As New SessionAppointment(selectedDate)
            sessionAppointment.ShowDialog()
        End If
    End Sub



    Private Function CheckExistingAppointments(dateToCheck As Date) As Boolean
        Dim connectionString As String = "server=localhost;username=root;password=new_password;database=infiniteeth"
        Dim existingAppointments As Boolean = False

        Try
            Dim selectQuery As String = "SELECT COUNT(*) FROM session WHERE date = @date"
            Using con As New MySqlConnection(connectionString)
                Using cmd As New MySqlCommand(selectQuery, con)
                    cmd.Parameters.AddWithValue("@date", dateToCheck)
                    con.Open()
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    existingAppointments = (count > 0)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error checking existing appointments: " & ex.Message)
        End Try

        Return existingAppointments
    End Function
End Class
