Imports WindowsApplication1

Public Class Pie
    Public Class Squares
        Implements DrawInterface

        Public Property Pen As Pen Implements DrawInterface.Pen

        Public Property Animate As Boolean Implements DrawInterface.Animate

        Dim m_image As Image
        Dim m_a As Point
        Dim m_size As Integer
        Dim m_height As Integer


        'Constructor
        Public Sub New(i As Image, a As Point, Size As Integer, Height As Integer)
            _Pen = New Pen(Color.Black, 1)
            m_image = i
            m_a = a
            m_size = Size
            m_height = Height
        End Sub



        Public Sub Draw(g As Graphics) Implements DrawInterface.Draw
            g.DrawRectangle(Pen, m_a.X, m_a.Y, m_size, m_height)
            If Animate Then
                m_a.Y += 1
            End If
        End Sub
    End Class
End Class
