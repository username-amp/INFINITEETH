Imports System.IO

Public Class Calendar
    Private Sub Calendar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeCalendar()
    End Sub

    Private Sub InitializeCalendar()
        ' Set up the DataGridView
        With DataGridView1
            .RowHeadersVisible = False
            .ColumnHeadersVisible = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .EditMode = DataGridViewEditMode.EditOnEnter
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoGenerateColumns = False
        End With

        ' Add columns
        With DataGridView1.Columns
            .Add("DateColumn", "Date")
            .Add("TimeColumn", "Time")
            .Add("AppointmentColumn", "Appointment")
        End With

        ' Set column widths
        DataGridView1.Columns("DateColumn").Width = 100
        DataGridView1.Columns("TimeColumn").Width = 100
        DataGridView1.Columns("AppointmentColumn").Width = 200

        ' Add rows
        For i As Integer = 8 To 17
            Dim time As String = i.ToString("00") & ":00"
            DataGridView1.Rows.Add(DateTime.Today.ToShortDateString(), time, "")
        Next
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' Add a new row for a new appointment
        DataGridView1.Rows.Add(DateTime.Today.ToShortDateString(), "", "")
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        ' Allow user to edit the selected appointment
        If DataGridView1.SelectedRows.Count > 0 Then
            DataGridView1.BeginEdit(True)
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' Delete the selected appointment
        If DataGridView1.SelectedRows.Count > 0 Then
            DataGridView1.Rows.Remove(DataGridView1.SelectedRows(0))
        End If
    End Sub

    Private Sub Calendar_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Save appointments before closing
        SaveAppointmentsToFile("Appointments.txt")
    End Sub

    Private Sub LoadAppointmentsFromFile(filename As String)
        ' Load appointments from file
        If File.Exists(filename) Then
            Using reader As New StreamReader(filename)
                While Not reader.EndOfStream
                    Dim line As String = reader.ReadLine()
                    Dim parts() As String = line.Split(","c)
                    If parts.Length = 3 Then
                        DataGridView1.Rows.Add(parts(0), parts(1), parts(2))
                    End If
                End While
            End Using
        End If
    End Sub

    Private Sub SaveAppointmentsToFile(filename As String)
        ' Save appointments to file
        Using writer As New StreamWriter(filename)
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    writer.WriteLine($"{row.Cells("DateColumn").Value},{row.Cells("TimeColumn").Value},{row.Cells("AppointmentColumn").Value}")
                End If
            Next
        End Using
    End Sub
End Class
