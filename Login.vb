Public Class Login
    Private Sub btnLogIn_Click(sender As Object, e As EventArgs) Handles btnLogIn.Click
        Dim username As String = TextBox2.Text.Trim()
        Dim password As String = TextBox3.Text

        If username = "admin" AndAlso password = "admin" Then
            Dim dash As New maindashboard()
            dash.Show()
            Me.Hide()
        Else
            MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class