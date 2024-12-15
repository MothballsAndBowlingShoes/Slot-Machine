Imports System.Threading
Imports System.Windows.Forms.VisualStyles

Public Class Form1
    ' The maximum number of reels in the slot machine.
    Dim MaxReels As Integer
    ' The number of times the spin button has been pressed.
    Dim TimesButtonPressed As Integer = 0
    ' A list of reels for the slot machine.
    Dim Reels As List(Of Reel)

    ''' <summary>
    ''' Initializes the form and sets up the reels.
    ''' </summary>
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize the reels with corresponding RichTextBox controls.
        Reels = New List(Of Reel) From {
            New Reel(RichTextBox1),
            New Reel(RichTextBox2),
            New Reel(RichTextBox3)
        }

        ' Set the maximum number of reels.
        MaxReels = Reels.Count
    End Sub

    ''' <summary>
    ''' Handles the button click event to start or stop the slot machine reels' animation.
    ''' </summary>
    ''' <param name="sender">The sender object.</param>
    ''' <param name="e">The event arguments.</param>
    Private Async Sub btn_SpinSlotMachine_Click(sender As Object, e As EventArgs) Handles btn_SpinSlotMachine.Click
        Select Case TimesButtonPressed
            ' Start the animation of all reels asynchronously when the button is first pressed.
            Case 0
                btn_SpinSlotMachine.Text = "Stop Reel " + (TimesButtonPressed + 1).ToString
                ' Start animating all reels asynchronously.
                Dim reelTasks As New List(Of Task)
                For index As Integer = 0 To MaxReels - 1
                    reelTasks.Add(Reels(index).ReelAnimator())
                Next
                TimesButtonPressed += 1

                ' Await all reels to complete their animation.
                Await Task.WhenAll(reelTasks)

            ' Stop animation for each reel on subsequent presses.
            Case 0 To MaxReels
                If TimesButtonPressed < 3 Then
                    btn_SpinSlotMachine.Text = "Stop Reel " + (TimesButtonPressed + 1).ToString
                Else
                    btn_SpinSlotMachine.Text = "See Results"
                End If

                ' Stop animation for the next reel.
                Reels(TimesButtonPressed - 1).IsReelAnimated = False
                TimesButtonPressed += 1

                ' Show the results form and reset the game when the button is pressed again.
            Case Else
                ' Show results in a new form and reset the button text.
                Dim ResultsForm As New WinForm()
                ResultsForm.Show()
                TimesButtonPressed = 0
                btn_SpinSlotMachine.Text = "Start A New Game"
        End Select
    End Sub

    ''' <summary>
    ''' Determines the prize based on the symbols selected on the reels.
    ''' </summary>
    ''' <returns>The prize amount based on matching symbols.</returns>
    Public Function GetWinPrize() As Integer
        ' Get the selected symbols from each reel.
        Dim FirstReelSymbol As ReelSymbol = Reels(0).SelectedSymbol
        Dim SecondReelSymbol As ReelSymbol = Reels(1).SelectedSymbol
        Dim ThirdReelSymbol As ReelSymbol = Reels(2).SelectedSymbol

        ' Check for matching symbols and return the corresponding prize.
        If FirstReelSymbol.Name = SecondReelSymbol.Name AndAlso FirstReelSymbol.Name = ThirdReelSymbol.Name Then
            Return FirstReelSymbol.WinningSymbolNumbers(2)
        ElseIf FirstReelSymbol.Name = SecondReelSymbol.Name OrElse FirstReelSymbol.Name = ThirdReelSymbol.Name Then
            Return FirstReelSymbol.WinningSymbolNumbers(1)
        ElseIf SecondReelSymbol.Name = ThirdReelSymbol.Name Then
            Return SecondReelSymbol.WinningSymbolNumbers(1)
        End If

        ' Default case: no match, return 0 prize.
        Return 0
    End Function

End Class


