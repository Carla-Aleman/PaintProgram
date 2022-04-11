Public Class nGon
    Public Property xSpeed As Integer
    Public Property ySpeed As Integer
    Dim xOffset As Integer
    Dim yOffset As Integer
    Public Property Pen As Pen
    Public Property sides As Integer
    Public Property radius As Integer
    Dim m_image As Image
    Dim m_a As Point
    Dim m_b As Point
    Public Property fill As Boolean
    Public Property color1 As Color
    Public Property color2 As Color

    Public Sub New(i As Image, a As Point, b As Point)
        Pen = Pens.Red
        m_image = i
        m_a = a
        m_b = b
    End Sub
    Public Sub Draw()
        Dim lingrBrush As Drawing.Drawing2D.LinearGradientBrush
        lingrBrush = New Drawing.Drawing2D.LinearGradientBrush(
                    New Point(0, 10),
                    New Point(100, 10),
                    color1,
                    color2)
        If fill Then
            Using g As Graphics = Graphics.FromImage(m_image)

                Dim points(sides - 1) As Point
                For index = 0 To sides - 1
                    Dim x As Integer
                    Dim y As Integer
                    y = Math.Sin(index * 2 * Math.PI / sides) * radius
                    x = Math.Cos(index * 2 * Math.PI / sides) * radius
                    points(index) = New Point(m_a.X + x, m_a.Y + y)
                Next
                g.FillPolygon(lingrBrush, points)
            End Using
        Else
            Using g As Graphics = Graphics.FromImage(m_image)

                Dim points(sides - 1) As Point
                For index = 0 To sides - 1
                    Dim x As Integer
                    Dim y As Integer
                    y = Math.Sin(index * 2 * Math.PI / sides) * radius
                    x = Math.Cos(index * 2 * Math.PI / sides) * radius
                    points(index) = New Point(m_a.X + x, m_a.Y + y)
                Next
                g.DrawPolygon(Pen, points)
            End Using
        End If
    End Sub
End Class
