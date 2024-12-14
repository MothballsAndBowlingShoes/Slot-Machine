Imports System.Threading
Imports System.Windows.Forms.VisualStyles

Public Class Form1
    Dim TimesButtonPressed As Integer = 0

    Dim Reels As Reel()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Reels = New Reel(2) {
            New Reel(PictureBox1),
            New Reel(PictureBox2),
            New Reel(PictureBox3)
        }
    End Sub

    Private Sub btn_SpinSlotMachine_Click(sender As Object, e As EventArgs) Handles btn_SpinSlotMachine.Click
        Select Case TimesButtonPressed
            Case 0
                For index As Integer = 0 To 2
                    Reels(index).ReelAnimator()
                Next
                TimesButtonPressed += 1

            Case 1
                TimesButtonPressed += 1
                Reels(0).IsReelAnimated = False

            Case 2
                TimesButtonPressed += 1
                Reels(1).IsReelAnimated = False

            Case 3
                TimesButtonPressed += 1
                Reels(2).IsReelAnimated = False
            Case Else
                Dim ResultsForm As Form = New WinForm()
                ResultsForm.Show()
                TimesButtonPressed = 0
        End Select
    End Sub

    Public Function GetWinPrize() As Integer
        Dim FirstReelSymbol As Symbol = Reels(0).SelectedSymbol
        Dim NumberOfMatches As Integer = 0
        Dim MatchingSymbols As Symbol
        If FirstReelSymbol.Name = Reels(1).SelectedSymbol.Name And FirstReelSymbol.Name = Reels(2).SelectedSymbol.Name Then
            NumberOfMatches += 2
            MatchingSymbols = FirstReelSymbol
            Return MatchingSymbols.WinningSymbolNumbers(NumberOfMatches)

        ElseIf FirstReelSymbol.Name = Reels(1).SelectedSymbol.Name Then
            NumberOfMatches += 1
            MatchingSymbols = FirstReelSymbol
            Return MatchingSymbols.WinningSymbolNumbers(NumberOfMatches)

        ElseIf FirstReelSymbol.Name = Reels(2).SelectedSymbol.Name Then
            NumberOfMatches += 1
            MatchingSymbols = FirstReelSymbol
            Return MatchingSymbols.WinningSymbolNumbers(NumberOfMatches)

        ElseIf Reels(1).SelectedSymbol.Name = Reels(2).SelectedSymbol.Name Then
            NumberOfMatches += 1
            MatchingSymbols = Reels(1).SelectedSymbol
            Return MatchingSymbols.WinningSymbolNumbers(NumberOfMatches)

        End If

        Return 0
    End Function
End Class

