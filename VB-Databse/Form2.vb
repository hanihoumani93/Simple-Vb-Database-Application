
Imports MySql.Data.MySqlClient

Public Class Form2
    Dim gender As String
    Dim MySqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Dim READER As MySqlDataReader
    Dim dbDataTable As New DataTable 'It help us to bind the data taken from db with the GridView'

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
        Me.Hide()



    End Sub

    Private Sub LoadTable()
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString =
           "server=localhost;user id=root;persistsecurityinfo=True;database=hani;password=Ray-07767767"
        Dim SDA As New MySqlDataAdapter 'It help us to get the data from the database'

        Dim bSource As New BindingSource 'It help us to bind the data taken from db with the GridView'
        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "Select id as 'Employee ID',fname as 'FirstName',lname as 'LastName',age as 'Age' From hani.vbusers "


            COMMAND = New MySqlCommand(Query, MySqlConn)
            SDA.SelectCommand = COMMAND 'This will perform your query'
            SDA.Fill(dbDataTable) 'This will fill DataTable with all values taken from SDA (query)'
            bSource.DataSource = dbDataTable 'The DataSet now have the values so it bind them with DataTable '
            DataGridView1.DataSource = bSource 'Fill The GridView with data taken from Database (bSource)'
            SDA.Update(dbDataTable)

            MySqlConn.Close()



        Catch ex As MySqlException
            MessageBox.Show(ex.Message)

        Finally
            MySqlConn.Dispose()

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString =
           "server=localhost;user id=root;persistsecurityinfo=True;database=hani;password=Ray-07767767;"
        Dim READER As MySqlDataReader
        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "insert into hani.vbusers (id,fname,lname,age,gender,DOB) values ('" & txtId.Text & "','" & txtFname.Text & "','" & txtLname.Text & "','" & txtAge.Text & "','" & gender & "','" & DateTimePicker1.Text & "' )"


            COMMAND = New MySqlCommand(Query, MySqlConn)

            READER = COMMAND.ExecuteReader
            MessageBox.Show("Data Saved!")
            MySqlConn.Close()
            LoadTable()


        Catch ex As MySqlException
            MessageBox.Show(ex.Message)

        Finally
            MySqlConn.Dispose()

        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString =
           "server=localhost;user id=root;persistsecurityinfo=True;database=hani;password=Ray-07767767"
        Dim READER As MySqlDataReader
        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "update hani.vbusers set id='" & txtId.Text & "',fname='" & txtFname.Text & "',lname='" & txtLname.Text & "',age='" & txtAge.Text & "', gender='" & gender & "', DOB='" & DateTimePicker1.Text & "'  where id='" & txtId.Text & "'"


            COMMAND = New MySqlCommand(Query, MySqlConn)

            READER = COMMAND.ExecuteReader
            MessageBox.Show("Data Updated!")
            MySqlConn.Close()

            LoadTable()

        Catch ex As MySqlException
            MessageBox.Show(ex.Message)

        Finally
            MySqlConn.Dispose()

        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString =
           "server=localhost;user id=root;persistsecurityinfo=True;database=hani;password=Ray-07767767"
        Dim READER As MySqlDataReader
        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "Delete From hani.vbusers where id='" & txtId.Text & "'"


            COMMAND = New MySqlCommand(Query, MySqlConn)

            READER = COMMAND.ExecuteReader
            MessageBox.Show("Data Deleted!")
            MySqlConn.Close()

            LoadTable()

        Catch ex As MySqlException
            MessageBox.Show(ex.Message)

        Finally
            MySqlConn.Dispose()

        End Try
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString =
           "server=localhost;user id=root;persistsecurityinfo=True;database=hani;password=Ray-07767767"
        Dim READER As MySqlDataReader
        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "Select * From hani.vbusers "


            COMMAND = New MySqlCommand(Query, MySqlConn)

            READER = COMMAND.ExecuteReader
            While READER.Read
                Dim sName = READER.GetString("fname")
                ComboBox1.Items.Add(sName)
            End While
            MySqlConn.Close()



        Catch ex As MySqlException
            MessageBox.Show(ex.Message)

        Finally
            MySqlConn.Dispose()

        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString =
           "server=localhost;user id=root;persistsecurityinfo=True;database=hani;password=Ray-07767767"
        Dim READER As MySqlDataReader
        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "Select * From hani.vbusers where fname = '" & ComboBox1.Text & "' "


            COMMAND = New MySqlCommand(Query, MySqlConn)

            READER = COMMAND.ExecuteReader
            While READER.Read
                txtId.Text = READER.GetInt32("id")
                txtFname.Text = READER.GetString("fname")
                txtLname.Text = READER.GetString("lname")
                txtAge.Text = READER.GetInt32("age")

            End While
            MySqlConn.Close()



        Catch ex As MySqlException
            MessageBox.Show(ex.Message)

        Finally
            MySqlConn.Dispose()

        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString =
           "server=localhost;user id=root;persistsecurityinfo=True;database=hani;password=Ray-07767767;convert zero datetime=True"
        Dim SDA As New MySqlDataAdapter 'It help us to get the data from the database'

        Dim bSource As New BindingSource 'It help us to bind the data taken from db with the GridView'
        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "Select id as 'Employee ID',fname as 'FirstName',lname as 'LastName',age as 'Age', gender as 'Gender',  DOB as 'DOB' From hani.vbusers "


            COMMAND = New MySqlCommand(Query, MySqlConn)
            SDA.SelectCommand = COMMAND 'This will perform your query'
            SDA.Fill(dbDataTable) 'This will fill DataTable with all values taken from SDA (query)'
            bSource.DataSource = dbDataTable 'The DataSet now have the values so it bind them with DataTable '
            DataGridView1.DataSource = bSource 'Fill The GridView with data taken from Database (bSource)'
            SDA.Update(dbDataTable)

            MySqlConn.Close()



        Catch ex As MySqlException
            MessageBox.Show(ex.Message)

        Finally
            MySqlConn.Dispose()

        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Dim DV As New DataView(dbDataTable)
        DV.RowFilter = String.Format("fname Like '%" & txtSearch.Text & "%'")
        DataGridView1.DataSource = DV
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString =
           "server=localhost;user id=root;persistsecurityinfo=True;database=hani;password=Ray-07767767"
        Dim READER As MySqlDataReader
        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "Select * From hani.vbusers"

            COMMAND = New MySqlCommand(Query, MySqlConn)

            READER = COMMAND.ExecuteReader
            While READER.Read
                Chart1.Series("Name_VS_Age").Points.AddXY(READER.GetString("fname"), READER.GetInt32("age"))

            End While

            MySqlConn.Close()



        Catch ex As MySqlException
            MessageBox.Show(ex.Message)

        Finally
            MySqlConn.Dispose()

        End Try
    End Sub

    Private Sub Form2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim dialog As DialogResult
        dialog = MessageBox.Show("Do you really want to close the app?", "Exit", MessageBoxButtons.YesNo)
        If dialog = DialogResult.No Then
            e.Cancel = True
        Else
            Application.ExitThread()
        End If
    End Sub

    Private Sub Chart1_Click(sender As Object, e As EventArgs) Handles Chart1.Click

    End Sub

    Private Sub RadioButton_male_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_male.CheckedChanged
        gender = "Male"
    End Sub

    Private Sub RadioButton_female_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_female.CheckedChanged
        gender = "Female"
    End Sub
End Class



