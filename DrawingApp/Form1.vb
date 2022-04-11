Public Class Form1
    Private m_Previous As System.Nullable(Of Point) = Nothing
    Dim m_shapes As New Collection
    Dim c As Color
    Dim b As Color
    Dim u As Color
    Dim w As Integer
    Dim type As String = "line"
    Private Sub picturebox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        m_Previous = e.Location
        picturebox1_MouseMove(sender, e)
    End Sub
    Sub Clear1()
        If PictureBox1.Image Is Nothing Then
            Dim bmp As New Bitmap(PictureBox1.Width, PictureBox1.Height)
            Using g As Graphics = Graphics.FromImage(bmp)
                g.Clear(Color.White)
            End Using
            PictureBox1.Image = bmp
        End If
    End Sub
    Private Sub picturebox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        If m_Previous IsNot Nothing Then
            Dim d As Object
            If type = "ellipse" Then
                d = New Circle(PictureBox1.Image, m_Previous, e.Location)
                d.Pen = New Pen(c, w)
                d.fill = CheckBox1.Checked
                d.color1 = bA.BackColor
                d.color2 = bB.BackColor
                d.w = TrackBar2.Value
                d.h = TrackBar3.Value
            End If
            If type = "heart" Then
                d = New heart(PictureBox1.Image, m_Previous, e.Location)
                d.Pen = New Pen(c, w)
                d.fill = CheckBox1.Checked
                d.color1 = bA.BackColor
                d.color2 = bB.BackColor
            End If
            If type = "nGon" Then
                d = New nGon(PictureBox1.Image, m_Previous, e.Location)
                d.sides = polySides.Value
                d.radius = polyRad.Value
                d.Pen = New Pen(c, w)
                d.fill = CheckBox1.Checked
                d.color1 = bA.BackColor
                d.color2 = bB.BackColor
            End If
            If type = "line" Then
                d = New Line(PictureBox1.Image, m_Previous, e.Location)
                d.Pen = New Pen(c, w)
                d.xspeed = xSpeedTrackBar.Value
            End If
            If type = "rectangle" Then
                d = New tryRectangle(PictureBox1.Image, m_Previous, e.Location)
                d.fill = CheckBox1.Checked
                d.color1 = bA.BackColor
                d.color2 = bB.BackColor
                d.xspeed = xSpeedTrackBar.Value
                d.xspeed = xSpeedTrackBar.Value
                d.ySpeed = ySpeed.Value
                d.Pen = New Pen(c, w)

            End If
            If type = "pie" Then
                d = New Pie(PictureBox1.Image, m_Previous, e.Location)
                d.Pen = New Pen(c, w)

            End If
            If type = "fillRect" Then
                d = New fillRect(PictureBox1.Image, m_Previous, e.Location)
                d.Pen = New Pen(c, w)
                d.xspeed = xSpeedTrackBar.Value
            End If
            If type = "arc" Then
                d = New arc(PictureBox1.Image, m_Previous, e.Location)
                d.Pen = New Pen(c, w)
            End If
            'If type = "pentagon" Then
            '    d = New Pentagon(picturebox1.Image, m_Previous, e.Location, TrackBar4.Value)
            '    d.Pen = New Pen(c, w)
            'End If
            If type = "picture" Then
                d = New PBox(PictureBox1.Image, m_Previous, e.Location)
                d.w = TrackBar2.Value
                d.h = TrackBar3.Value
                d.picture = PictureBox4.Image
            End If
            m_shapes.Add(d)
            PictureBox1.Invalidate()
            m_Previous = e.Location
        End If
    End Sub
    Private Sub picturebox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        m_Previous = Nothing
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Clear1()
        TrackBar1.Visible = False
        clearPanel.Visible = False
        xSpeedTrackBar.Visible = False
        speedLabel.Visible = False
        ySpeed.Visible = False
        ySpeedLabel.Visible = False
        polySides.Value = 3
        polyRad.Value = 100
    End Sub
    Private Sub picturebox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        Clear1()
        For Each s As Object In m_shapes
            s.Draw()
        Next
        If (autoRefreshCB.Checked) Then
            Refresh()
        End If
    End Sub
    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        w = TrackBar1.Value
        PictureBox2.BackColor = sender.backcolor
    End Sub
    Private Sub clear()
        MsgBox("Clear Drawing?")
        If PictureBox1.Image IsNot Nothing Then
            Dim bmp As New Bitmap(PictureBox1.Width, PictureBox1.Height)
            Using g As Graphics = Graphics.FromImage(bmp)
                g.Clear(Color.White)
            End Using
            PictureBox1.Image = bmp
        End If
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        PictureBox1.Enabled = False
        toolsPanel.Enabled = False
        clearPanel.Visible = True
    End Sub
    Private Sub Button13_Click(sender As Object, e As EventArgs)
        b = PictureBox2.BackColor
        PictureBox1.BackColor = b
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        SaveFileDialog1.ShowDialog()
    End Sub
    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button85.Click, Button84.Click, Button82.Click, Button81.Click, Button79.Click, Button78.Click, Button76.Click, Button75.Click, Button73.Click, Button72.Click, Button30.Click, Button29.Click, Button27.Click, Button26.Click, Button24.Click, Button23.Click, Button17.Click, Button16.Click
        'ColorDialog1.ShowDialog()
        'c = ColorDialog1.Color
        'Button1.BackColor = c
        'PictureBox2.BackColor = sender.backcolor
        c = sender.backcolor
        PictureBox2.BackColor = sender.backcolor
    End Sub
    Private Sub Button34_Click(sender As Object, e As EventArgs) Handles Button34.Click
        If TrackBar1.Visible = False Then
            TrackBar1.Visible = True
        ElseIf TrackBar1.Visible = True Then
            TrackBar1.Visible = False
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        PictureBox1.Enabled = True
        toolsPanel.Enabled = True
        clearPanel.Visible = False
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim bmp As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.Clear(Color.White)
        End Using
        PictureBox1.Image = bmp
        PictureBox1.Enabled = True
        toolsPanel.Enabled = True
        clearPanel.Visible = False
    End Sub
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        c = sender.backcolor
        PictureBox2.BackColor = sender.backcolor
    End Sub

    Private Sub changeBack_Click(sender As Object, e As EventArgs) Handles changeBack.Click
        OpenFileDialog1.ShowDialog()
    End Sub
    Private Sub PictureTextBox_TextChanged(sender As Object, e As EventArgs) Handles PictureTextBox.TextChanged
        If IO.File.Exists(PictureTextBox.Text) Then
            PictureBox1.Load(PictureTextBox.Text)
        End If
    End Sub
    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        PictureTextBox.Text = OpenFileDialog1.FileName
    End Sub
    Private Sub Button71_Click(sender As Object, e As EventArgs) Handles Button71.Click
        type = "line"
    End Sub
    Private Sub Button65_Click(sender As Object, e As EventArgs) Handles Button65.Click
        type = "ellipse"
        widthHeightPan.Visible = True
        polyPan.Visible = False
    End Sub
    Private Sub Button53_Click(sender As Object, e As EventArgs) Handles Button53.Click
        type = "pie"
    End Sub
    Private Sub Button59_Click(sender As Object, e As EventArgs) Handles Button59.Click
        type = "arc"
    End Sub
    Private Sub Button70_Click(sender As Object, e As EventArgs)
        type = "fillRect"
    End Sub
    Private Sub rect_Click(sender As Object, e As EventArgs) Handles rect.Click
        type = "rectangle"
    End Sub
    Private Sub pentagon_Click(sender As Object, e As EventArgs) Handles pentagon.Click
        type = "nGon"
        widthHeightPan.Visible = False
        polyPan.Visible = True
    End Sub
    Private Sub TrackBar3_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        w = TrackBar3.Value
    End Sub
    Private Sub SaveFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        PictureBox1.Image.Save(SaveFileDialog1.FileName)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ColorDialog1.ShowDialog()
        c = ColorDialog1.Color
        Button1.BackColor = c
    End Sub
    Private Sub Button63_Click(sender As Object, e As EventArgs)
        type = "star"
    End Sub
    Private Sub nGon_Click(sender As Object, e As EventArgs)
        type = "ngon"
    End Sub
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        type = "picture"
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        OpenFileDialog2.ShowDialog()
    End Sub
    Private Sub OpenFileDialog2_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog2.FileOk
        PictureBox4.Load(OpenFileDialog2.FileName)
    End Sub
    Private Sub toolsPanel_Paint(sender As Object, e As PaintEventArgs) Handles toolsPanel.Paint
    End Sub
    Private Sub bA_Click(sender As Object, e As EventArgs) Handles bA.Click
        ColorDialog1.ShowDialog()
        c = ColorDialog1.Color
        sender.BackColor = c
    End Sub
    Private Sub bB_Click(sender As Object, e As EventArgs) Handles bB.Click
        ColorDialog1.ShowDialog()
        c = ColorDialog1.Color
        sender.BackColor = c
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        type = "heart"
    End Sub
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If xSpeedTrackBar.Visible = True Then
            xSpeedTrackBar.Visible = False
            speedLabel.Visible = False
            ySpeed.Visible = False
            ySpeedLabel.Visible = False
        ElseIf xSpeedTrackBar.Visible = False Then
            xSpeedTrackBar.Visible = True
            speedLabel.Visible = True
            ySpeed.Visible = True
            ySpeedLabel.Visible = True
        End If
    End Sub
    Private Sub xSpeedTrackBar_Scroll(sender As Object, e As EventArgs) Handles xSpeedTrackBar.Scroll
    End Sub
    Private Sub TrackBar3_Scroll_1(sender As Object, e As EventArgs) Handles TrackBar3.Scroll
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
    End Sub
    Private Sub Button9_Click(sender As Object, e As EventArgs)
        Dim d As Object
        ColorDialog1.ShowDialog()
        u = ColorDialog1.Color
        Button1.BackColor = u
    End Sub
End Class
