Public Class nGon

    Public Property Pen As Pen
    Public Property sides As Integer
    Public Property radius As Integer
    Dim m_image As Image
    Dim m_a As Point
    Dim m_b As Point
    Public Sub New(i As Image, a As Point, b As Point)
        Pen = Pens.Red
        m_image = i
        m_a = a
        m_b = b



    End Sub
    Public Sub Draw()
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
    End Sub























    'Public Property Pen As Pen
    'Dim m_image As Image
    'Dim m_a As Point
    'Dim m_b As Point
    'Dim points(100) As Point
    'Dim radius As Integer
    'Dim numSides As Integer
    'Dim count As Integer
    'Dim angle As Double
    'Public Sub New(i As Image, a As Point, b As Point, rad As Integer, pt As Integer)
    '    Pen = Pens.Red
    '    m_image = i
    '    m_a = a
    '    m_b = b
    '    radius = rad
    '    numSides = pt
    '    angle = 360 / pt
    '    For count = 1 To pt
    '        points(count) = New Point(m_a.X + Math.Cos(angle), m_a.Y + Math.Sin(angle))
    '        angle += angle
    '    Next
    '    'points(0) = New Point(m_a.X, m_a.Y)
    '    'points(1) = New Point(m_a.X - r, m_a.Y + r)
    '    'points(2) = New Point(m_a.X - (r / 2), m_a.Y + (2 * r))
    '    'points(3) = New Point(m_a.X + (r / 2), m_a.Y + (2 * r))
    '    'points(4) = New Point(m_a.X + r, m_a.Y + r)

    'End Sub
    'Public Sub Draw()
    '    Using g As Graphics = Graphics.FromImage(m_image)
    '        g.DrawPolygon(Pen, points)
    '    End Using
    'End Sub
End Class
