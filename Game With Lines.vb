Public Class Form1

    Dim xMin1, xMax2, yMin1, yMax2, xMin2, xMax1, yMin2, yMax1 As Integer
    Dim mouse_position As Point
    Dim form_position As Point
    Dim mouse_angle As Double
    Dim score As Integer

    Public Structure bullets
        Public x As Integer
        Public y As Integer
        Public vector_x As Double
        Public vector_y As Double
        Public on_screen As Boolean
    End Structure

    Public Structure enemys
        Public x As Integer
        Public y As Integer
        Public alive As Integer
    End Structure

    Dim gameEnemy(100) As enemys
    Dim gameBullets(100) As bullets

    Private Sub Form1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Line1 As System.Drawing.Graphics
        Dim PenLine As New System.Drawing.Pen(System.Drawing.Color.Black)
        Dim Red As New System.Drawing.Pen(System.Drawing.Color.Red)
        Line1 = Me.CreateGraphics

        Line1.DrawLine(Red, mouse_position.X - 5, mouse_position.Y, mouse_position.X + 5, mouse_position.Y)
        Line1.DrawLine(Red, mouse_position.X, mouse_position.Y - 5, mouse_position.X, mouse_position.Y + 5)



        For i As Integer = 0 To 100 Step 1

            If gameEnemy(i).alive = True Then
                'Line1.DrawLine(PenLine, gameEnemy(i).x - 10, gameEnemy(i).y, gameEnemy(i).x + 10, gameEnemy(i).y)
                'Line1.DrawLine(PenLine, gameEnemy(i).x + 10, gameEnemy(i).y, gameEnemy(i).x + 10, gameEnemy(i).y + 10)
                'Line1.DrawLine(PenLine, gameEnemy(i).x, gameEnemy(i).y - 10, gameEnemy(i).x, gameEnemy(i).y + 10)
                'Line1.DrawLine(PenLine, gameEnemy(i).x + 10, gameEnemy(i).y - 10, gameEnemy(i).x, gameEnemy(i).y - 10)
                ' Line1.DrawLine(PenLine, gameEnemy(i).x - 10, gameEnemy(i).y, gameEnemy(i).x - 10, gameEnemy(i).y - 10)
                'Line1.DrawLine(PenLine, gameEnemy(i).x, gameEnemy(i).y + 10, gameEnemy(i).x - 10, gameEnemy(i).y + 10)

                Line1.DrawLine(PenLine, gameEnemy(i).x, gameEnemy(i).y, gameEnemy(i).x + 10, gameEnemy(i).y + 10)
                Line1.DrawLine(PenLine, gameEnemy(i).x, gameEnemy(i).y, gameEnemy(i).x + 10, gameEnemy(i).y - 10)
                Line1.DrawLine(PenLine, gameEnemy(i).x + 10, gameEnemy(i).y + 10, gameEnemy(i).x + 20, gameEnemy(i).y)
                Line1.DrawLine(PenLine, gameEnemy(i).x + 10, gameEnemy(i).y - 10, gameEnemy(i).x + 20, gameEnemy(i).y)
                Line1.DrawLine(PenLine, gameEnemy(i).x + 10, gameEnemy(i).y + 10, gameEnemy(i).x + 10, gameEnemy(i).y + 30)
                Line1.DrawLine(PenLine, gameEnemy(i).x, gameEnemy(i).y + 10, gameEnemy(i).x + 20, gameEnemy(i).y + +10)
                Line1.DrawLine(PenLine, gameEnemy(i).x + 10, gameEnemy(i).y + 30, gameEnemy(i).x + 20, gameEnemy(i).y + 40)
                Line1.DrawLine(PenLine, gameEnemy(i).x, gameEnemy(i).y + 10, gameEnemy(i).x + 20, gameEnemy(i).y + +10)
                Line1.DrawLine(PenLine, gameEnemy(i).x + 10, gameEnemy(i).y + 30, gameEnemy(i).x, gameEnemy(i).y + 40)
            End If
        Next
        For i As Integer = 0 To 100 Step 1
            If gameBullets(i).on_screen = True Then
                Line1.DrawLine(PenLine, gameBullets(i).x, gameBullets(i).y, gameBullets(i).x + 1, gameBullets(i).y + 1)
                Line1.DrawLine(PenLine, gameBullets(i).x, gameBullets(i).y + 1, gameBullets(i).x + 1, gameBullets(i).y)
            End If

        Next
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Cursor.Hide()


    End Sub

    Private Sub GameTick_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GameTick.Tick


        mouse_position = Cursor.Position - Me.Location
        'mouse_position = New Point(Rnd() * 1000, Rnd() * 1000)

        Dim tan_1, tan_2 As Double

        tan_2 = 400 - (mouse_position.X)
        tan_1 = 300 - (mouse_position.Y)


        mouse_angle = Math.Atan2(tan_1, tan_2)
        Dim random_number As Integer
        random_number = Rnd() * 10
        If random_number = 1 Then
            Dim random As Integer
            random = Rnd() * 100
            gameEnemy(random).alive = True
            gameEnemy(random).x = Rnd() * 800
            gameEnemy(random).y = Rnd() * 600
        End If

        For i As Integer = 0 To 100 Step 1
            If gameBullets(i).on_screen = True Then
                gameBullets(i).x -= gameBullets(i).vector_x * 16
                gameBullets(i).y -= gameBullets(i).vector_y * 16
                If gameBullets(i).x > 800 Or gameBullets(i).y > 600 Or gameBullets(i).x < 0 Or gameBullets(i).y < 0 Then
                    gameBullets(i).on_screen = False

                End If
            End If

        Next

        For i As Integer = 0 To 100 Step 1
            If gameEnemy(i).alive = True Then

                xMin1 = 400
                xMax1 = 420
                yMin1 = 300
                yMax1 = 320

                xMin2 = gameEnemy(i).x
                xMax2 = gameEnemy(i).x + 20
                yMin2 = gameEnemy(i).y
                yMax2 = gameEnemy(i).y + 30

                If xMin1 < xMax2 And yMin1 < yMax2 And xMin2 < xMax1 And yMin2 < yMax1 Then
                    MsgBox("You lose hahahahaahahahahha")
                    End
                End If

                If gameEnemy(i).x > 400 Then
                    gameEnemy(i).x -= 2
                End If
                If gameEnemy(i).x < 400 Then
                    gameEnemy(i).x += 2

                End If
                If gameEnemy(i).y < 300 Then
                    gameEnemy(i).y += 2

                End If


                If gameEnemy(i).y > 300 Then
                    gameEnemy(i).y -= 2
                End If

                For j As Integer = 0 To 100 Step 1

                    xMin1 = gameBullets(j).x
                    xMax1 = gameBullets(j).x + 2
                    yMin1 = gameBullets(j).y
                    yMax1 = gameBullets(j).y + 2

                    xMin2 = gameEnemy(i).x
                    xMax2 = gameEnemy(i).x + 20
                    yMin2 = gameEnemy(i).y
                    yMax2 = gameEnemy(i).y + 30




                    If xMin1 < xMax2 And yMin1 < yMax2 And xMin2 < xMax1 And yMin2 < yMax1 Then
                        gameEnemy(i).alive = False
                        gameBullets(j).on_screen = False
                        score += 1
                    End If
                Next


            End If




        Next
        lblScore.Text = score

        Me.Refresh()


    End Sub

    Private Sub btnShoot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShoot.Click
        Dim fired_bullet As Boolean
        For i As Integer = 0 To 100 Step 1
            If fired_bullet = False And gameBullets(i).on_screen = False Then
                gameBullets(i).on_screen = True
                gameBullets(i).x = 400
                gameBullets(i).y = 300
                gameBullets(i).vector_x = Math.Cos(mouse_angle)
                gameBullets(i).vector_y = Math.Sin(mouse_angle)
                fired_bullet = True
            End If
        Next





    End Sub

  


End Class
