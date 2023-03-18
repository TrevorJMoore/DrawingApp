Imports WindowsApplication1

Public Class Polygons

    Implements DrawInterface

    Public Property Pen As Pen Implements DrawInterface.Pen

    Public Property Animate As Boolean Implements DrawInterface.Animate

    Dim m_image As Image
    Dim m_a As Point
    Dim m_size As Integer

    Public Sub New(i As Image, a As Point, Size As Integer)
        _Pen = New Pen(Color.Black, 1)
        m_image = i
        m_a = a
        m_size = Size

    End Sub



    Public Sub Draw(g As Graphics) Implements DrawInterface.Draw
        Dim points(3) As Point
        points(0) = m_a
        points(1) = New Point(m_a.X - 100, m_a.Y)
        points(2) = New Point(m_a.X - 150, m_a.Y + 100)
        points(3) = New Point(m_a.X + 50, m_a.Y + 100)
        g.DrawPolygon(Pen, points)
        If Animate Then
            m_a.Y += 1
        End If
    End Sub

End Class
