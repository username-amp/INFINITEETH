Imports System.Diagnostics.Eventing.Reader

Public Class Main


    Sub switchpanel(ByVal panel As Form)
        Guna2Panel2.Controls.Clear()
        panel.TopLevel = False
        Guna2Panel2.Controls.Add(panel)
        panel.Show()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        PatientForm.Show()
        Me.Hide()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs)
        Me.Hide()
        Form1.Show()

    End Sub

    Private Sub DashboardForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        switchpanel(Dashboard)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)
        Me.Hide()
        AppoinmentForm.Show()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        Me.Hide()
        DoctorForm.Show()
    End Sub

    Private Sub btnSession_Click(sender As Object, e As EventArgs)
        Me.Hide()
        SessionForm.Show()
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        switchpanel(PatientForm)
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        switchpanel(DoctorForm)
        Dashboard.CountAndDisplayPatients()
        Dashboard.CountAndDisplayDentist()
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        switchpanel(AppoinmentForm)
    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        switchpanel(SessionForm)
    End Sub

    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs) Handles Guna2Button6.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        switchpanel(Dashboard)
        Dashboard.LoadUpcomingAppointments()
        Dashboard.CountAppointmentsByMonth()
        Dashboard.CountAndDisplayPatients()
        Dashboard.CountAndDisplayDentist()
        Dashboard.FetchAndDisplayWeather()




    End Sub

    Private Sub Guna2Button8_Click(sender As Object, e As EventArgs) Handles Guna2Button8.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Guna2Button7_Click(sender As Object, e As EventArgs) Handles Guna2Button7.Click
        Me.Close()
    End Sub
End Class