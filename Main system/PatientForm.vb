Imports MySql.Data.MySqlClient

Public Class PatientForm
    Dim con As MySqlConnection = New MySqlConnection("server=localhost;username=root;password=new_password;database=infiniteeth")
    Public cmd As MySqlCommand
    Public da As New MySqlDataAdapter(cmd)
    Public dt As New DataTable
    Dim dr As MySqlDataReader

    Private Sub btnAdd_Click(sender As Object, e As EventArgs)
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            Dim query As String
            query = "INSERT INTO patient(`Full Name`, Sex, Age, Address, Contact) VALUES (@FullName, @Sex, @Age, @Address, @Contact)"
            cmd = New MySqlCommand(query, con)

            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@FullName", txtfullname.Text)
            cmd.Parameters.AddWithValue("@Sex", cbsex.SelectedItem)
            cmd.Parameters.AddWithValue("@Age", txtage.Text)
            cmd.Parameters.AddWithValue("@Address", txtaddress.Text)
            cmd.Parameters.AddWithValue("@Contact", txtcontactno.Text)

            cmd.ExecuteNonQuery()
            MsgBox("Data inserted")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            loadData()
            con.Close()
        End Try
    End Sub

    Sub loadData()
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            Dim cmd As New MySqlCommand("SELECT * FROM patient", con)
            Dim da As New MySqlDataAdapter(cmd)
            dt.Clear()
            da.Fill(dt)
            DataGridView1.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs)
        If DataGridView1.SelectedRows.Count > 0 Then
            Try
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)
                Dim id As Integer = Convert.ToInt32(selectedRow.Cells("PatientID").Value)

                Dim query As String = "DELETE FROM patient WHERE PatientID = @ID"
                cmd = New MySqlCommand(query, con)
                cmd.Parameters.AddWithValue("@ID", id)
                cmd.ExecuteNonQuery()
                MsgBox("Data deleted")

                txtfullname.Clear()
                cbsex.SelectedIndex = -1
                txtage.Clear()
                txtaddress.Clear()
                txtcontactno.Clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                loadData()
                con.Close()
            End Try
        Else
            MsgBox("Please select a row to delete.")
        End If
    End Sub

    Private Sub PatientForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadData()
        DataGridView1.DefaultCellStyle.BackColor = Color.Beige
        DataGridView1.DefaultCellStyle.Font = New Font(DataGridView1.DefaultCellStyle.Font.FontFamily, DataGridView1.DefaultCellStyle.Font.Size + 2)
        DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs)
        Main.Show()
        Me.Hide()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

            txtfullname.Text = selectedRow.Cells("Full Name").Value.ToString()
            cbsex.SelectedItem = selectedRow.Cells("Sex").Value.ToString()
            txtage.Text = selectedRow.Cells("Age").Value.ToString()
            txtaddress.Text = selectedRow.Cells("Address").Value.ToString()
            txtcontactno.Text = selectedRow.Cells("Contact").Value.ToString()
        End If
    End Sub

    Private Sub Guna2GradientButton1_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim query As String
            query = "INSERT INTO patient(`Full Name`, Sex, Age, Address, Contact) VALUES (@FullName, @Sex, @Age, @Address, @Contact)"
            cmd = New MySqlCommand(query, con)

            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@FullName", txtfullname.Text)
            cmd.Parameters.AddWithValue("@Sex", cbsex.SelectedItem)
            cmd.Parameters.AddWithValue("@Age", txtage.Text)
            cmd.Parameters.AddWithValue("@Address", txtaddress.Text)
            cmd.Parameters.AddWithValue("@Contact", txtcontactno.Text)

            cmd.ExecuteNonQuery()
            MsgBox("Data inserted")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            loadData()
            con.Close()
        End Try
    End Sub

    Private Sub Guna2GradientButton1_Click_1(sender As Object, e As EventArgs) Handles btnDelete.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Try
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)
                Dim id As Integer = Convert.ToInt32(selectedRow.Cells("PatientID").Value)

                Dim query As String = "DELETE FROM patient WHERE PatientID = @ID"
                cmd = New MySqlCommand(query, con)
                cmd.Parameters.AddWithValue("@ID", id)
                cmd.ExecuteNonQuery()
                MsgBox("Data deleted")

                txtfullname.Clear()
                cbsex.SelectedIndex = -1
                txtage.Clear()
                txtaddress.Clear()
                txtcontactno.Clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                loadData()
                con.Close()
            End Try
        Else
            MsgBox("Please select a row to delete.")
        End If
    End Sub
End Class
