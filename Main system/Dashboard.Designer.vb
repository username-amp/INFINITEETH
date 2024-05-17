<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Dashboard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea13 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend13 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series13 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim DataGridViewCellStyle49 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle50 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle51 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle52 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Guna2Elipse1 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2GradientPanel1 = New Guna.UI2.WinForms.Guna2GradientPanel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New Guna.UI2.WinForms.Guna2CircleProgressBar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Guna2GradientPanel2 = New Guna.UI2.WinForms.Guna2GradientPanel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ProgressBar2 = New Guna.UI2.WinForms.Guna2CircleProgressBar()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Guna2GradientPanel3 = New Guna.UI2.WinForms.Guna2GradientPanel()
        Me.PictureBox1 = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Guna2GradientPanel4 = New Guna.UI2.WinForms.Guna2GradientPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Guna2GradientPanel7 = New Guna.UI2.WinForms.Guna2GradientPanel()
        Me.panel7 = New Guna.UI2.WinForms.Guna2GradientPanel()
        Me.DataGridView1 = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Guna2GradientPanel1.SuspendLayout()
        Me.ProgressBar1.SuspendLayout()
        Me.Guna2GradientPanel2.SuspendLayout()
        Me.ProgressBar2.SuspendLayout()
        Me.Guna2GradientPanel3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2GradientPanel4.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2GradientPanel7.SuspendLayout()
        Me.panel7.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Guna2Elipse1
        '
        Me.Guna2Elipse1.TargetControl = Me
        '
        'Guna2GradientPanel1
        '
        Me.Guna2GradientPanel1.Controls.Add(Me.Label6)
        Me.Guna2GradientPanel1.Controls.Add(Me.ProgressBar1)
        Me.Guna2GradientPanel1.Location = New System.Drawing.Point(9, 11)
        Me.Guna2GradientPanel1.Name = "Guna2GradientPanel1"
        Me.Guna2GradientPanel1.Size = New System.Drawing.Size(199, 139)
        Me.Guna2GradientPanel1.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(39, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(121, 24)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Total Patients"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Animated = True
        Me.ProgressBar1.Controls.Add(Me.Label3)
        Me.ProgressBar1.FillColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.ProgressBar1.FillThickness = 8
        Me.ProgressBar1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.ProgressBar1.ForeColor = System.Drawing.Color.White
        Me.ProgressBar1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.ProgressBar1.Location = New System.Drawing.Point(53, 34)
        Me.ProgressBar1.Minimum = 0
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.ProgressColor = System.Drawing.Color.Yellow
        Me.ProgressBar1.ProgressColor2 = System.Drawing.Color.Red
        Me.ProgressBar1.ProgressThickness = 9
        Me.ProgressBar1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        Me.ProgressBar1.Size = New System.Drawing.Size(86, 86)
        Me.ProgressBar1.TabIndex = 0
        Me.ProgressBar1.Text = "Guna2CircleProgressBar1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(25, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 32)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "10"
        '
        'Guna2GradientPanel2
        '
        Me.Guna2GradientPanel2.Controls.Add(Me.Label7)
        Me.Guna2GradientPanel2.Controls.Add(Me.ProgressBar2)
        Me.Guna2GradientPanel2.Location = New System.Drawing.Point(214, 11)
        Me.Guna2GradientPanel2.Name = "Guna2GradientPanel2"
        Me.Guna2GradientPanel2.Size = New System.Drawing.Size(199, 139)
        Me.Guna2GradientPanel2.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(43, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 24)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Total Dentist"
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Animated = True
        Me.ProgressBar2.Controls.Add(Me.Label4)
        Me.ProgressBar2.FillColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.ProgressBar2.FillThickness = 8
        Me.ProgressBar2.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.ProgressBar2.ForeColor = System.Drawing.Color.White
        Me.ProgressBar2.Location = New System.Drawing.Point(55, 34)
        Me.ProgressBar2.Minimum = 0
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.ProgressColor = System.Drawing.Color.Yellow
        Me.ProgressBar2.ProgressColor2 = System.Drawing.Color.Orange
        Me.ProgressBar2.ProgressThickness = 9
        Me.ProgressBar2.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        Me.ProgressBar2.Size = New System.Drawing.Size(86, 86)
        Me.ProgressBar2.TabIndex = 1
        Me.ProgressBar2.Text = "Guna2CircleProgressBar2"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(25, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 32)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "10"
        '
        'Guna2GradientPanel3
        '
        Me.Guna2GradientPanel3.Controls.Add(Me.PictureBox1)
        Me.Guna2GradientPanel3.Controls.Add(Me.Label10)
        Me.Guna2GradientPanel3.Controls.Add(Me.Label9)
        Me.Guna2GradientPanel3.Controls.Add(Me.Label8)
        Me.Guna2GradientPanel3.Controls.Add(Me.Label2)
        Me.Guna2GradientPanel3.Location = New System.Drawing.Point(422, 11)
        Me.Guna2GradientPanel3.Name = "Guna2GradientPanel3"
        Me.Guna2GradientPanel3.Size = New System.Drawing.Size(199, 139)
        Me.Guna2GradientPanel3.TabIndex = 2
        '
        'PictureBox1
        '
        Me.PictureBox1.ImageRotate = 0!
        Me.PictureBox1.Location = New System.Drawing.Point(125, 65)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 54)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(14, 104)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 13)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Label10"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 83)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Label9"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 59)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Label8"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 30)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Date Today"
        '
        'Guna2GradientPanel4
        '
        Me.Guna2GradientPanel4.AutoScroll = True
        Me.Guna2GradientPanel4.BackColor = System.Drawing.Color.White
        Me.Guna2GradientPanel4.Controls.Add(Me.Guna2GradientPanel2)
        Me.Guna2GradientPanel4.Controls.Add(Me.Guna2GradientPanel1)
        Me.Guna2GradientPanel4.Controls.Add(Me.Guna2GradientPanel3)
        Me.Guna2GradientPanel4.Location = New System.Drawing.Point(18, 45)
        Me.Guna2GradientPanel4.Name = "Guna2GradientPanel4"
        Me.Guna2GradientPanel4.Size = New System.Drawing.Size(630, 160)
        Me.Guna2GradientPanel4.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Kristen ITC", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(154, 33)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Dashboard"
        '
        'Chart1
        '
        ChartArea13.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea13)
        Me.Chart1.Cursor = System.Windows.Forms.Cursors.Default
        Legend13.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend13)
        Me.Chart1.Location = New System.Drawing.Point(18, 13)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel
        Series13.ChartArea = "ChartArea1"
        Series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineRange
        Series13.Legend = "Legend1"
        Series13.Name = "Series1"
        Series13.YValuesPerPoint = 6
        Me.Chart1.Series.Add(Series13)
        Me.Chart1.Size = New System.Drawing.Size(595, 377)
        Me.Chart1.TabIndex = 5
        Me.Chart1.Text = "Chart1"
        '
        'Guna2GradientPanel7
        '
        Me.Guna2GradientPanel7.BackColor = System.Drawing.Color.White
        Me.Guna2GradientPanel7.Controls.Add(Me.Chart1)
        Me.Guna2GradientPanel7.Location = New System.Drawing.Point(18, 211)
        Me.Guna2GradientPanel7.Name = "Guna2GradientPanel7"
        Me.Guna2GradientPanel7.Size = New System.Drawing.Size(630, 393)
        Me.Guna2GradientPanel7.TabIndex = 6
        '
        'panel7
        '
        Me.panel7.BackColor = System.Drawing.Color.White
        Me.panel7.Controls.Add(Me.DataGridView1)
        Me.panel7.Controls.Add(Me.Label5)
        Me.panel7.Location = New System.Drawing.Point(665, 45)
        Me.panel7.Name = "panel7"
        Me.panel7.Size = New System.Drawing.Size(260, 559)
        Me.panel7.TabIndex = 7
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToResizeRows = False
        DataGridViewCellStyle49.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle49.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle49.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle49.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle49.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle49
        DataGridViewCellStyle50.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle50.BackColor = System.Drawing.Color.Navy
        DataGridViewCellStyle50.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle50.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle50.SelectionBackColor = System.Drawing.Color.Navy
        DataGridViewCellStyle50.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle50.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle50
        Me.DataGridView1.ColumnHeadersHeight = 50
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle51.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle51.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle51.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle51.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle51.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle51.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle51.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle51
        Me.DataGridView1.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DataGridView1.Location = New System.Drawing.Point(10, 45)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle52.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle52.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle52.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle52.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle52.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle52.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle52.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle52
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.Height = 50
        Me.DataGridView1.Size = New System.Drawing.Size(240, 501)
        Me.DataGridView1.TabIndex = 1
        Me.DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.DataGridView1.ThemeStyle.AlternatingRowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.DataGridView1.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.DataGridView1.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DataGridView1.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.Navy
        Me.DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DataGridView1.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridView1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.DataGridView1.ThemeStyle.HeaderStyle.Height = 50
        Me.DataGridView1.ThemeStyle.ReadOnly = True
        Me.DataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.DataGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DataGridView1.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.White
        Me.DataGridView1.ThemeStyle.RowsStyle.Height = 50
        Me.DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(41, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(179, 20)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Upcoming Appoinments"
        '
        'Dashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(937, 634)
        Me.Controls.Add(Me.panel7)
        Me.Controls.Add(Me.Guna2GradientPanel7)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Guna2GradientPanel4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Dashboard"
        Me.Text = "Dashboard"
        Me.Guna2GradientPanel1.ResumeLayout(False)
        Me.Guna2GradientPanel1.PerformLayout()
        Me.ProgressBar1.ResumeLayout(False)
        Me.ProgressBar1.PerformLayout()
        Me.Guna2GradientPanel2.ResumeLayout(False)
        Me.Guna2GradientPanel2.PerformLayout()
        Me.ProgressBar2.ResumeLayout(False)
        Me.ProgressBar2.PerformLayout()
        Me.Guna2GradientPanel3.ResumeLayout(False)
        Me.Guna2GradientPanel3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2GradientPanel4.ResumeLayout(False)
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2GradientPanel7.ResumeLayout(False)
        Me.panel7.ResumeLayout(False)
        Me.panel7.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Guna2Elipse1 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2GradientPanel1 As Guna.UI2.WinForms.Guna2GradientPanel
    Friend WithEvents Guna2GradientPanel4 As Guna.UI2.WinForms.Guna2GradientPanel
    Friend WithEvents Guna2GradientPanel3 As Guna.UI2.WinForms.Guna2GradientPanel
    Friend WithEvents Guna2GradientPanel2 As Guna.UI2.WinForms.Guna2GradientPanel
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents Label1 As Label
    Friend WithEvents Guna2GradientPanel7 As Guna.UI2.WinForms.Guna2GradientPanel
    Friend WithEvents panel7 As Guna.UI2.WinForms.Guna2GradientPanel
    Friend WithEvents ProgressBar1 As Guna.UI2.WinForms.Guna2CircleProgressBar
    Friend WithEvents ProgressBar2 As Guna.UI2.WinForms.Guna2CircleProgressBar
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents PictureBox1 As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents DataGridView1 As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents Guna2DataGridViewStyler1 As Guna.UI2.WinForms.Guna2DataGridViewStyler
End Class
