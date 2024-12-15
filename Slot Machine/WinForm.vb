Public Class WinForm
    Private Sub Winform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim PrizeAmount As Integer = Form1.GetWinPrize()
        If PrizeAmount <> 0 Then
            lbl_ResultText.Text = "You Win!" + Environment.NewLine + "You won $" + PrizeAmount.ToString + "!"
        Else
            lbl_ResultText.Text = "You Lose"
            lbl_ResultText.Image = Nothing
        End If
    End Sub
End Class