''' <summary>
''' The reel class makes up a single reel in the slot machine.
''' There are 3 reels in the slot machine.
''' </summary>
' Class Reel represents the functionality of a digital slot machine reel.
Class Reel
    ' Constants defining the upper and lower bounds for RNG (Random Number Generator) and other values.
    Const intUPPERBOUND As Integer = 999   ' The Upperbound for the RNG.
    Const intLOWERBOUND As Integer = 1     ' The Lowerbound for the RNG.
    Const intDIVISONVALUE As Integer = 64  ' The Divisional Value for the RNG to divide by using Modulus.
    Const intNUMBEROFSYMBOLS As Integer = 21 ' The number of different symbols in the reel.

    ' An array of ReelSymbol objects representing the symbols in the reel.
    Dim ReelSymbolList As List(Of ReelSymbol) = ReelSymbolFactory.CreateSymbols()

    Public SelectedSymbol As ReelSymbol ' Selected symbol after animation.

    Private Seed As Integer ' The Seed used to generate random numbers.

    Private Textbox As RichTextBox ' The RichTextBox to display the current symbol.

    Public IsReelAnimated As Boolean ' Boolean to track if the reel is animating.

    ''' <summary>
    ''' Constructor for the Reel object. Initializes the Textbox and sets text alignment.
    ''' </summary>
    ''' <param name="Textbox">The RichTextBox to display the result.</param>
    Public Sub New(Textbox As RichTextBox)
        Me.Textbox = Textbox
        Textbox.SelectionAlignment = HorizontalAlignment.Center ' Set the alignment of text in the Textbox to center.
    End Sub

    ''' <summary>
    ''' Calculates a random number between the upper and lower bounds, then returns its modulus by intDIVISONVALUE.
    ''' </summary>
    ''' <returns>Modular value of the generated random number.</returns>
    Private Function CalculateDigitalReel() As Integer
        Dim RandomNumber = New Random() ' Seed the random number generator.
        Seed = RandomNumber.Next(intLOWERBOUND, intUPPERBOUND) ' Generate random number between LOWERBOUND and UPPERBOUND.

        Return Seed Mod intDIVISONVALUE ' Return modulus with DIVISONVALUE to limit the range.
    End Function

    ''' <summary>
    ''' Converts the digital reel value (0-63) into a physical symbol from the ReelSymbolList.
    ''' </summary>
    ''' <param name="DigitalReel">The digital reel value generated by the RNG.</param>
    ''' <returns>A ReelSymbol object based on the value of DigitalReel.</returns>
    Private Function ConvertDigitalReelToPhysical(DigitalReel As Integer) As ReelSymbol
        ' Select the corresponding symbol based on the DigitalReel value.
        Select Case DigitalReel
            Case 5, 27, 51, 41
                Return ReelSymbolList(0)
            Case 13, 35, 63, 37
                Return ReelSymbolList(1)
            Case 16, 32, 49
                Return ReelSymbolList(2)
            Case 7, 14, 42
                Return ReelSymbolList(3)
            Case 9, 21, 56
                Return ReelSymbolList(4)
            Case 11, 29, 60
                Return ReelSymbolList(5)
            Case 2, 10, 38
                Return ReelSymbolList(6)
            Case 0, 18, 45
                Return ReelSymbolList(7)
            Case 3, 24, 54
                Return ReelSymbolList(8)
            Case 6, 30, 57
                Return ReelSymbolList(9)
            Case 1, 19, 46
                Return ReelSymbolList(10)
            Case 4, 25, 52
                Return ReelSymbolList(11)
            Case 8, 22, 48
                Return ReelSymbolList(12)
            Case 12, 33, 59
                Return ReelSymbolList(13)
            Case 15, 36, 62
                Return ReelSymbolList(14)
            Case 17, 39, 64
                Return ReelSymbolList(15)
            Case 20, 43, 44
                Return ReelSymbolList(16)
            Case 23, 47, 58
                Return ReelSymbolList(17)
            Case 26, 50, 40
                Return ReelSymbolList(18)
            Case 28, 53, 61
                Return ReelSymbolList(19)
            Case 31, 55
                Return ReelSymbolList(20)
            Case 34
                Return ReelSymbolList(21)
        End Select

        Return Nothing ' Return nothing if no match is found.
    End Function

    ''' <summary>
    ''' Starts the animation by calling the AnimateReel function in a separate thread.
    ''' </summary>
    Public Function ReelAnimator() As Task
        Return AnimateReel() ' Start the reel animation.
    End Function

    ''' <summary>
    ''' Handles the animation sequence by calling several helper methods.
    ''' </summary>
    Private Async Function AnimateReel() As Task
        StartAnimationLoop() ' Begin the animation loop.

        Await GraduallySlowAnimation() ' Gradually slow down the animation.

        StopReelOnFinalSymbol() ' Stop the animation on the final symbol.
    End Function

    ''' <summary>
    ''' Continuously updates the Textbox with new symbols in a loop.
    ''' </summary>
    Private Async Sub StartAnimationLoop()
        IsReelAnimated = True
        Dim randomGenerator As New Random()

        While IsReelAnimated
            Dim randomSymbol = ConvertDigitalReelToPhysical(randomGenerator.Next(intLOWERBOUND, intUPPERBOUND) Mod intDIVISONVALUE)
            SelectedSymbol = randomSymbol ' Update SelectedSymbol
            UpdateTextbox(randomSymbol.Name) ' Update the textbox
            Await Task.Delay(10)
        End While
    End Sub


    ''' <summary>
    ''' Gradually slows down the animation by increasing the delay between updates.
    ''' </summary>
    Private Async Function GraduallySlowAnimation() As Task
        Dim randomGenerator As New Random()

        For delay As Integer = 10 To 100 Step 5 ' Gradually increase delay from 10 to 100 ms.
            Dim randomSymbol = ConvertDigitalReelToPhysical(randomGenerator.Next(intLOWERBOUND, intUPPERBOUND) Mod intDIVISONVALUE)
            SelectedSymbol = randomSymbol ' Update the SelectedSymbol to match the displayed symbol
            UpdateTextbox(randomSymbol.Name) ' Update the Textbox with the same symbol
            Await Task.Delay(delay) ' Wait for the increasing delay time before updating again
        Next
    End Function


    ''' <summary>
    ''' Stops the reel on the final symbol and updates the Textbox.
    ''' </summary>
    Private Shared reelLock As New Object()

    Private Sub StopReelOnFinalSymbol()
        SyncLock reelLock ' Ensure thread safety when stopping the reel.
            ' Get the final symbol by calculating the digital reel and converting it to physical.
            Dim finalSymbol = ConvertDigitalReelToPhysical(CalculateDigitalReel())
            SelectedSymbol = finalSymbol ' Store the selected symbol.
            UpdateTextbox(finalSymbol.Name) ' Update the Textbox with the final symbol.
        End SyncLock
    End Sub

    ''' <summary>
    ''' Updates the Textbox with the given text.
    ''' </summary>
    Private Sub UpdateTextbox(text As String)
        Textbox.Invoke(Sub()
                           Textbox.Text = text ' Set the Textbox content to the new symbol name.
                       End Sub)
    End Sub
End Class

' Class ReelSymbol represents a single symbol on the reel.
Public Class ReelSymbol
    Public WinningSymbolNumbers As Integer() ' The numbers associated with winning symbols.
    Public Name As String ' The name of the symbol.

    ''' <summary>
    ''' Constructor for a ReelSymbol.
    ''' </summary>
    ''' <param name="WinningSymbol">Array of numbers representing winning symbol numbers.</param>
    ''' <param name="Name">Name of the symbol.</param>
    Public Sub New(WinningSymbol As Integer(), Name As String)
        Me.WinningSymbolNumbers = WinningSymbol
        Me.Name = Name
    End Sub
