Imports System.Threading
Imports System.Windows.Forms.VisualStyles

Public Class Form1
    Const intMAXREELS As Integer = 2

    Dim Reels As Reel()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Reels = New Reel(intMAXREELS) {
            New Reel(RichTextBox1),
            New Reel(RichTextBox2),
            New Reel(RichTextBox3)
        }
    End Sub

    Private Async Sub btn_SpinSlotMachine_Click(sender As Object, e As EventArgs) Handles btn_SpinSlotMachine.Click
        Dim TimesButtonPressed As Integer = 0

        Select Case TimesButtonPressed
            Case 0
                ' Start animating all reels asynchronously
                Dim reelTasks As New List(Of Task)
                For index As Integer = 0 To intMAXREELS
                    reelTasks.Add(Reels(index).ReelAnimator())
                Next
                TimesButtonPressed += 1

                ' Await all reels to complete their animation
                Await Task.WhenAll(reelTasks)

            Case 0 To intMAXREELS + 1
                ' Stop animation for the next reel
                Reels(TimesButtonPressed - 1).IsReelAnimated = False
                TimesButtonPressed += 1

            Case Else
                ' Show results form and reset
                Dim ResultsForm As New WinForm()
                ResultsForm.Show()
                TimesButtonPressed = 0
        End Select
    End Sub


    Public Function GetWinPrize() As Integer
        Dim FirstReelSymbol As ReelSymbol = Reels(0).SelectedSymbol
        Dim SecondReelSymbol As ReelSymbol = Reels(1).SelectedSymbol
        Dim ThirdReelSymbol As ReelSymbol = Reels(2).SelectedSymbol

        ' Check for matching symbols
        If FirstReelSymbol.Name = SecondReelSymbol.Name AndAlso FirstReelSymbol.Name = ThirdReelSymbol.Name Then
            Return FirstReelSymbol.WinningSymbolNumbers(2)
        ElseIf FirstReelSymbol.Name = SecondReelSymbol.Name OrElse FirstReelSymbol.Name = ThirdReelSymbol.Name Then
            Return FirstReelSymbol.WinningSymbolNumbers(1)
        ElseIf SecondReelSymbol.Name = ThirdReelSymbol.Name Then
            Return SecondReelSymbol.WinningSymbolNumbers(1)
        End If

        ' Default case
        Return 0
    End Function

End Class