''' <summary>
''' The reel class makes up a single reel in the slot machine.
''' There are 3 reels in the slot machine.
''' </summary>
Class Reel
    Const Upperbound As Integer = 999   ' The Upperbound for the RNG.
    Const Lowerbound As Integer = 1     ' The Lowerbound for the RNG.
    Const DivisionValue As Integer = 64 ' The Divisional Value for the RNG to divide by using Modulas.

    Dim Symbols = New Symbol(21) {
        New Symbol({0, 0, 25}, "nine"),
        New Symbol({0, 0, 25}, "nine"),
        New Symbol({0, 25, 100}, "ten"),
        New Symbol({0, 25, 100}, "ten"),
        New Symbol({0, 25, 100}, "ten"),
        New Symbol({0, 25, 100}, "ten"),
        New Symbol({0, 25, 100}, "ten"),
        New Symbol({0, 50, 100}, "jack"),
        New Symbol({0, 50, 100}, "jack"),
        New Symbol({0, 50, 125}, "queen"),
        New Symbol({0, 50, 125}, "queen"),
        New Symbol({0, 50, 250}, "king"),
        New Symbol({0, 75, 250}, "ace"),
        New Symbol({0, 75, 250}, "cherry"),
        New Symbol({0, 75, 250}, "cherry"),
        New Symbol({0, 75, 250}, "cherry"),
        New Symbol({0, 50, 400}, "lemon"),
        New Symbol({0, 50, 400}, "lemon"),
        New Symbol({0, 100, 400}, "watermelon"),
        New Symbol({0, 100, 400}, "watermelon"),
        New Symbol({0, 100, 750}, "bell"),
        New Symbol({0, 2000, 9000}, "moneyBag")
    }

    Public SelectedSymbol As Symbol

    Private Seed As Integer             ' The Seed that is used to generate the number.

    Private picture As PictureBox          ' The Textbox that it writes too.

    Public IsReelAnimated As Boolean    ' Checks if the Reel is Currently Animated.

    ''' <summary>
    ''' The Constructor for a Reel object. 
    ''' Upon construction it Randomizes the Rnd() function and Generates the Seed.
    ''' </summary>
    ''' <param name="Picture"></param>
    Public Sub New(Picture As PictureBox)
        Me.picture = Picture
    End Sub

    ''' <summary>
    ''' Calculates the Digital Reel Numbers
    ''' </summary>
    ''' <returns></returns>
    Private Function CalculateDigitalReel()
        Randomize()
        Seed = Int((Upperbound * Rnd()) + Lowerbound)

        Return Seed Mod DivisionValue
    End Function

    ''' <summary>
    ''' It takes the Digital Reel, which is a random number between 1 and 64, and converts it to a Physical Reel between 1-22.
    ''' </summary>
    ''' <param name="DigitalReel"></param>
    ''' <returns></returns>
    Private Function CovnvertDigitalReelToPhysical(DigitalReel As Integer) As Symbol
        Select Case DigitalReel
            Case 5, 27, 51, 41
                Return Symbols(0)

            Case 13, 35, 63, 37
                Return Symbols(1)

            Case 16, 32, 49
                Return Symbols(2)

            Case 7, 14, 42
                Return Symbols(3)

            Case 9, 21, 56
                Return Symbols(4)

            Case 11, 29, 60
                Return Symbols(5)

            Case 2, 10, 38
                Return Symbols(6)

            Case 0, 18, 45
                Return Symbols(7)

            Case 3, 24, 54
                Return Symbols(8)

            Case 6, 30, 57
                Return Symbols(9)

            Case 1, 19, 46
                Return Symbols(10)

            Case 4, 25, 52
                Return Symbols(11)

            Case 8, 22, 48
                Return Symbols(12)

            Case 12, 33, 59
                Return Symbols(13)

            Case 15, 36, 62
                Return Symbols(14)

            Case 17, 39, 64
                Return Symbols(15)

            Case 20, 43, 44
                Return Symbols(16)

            Case 23, 47, 58
                Return Symbols(17)

            Case 26, 50, 40
                Return Symbols(18)

            Case 28, 53, 61
                Return Symbols(19)

            Case 31, 55
                Return Symbols(20)

            Case 34
                Return Symbols(21)
        End Select

        Return Nothing
    End Function

    ''' <summary>
    ''' It creates a background thread to handle animation.
    ''' </summary>
    Public Sub ReelAnimator()
        Dim AnimationThread As New Thread(AddressOf StartAnimation)
        AnimationThread.Start()
    End Sub

    ''' <summary>
    ''' Starts the animation, and keeps it running until IsReelAnimated is false. 
    ''' Every loop generates a random number and writes it too the Textbox.
    ''' After IsReelAnimated = False it slows it down with a for loop.
    ''' </summary>
    Private Sub StartAnimation()
        IsReelAnimated = True

        Do Until IsReelAnimated = False
            Dim randomSymbol = CovnvertDigitalReelToPhysical(Int((Upperbound * Rnd()) + Lowerbound) Mod DivisionValue)

            picture.Invoke(Sub()
                               picture.Image = randomSymbol.Symbol
                           End Sub)

            Thread.Sleep(10)
        Loop

        For speedShift As Integer = 10 To 100 Step 5
            Dim randomSymbol = CovnvertDigitalReelToPhysical(Int((Upperbound * Rnd()) + Lowerbound) Mod DivisionValue)
            picture.Invoke(Sub()
                               picture.Image = randomSymbol.Symbol
                           End Sub)

            Thread.Sleep(speedShift)
        Next

        SelectedSymbol = CovnvertDigitalReelToPhysical(CalculateDigitalReel())
        picture.Invoke(Sub()
                           picture.Image = SelectedSymbol.Symbol
                       End Sub)

    End Sub
End Class

Public Class Symbol
    Public WinningSymbolNumbers As Integer()
    Public Symbol As Image
    Public Name As String
    Public Sub New(WinningSymbol As Integer(), Name As String)
        Me.WinningSymbolNumbers = WinningSymbol
        Me.Name = Name
    End Sub
End Class
