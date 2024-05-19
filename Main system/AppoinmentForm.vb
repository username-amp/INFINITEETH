Imports System.Web.UI.WebControls
Imports MySql.Data.MySqlClient
Imports System.Net.Http

Public Class AppoinmentForm
    Dim con As MySqlConnection = New MySqlConnection("server=localhost;username=root;password=;database=infiniteeth")

    Private Sub LoadAppointments(Optional searchQuery As String = "")
        Try
            Dim pendingQuery As String = "SELECT *, TIME_FORMAT(Time, '%h:%i %p') AS Time FROM pendingappointments WHERE Client_Name IS NOT NULL AND Services IS NOT NULL AND Dentist IS NOT NULL AND Day IS NOT NULL AND Time IS NOT NULL AND Status IS NOT NULL"
            Dim historyQuery As String = "SELECT *, TIME_FORMAT(Time, '%h:%i %p') AS Time FROM appointment_history WHERE Client_Name IS NOT NULL AND Services IS NOT NULL AND Dentist IS NOT NULL AND Day IS NOT NULL AND Time IS NOT NULL AND Status IS NOT NULL"

            If Not String.IsNullOrEmpty(searchQuery) Then
                pendingQuery &= " AND (Client_Name LIKE @search OR Services LIKE @search OR Dentist LIKE @search OR Day LIKE @search OR Time LIKE @search OR Status LIKE @search)"
                historyQuery &= " AND (Client_Name LIKE @search OR Services LIKE @search OR Dentist LIKE @search OR Day LIKE @search OR Time LIKE @search OR Status LIKE @search)"
            End If

            Using connection As New MySqlConnection(con.ConnectionString)
                Using pendingCommand As New MySqlCommand(pendingQuery, connection), historyCommand As New MySqlCommand(historyQuery, connection)
                    If Not String.IsNullOrEmpty(searchQuery) Then
                        pendingCommand.Parameters.AddWithValue("@search", "%" & searchQuery & "%")
                        historyCommand.Parameters.AddWithValue("@search", "%" & searchQuery & "%")
                    End If

                    Dim pendingAdapter As New MySqlDataAdapter(pendingCommand)
                    Dim historyAdapter As New MySqlDataAdapter(historyCommand)

                    Dim pendingTable As New DataTable()
                    Dim historyTable As New DataTable()

                    pendingAdapter.Fill(pendingTable)
                    historyAdapter.Fill(historyTable)

                    ' Set primary keys for DataTables
                    If Not pendingTable.Columns.Contains("PendingID") Then
                        MessageBox.Show("Error: PendingID column is missing in pendingappointments table.")
                        Return
                    End If
                    pendingTable.PrimaryKey = New DataColumn() {pendingTable.Columns("PendingID")}

                    If Not historyTable.Columns.Contains("PendingID") Then
                        MessageBox.Show("Error: PendingID column is missing in appointment_history table.")
                        Return
                    End If
                    historyTable.PrimaryKey = New DataColumn() {historyTable.Columns("PendingID")}

                    ' Hide the original Time column
                    If DataGridView1.Columns.Contains("Time") Then
                        DataGridView1.Columns("Time").Visible = False
                    End If

                    If DataGridView2.Columns.Contains("Time") Then
                        DataGridView2.Columns("Time").Visible = False
                    End If

                    If pendingTable.Rows.Count > 0 Then
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

                        With DataGridView1
                            .DefaultCellStyle.Font = New Font("Arial", 12)
                            .DefaultCellStyle.ForeColor = Color.Black
                            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                        End With
                    Else
                        DataGridView1.DataSource = Nothing
                    End If

                    If historyTable.Rows.Count > 0 Then
                        DataGridView2.DataSource = historyTable

                        With DataGridView2
                            .DefaultCellStyle.Font = New Font("Arial", 12)
                            .DefaultCellStyle.ForeColor = Color.Black
                            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                        End With
                    Else
                        DataGridView2.DataSource = Nothing
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading appointments: " & ex.Message)
        End Try
    End Sub









    Private Sub LoadAppointmentsData(Optional searchQuery As String = "")
        LoadAppointments(searchQuery)
    End Sub


    Private Sub ApproveAppointment()
        If DataGridView1.Rows.Count > 0 Then ' Check if there are rows in the DataGridView
            If DataGridView1.SelectedRows.Count > 0 Then
                Dim appointmentId As Integer = Convert.ToInt32(DataGridView1.SelectedRows(0).Cells("PendingID").Value)
                Dim clientName As String = Convert.ToString(DataGridView1.SelectedRows(0).Cells("Client_Name").Value)
                Dim service As String = Convert.ToString(DataGridView1.SelectedRows(0).Cells("Services").Value)
                Dim dentist As String = Convert.ToString(DataGridView1.SelectedRows(0).Cells("Dentist").Value)
                Dim day As String = Convert.ToString(DataGridView1.SelectedRows(0).Cells("Day").Value)
                Dim time As String = Convert.ToString(DataGridView1.SelectedRows(0).Cells("Time").Value)
                Dim patientID As Integer = Convert.ToInt32(DataGridView1.SelectedRows(0).Cells("patient_PatientID").Value)

                Dim message As String = GetMessageFromDatabase(appointmentId)

                UpdateAppointmentStatus(appointmentId, "Approved")
                InsertIntoHistory(appointmentId, clientName, service, dentist, day, time, "Approved", message, patientID)

                RemoveFromDataGridView(DataGridView1, DataGridView2, DataGridView1.SelectedRows(0))
                LoadAppointments()
            Else
                MessageBox.Show("Please select an appointment to approve.", "No Appointment Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("There are no appointments to approve.", "No Appointments", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub


    Private Sub RejectAppointment()
        If DataGridView1.Rows.Count > 0 Then ' Check if there are rows in the DataGridView
            If DataGridView1.SelectedRows.Count > 0 Then
                Dim appointmentId As Integer = Convert.ToInt32(DataGridView1.SelectedRows(0).Cells("PendingID").Value)
                Dim clientName As String = Convert.ToString(DataGridView1.SelectedRows(0).Cells("Client_Name").Value)
                Dim service As String = Convert.ToString(DataGridView1.SelectedRows(0).Cells("Services").Value)
                Dim dentist As String = Convert.ToString(DataGridView1.SelectedRows(0).Cells("Dentist").Value)
                Dim day As String = Convert.ToString(DataGridView1.SelectedRows(0).Cells("Day").Value)
                Dim time As String = Convert.ToString(DataGridView1.SelectedRows(0).Cells("Time").Value)
                Dim patientID As Integer = Convert.ToInt32(DataGridView1.SelectedRows(0).Cells("patient_PatientID").Value) ' Assuming PatientID is the correct column name

                ' Show input dialog to get rejection message
                Dim rejectionMessage As String = InputBox("Please enter a rejection message:", "Rejection Message")
                If String.IsNullOrEmpty(rejectionMessage) Then
                    MessageBox.Show("Rejection message is required.", "Rejection Message Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                ' Update the status and message in the pendingappointments table
                UpdateAppointmentStatusAndMessage(appointmentId, "Rejected", rejectionMessage)

                ' Insert the rejected appointment into the history with the rejection message
                InsertIntoHistory(appointmentId, clientName, service, dentist, day, time, "Rejected", rejectionMessage, patientID)

                ' Update the status and message in the appointment_history table
                UpdateAppointmentHistoryStatusAndMessage(appointmentId, "Rejected", rejectionMessage)

                ' Remove the rejected appointment from the pending list and refresh the view
                RemoveFromDataGridView(DataGridView1, DataGridView2, DataGridView1.SelectedRows(0))
                LoadAppointments()
            Else
                MessageBox.Show("Please select an appointment to reject.", "No Appointment Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("There are no appointments to reject.", "No Appointments", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub



    Private Sub UpdateAppointmentStatusAndMessage(appointmentId As Integer, status As String, message As String)
        Dim query As String = "UPDATE pendingappointments SET Status = @Status, Message = @Message WHERE PendingID = @PendingID"
        Using connection As New MySqlConnection(con.ConnectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@Status", status)
                command.Parameters.AddWithValue("@Message", message)
                command.Parameters.AddWithValue("@PendingID", appointmentId)
                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub UpdateAppointmentHistoryStatusAndMessage(appointmentId As Integer, status As String, message As String)
        Dim query As String = "UPDATE appointment_history SET Status = @Status, Message = @Message WHERE PendingID = @PendingID"
        Using connection As New MySqlConnection(con.ConnectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@Status", status)
                command.Parameters.AddWithValue("@Message", message)
                command.Parameters.AddWithValue("@PendingID", appointmentId)
                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub











    Private Function GetMessageFromDatabase(appointmentId As Integer) As String
        Dim message As String = ""
        Dim query As String = "SELECT Message FROM pendingappointments WHERE PendingID = @PendingID"

        Using connection As New MySqlConnection(con.ConnectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@PendingID", appointmentId)
                connection.Open()
                Dim result = command.ExecuteScalar()
                If result IsNot Nothing Then
                    message = result.ToString()
                End If
            End Using
        End Using

        Return message
    End Function

    Private Sub RemoveFromDataGridView(sourceDataGridView As DataGridView, destinationDataGridView As DataGridView, selectedRow As DataGridViewRow)
        If sourceDataGridView.DataSource IsNot Nothing AndAlso TypeOf sourceDataGridView.DataSource Is DataTable AndAlso
       destinationDataGridView.DataSource IsNot Nothing AndAlso TypeOf destinationDataGridView.DataSource Is DataTable Then

            Dim sourceDataTable As DataTable = CType(sourceDataGridView.DataSource, DataTable)
            Dim destinationDataTable As DataTable = CType(destinationDataGridView.DataSource, DataTable)

            Dim selectedRowData As DataRowView = CType(selectedRow.DataBoundItem, DataRowView)
            Dim primaryKeyValue As Object = selectedRowData.Row(sourceDataTable.PrimaryKey(0))

            ' Check if the row exists in the source DataTable by primary key value
            Dim rowToRemove As DataRow = sourceDataTable.Rows.Find(primaryKeyValue)

            If rowToRemove IsNot Nothing Then
                ' Import row to destination DataTable
                destinationDataTable.ImportRow(rowToRemove)
                ' Remove row from source DataTable
                sourceDataTable.Rows.Remove(rowToRemove)
            Else
                MessageBox.Show("Selected row not found in the source DataGridView.")
            End If
        Else
            MessageBox.Show("Error: Source or destination DataGridView is not properly initialized.")
        End If
    End Sub





    Private Sub InsertIntoHistory(pendingID As Integer, clientName As String, service As String, dentist As String, day As String, time As String, status As String, message As String, patientID As Integer)
        ' Extract date part from the time string
        Dim datePart As String = day.Split(" "c)(0) ' Assuming day is in the format 'YYYY-MM-DD'

        ' Build the query
        Dim query As String = "INSERT INTO appointment_history (PendingID, Client_Name, Services, Dentist, Day, Time, Status, Message, patient_PatientID) VALUES (@PendingID, @Client_Name, @Services, @Dentist, @Day, @Time, @Status, @Message, @PatientID)"

        ' Execute the query
        Using connection As New MySqlConnection(con.ConnectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@PendingID", pendingID)
                command.Parameters.AddWithValue("@Client_Name", clientName)
                command.Parameters.AddWithValue("@Services", service)
                command.Parameters.AddWithValue("@Dentist", dentist)
                command.Parameters.AddWithValue("@Day", datePart) ' Insert date part only
                command.Parameters.AddWithValue("@Time", time)
                command.Parameters.AddWithValue("@Status", status)
                command.Parameters.AddWithValue("@Message", message)
                command.Parameters.AddWithValue("@PatientID", patientID)
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
        Dim cancelledCount As Integer = CountAppointmentsByStatus("Cancelled")

        lblPending.Text = "Pending: " & pendingCount.ToString()
        lblapprove.Text = "Approved: " & approvedCount.ToString()
        lblreject.Text = "Rejected: " & rejectedCount.ToString()
        lblCancelled.Text = "Cancelled: " & cancelledCount.ToString()

        SetProgressBarValue(pbPending, pendingCount, totalAppointments)
        SetProgressBarValue(pbApprove, approvedCount, totalAppointments)
        SetProgressBarValue(pbReject, rejectedCount, totalAppointments)
        SetProgressBarValue(pbCancelled, cancelledCount, totalAppointments)
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

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns.Contains("Delete") AndAlso DataGridView1.Columns.Contains("PendingID") Then
            If e.RowIndex >= 0 AndAlso e.ColumnIndex = DataGridView1.Columns("Delete").Index Then
                Dim confirmation As DialogResult = MessageBox.Show("Are you sure you want to delete this appointment?", "Confirmation", MessageBoxButtons.YesNo)
                If confirmation = DialogResult.Yes Then
                    Dim cellValue As Object = DataGridView1.Rows(e.RowIndex).Cells("PendingID").Value

                    If cellValue IsNot DBNull.Value AndAlso Not String.IsNullOrEmpty(cellValue.ToString()) Then
                        Dim appointmentId As Integer = Convert.ToInt32(cellValue)
                        DeleteAppointment(appointmentId)
                    Else
                        MessageBox.Show("There are no appointments to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If
                End If
            End If
        End If
    End Sub


    Private Sub DeleteAppointment(appointmentId As Integer)
        Dim querySelect As String = "SELECT * FROM pendingappointments WHERE PendingID = @PendingID"
        Dim appointmentDetails As DataTable = New DataTable()

        Try
            Using connection As New MySqlConnection(con.ConnectionString)
                Using command As New MySqlCommand(querySelect, connection)
                    command.Parameters.AddWithValue("@PendingID", appointmentId)
                    connection.Open()

                    Using reader As MySqlDataReader = command.ExecuteReader()
                        appointmentDetails.Load(reader)
                    End Using
                End Using
            End Using

            If appointmentDetails.Rows.Count = 1 Then
                Dim queryDelete As String = "DELETE FROM pendingappointments WHERE PendingID = @PendingID"

                Using connection As New MySqlConnection(con.ConnectionString)
                    Using command As New MySqlCommand(queryDelete, connection)
                        command.Parameters.AddWithValue("@PendingID", appointmentId)
                        connection.Open()
                        command.ExecuteNonQuery()
                    End Using
                End Using
                LoadAppointments()
                LoadAppointmentsData()
                CountAndDisplayAppointments()
            Else
                MessageBox.Show("Error: Appointment not found.")
            End If
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

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadAppointmentsData(txtSearch.Text)
    End Sub
End Class
