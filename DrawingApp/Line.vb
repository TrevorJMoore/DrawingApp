Imports WindowsApplication1

Public Class Line
    Implements DrawInterface

    Public Property Pen As Pen Implements DrawInterface.Pen

    Public Property Animate As Boolean Implements DrawInterface.Animate

    Dim m_image As Image
    Dim m_a As Point
    Dim m_b As Point

    Public Sub New(i As Image, a As Point, b As Point)
        _Pen = New Pen(Color.Black, 1)
        m_image = i
        m_a = a
        m_b = b
    End Sub
    Public Sub Draw(g As Graphics) Implements DrawInterface.Draw
        Try
            g.DrawLine(Pen, m_a, m_b)
        Catch ex As Exception
            MsgBox(ex.ToString & Environment.NewLine & Environment.NewLine & "Sorry, looks like that caused an error!" & Environment.NewLine & Environment.NewLine & "The program will now close to avoid any more errors.")
            Form1.Close()
        End Try
        If Animate Then
            m_a.Y += 1
        End If
    End Sub

End Class
