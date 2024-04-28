Imports MySql.Data.MySqlClient

Public Class AppoinmentForm
    Dim con As MySqlConnection = New MySqlConnection("server=localhost;username=root;password=;database=infiniteeth")
    Public cmd As MySqlCommand
    Public da As New MySqlDataAdapter(cmd)
    Public dt As New DataTable
    Dim dr As MySqlDataReader

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        DashboardForm.Show()
        Me.Hide()
    End Sub

    Private Sub LoadAppointments()
        Try
            Dim query As String = "SELECT * FROM pendingappointments"
            Using connection As New MySqlConnection(con.ConnectionString)
                Using command As New MySqlCommand(query, connection)
                    Dim adapter As New MySqlDataAdapter(command)
                    Dim dataTable As New DataTable()
                    adapter.Fill(dataTable)
                    DataGridView1.DataSource = dataTable
                    With DataGridView1
                        .DefaultCellStyle.Font = New Font("Arial", 12)
                        .DefaultCellStyle.ForeColor = Color.Black
                    End With
                    MessageBox.Show("Loaded " & dataTable.Rows.Count & " appointments.")
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading appointments: " & ex.Message)
        End Try
    End Sub



    Private Sub ApproveAppointment()
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim appointmentId As Integer = Convert.ToInt32(DataGridView1.SelectedRows(0).Cells("PendingID").Value)
            UpdateAppointmentStatus(appointmentId, "Approved")
            LoadAppointments()
        Else
            MessageBox.Show("Please select an appointment to approve.")
        End If
    End Sub

    Private Sub RejectAppointment()
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim appointmentId As Integer = Convert.ToInt32(DataGridView1.SelectedRows(0).Cells("PendingID").Value)
            UpdateAppointmentStatus(appointmentId, "Rejected")
            LoadAppointments()
        Else
            MessageBox.Show("Please select an appointment to reject.")
        End If
    End Sub

    Private Sub UpdateAppointmentStatus(appointmentId As Integer, status As String)
        Dim query As String = "UPDATE pendingappointments SET Status = @Status WHERE PendingID = @PendingID"
        Using connection As New MySqlConnection(con.ConnectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@Status", status)
                command.Parameters.AddWithValue("@PendingID", appointmentId)
                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub InsertAppointment(service As String, dentist As String, time As String)
        Dim query As String = "INSERT INTO pendingAppointments (Services, Dentist, Time, Status) VALUES (@Services, @Dentist, @Time, 'Pending')"
        Using connection As New MySqlConnection(con.ConnectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@Services", service)
                command.Parameters.AddWithValue("@Dentist", dentist)
                command.Parameters.AddWithValue("@Time", time)
                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub




    Private Sub CountAndDisplayAppointments()
        Dim pendingCount As Integer = CountAppointmentsByStatus("Pending")
        Dim approvedCount As Integer = CountAppointmentsByStatus("Approved")
        Dim rejectedCount As Integer = CountAppointmentsByStatus("Rejected")

        lblPending.Text = "Pending: " & pendingCount.ToString()
        lblApproved.Text = "Approved: " & approvedCount.ToString()
        lblRejected.Text = "Rejected: " & rejectedCount.ToString()
    End Sub

    Private Function CountAppointmentsByStatus(status As String) As Integer
        Dim count As Integer = 0
        Dim query As String = "SELECT COUNT(*) FROM pendingappointments WHERE Status = @Status"
        Using connection As New MySqlConnection(con.ConnectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@Status", status)
                connection.Open()
                count = Convert.ToInt32(command.ExecuteScalar())
            End Using
        End Using
        Return count
    End Function


    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        ApproveAppointment()
        CountAndDisplayAppointments()
    End Sub

    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        RejectAppointment()
        CountAndDisplayAppointments()
    End Sub

    Private Sub AppoinmentForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAppointments()
        CountAndDisplayAppointments()
    End Sub

    Private Sub btnAdd_Click_1(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim service As String = txtService.Text
        Dim dentist As String = txtDentist.Text
        Dim time As String = txtTime.Text


        If Not String.IsNullOrEmpty(service) AndAlso Not String.IsNullOrEmpty(dentist) AndAlso Not String.IsNullOrEmpty(time) Then

            InsertAppointment(service, dentist, time)

            LoadAppointments()
        Else
            MessageBox.Show("Please fill in all fields before adding appointment.")
        End If
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        LoadAppointments()
        CountAndDisplayAppointments()
    End Sub
End Class
