Public Class maindashboard
    ' In-memory member list
    Private members As New List(Of Member)
    Private nextUserId As Integer = 1

    ' Member class
    Private Class Member
        Public Property UserId As Integer
        Public Property FirstName As String
        Public Property LastName As String
        Public Property PaymentStatus As String
    End Class

    Private Sub maindashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Setup DataGridView columns
        DataGridView1.Columns.Clear()
        DataGridView1.Columns.Add("UserId", "User ID")
        DataGridView1.Columns.Add("FirstName", "First Name")
        DataGridView1.Columns.Add("LastName", "Last Name")
        DataGridView1.Columns.Add("PaymentStatus", "Payment Status")
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.MultiSelect = False
    End Sub

    ' Add member button click
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim firstName As String = txtFirstName.Text.Trim()
        Dim lastName As String = txtLastName.Text.Trim()
        If String.IsNullOrEmpty(firstName) OrElse String.IsNullOrEmpty(lastName) Then
            MessageBox.Show("Please enter first and last name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim m As New Member With {
            .UserId = nextUserId,
            .FirstName = firstName,
            .LastName = lastName,
            .PaymentStatus = "Unpaid"
        }
        members.Add(m)
        nextUserId += 1
        RefreshTable()
        txtFirstName.Clear()
        txtLastName.Clear()
    End Sub

    ' Update payment status button click
    Private Sub btnUpdatePayment_Click(sender As Object, e As EventArgs) Handles btnUpdatePayment.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Select a member to update payment.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim userId As Integer = CInt(DataGridView1.SelectedRows(0).Cells("UserId").Value)
        Dim member = members.FirstOrDefault(Function(m) m.UserId = userId)
        If member IsNot Nothing Then
            member.PaymentStatus = "Paid"
            RefreshTable()
        End If
    End Sub

    ' Remove member button click
    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Select a member to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim userId As Integer = CInt(DataGridView1.SelectedRows(0).Cells("UserId").Value)
        members.RemoveAll(Function(m) m.UserId = userId)
        RefreshTable()
    End Sub

    ' Helper to refresh DataGridView
    Private Sub RefreshTable()
        DataGridView1.Rows.Clear()
        For Each m In members
            DataGridView1.Rows.Add(m.UserId, m.FirstName, m.LastName, m.PaymentStatus)
        Next
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click

    End Sub
End Class