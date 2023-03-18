Public Class Form4
    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        Label1.Text = "Size: " & TrackBar1.Value
        Form1.erasersizetrack.Value = TrackBar1.Value
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = "Size: " & Form1.erasersizetrack.Value
        TrackBar1.Value = Form1.erasersizetrack.Value
    End Sub
End Class