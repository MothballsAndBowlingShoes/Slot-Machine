Public Class Settings

    Enum UseNameOrIcon
        UseIcon
        UseName
    End Enum

    Private Sub rdBtn_Icons_CheckedChanged(sender As Object, e As EventArgs) Handles rdBtn_Icons.CheckedChanged
        Form1.IconSettings = UseNameOrIcon.UseIcon
    End Sub

    Private Sub rdBtns_Intials_CheckedChanged(sender As Object, e As EventArgs) Handles rdBtns_Intials.CheckedChanged
        Form1.IconSettings = UseNameOrIcon.UseName
    End Sub
End Class