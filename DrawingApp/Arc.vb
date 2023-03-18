Imports WindowsApplication1

Public Class Arc
    Implements DrawInterface
    Public Property Pen As Pen Implements DrawInterface.Pen

    Public Property Animate As Boolean Implements DrawInterface.Animate

    Dim m_image As Image
    Dim m_a As Point
    Dim m_size As Integer
    Dim m_height As Integer
    Dim m_startAngle As Integer
    Dim m_sweepAngle As Integer

    'Constructor
    Public Sub New(i As Image, a As Point, Size As Integer, Height As Integer, StartAngle As Integer, SweepAngle As Integer)
        _Pen = New Pen(Color.Black, 1)
        m_image = i
        m_a = a
        Size = m_size
        Height = m_height
        StartAngle = m_startAngle
        SweepAngle = m_sweepAngle
    End Sub



    Public Sub Draw(g As Graphics) Implements DrawInterface.Draw
        g.DrawArc(Pen, m_a.X, m_a.Y, m_size, m_height, m_startAngle, m_sweepAngle)
        If Animate Then
            m_a.Y += 1
        End If
    End Sub
End Class