''' <summary>
''' The reel class makes up a single reel in the slot machine.
''' There are 3 reels in the slot machine.
''' </summary>
Class Reel
    Const intUPPERBOUND As Integer = 999   ' The Upperbound for the RNG.
    Const intLOWERBOUND As Integer = 1     ' The Lowerbound for the RNG.
    Const intDIVISONVALUE As Integer = 64 ' The Divisional Value for the RNG to divide by using Modulas.
    Const intNUMBEROFSYMBOLS As Integer = 21

    Dim ReelSymbolList = New ReelSymbol(intNUMBEROFSYMBOLS) {
        New ReelSymbol({0, 0, 25}, "🂪"),
        New ReelSymbol({0, 0, 25}, "🂪"),
        New ReelSymbol({0, 25, 100}, "🂪"),
        New ReelSymbol({0, 25, 100}, "🂪"),
        New ReelSymbol({0, 25, 100}, "🂪"),
        New ReelSymbol({0, 25, 100}, "🂪"),
        New ReelSymbol({0, 25, 100}, "🂪"),
        New ReelSymbol({0, 50, 100}, "🂪"),
        New ReelSymbol({0, 50, 100}, "🂪"),
        New ReelSymbol({0, 50, 125}, "🂪"),
        New ReelSymbol({0, 50, 125}, "🂪"),
        New ReelSymbol({0, 50, 250}, "🂪"),
        New ReelSymbol({0, 75, 250}, "🂡"),
        New ReelSymbol({0, 75, 250}, "🌸"),
        New ReelSymbol({0, 75, 250}, "🌸"),
        New ReelSymbol({0, 75, 250}, "🌸"),
        New ReelSymbol({0, 50, 400}, "🍋"),
        New ReelSymbol({0, 50, 400}, "🍋"),
        New ReelSymbol({0, 100, 400}, "🍉"),
        New ReelSymbol({0, 100, 400}, "🍉"),
        New ReelSymbol({0, 100, 750}, "⍾"),
        New ReelSymbol({0, 2000, 9000}, "💰")
    }

    Public SelectedSymbol As ReelSymbol

    Private Seed As Integer             ' The Seed that is used to generate the number.

    Private Textbox As RichTextBox          ' The Textbox that it writes too.

    Public IsReelAnimated As Boolean    ' Checks if the Reel is Currently Animated.

    ''' <summary>
    ''' The Constructor for a Reel object. 
    ''' Upon construction it Randomizes the Rnd() function and Generates the Seed.
    ''' </summary>
    ''' <param name="Picture"></param>
    Public Sub New(Textbox As RichTextBox)
        Me.Textbox = Textbox
        Textbox.SelectionAlignment = HorizontalAlignment.Center
    End Sub

    ''' <summary>
    ''' Calculates the Digital Reel Numbers
    ''' </summary>
    ''' <returns></returns>
    Private Function CalculateDigitalReel()
        Randomize()
        Seed = Int((intUPPERBOUND * Rnd()) + intLOWERBOUND)

        Return Seed Mod intDIVISONVALUE
    End Function

    ''' <summary>
    ''' It takes the Digital Reel, which is a random number between 1 and 64, and converts it to a Physical Reel between 1-22.
    ''' </summary>
    ''' <param name="DigitalReel"></param>
    ''' <returns></returns>
    Private Function ConvertDigitalReelToPhysical(DigitalReel As Integer) As ReelSymbol
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

        Return Nothing
    End Function

    ''' <summary>
    ''' It creates a background thread to handle animation.
    ''' </summary>
    Public Function ReelAnimator() As Task
        Return AnimateReel()
    End Function

    Private Async Function AnimateReel() As Task
        StartAnimationLoop()

        Await GraduallySlowAnimation()

        StopReelOnFinalSymbol()
    End Function

    Private Async Sub StartAnimationLoop()
        IsReelAnimated = True
        Dim randomGenerator As New Random()

        While IsReelAnimated
            UpdateTextbox(ConvertDigitalReelToPhysical(randomGenerator.Next(intLOWERBOUND, intUPPERBOUND) Mod intDIVISONVALUE).Name)
            Await Task.Delay(10) ' Use Await here instead of Wait
        End While
    End Sub


    Private Async Function GraduallySlowAnimation() As Task
        For delay As Integer = 10 To 100 Step 5
            Dim randomGenerator As New Random()
            UpdateTextbox(ConvertDigitalReelToPhysical(randomGenerator.Next(intLOWERBOUND, intUPPERBOUND) Mod intDIVISONVALUE).Name)
            Await Task.Delay(delay)
        Next
    End Function

    Private Shared reelLock As New Object()

    Private Sub StopReelOnFinalSymbol()
        SyncLock reelLock
            Dim finalSymbol = ConvertDigitalReelToPhysical(CalculateDigitalReel())
            SelectedSymbol = finalSymbol
            UpdateTextbox(finalSymbol.Name)
        End SyncLock
    End Sub

    Private Sub UpdateTextbox(text As String)
        Textbox.Invoke(Sub()
                           Textbox.Text = text
                       End Sub)
    End Sub
End Class

Public Class ReelSymbol
    Public WinningSymbolNumbers As Integer()
    Public Symbol As Image
    Public Name As String

    Public Sub New(WinningSymbol As Integer(), Name As String)
        Me.WinningSymbolNumbers = WinningSymbol
        Me.Name = Name
    End Sub
End Class
