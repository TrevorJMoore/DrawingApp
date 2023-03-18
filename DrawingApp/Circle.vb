
Imports WindowsApplication1

Public Class Circle
    Implements DrawInterface

    Public Property Pen As Pen Implements DrawInterface.Pen
    Public Property Animate As Boolean Implements DrawInterface.Animate

    Dim m_image As Image
    Dim m_a As Point
    Dim m_size As Integer ' Width
    Dim m_height As Integer


    'Constructor
    Public Sub New(i As Image, a As Point, Size As Integer)
        _Pen = New Pen(Color.Black, 1)
        m_image = i
        m_a = a
        m_size = Size 'Width
        m_height = Size
    End Sub



    Public Sub Draw(g As Graphics) Implements DrawInterface.Draw
        'Static shift As Integer
        g.DrawEllipse(Pen, m_a.X, m_a.Y, m_size, m_height)
        If Animate Then
            m_a.Y += 1
        End If
        'g.DrawEllipse(Pen, m_a.X, m_a.Y + shift, m_size, m_height)
        'shift = (shift + 1) Mod 100

    End Sub
End Class
