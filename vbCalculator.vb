Public Class frmCalculator

    Dim val1 As String = ""
    Dim val2 As String = ""
    Dim val3 As Double = 0.0

    Private Sub equal_click(sender As Object, e As EventArgs) Handles btnEqual.Click
        If val1 > "" And val2 = "+" Then
            TextBox1.Text = Val(val1) + Val(TextBox1.Text)
            val3 = TextBox1.Text
        ElseIf val1 > "" And val2 = "-" Then
            TextBox1.Text = Val(val1) - Val(TextBox1.Text)
            val3 = TextBox1.Text
        ElseIf val1 > "" And val2 = "*" Then
            TextBox1.Text = Val(val1) * Val(TextBox1.Text)
            val3 = TextBox1.Text
        ElseIf val1 > "" And val2 = "/" Then
            TextBox1.Text = Val(val1) / Val(TextBox1.Text)
            val3 = TextBox1.Text
        Else
            TextBox1.Text = "ERROR"
        End If

        val1 = ""
        val2 = ""

    End Sub

    Private Sub operation_click(sender As Object, e As EventArgs) Handles btnAdd.Click, btnDivide.Click, btnMulti.Click, btnSub.Click
        val2 = sender.text
        val1 = TextBox1.Text
    End Sub
    Private Sub numbers_Click(sender As Object, e As EventArgs) Handles btnSeven.Click, btnEight.Click, btnNine.Click, btnFour.Click, btnFive.Click, btnSix.Click, btnOne.Click, btnTwo.Click, btnThree.Click, btnZero.Click, btnDot.Click



        Select Case sender.text
            Case "0"
                If TextBox1.Text = "0" Or TextBox1.Text = "0." Then
                    TextBox1.Text = "0."
                ElseIf TextBox1.Text = System.Convert.ToString(val3) Or TextBox1.Text = val1 Then
                    TextBox1.Text = sender.text
                Else
                    TextBox1.Text = TextBox1.Text & sender.text
                End If
            Case "."
                If TextBox1.Text <> "" And Not TextBox1.Text.Contains(".") Then
                    TextBox1.Text = TextBox1.Text & "."
                ElseIf TextBox1.Text = "0" Or TextBox1.Text = val1 Then
                    TextBox1.Text = "0."
                Else
                    Exit Sub
                End If
            Case Else
                If TextBox1.Text = val1 Or TextBox1.Text = "0" Or TextBox1.Text = System.Convert.ToString(val3) Then
                    TextBox1.Text = sender.text
                ElseIf TextBox1.Text = "-" Then
                    TextBox1.Text = TextBox1.Text & sender.text
                Else
                    TextBox1.Text = TextBox1.Text & sender.text ' if there is already a value in there just combine them
                End If


        End Select

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = "0"
    End Sub

    Private Sub backSpace_Click(sender As Object, e As EventArgs) Handles btnBS.Click ' Backspace

        If TextBox1.Text = "" Or val3 Or TextBox1.Text = "ERROR" Then
            val3 = 0.0
            TextBox1.Text = "0"

        ElseIf TextBox1.Text <> "" Then
            TextBox1.Text = Mid(TextBox1.Text, 1, Len(TextBox1.Text) - 1) ' Give back the string minus one digit
            If Len(TextBox1.Text) = 0 Then
                TextBox1.Text = "0"
            End If

        Else
            Exit Sub

        End If


    End Sub

    Private Sub neqativeSign_Click(sender As Object, e As EventArgs) Handles btnSign.Click

        If Not TextBox1.Text = val3 OrElse TextBox1.Text = "-" Then ' This is to prevent the user from changing the final result by adding a "-"
            TextBox1.Text = Val(TextBox1.Text) * -1

        End If
    End Sub

    Private Sub clear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        val1 = ""
        val2 = ""
        val3 = 0.0
        TextBox1.Text = "0"

    End Sub
    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If TextBox1.Text = "0" OrElse TextBox1.Text = val1 Then ' So that we don't have to delete the zero and to clear the value if we want to add the second operand

            TextBox1.Text = ""
        End If

        If Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then ' Dont allow anything that is not a backspace or a number
            e.Handled = True
        End If

    End Sub
End Class
