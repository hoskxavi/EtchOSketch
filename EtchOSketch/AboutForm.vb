Public Class AboutForm
    Private Sub AboutForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AboutLabel.Text = "This program acts As a paint canvas. Colors can be selected Using either the" _
                           & "Select CaseColor button Or the Select Color Option In the Edit menu. The Draw Waveforms" _
                           & "Option via the Draw Waveforms button Or the Edit menu draws a Sine, Cosine, And Tangent waveform."
    End Sub

    Private Sub ReturnButton_Click(sender As Object, e As EventArgs) Handles ReturnButton.Click
        Me.Hide()
        EtchOSketchForm.Show()
    End Sub
End Class