Public Class TtsGUI

    Dim ss As New Speech.Synthesis.SpeechSynthesizer

    Private Sub TtsGUI_FormClosed(sender As Object, e As Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub TtsGUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ss.SetOutputToDefaultAudioDevice()
        ss.Speak(RichTextBox1.Text)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SaveFileDialog1.ShowDialog()
    End Sub

    Private Sub SaveFileDialog1_FileOk(sender As Object, e As ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        ss.SetOutputToWaveFile(SaveFileDialog1.FileName)
        ss.Speak(RichTextBox1.Text)
        ss.SetOutputToDefaultAudioDevice()
    End Sub
End Class