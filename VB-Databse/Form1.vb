Imports MySql.Data.MySqlClient


Public Class Form1
    Dim MySqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Dim READER As MySqlDataReader

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString =
            "server=localhost;user id=root;persistsecurityinfo=True;database=hani;password=Ray-07767767"
        Try

            MySqlConn.Open()
            MessageBox.Show("Connection Successful!")




        Catch ex As MySqlException
            MessageBox.Show(ex.Message)

        Finally
            MySqlConn.Dispose()

        End Try




    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MySqlConn = New MySqlConnection



        MySqlConn.ConnectionString =
            "server=localhost;user id=root;persistsecurityinfo=True;database=hani;password=Ray-07767767"



        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "SELECT * FROM hani.login WHERE username = '" & username.Text & "' AND password = '" & password.Text & "'"


            COMMAND = New MySqlCommand(Query, MySqlConn)

            READER = COMMAND.ExecuteReader
            Dim count As Integer
            count = 0

            While READER.Read
                count = count + 1
            End While

            If count = 1 Then

                MessageBox.Show("Login Successful")
                Form2.Show()
                Me.Hide()





            ElseIf count > 1 Then

                MessageBox.Show("Login Successful But its Duplicated!")
            Else
                MessageBox.Show("Login Faled")
            End If

        Catch ex As MySqlException
            MessageBox.Show(ex.Message)

        Finally
            MySqlConn.Dispose()

        End Try
    End Sub
End Class
