Public Class heart
    Public Property xSpeed As Integer
    Public Property ySpeed As Integer
    Dim xOffset As Integer
    Dim yOffset As Integer
    Public Property Pen As Pen
    Dim m_image As Image
    Dim m_a As Point
    Dim m_b As Point
    Public Property w As Integer
    Public Property h As Integer
    Dim points(2) As Point
    Public Sub New(i As Image, a As Point, b As Point)
        Pen = Pens.Red
        m_image = i
        m_a = a
        m_b = b
        points(0) = New Point(m_a.X - 77, m_a.Y + 55)
        points(1) = New Point(m_a.X + 10, m_a.Y + 175)
        points(2) = New Point(m_a.X + 100, m_a.Y + 56)
    End Sub
    Public Property fill As Boolean
    Public Property color1 As Color
    Public Property color2 As Color

    Public Sub Draw()
        Using g As Graphics = Graphics.FromImage(m_image)
            If fill Then
                'Dim lingrBrush As Drawing.Drawing2D.LinearGradientBrush
                'lingrBrush = New Drawing.Drawing2D.LinearGradientBrush(
                '    New Point(0, 10),
                '    New Point(100, 10),
                '    color1,
                '    color2)
                'g.FillEllipse(lingrBrush, m_a.X, m_a.Y, 100, 100)
                'g.FillEllipse(lingrBrush, m_a.X + 100, m_a.Y, 100, 100)
                ''points(0) = New Point(m_a.X, m_a.Y)
                ''points(1) = New Point(m_a.X, m_a.Y + 50)
                ''points(2) = New Point(m_a.X + 50, m_a.Y)
                Dim lingrBrush As Drawing.Drawing2D.LinearGradientBrush
                lingrBrush = New Drawing.Drawing2D.LinearGradientBrush(
                    New Point(0, 10),
                    New Point(100, 10),
                    color1,
                    color2)
                'g.DrawArc(Pen, m_a.X, m_a.Y, 100, 100, -140, 150)
                'g.DrawArc(Pen, m_a.X - 77, m_a.Y, 100, 100, -185, 145)
                g.FillPie(lingrBrush, m_a.X - 77, m_a.Y, 100, 100, -185, 145)
                g.FillPie(lingrBrush, m_a.X, m_a.Y, 100, 100, -140, 150)
                'g.FillEllipse(lingrBrush, m_a.X, m_a.Y, 100, 100)
                'g.FillEllipse(lingrBrush, m_a.X - 77, m_a.Y, 100, 100)
                g.FillPolygon(lingrBrush, points)

                g.FillRectangle(lingrBrush, m_a.X - 65, m_a.Y + 18, 145, 50)
                g.FillRectangle(lingrBrush, m_a.X - 75, m_a.Y + 40, 40, 20)

            Else
                'g.DrawEllipse(Pen, m_a.X, m_a.Y, 100, 100)
                'g.DrawEllipse(Pen, m_a.X + 100, m_a.Y, 100, 100)
                g.DrawArc(Pen, m_a.X, m_a.Y, 100, 100, -140, 150)
                g.DrawArc(Pen, m_a.X - 77, m_a.Y, 100, 100, -185, 145)
                g.DrawLine(Pen, points(0), points(1))
                g.DrawLine(Pen, points(1), points(2))

                ' g.DrawPolygon(Pen, points)

            End If
        End Using
    End Sub
End Class
