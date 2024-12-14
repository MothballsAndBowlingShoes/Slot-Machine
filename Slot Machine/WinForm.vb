Public Class WinForm
    Private Sub Winform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Form1.GetWinPrize() <> 0 Then
            pctBx_ImageOverlay.Visible = True
        End If
    End Sub
End Class