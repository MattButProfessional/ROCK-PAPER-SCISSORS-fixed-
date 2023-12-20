Module Module1
    'Matthew Burnham
    '12/12/2023
    'Rock Paper Scissors
    Dim Rand As New Random
    Dim compNum As Integer
    Dim usermove(4) As String
    Dim cmpmove(4) As String
    Dim results(4) As String
    Dim user As String
    Dim cmp As String
    Dim result As String
    Dim roundnum As Integer
    Dim numofwins As Double
    Dim numofloss As Double
    Dim numofties As Double
    Dim numofwinspercent As Double
    Dim numoflosspercent As Double
    Dim numoftiespercent As Double
    Sub Main()
        PrintTitle()
        For i As Integer = 0 To 4
            user = GetValidInput()
            cmp = ComputerMove()
            result = DetermineOutcome(user, cmp)
            Console.WriteLine("".PadRight(60, "-"))
            Console.WriteLine($"The user put down {user}")
            Console.WriteLine($"The computer put down {cmp}")
            Console.WriteLine($"You {result}")
            Console.WriteLine("".PadRight(60, "-"))
            usermove(i) = user
            cmpmove(i) = cmp
            results(i) = result
        Next
        PrintReport()
        Percentages()
    End Sub
    ''' <summary>
    ''' Prints out the title for the game
    ''' </summary>
    Sub PrintTitle()
        Console.WriteLine(".-. .-. .-. . .     .-. .-. .-. .-. .-.     .-. .-. .-. .-. .-. .-. .-. .-.
|(  | | |   |<      |-' |-| |-' |-  |(      `-. |    |  `-. `-. | | |(  `-.
' ' `-' `-' ' ` ,   '   ` ' '   `-' ' ' ,   `-' `-' `-' `-' `-' `-' ' ' `-'
    _______           _______               _______
---'   ____)      ---'   ____)____     ---'    ____)____
      (_____)               ______)               ______)
      (_____)               _______)           __________)
      (____)               _______)           (____)
---.__(___)       ---.__________)      ---.__(___)
")
    End Sub
    ''' <summary>
    ''' Asks the user what move they want to make
    ''' </summary>
    ''' <returns></returns>
    Function GetValidInput()
        Dim input As String
        Dim int As Integer = 0
        Do
            Console.Write("Enter 1 for Rock, 2 for Paper, and 3 for Scissors -> ")
            input = Console.ReadLine()
            Integer.TryParse(input, int)
            If int < 1 Or int > 3 Then
                Console.WriteLine("Invalid input, please try again")
                int = 0
            End If
        Loop While int = 0
        Return Conversion(int)
    End Function
    ''' <summary>
    ''' Gets a random number between 1 and 3 and returns it
    ''' </summary>
    ''' <returns></returns>
    Function ComputerMove()
        compNum = Rand.Next(1, 4)
        Return Conversion(compNum)
    End Function
    ''' <summary>
    ''' This makes the number into the corrisponding "Rock", "Paper", or "Scissors"
    ''' </summary>
    ''' <returns></returns>
    Function Conversion(input As Integer)
        If input = 1 Then
            Return "Rock"
        ElseIf input = 2 Then
            Return "Paper"
        ElseIf input = 3 Then
            Return "Scissors"
        Else
            Return "invalid"
        End If
    End Function
    ''' <summary>
    ''' it says if the outcome is a win, lose, or tie
    ''' </summary>
    ''' <returns></returns>
    Function DetermineOutcome(user As String, cmp As String)
        If (user = "Rock" AndAlso cmp = "Paper") Or (user = "Paper" AndAlso cmp = "Scissors") Or (user = "Scissors" AndAlso cmp = "Rock") Then
            numofloss += 1
            Return "Lose"
        ElseIf (cmp = "Rock" AndAlso user = "Paper") Or (cmp = "Paper" AndAlso user = "Scissors") Or (cmp = "Scissors" AndAlso user = "Rock") Then
            numofwins += 1
            Return "Win"
        ElseIf user = cmp Then
            numofties += 1
            Return "Tied"
        Else
            Return "invalid"
        End If
    End Function
    ''' <summary>
    ''' Prints the report table
    ''' </summary>
    Sub PrintReport()
        Console.WriteLine("".PadRight(60, "#"))
        Console.WriteLine("".PadRight("15", "#") & " Rock, Paper, Scissors Report ".PadRight(45, "#"))
        Console.WriteLine("".PadRight(60, "#"))
        Console.WriteLine("".PadRight(60, "-"))
        Console.WriteLine("|".PadRight(3) & "Round".PadRight(8) & "|".PadRight(4) & "User Played".PadRight(14) & "|".PadRight(3) & "Computer Played".PadRight(17) & "|".PadRight(2) & "Outcome".PadRight(8) & "|")
        For i As Integer = 0 To 4
            roundnum += 1
            Console.WriteLine("".PadRight(60, "-"))
            Console.WriteLine("|".PadRight(3) & roundnum.ToString.PadRight(8) & "|".PadRight(4) & usermove(i).ToString.PadRight(14) & "|".PadRight(3) & cmpmove(i).ToString.PadRight(17) & "|".PadRight(2) & results(i).ToString.PadRight(8) & "|")
        Next
        Console.WriteLine("".PadRight(60, "-"))
    End Sub
    ''' <summary>
    ''' Calculates and prints out the percentages
    ''' </summary>
    Sub Percentages()
        numofwinspercent = numofwins / 5
        numoflosspercent = numofloss / 5
        numoftiespercent = numofties / 5
        Console.WriteLine($"You won {numofwinspercent.ToString("P2")} of the matches")
        Console.WriteLine($"You lost {numoflosspercent.ToString("P2")} of the matches")
        Console.WriteLine($"You tied {numoftiespercent.ToString("P2")} of the matches")
        If numofwins > numofloss Then
            Console.WriteLine("You won the series!")
        ElseIf numofloss > numofwins Then
            Console.WriteLine("You lost the series!")
        Else
            Console.WriteLine("You have tied the series!")
        End If
    End Sub
End Module
