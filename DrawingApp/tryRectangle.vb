Public Class tryRectangle
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
    Public Property color1 As Color
    Public Property color2 As Color

    Public Sub New(i As Image, a As Point, b As Point)
        Pen = Pens.Red
        m_image = i
        m_a = a
        m_b = b
    End Sub
    Public Property fill As Boolean

    Public Sub Draw()
        Using g As Graphics = Graphics.FromImage(m_image)
            xOffset += xSpeed
            yOffset += ySpeed
            If fill Then
                Dim lingrBrush As Drawing.Drawing2D.LinearGradientBrush
                lingrBrush = New Drawing.Drawing2D.LinearGradientBrush(
                    New Point(0, 10),
                    New Point(100, 10),
                    color1,
                    color2)
                g.FillRectangle(lingrBrush, m_a.X + xOffset, m_a.Y + yOffset, 100, 100)
            Else
                g.DrawRectangle(Pen, m_a.X + xOffset, m_a.Y + yOffset, 100, 100)
            End If
        End Using
    End Sub
End Class
