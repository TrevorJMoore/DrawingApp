Public Class Form3
    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        Label1.Text = "Width: " & TrackBar1.Value
        Form1.penWidth.Value = TrackBar1.Value
    End Sub

    Private Sub TrackBar2_Scroll(sender As Object, e As EventArgs) Handles TrackBar2.Scroll
        Label2.Text = "Height: " & TrackBar2.Value
        Form1.penHeight.Value = TrackBar2.Value
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles Me.Load
        Form1.penWidth.Value = TrackBar1.Value
        Form1.penHeight.Value = TrackBar2.Value
        Label1.Text = "Width: " & Form1.penWidth.Value
        Label2.Text = "Height: " & Form1.penHeight.Value

    End Sub
End Class