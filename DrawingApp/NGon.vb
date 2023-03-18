Imports WindowsApplication1

Public Class NGon
    Implements DrawInterface

    Public Property Pen As Pen Implements DrawInterface.Pen
    Public Property Sides As Integer
    Public Property SideLength As Integer

    Public Property Animate As Boolean Implements DrawInterface.Animate
    'Public Property Brush As Brush


    Dim m_image As Image
    Dim m_a As Point


    Public Sub New(i As Image, a As Point)
        _Pen = New Pen(Color.Black, 1)
        m_image = i
        m_a = a

    End Sub



    Public Sub Draw(g As Graphics) Implements DrawInterface.Draw
        Dim points(Sides - 1) As Point
        For t = 0 To Sides - 1
            points(t) = New Point(m_a.X + Math.Cos(t * 2 * Math.PI / Sides) * SideLength, m_a.Y + Math.Sin(t * 2 * Math.PI / Sides) * SideLength)
        Next
        g.DrawPolygon(Pen, points)
        'g.FillPolygon(Brush, points)
        If Animate Then
            m_a.Y += 1
        End If
    End Sub
End Class
