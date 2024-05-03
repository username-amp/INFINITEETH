Imports System.Web.UI.WebControls
Imports MySql.Data.MySqlClient

Public Class AppoinmentForm
    Dim con As MySqlConnection = New MySqlConnection("server=localhost;username=root;password=;database=infiniteeth")

    Private Sub LoadAppointments()
        Try
            Dim pendingQuery As String = "SELECT * FROM pendingappointments"
            Dim historyQuery As String = "SELECT * FROM appointment_history"

            Using connection As New MySqlConnection(con.ConnectionString)
                Using pendingCommand As New MySqlCommand(pendingQuery, connection), historyCommand As New MySqlCommand(historyQuery, connection)
                    Dim pendingAdapter As New MySqlDataAdapter(pendingCommand)
                    Dim historyAdapter As New MySqlDataAdapter(historyCommand)

                    Dim pendingTable As New DataTable()
                    Dim historyTable As New DataTable()

                    pendingAdapter.Fill(pendingTable)
                    historyAdapter.Fill(historyTable)

                    DataGridView1.DataSource = pendingTable
                    If DataGridView1.Columns.Contains("Delete") Then
                        DataGridView1.Columns.Remove("Delete")
                    End If
                    Dim deleteButtonColumn As New DataGridViewButtonColumn()
                    deleteButtonColumn.HeaderText = "Delete"
                    deleteButtonColumn.Text = "Delete"
                    deleteButtonColumn.UseColumnTextForButtonValue = True
                    deleteButtonColumn.Name = "Delete"
                    DataGridView1.Columns.Add(deleteButtonColumn)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading appointments: " & ex.Message)
        End Try
    End Sub

    Private Sub ApproveAppointment()
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim appointmentId As Integer = Convert.ToInt32(DataGridView1.SelectedRows(0).Cells("PendingID").Value)
            Dim clientName As String = Convert.ToString(DataGridView1.SelectedRows(0).Cells("Client_Name").Value)
            Dim service As String = Convert.ToString(DataGridView1.SelectedRows(0).Cells("Services").Value)
            Dim dentist As String = Convert.ToString(DataGridView1.SelectedRows(0).Cells("Dentist").Value)
            Dim day As String = Convert.ToString(DataGridView1.SelectedRows(0).Cells("Day").Value)
            Dim time As String = Convert.ToString(DataGridView1.SelectedRows(0).Cells("Time").Value)

            UpdateAppointmentStatus(appointmentId, "Approved")
            InsertIntoHistory(clientName, service, dentist, day, time, "Approved")
            RemoveFromDataGridView(DataGridView1, DataGridView2, DataGridView1.SelectedRows(0))
            LoadAppointments()

        Else
            MessageBox.Show("Please select an appointment to approve.")
        End If
    End Sub

    Private Sub RejectAppointment()
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim appointmentId As Integer = Convert.ToInt32(DataGridView1.SelectedRows(0).Cells("PendingID").Value)
            Dim clientName As String = Convert.ToString(DataGridView1.SelectedRows(0).Cells("Client_Name").Value)
            Dim service As String = Convert.ToString(DataGridView1.SelectedRows(0).Cells("Services").Value)
            Dim dentist As String = Convert.ToString(DataGridView1.SelectedRows(0).Cells("Dentist").Value)
            Dim day As String = Convert.ToString(DataGridView1.SelectedRows(0).Cells("Day").Value)
            Dim time As String = Convert.ToString(DataGridView1.SelectedRows(0).Cells("Time").Value)

            UpdateAppointmentStatus(appointmentId, "Rejected")
            InsertIntoHistory(clientName, service, dentist, day, time, "Rejected")
            RemoveFromDataGridView(DataGridView1, DataGridView2, DataGridView1.SelectedRows(0))
            LoadAppointments()

        Else
            MessageBox.Show("Please select an appointment to reject.")
        End If
    End Sub

    Private Sub RemoveFromDataGridView(sourceDataGridView As DataGridView, destinationDataGridView As DataGridView, selectedRow As DataGridViewRow)
        Dim sourceDataTable As DataTable = CType(sourceDataGridView.DataSource, DataTable)

        If destinationDataGridView.DataSource IsNot Nothing AndAlso TypeOf destinationDataGridView.DataSource Is DataTable Then
            Dim destinationDataTable As DataTable = CType(destinationDataGridView.DataSource, DataTable)

            Dim selectedRowData As DataRow = CType(selectedRow.DataBoundItem, DataRowView).Row

            destinationDataTable.ImportRow(selectedRowData)
            sourceDataTable.Rows.Remove(selectedRowData)
        Else
            MessageBox.Show("Error: Destination DataGridView is not properly initialized.")
        End If
    End Sub

    Private Sub InsertIntoHistory(clientName As String, service As String, dentist As String, day As String, time As String, status As String)
        Dim query As String = "INSERT INTO appointment_history (Client_Name, Services, Dentist, Day, Time, Status) VALUES (@Client_Name, @Services, @Dentist, @Day, @Time, @Status)"
        Using connection As New MySqlConnection(con.ConnectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@Client_Name", clientName)
                command.Parameters.AddWithValue("@Services", service)
                command.Parameters.AddWithValue("@Dentist", dentist)
                command.Parameters.AddWithValue("@Day", day)
                command.Parameters.AddWithValue("@Time", time)
                command.Parameters.AddWithValue("@Status", status)
                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using
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

    Private Sub InsertAppointment(clientName As String, service As String, dentist As String, day As String, time As String)
        Dim query As String = "INSERT INTO pendingAppointments (Client_Name, Services, Dentist, Day, Time, Status) VALUES (@Client_Name, @Services, @Dentist, @Day, @Time, 'Pending')"
        Using connection As New MySqlConnection(con.ConnectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@Client_Name", clientName)
                command.Parameters.AddWithValue("@Services", service)
                command.Parameters.AddWithValue("@Dentist", dentist)
                command.Parameters.AddWithValue("@Day", day)
                command.Parameters.AddWithValue("@Time", time)
                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub CountAndDisplayAppointments()
        Dim totalAppointments As Integer = CountTotalAppointments()
        Dim pendingCount As Integer = CountAppointmentsByStatus("Pending")
        Dim approvedCount As Integer = CountAppointmentsByStatus("Approved")
        Dim rejectedCount As Integer = CountAppointmentsByStatus("Rejected")

        SetProgressBarValue(pbPending, pendingCount, totalAppointments)
        SetProgressBarValue(pbApprove, approvedCount, totalAppointments)
        SetProgressBarValue(pbReject, rejectedCount, totalAppointments)
    End Sub

    Private Sub SetProgressBarValue(progressBar As Guna.UI2.WinForms.Guna2ProgressBar, appointmentsCount As Integer, totalAppointments As Integer)
        Dim percentage As Integer = If(totalAppointments > 0, (appointmentsCount / totalAppointments) * 100, 0)
        progressBar.Value = percentage

    End Sub

    Private Function CountTotalAppointments() As Integer
        Dim total As Integer = 0
        Dim query As String = "SELECT COUNT(*) FROM pendingappointments"
        Using connection As New MySqlConnection(con.ConnectionString)
            Using command As New MySqlCommand(query, connection)
                connection.Open()
                total = Convert.ToInt32(command.ExecuteScalar())
            End Using
        End Using
        Return total
    End Function

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

    Private Sub AppoinmentForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAppointmentsData()
        CountAndDisplayAppointments()

    End Sub

    Private Sub LoadAppointmentsData()
        Try
            Dim pendingQuery As String = "SELECT * FROM pendingappointments"
            Dim historyQuery As String = "SELECT * FROM appointment_history"

            Using connection As New MySqlConnection(con.ConnectionString)
                Using pendingCommand As New MySqlCommand(pendingQuery, connection), historyCommand As New MySqlCommand(historyQuery, connection)
                    Dim pendingAdapter As New MySqlDataAdapter(pendingCommand)
                    Dim historyAdapter As New MySqlDataAdapter(historyCommand)

                    Dim pendingTable As New DataTable()
                    Dim historyTable As New DataTable()

                    pendingAdapter.Fill(pendingTable)
                    historyAdapter.Fill(historyTable)

                    DataGridView1.DataSource = pendingTable
                    DataGridView2.DataSource = historyTable

                    With DataGridView1
                        .DefaultCellStyle.Font = New Font("Arial", 12)
                        .DefaultCellStyle.ForeColor = Color.Black
                    End With

                    With DataGridView2
                        .DefaultCellStyle.Font = New Font("Arial", 12)
                        .DefaultCellStyle.ForeColor = Color.Black
                    End With
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading appointments: " & ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = DataGridView1.Columns("Delete").Index Then
            Dim confirmation As DialogResult = MessageBox.Show("Are you sure you want to delete this appointment?", "Confirmation", MessageBoxButtons.YesNo)
            If confirmation = DialogResult.Yes Then
                Dim appointmentId As Integer = Convert.ToInt32(DataGridView1.Rows(e.RowIndex).Cells("PendingID").Value)
                DeleteAppointment(appointmentId)
                LoadAppointments()
            End If
        End If
    End Sub


    Private Sub DeleteAppointment(appointmentId As Integer)
        Dim query As String = "DELETE FROM pendingappointments WHERE PendingID = @PendingID"
        Try
            Using connection As New MySqlConnection(con.ConnectionString)
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@PendingID", appointmentId)
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error deleting appointment: " & ex.Message)
        End Try
    End Sub



    Private Sub btnApprove_Click_1(sender As Object, e As EventArgs) Handles btnApprove.Click
        ApproveAppointment()
        CountAndDisplayAppointments()
    End Sub

    Private Sub btnReject_Click_1(sender As Object, e As EventArgs) Handles btnReject.Click
        RejectAppointment()
        CountAndDisplayAppointments()
    End Sub

    Private Sub btnLoad_Click_1(sender As Object, e As EventArgs) Handles btnLoad.Click
        LoadAppointmentsData()
        CountAndDisplayAppointments()
    End Sub

    Private Sub Guna2Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel4.Paint

    End Sub
End Class
