Imports Shell32

Public Class desktop
    Dim sh As New Shell
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        sh.MinimizeAll()
    End Sub
End Class