Imports MySql.Data.MySqlClient
Public Class Form1
    Dim query As String
    Dim tableInfo As DataTable 'hold record from mysql
    Dim da As MySqlDataAdapter ' handle sql query
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'call databaseConnect procedure to open connection 
        databaseConnect()
    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        End
    End Sub

    Private Sub btnload_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Try
            query = "SELECT * FROM  vehicleinfo"
            'send sql query to server'
            da = New MySqlDataAdapter(query, datacon)
            tableInfo = New DataTable
            'Fill the table 
            da.Fill(tableInfo)
            'display record in data grid view
            dataRecord.DataSource = tableInfo
            datacon.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            datacon.Close()
        End Try
    End Sub

    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        Form2.Show()
        Me.Hide()
    End Sub
End Class

