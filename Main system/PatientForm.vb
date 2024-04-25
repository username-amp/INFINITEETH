Imports MySql.Data.MySqlClient

Public Class PatientForm
    Dim con As MySqlConnection = New MySqlConnection("server=localhost;username=root;password=;database=infiniteeth")

    Public cmd As MySqlCommand
    Public da As New MySqlDataAdapter(cmd)
    Public dt As New DataTable
    Dim dr As MySqlDataReader

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            Dim query As String
            query = "INSERT INTO patient(`Full Name`, `Sex`, `Age`, `Address`, `Contact`) VALUES (@FullName, @Sex, @Age, @Address,@Contact)"
            cmd = New MySqlCommand(query, con)

            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@FullName", txtfullname.Text)
            cmd.Parameters.AddWithValue("@Sex", cbsex.SelectedItem)
            cmd.Parameters.AddWithValue("@Age", txtage.Text)
            cmd.Parameters.AddWithValue("@Address", txtaddress.Text)
            cmd.Parameters.AddWithValue("@Contact", txtcontactno.Text)

            cmd.ExecuteNonQuery()
            MsgBox("data inserted")
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

            Dim cmd As New MySqlCommand("SELECT * FROM `patient`", con)
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

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        loadData()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            cmd.CommandText = ""
            cmd.ExecuteNonQuery()
            MsgBox("deleted")
            loadData()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub PatientForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadData()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        DashboardForm.Show()
        Me.Hide()
    End Sub
End Class
