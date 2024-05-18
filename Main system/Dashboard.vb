Imports System.Globalization
Imports System.Net
Imports System.Windows.Forms.DataVisualization.Charting
Imports MySql.Data.MySqlClient
Imports Newtonsoft.Json.Linq

Public Class Dashboard
    Dim con As MySqlConnection = New MySqlConnection("server=localhost;username=root;password=;database=infiniteeth")
    Dim cmd As MySqlCommand
    Private Const MAX_PATIENTS As Integer = 100
    Private Const MAX_DENTISTS As Integer = 50
    Private Const API_KEY As String = "331aa198ddd87a127ed0d43f5be3a6c0"
    Private Const CITY_NAME As String = "Rizal, PH"
    Private Const API_URL As String = "http://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}"
    Private weatherImages As New Dictionary(Of String, Image)()

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadWeatherImages()
            CountAndDisplayPatients()
            CountAndDisplayDentist()
            Label2.Text = DateTime.Now.ToString("MMMM dd, yyyy")
            FetchAndDisplayWeather()
            LoadUpcomingAppointments()
            CountAppointmentsByMonth()
        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message)
        End Try
    End Sub


    Private Sub LoadWeatherImages()
        weatherImages.Add("Rain", Image.FromFile("C:\Users\Lenovo\Downloads\icons8-heavy-rain.gif"))
        weatherImages.Add("Clear", Image.FromFile("C:\Users\Lenovo\Downloads\icons8-summer.gif"))
        weatherImages.Add("Clouds", Image.FromFile("C:\Users\Lenovo\Downloads\icons8-clouds.gif"))
        weatherImages.Add("broken clouds", Image.FromFile("C:\Users\Lenovo\Downloads\icons8-error-cloud.gif"))
        weatherImages.Add("light rain", Image.FromFile("C:\Users\Lenovo\Downloads\icons8-light-rain.gif"))
    End Sub

    Private Sub CountAndDisplayPatients()
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            Dim query As String = "SELECT COUNT(*) FROM patient"
            cmd = New MySqlCommand(query, con)
            Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())

            Label3.Text = count.ToString()
            ProgressBar1.Value = (count / MAX_PATIENTS) * 100
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub CountAndDisplayDentist()
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            Dim query As String = "SELECT COUNT(*) FROM dentist"
            cmd = New MySqlCommand(query, con)
            Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())

            Label4.Text = count.ToString()
            ProgressBar2.Value = (count / MAX_DENTISTS) * 100
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub FetchAndDisplayWeather()
        Try
            Dim url As String = String.Format(API_URL, CITY_NAME, API_KEY)
            Dim client As New WebClient()
            Dim response As String = client.DownloadString(url)

            Dim json As JObject = JObject.Parse(response)

            Dim temperatureKelvin As Double = json.SelectToken("main.temp")
            Dim temperatureCelsius As Double = temperatureKelvin - 273.15

            Dim temperature As Double = json.SelectToken("main.temp")
            Dim humidity As Integer = json.SelectToken("main.humidity")
            Dim weatherDescription As String = json.SelectToken("weather[0].description")

            Label8.Text = "Temperature: " & Math.Round(temperatureCelsius, 2).ToString() & "°C"
            Label9.Text = "Humidity: " & humidity.ToString() & "%"
            Label10.Text = "Weather: " & weatherDescription

            If weatherImages.ContainsKey(weatherDescription) Then
                PictureBox1.Image = weatherImages(weatherDescription)
            Else
                PictureBox1.Image = Nothing
            End If

        Catch ex As Exception
            MsgBox("Error fetching weather: " & ex.Message)
        End Try
    End Sub

    Public Sub LoadUpcomingAppointments()
        Dim startDate As Date = Date.Today
        Dim endDate As Date = startDate.AddDays(3)
        Dim query As String = "SELECT Client_Name, Day FROM pendingappointments WHERE Day >= @StartDate AND Day <= @EndDate"

        Try
            Using con As New MySqlConnection("server=localhost;username=root;password=;database=infiniteeth")
                con.Open()

                Using command As New MySqlCommand(query, con)
                    command.Parameters.AddWithValue("@StartDate", startDate)
                    command.Parameters.AddWithValue("@EndDate", endDate)

                    Dim adapter As New MySqlDataAdapter(command)
                    Dim dataTable As New DataTable()
                    adapter.Fill(dataTable)
                    DataGridView1.DataSource = dataTable
                    DataGridView1.ColumnHeadersVisible = False
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading upcoming appointments: " & ex.Message)
        End Try
    End Sub


    Private Sub CountAppointmentsByMonth()
        Dim query As String = "SELECT MONTH(Day) AS Month, COUNT(*) AS AppointmentsCount FROM pendingappointments GROUP BY MONTH(Day)"

        Try
            Using con As New MySqlConnection("server=localhost;username=root;password=;database=infiniteeth")
                con.Open()

                Using command As New MySqlCommand(query, con)
                    Dim adapter As New MySqlDataAdapter(command)
                    Dim dataTable As New DataTable()
                    adapter.Fill(dataTable)

                    Dim chartData As New List(Of KeyValuePair(Of String, Integer))()

                    For Each row As DataRow In dataTable.Rows
                        Dim monthNumber As Integer = Convert.ToInt32(row("Month"))
                        Dim monthName As String = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(monthNumber)
                        Dim count As Integer = Convert.ToInt32(row("AppointmentsCount"))
                        chartData.Add(New KeyValuePair(Of String, Integer)(monthName, count))
                    Next

                    Chart1.Series.Clear()
                    Chart1.Series.Add("Appointments")
                    Chart1.Series("Appointments").Points.DataBind(chartData, "Key", "Value", "")

                    Chart1.Series("Appointments").ChartType = SeriesChartType.Column

                    Chart1.ChartAreas(0).AxisX.MajorGrid.Enabled = False
                    Chart1.ChartAreas(0).AxisY.MajorGrid.Enabled = False

                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error counting appointments by month: " & ex.Message)
        End Try
    End Sub





End Class