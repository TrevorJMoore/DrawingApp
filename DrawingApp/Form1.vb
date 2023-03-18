Public Class Form1
    Private m_Previous As System.Nullable(Of Point) = Nothing
    Private m_First As System.Nullable(Of Point) = Nothing
    Dim m_shapes As New Collection
    'Dim changeIs As Integer = 0
    Dim i As Integer = 0
    Dim resizedor As Integer = 0
    Dim closeSave As Integer = 0
    Dim initColor As Color
    Dim customColor As Color = Nothing
    Dim f As Integer = 0
    Private IsFormBeingDragged As Boolean = False
    Private MouseDwnX As Integer
    Private MouseDwnY As Integer
    Dim customColorFallBack As Color = Nothing
    Dim t As Integer = 0
    Dim clickedBox As Integer = 0


    Private Sub pictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        m_Previous = e.Location

        pictureBox1_MouseMove(sender, e)
    End Sub

    Private Sub pictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        If t = 0 Then
            If m_Previous IsNot Nothing Then
                Select Case True
                    Case RadioButton1.Checked
                        Dim l As New Line(PictureBox1.Image, m_Previous, e.Location)
                        If penColorLabel.BackColor <> Me.BackColor Then
                            l.Pen = New Pen(penColorLabel.BackColor, penWidth.Value)
                            m_shapes.Add(l)
                        Else
                            l.Pen = New Pen(Color.Black, penWidth.Value)
                            m_shapes.Add(l)
                        End If
                    Case RadioButton2.Checked
                        If penHeight.Value < penWidth.Value Then
                            penHeight.Value = penWidth.Value
                        ElseIf penHeight.Value > penWidth.Value Then
                            penWidth.Value = penHeight.Value
                        End If
                        Dim l As New Circle(PictureBox1.Image, m_Previous, penWidth.Value)
                        If penColorLabel.BackColor <> Me.BackColor Then
                            l.Pen = New Pen(penColorLabel.BackColor, penWidth.Value)
                            m_shapes.Add(l)
                        Else
                            l.Pen = New Pen(Color.Black, penWidth.Value)
                            m_shapes.Add(l)
                        End If
                    Case RadioButton3.Checked
                        Dim l As New Squares(PictureBox1.Image, m_Previous, penWidth.Value, penHeight.Value)
                        If penColorLabel.BackColor <> Me.BackColor Then
                            l.Pen = New Pen(penColorLabel.BackColor, penWidth.Value)
                            l.Animate = CheckBox1.Checked
                            m_shapes.Add(l)
                        Else
                            l.Pen = New Pen(Color.Black, penWidth.Value)
                            l.Animate = CheckBox1.Checked
                            m_shapes.Add(l)
                        End If
                    Case RadioButton4.Checked
                        Dim l As New Icon(PictureBox1.Image, m_Previous, penWidth.Value, penHeight.Value, ImageList1.Images(0))
                        If penColorLabel.BackColor <> Me.BackColor Then
                            l.Pen = New Pen(penColorLabel.BackColor, penWidth.Value)
                            m_shapes.Add(l)
                        Else
                            l.Pen = New Pen(Color.Black, penWidth.Value)
                            m_shapes.Add(l)
                        End If
                    Case RadioButton5.Checked
                        Dim l As New Arc(PictureBox1.Image, m_Previous, penWidth.Value, penHeight.Value, 0, 45)
                        If penColorLabel.BackColor <> Me.BackColor Then
                            l.Pen = New Pen(penColorLabel.BackColor, penWidth.Value)
                            m_shapes.Add(l)
                        Else
                            l.Pen = New Pen(Color.Black, penWidth.Value)
                            m_shapes.Add(l)
                        End If
                    Case RadioButton7.Checked
                        Dim l As New Polygons(PictureBox1.Image, m_Previous, penWidth.Value)
                        If penColorLabel.BackColor <> Me.BackColor Then
                            l.Pen = New Pen(penColorLabel.BackColor, penWidth.Value)

                            m_shapes.Add(l)
                        Else
                            l.Pen = New Pen(Color.Black, penWidth.Value)
                            m_shapes.Add(l)
                        End If
                    Case RadioButton9.Checked
                        Dim l As New NGon(PictureBox1.Image, m_Previous)
                        If penColorLabel.BackColor <> Me.BackColor Then
                            l.Pen = New Pen(penColorLabel.BackColor, penWidth.Value)
                            'Dim linGrBrush As New Drawing2D.LinearGradientBrush(New Point(0, 10), New Point(200, 10), Color.FromArgb(255, 255, 0, 0), Color.FromArgb(255, 0, 0, 255))
                            '
                            'l.Brush = linGrBrush
                            'l.Pen = New Pen(linGrBrush)
                            l.Sides = numberSides.Value
                            l.SideLength = sideLength.Value
                            m_shapes.Add(l)

                        Else
                            l.Pen = New Pen(Color.Black, penWidth.Value)
                            'Dim linGrBrush As New Drawing2D.LinearGradientBrush(New Point(0, 10), New Point(200, 10), Color.FromArgb(255, 255, 0, 0), Color.FromArgb(255, 0, 0, 255))
                            'l.Brush = linGrBrush
                            'l.Pen = New Pen(linGrBrush)
                            l.Sides = numberSides.Value
                            l.SideLength = sideLength.Value
                            m_shapes.Add(l)

                        End If
                    Case RadioButton11.Checked
                        Dim l As New Circle(PictureBox1.Image, m_Previous, erasersizetrack.Value)
                        If customColorFallBack <> Nothing Then
                            l.Pen = New Pen(customColorFallBack, erasersizetrack.Value)
                            m_shapes.Add(l)
                        Else
                            l.Pen = New Pen(Me.BackColor, erasersizetrack.Value)
                            m_shapes.Add(l)
                        End If
                End Select
                'Dim l As New Line(PictureBox1.Image, m_Previous, e.Location)
                ' Dim l As New Squares(PictureBox1.Image, m_Previous, penWidth.Value)

                PictureBox1.Invalidate()
                m_Previous = e.Location

            End If
        End If
        closeSave = 1
    End Sub

    Private Sub pictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        m_Previous = Nothing
    End Sub
    Private Sub Reset()
        m_shapes.Clear()
        PictureBox1.Invalidate()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Reset()
        Label8.Text = PictureBox1.Size.ToString()
        ComboBox1.SelectedItem = "Line"
    End Sub

    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        For Each s As Object In m_shapes
            s.Draw(e.Graphics)
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Reset()
        Label16.BackColor = Label15.BackColor
        Label17.BackColor = Label15.BackColor
        Label16.ForeColor = Color.Black
        Label17.ForeColor = Color.Black
        penColorLabel.BackColor = Me.BackColor
        closeSave = 0
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        ColorDialog1.ShowDialog()
        backGroundColorLabel.BackColor = ColorDialog1.Color
    End Sub

    'Private Sub Button3_Click(sender As Object, e As EventArgs)
    '    penColorLabel.BackColor = ColorDialog1.Color
    'End Sub

    Private Sub PictureBox10_Click(sender As Object, e As EventArgs) Handles PictureBox13.Click, PictureBox12.Click, PictureBox11.Click, PictureBox10.Click, PictureBox14.Click, PictureBox15.Click, PictureBox16.Click, PictureBox17.Click
        If customColor <> Nothing Then
            sender.BackColor = customColor
        End If
        t = 0
        customColor = Nothing
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click, PictureBox8.Click, PictureBox7.Click, PictureBox6.Click, PictureBox5.Click, PictureBox4.Click, PictureBox3.Click, PictureBox2.Click, PictureBox13.Click, PictureBox12.Click, PictureBox11.Click, PictureBox10.Click, PictureBox14.Click, PictureBox15.Click, PictureBox16.Click, PictureBox17.Click, Label16.Click
        If i = 0 AndAlso sender.BackColor <> Label15.BackColor Then
            Label16.BackColor = sender.BackColor
            If Label16.BackColor = Color.Black Then
                Label16.ForeColor = Color.White
            Else
                Label16.ForeColor = Color.Black
            End If
            penColorLabel.BackColor = sender.BackColor
            i = 1
        ElseIf i = 1 AndAlso sender.BackColor <> Label15.BackColor Then
            Label17.BackColor = Label16.BackColor
            If Label17.BackColor = Color.Black Then
                Label17.ForeColor = Color.White
            Else
                Label17.ForeColor = Color.Black
            End If
            Label16.BackColor = sender.BackColor
            If Label16.BackColor = Color.Black Then
                Label16.ForeColor = Color.White
            Else
                Label16.ForeColor = Color.Black
            End If
            penColorLabel.BackColor = sender.BackColor
            i = 2
        ElseIf i = 2 AndAlso sender.BackColor <> Label15.BackColor Then
            Label17.BackColor = Label16.BackColor
            If Label17.BackColor = Color.Black Then
                Label17.ForeColor = Color.White
            Else
                Label17.ForeColor = Color.Black
            End If

            Label16.BackColor = sender.BackColor
            If Label16.BackColor = Color.Black Then
                Label16.ForeColor = Color.White
            Else
                Label16.ForeColor = Color.Black
            End If
            penColorLabel.BackColor = sender.BackColor

            i = 1
        End If

        'If sender.BackColor = Color.Black Then
        '    Label16.ForeColor = Color.White
        '    i = 1
        'ElseIf i = 0 Then
        '    Label17.BackColor = Label16.BackColor
        'ElseIf Label16.BackColor = Color.Black Then
        '    Label17.ForeColor = Color.White
        'Else
        '    Label16.ForeColor = Color.Black
        '    Label17.ForeColor = Color.Black
        'End If
    End Sub

    'Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
    '    Me.Close()
    'End Sub
    '
    'Private Sub ResetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetToolStripMenuItem.Click
    '    Reset()
    'End Sub

    'Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
    '
    '    OpenFileDialog1.ShowDialog()
    '    PictureBox1.Load(OpenFileDialog1.FileName)
    '
    'End Sub

    'Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
    '
    '    If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
    '        PictureBox1.Image.Save(SaveFileDialog1.FileName)
    '    End If
    'End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If t = 1 Then
            Dim bmp As New Bitmap(PictureBox1.Width, PictureBox1.Height)
            Using g As Graphics = Graphics.FromImage(bmp)
                g.Clear(customColor)
            End Using
            PictureBox1.Image = bmp
            customColorFallBack = customColor
            t = 0
            f = 1
            customColor = Nothing
        End If
        closeSave = 1
    End Sub



    Private Sub PolygonToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim f2 As New Form2
        f2.ShowDialog()
    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click
        initColor = Label17.BackColor

        If initColor <> Label15.BackColor Then
            penColorLabel.BackColor = initColor
        Else
            penColorLabel.BackColor = Color.Black
        End If

        Label17.BackColor = Label16.BackColor
        If initColor = Color.Black Then
            Label16.BackColor = initColor
            Label16.ForeColor = Color.White
        Else
            Label16.BackColor = initColor
        End If

        If Label17.BackColor = Color.Black Then
            Label17.ForeColor = Color.White
        Else
            Label17.ForeColor = Color.Black
        End If
        If Label16.BackColor = Color.Black Then
            Label16.ForeColor = Color.White
        Else
            Label16.ForeColor = Color.Black
        End If

    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click

        If ColorDialog1.ShowDialog() = DialogResult.OK Then

            If ColorDialog1.Color = backGroundColorLabel.BackColor Then
                customColor = backGroundColorLabel.BackColor
            Else
                customColor = ColorDialog1.Color
            End If
        Else
            customColor = Nothing
        End If


        t = 1
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If closeSave = 1 Then
            MessageBox.Show("Do you want to save your changes?", "Save Changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)
            If DialogResult.No Then
                Me.Close()
            ElseIf MessageBox.Show("Do you want to save your changes?", "Save Changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
                SaveFileDialog1.ShowDialog()

            End If
        ElseIf closeSave = 0 Then
            Me.Close()
        End If

    End Sub

    Private Sub Panel7_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel7.MouseDown
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            IsFormBeingDragged = True
            MouseDwnX = e.X
            MouseDwnY = e.Y

        End If
    End Sub

    Private Sub Panel7_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel7.MouseUp
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            IsFormBeingDragged = False
        End If
    End Sub

    Private Sub Panel7_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel7.MouseMove
        If IsFormBeingDragged = True Then
            Dim tmp As Point = New Point
            tmp.X = Me.Location.X + (e.X - MouseDwnX)
            tmp.Y = Me.Location.Y + (e.Y - MouseDwnY)
            Me.Location = tmp
        End If
    End Sub

    Private Sub PictureBox1_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox1.MouseEnter
        'Me.Cursor = Cursors.Cross
    End Sub

    Private Sub PictureBox1_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox1.MouseLeave
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)
        Dim l As New Circle(PictureBox1.Image, m_First, Form3.TrackBar1.Value)
        'l.Pen(PictureBox1.)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim bob As String = ComboBox1.SelectedItem
        If ComboBox1.SelectedItem = "Square" Then
            RadioButton3.Checked = True
            Button2.Text = "Edit" & Environment.NewLine & bob
        ElseIf bob = "Circle" Then
            RadioButton2.Checked = True
            Button2.Text = "Edit" & Environment.NewLine & bob
        ElseIf bob = "Polygon" Then
            RadioButton9.Checked = True
            Button2.Text = "Edit" & Environment.NewLine & bob
        ElseIf bob = "Icon" Then
            RadioButton4.Checked = True
            Button2.Text = "Edit" & Environment.NewLine & bob
        Else
            RadioButton1.Checked = True
            Button2.Text = "Line"
        End If

        penWidth.Value = 1
        penHeight.Value = 1

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Dim bob As String = ComboBox1.SelectedItem
        Dim f3 As New Form3
        Dim f2 As New Form2
        If Button2.Text = "None" Then
            ComboBox1.DroppedDown = True
        ElseIf bob = "Line" Then
            ComboBox1.DroppedDown = True
        ElseIf Button2.Text = "Eraser" Then
            ComboBox1.DroppedDown = True
        ElseIf bob = "Circle" Then
            f3.ShowDialog()
        ElseIf bob = "Square" Then
            f3.ShowDialog()
        ElseIf bob = "Polygon" Then
            f2.ShowDialog()
        ElseIf bob = "Icon" Then
            f3.ShowDialog()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        ComboBox1.SelectedItem = Nothing
        RadioButton11.Checked = True
        Button2.Text = "Eraser"
        Dim f4 As New Form4
        f4.ShowDialog()
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub PictureBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseClick
        If t = 0 AndAlso f = 0 Then
            If m_Previous IsNot Nothing Then
                Select Case True
                    Case RadioButton1.Checked
                        Dim l As New Line(PictureBox1.Image, m_Previous, e.Location)
                        If penColorLabel.BackColor <> Me.BackColor Then
                            l.Pen = New Pen(penColorLabel.BackColor, penWidth.Value)
                            m_shapes.Add(l)
                        Else
                            l.Pen = New Pen(Color.Black, penWidth.Value)
                            m_shapes.Add(l)
                        End If
                    Case RadioButton2.Checked
                        If penHeight.Value < penWidth.Value Then
                            penHeight.Value = penWidth.Value
                        ElseIf penHeight.Value > penWidth.Value Then
                            penWidth.Value = penHeight.Value
                        End If
                        Dim l As New Circle(PictureBox1.Image, m_Previous, penWidth.Value)
                        If penColorLabel.BackColor <> Me.BackColor Then
                            l.Pen = New Pen(penColorLabel.BackColor, penWidth.Value)
                            m_shapes.Add(l)
                        Else
                            l.Pen = New Pen(Color.Black, penWidth.Value)
                            m_shapes.Add(l)
                        End If
                    Case RadioButton3.Checked
                        Dim l As New Squares(PictureBox1.Image, m_Previous, penWidth.Value, penHeight.Value)
                        If penColorLabel.BackColor <> Me.BackColor Then
                            l.Pen = New Pen(penColorLabel.BackColor, penWidth.Value)
                            l.Animate = CheckBox1.Checked
                            m_shapes.Add(l)
                        Else
                            l.Pen = New Pen(Color.Black, penWidth.Value)
                            l.Animate = CheckBox1.Checked
                            m_shapes.Add(l)
                        End If
                    Case RadioButton4.Checked
                        Dim l As New Icon(PictureBox1.Image, m_Previous, penWidth.Value, penHeight.Value, ImageList1.Images(0))
                        If penColorLabel.BackColor <> Me.BackColor Then
                            l.Pen = New Pen(penColorLabel.BackColor, penWidth.Value)
                            m_shapes.Add(l)
                        Else
                            l.Pen = New Pen(Color.Black, penWidth.Value)
                            m_shapes.Add(l)
                        End If
                    Case RadioButton5.Checked
                        Dim l As New Arc(PictureBox1.Image, m_Previous, penWidth.Value, penHeight.Value, 0, 45)
                        If penColorLabel.BackColor <> Me.BackColor Then
                            l.Pen = New Pen(penColorLabel.BackColor, penWidth.Value)
                            m_shapes.Add(l)
                        Else
                            l.Pen = New Pen(Color.Black, penWidth.Value)
                            m_shapes.Add(l)
                        End If
                    Case RadioButton7.Checked
                        Dim l As New Polygons(PictureBox1.Image, m_Previous, penWidth.Value)
                        If penColorLabel.BackColor <> Me.BackColor Then
                            l.Pen = New Pen(penColorLabel.BackColor, penWidth.Value)

                            m_shapes.Add(l)
                        Else
                            l.Pen = New Pen(Color.Black, penWidth.Value)
                            m_shapes.Add(l)
                        End If
                    Case RadioButton9.Checked
                        Dim l As New NGon(PictureBox1.Image, m_Previous)
                        If penColorLabel.BackColor <> Me.BackColor Then
                            l.Pen = New Pen(penColorLabel.BackColor, penWidth.Value)
                            'Dim linGrBrush As New Drawing2D.LinearGradientBrush(New Point(0, 10), New Point(200, 10), Color.FromArgb(255, 255, 0, 0), Color.FromArgb(255, 0, 0, 255))
                            '
                            'l.Brush = linGrBrush
                            'l.Pen = New Pen(linGrBrush)
                            l.Sides = numberSides.Value
                            l.SideLength = sideLength.Value
                            m_shapes.Add(l)

                        Else
                            l.Pen = New Pen(Color.Black, penWidth.Value)
                            'Dim linGrBrush As New Drawing2D.LinearGradientBrush(New Point(0, 10), New Point(200, 10), Color.FromArgb(255, 255, 0, 0), Color.FromArgb(255, 0, 0, 255))
                            'l.Brush = linGrBrush
                            'l.Pen = New Pen(linGrBrush)
                            l.Sides = numberSides.Value
                            l.SideLength = sideLength.Value
                            m_shapes.Add(l)

                        End If
                    Case RadioButton11.Checked
                        Dim l As New Circle(PictureBox1.Image, m_Previous, erasersizetrack.Value)
                        If customColorFallBack <> Nothing Then
                            l.Pen = New Pen(customColorFallBack, erasersizetrack.Value)
                            m_shapes.Add(l)
                        Else
                            l.Pen = New Pen(Me.BackColor, erasersizetrack.Value)
                            m_shapes.Add(l)
                        End If
                End Select
                'Dim l As New Line(PictureBox1.Image, m_Previous, e.Location)
                ' Dim l As New Squares(PictureBox1.Image, m_Previous, penWidth.Value)

                PictureBox1.Invalidate()
                m_Previous = e.Location

            End If
        End If
        f = 0
        closeSave = 1
    End Sub

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            PictureBox1.Load(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            PictureBox1.Image.Save(SaveFileDialog1.FileName)
        End If
    End Sub

    Private Sub Label18_MouseDown(sender As Object, e As MouseEventArgs) Handles Label18.MouseDown
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            IsFormBeingDragged = True
            MouseDwnX = e.X
            MouseDwnY = e.Y

        End If
    End Sub

    Private Sub Label18_MouseUp(sender As Object, e As MouseEventArgs) Handles Label18.MouseUp
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            IsFormBeingDragged = False
        End If
    End Sub

    Private Sub Label18_MouseMove(sender As Object, e As MouseEventArgs) Handles Label18.MouseMove
        If IsFormBeingDragged = True Then
            Dim tmp As Point = New Point
            tmp.X = Me.Location.X + (e.X - MouseDwnX)
            tmp.Y = Me.Location.Y + (e.Y - MouseDwnY)
            Me.Location = tmp
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        PictureBox1.Invalidate()
    End Sub
End Class
