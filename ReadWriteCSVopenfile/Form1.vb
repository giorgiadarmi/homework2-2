Imports System.IO
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.RichTextBox1.EnableAutoDragDrop = True
    End Sub

    Private Sub RichTextBox1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles RichTextBox1.DragDrop
        e.Effect = DragDropEffects.None

        Me.RichTextBox1.Clear()

        Dim files() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())

        For Each path In files
            Me.ProcessaFile(path)
        Next
    End Sub

    Public Sub RichTextBox1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles RichTextBox1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Sub ProcessaFile(path As String)
        Me.RichTextBox1.AppendText(path & Environment.NewLine)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Path As String = Me.RichTextBox1.Text.Trim

        Using R As New StreamReader(Path)

            Do
                Dim Line As String = R.ReadLine
                If R.EndOfStream Then Exit Do

                Me.RichTextBox2.AppendText(Line & Environment.NewLine)
            Loop

        End Using

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim o As New OpenFileDialog
        o.ShowDialog()

        If String.IsNullOrWhiteSpace(o.FileName) Then Exit Sub
        Me.RichTextBox1.Text = o.FileName

    End Sub
End Class
