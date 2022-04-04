Public Class Pentagon
    Public Property xSpeed As Integer
    Public Property ySpeed As Integer
    Dim xOffset As Integer
    Dim yOffset As Integer
    Public Property Pen As Pen
    Dim m_image As Image
    Dim m_a As Point
    Dim m_b As Point
    Dim points(4) As Point
    Dim sideLength As Integer
    Public Sub New(i As Image, a As Point, b As Point, s As Integer)
        Pen = Pens.Red
        m_image = i
        m_a = a
        m_b = b
        sideLength = s
        points(0) = New Point(m_a.X, m_a.Y)
        points(1) = New Point(m_a.X - s, m_a.Y + s)
        points(2) = New Point(m_a.X - (s / 2), m_a.Y + (2 * s))
        points(3) = New Point(m_a.X + (s / 2), m_a.Y + (2 * s))
        points(4) = New Point(m_a.X + s, m_a.Y + s)

    End Sub
    Public Sub Draw()
        Using g As Graphics = Graphics.FromImage(m_image)
            g.DrawPolygon(Pen, points)
        End Using
    End Sub
End Class
