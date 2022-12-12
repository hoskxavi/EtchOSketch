'Xavier Hoskins
'RCET 0265
'Fall 2022
'Etch O Sketch
'https://www.github.com/hoskxavi/EtchOSketch.git

Public Class EtchOSketchForm
    Dim currentColor As Color = Color.Black
    Private Sub GraphicsExampleForm_MouseMove(sender As Object, e As MouseEventArgs) Handles GraphicsPictureBox.MouseMove
        Static lastX%, lastY%

        If e.Button = MouseButtons.Left Then
            MouseDraw(lastX, lastY, e.X, e.Y, 1)
        End If
        'update last whenever the mouse moves
        lastX = e.X
        lastY = e.Y
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutForm.Show()
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        MouseDraw(1, 1, 1, 1, 2)
    End Sub

    'Top menu tool strip 
    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        MouseDraw(1, 1, 1, 1, 2)
    End Sub

    'Context menu tool strip
    Private Sub ClearToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem1.Click
        MouseDraw(1, 1, 1, 1, 2)
    End Sub

    Sub MouseDraw(lastX As Integer, lastY As Integer, x1 As Integer, y1 As Integer, operation As Integer)
        Dim g As Graphics = GraphicsPictureBox.CreateGraphics
        Dim basicPen As New Pen(Me.currentColor)
        Select Case operation
            Case 1
                g.DrawLine(basicPen, lastX, lastY, x1, y1)
                basicPen.Dispose()
                g.Dispose()
            Case 2
                g.Clear(Color.White)
        End Select

    End Sub

    Private Sub SelectColorButton_Click(sender As Object, e As EventArgs) Handles SelectColorButton.Click
        ColorDialog.ShowDialog()
        Me.currentColor = ColorDialog.Color
    End Sub

    Private Sub EtchOSketchForm_MouseClick(sender As Object, e As MouseEventArgs) Handles GraphicsPictureBox.MouseClick
        If e.Button = MouseButtons.Middle Then
            ColorDialog.ShowDialog()
            Me.currentColor = ColorDialog.Color
        End If
    End Sub

    'Top menu tool strip
    Private Sub SelectColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectColorToolStripMenuItem.Click
        ColorDialog.ShowDialog()
        Me.currentColor = ColorDialog.Color
    End Sub

    'Context menu tool strip
    Private Sub SelectColorToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SelectColorToolStripMenuItem1.Click
        ColorDialog.ShowDialog()
        Me.currentColor = ColorDialog.Color
    End Sub

    Private Sub DrawWaveformsButton_Click(sender As Object, e As EventArgs) Handles DrawWaveformsButton.Click, DrawWaveformsToolStripMenuItem.Click, DrawWaveformsToolStripMenuItem1.Click
        Dim xScale As Integer
        Dim yScale As Integer
        Dim xWidth As Integer = GraphicsPictureBox.Width
        Dim yHeight As Integer = GraphicsPictureBox.Height
        Dim lastX%, lastY%, currentX%, currentY%

        For i = 1 To 10
            xScale = (GraphicsPictureBox.Width / 10) * i
            MouseDraw(xScale, 0, xScale, yHeight, 1)
        Next

        For i = 1 To 10
            yScale = (GraphicsPictureBox.Height / 10) * i
            MouseDraw(0, yScale, xWidth, yScale, 1)
        Next

        lastY = CInt(100 * Math.Sin(CDbl((Math.PI * currentX) / 180)) + 100)

        For currentX = 0 To 360 Step 1
            currentY = CInt(100 * Math.Sin(CDbl((Math.PI * currentX) / 180)) + 100) 'hides decimal vale for conversion
            DrawWaveforms(Color.Red, lastX, lastY, currentX, currentY)
            lastX = currentX
            lastY = currentY
        Next

        lastY = CInt(100 * Math.Cos(CDbl((Math.PI * currentX) / 180)) + 100)

        For currentX = 0 To 360 Step 1
            currentY = CInt(100 * Math.Cos(CDbl((Math.PI * currentX) / 180)) + 100) 'hides decimal vale for conversion
            DrawWaveforms(Color.Blue, lastX, lastY, currentX, currentY)
            lastX = currentX
            lastY = currentY
        Next

        lastX = 0
        lastY = CInt(25 * Math.Tan(CDbl((Math.PI * 0) / 180)) + 100)

        For currentX = 0 To 89 Step 1
            currentY = CInt(25 * Math.Tan(CDbl((Math.PI * currentX) / 180)) + 100)
            DrawWaveforms(Color.Green, lastX, lastY, currentX, currentY)
            lastX = currentX
            lastY = currentY
        Next

        lastY = CInt(25 * Math.Tan(CDbl((Math.PI * 91) / 180)) + 100)

        For currentX = 91 To 179 Step 1
            currentY = CInt(25 * Math.Tan(CDbl((Math.PI * currentX) / 180)) + 100)
            DrawWaveforms(Color.Green, lastX, lastY, currentX, currentY)
            lastX = currentX
            lastY = currentY
        Next

        lastY = CInt(25 * Math.Tan(CDbl((Math.PI * 181) / 180)) + 100)

        For currentX = 181 To 269 Step 1
            currentY = CInt(25 * Math.Tan(CDbl((Math.PI * currentX) / 180)) + 100)
            DrawWaveforms(Color.Green, lastX, lastY, currentX, currentY)
            lastX = currentX
            lastY = currentY
        Next

        lastY = CInt(25 * Math.Tan(CDbl((Math.PI * 271) / 180)) + 100)

        For currentX = 271 To 359 Step 1
            currentY = CInt(25 * Math.Tan(CDbl((Math.PI * currentX) / 180)) + 100)
            DrawWaveforms(Color.Green, lastX, lastY, currentX, currentY)
            lastX = currentX
            lastY = currentY
        Next
    End Sub

    Sub DrawWaveforms(penColor As Color, lastX As Integer, lastY As Integer, x1 As Integer, y1 As Integer)
        Dim g As Graphics = GraphicsPictureBox.CreateGraphics
        Dim basicPen As New Pen(penColor)
        Dim sx As Single = CSng(GraphicsPictureBox.Width / 360)
        Dim sy As Single = CSng(GraphicsPictureBox.Height / 200)

        g.PageUnit = GraphicsUnit.Pixel
        g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighSpeed
        g.ScaleTransform(sx, sy)

        g.DrawLine(basicPen, lastX, lastY, x1, y1)
        basicPen.Dispose()
        g.Dispose()
    End Sub
End Class
