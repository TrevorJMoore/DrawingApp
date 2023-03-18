Imports System.ComponentModel

Public Class Form2



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Form2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        Label1.Text = "# Of Sides: " & TrackBar1.Value
        Form1.numberSides.Value = TrackBar1.Value
    End Sub

    Private Sub TrackBar2_Scroll(sender As Object, e As EventArgs) Handles TrackBar2.Scroll
        Label2.Text = "Side Length: " & TrackBar2.Value
        Form1.sideLength.Value = TrackBar2.Value
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles Me.Load
        Form1.numberSides.Value = TrackBar1.Value
        Form1.sideLength.Value = TrackBar2.Value
        Label2.Text = "Side Length: " & Form1.sideLength.Value
        Label1.Text = "# Of Sides: " & Form1.numberSides.Value
    End Sub

End Class