End Class

Public Class ReelSymbolFactory
    Public Shared Function CreateSymbols() As List(Of ReelSymbol)
        Return New List(Of ReelSymbol) From {
            New ReelSymbol({0, 0, 25}, "🂩"),
            New ReelSymbol({0, 0, 25}, "🂩"),
            New ReelSymbol({0, 0, 25}, "🂩"),
            New ReelSymbol({0, 25, 100}, "🂪"),
            New ReelSymbol({0, 25, 100}, "🂪"),
            New ReelSymbol({0, 25, 100}, "🂪"),
            New ReelSymbol({0, 50, 100}, "🂫"),
            New ReelSymbol({0, 50, 100}, "🂫"),
            New ReelSymbol({0, 50, 100}, "🂫"),
            New ReelSymbol({0, 50, 125}, "🂭"),
            New ReelSymbol({0, 50, 125}, "🂭"),
            New ReelSymbol({0, 50, 250}, "🂮"),
            New ReelSymbol({0, 75, 250}, "🂡"),
            New ReelSymbol({0, 75, 250}, "🌸"),
            New ReelSymbol({0, 75, 250}, "🌸"),
            New ReelSymbol({0, 75, 250}, "🌸"),
            New ReelSymbol({0, 50, 400}, "🍋"),
            New ReelSymbol({0, 50, 400}, "🍋"),
            New ReelSymbol({0, 50, 400}, "🍋"),
            New ReelSymbol({0, 100, 400}, "🍉"),
            New ReelSymbol({0, 100, 750}, "⍾"),
            New ReelSymbol({0, 2000, 9000}, "💰")
        }
    End Function

End Class