Public Class Form1
    Private m_Previous As System.Nullable(Of Point) = Nothing
    Dim m_shapes As New Collection
    Dim c As Color
    Dim b As Color
    Dim w As Integer
    Dim type As String = "line"
    Private Sub pictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        m_Previous = e.Location
        pictureBox1_MouseMove(sender, e)
    End Sub

    Private Sub pictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        If m_Previous IsNot Nothing Then
            Dim d As Object
            If type = "ellipse" Then
                d = New Circle(PictureBox1.Image, m_Previous, e.Location)
                d.Pen = New Pen(c, w)
            End If
            If type = "ngon" Then
                d = New nGon(PictureBox1.Image, m_Previous, e.Location)
                d.sides = TrackBar2.Value
                d.radius = TrackBar3.Value
                d.Pen = New Pen(c, w)
            End If
            If type = "line" Then
                d = New Line(PictureBox1.Image, m_Previous, e.Location)
                d.Pen = New Pen(c, w)
            End If
            If type = "rectangle" Then
                d = New tryRectangle(PictureBox1.Image, m_Previous, e.Location)
                d.Pen = New Pen(c, w)
            End If
            If type = "pie" Then
                d = New Pie(PictureBox1.Image, m_Previous, e.Location)
                d.Pen = New Pen(c, w)
            End If
            If type = "fillRect" Then
                d = New fillRect(PictureBox1.Image, m_Previous, e.Location)
                d.Pen = New Pen(c, w)
            End If
            If type = "arc" Then
                d = New arc(PictureBox1.Image, m_Previous, e.Location)
                d.Pen = New Pen(c, w)
            End If
            If type = "pentagon" Then
                d = New Pentagon(PictureBox1.Image, m_Previous, e.Location, TrackBar3.Value)
                d.Pen = New Pen(c, w)
            End If
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
    Private Sub pictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        m_Previous = Nothing
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        If PictureBox1.Image Is Nothing Then
            Dim bmp As New Bitmap(PictureBox1.Width, PictureBox1.Height)
            Using g As Graphics = Graphics.FromImage(bmp)
                g.Clear(Color.White)
            End Using
            PictureBox1.Image = bmp
        End If
        TrackBar1.Visible = False
        clearPanel.Visible = False
    End Sub
    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        For Each s As Object In m_shapes
            s.Draw()
        Next
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
    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        b = PictureBox2.BackColor
        PictureBox1.BackColor = b
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        SaveFileDialog1.ShowDialog()
    End Sub
    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button85.Click, Button84.Click, Button83.Click, Button82.Click, Button81.Click, Button80.Click, Button79.Click, Button78.Click, Button77.Click, Button76.Click, Button75.Click, Button74.Click, Button73.Click, Button72.Click, Button30.Click, Button29.Click, Button28.Click, Button27.Click, Button26.Click, Button25.Click, Button24.Click, Button23.Click, Button22.Click, Button21.Click, Button20.Click, Button19.Click, Button18.Click, Button17.Click, Button16.Click, Button15.Click
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
    End Sub

    Private Sub Button53_Click(sender As Object, e As EventArgs) Handles Button53.Click
        type = "pie"
    End Sub

    Private Sub Button59_Click(sender As Object, e As EventArgs) Handles Button59.Click
        type = "arc"
    End Sub

    Private Sub Button70_Click(sender As Object, e As EventArgs) Handles Button70.Click
        type = "fillRect"
    End Sub

    Private Sub rect_Click(sender As Object, e As EventArgs) Handles rect.Click
        type = "rectangle"
    End Sub

    Private Sub pentagon_Click(sender As Object, e As EventArgs) Handles pentagon.Click
        type = "pentagon"
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

    Private Sub Button63_Click(sender As Object, e As EventArgs) Handles Button63.Click
        type = "star"
    End Sub

    Private Sub nGon_Click(sender As Object, e As EventArgs) Handles nGon.Click
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
End Class
