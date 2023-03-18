Imports WindowsApplication1

Public Class Icon
    Implements DrawInterface

    Public Property Pen As Pen Implements DrawInterface.Pen
    Public Property Animate As Boolean Implements DrawInterface.Animate

    Dim m_image As Image
    Dim m_a As Point
    Dim m_size As Integer
    Dim m_height As Integer
    Dim m_iconIm As Drawing.Image

    'Constructor
    Public Sub New(i As Image, a As Point, size As Integer, height As Integer, image As Drawing.Image)
        _Pen = New Pen(Color.Black, 1)
        m_image = i
        m_a = a
        m_size = size
        m_height = height
        m_iconIm = image
    End Sub



    Public Sub Draw(g As Graphics) Implements DrawInterface.Draw
        g.DrawImage(m_iconIm, m_a.X, m_a.Y, m_size, m_height)
        If Animate Then
            m_a.Y += 1
        End If
    End Sub
End Class
