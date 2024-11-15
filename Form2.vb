Imports MySql.Data.MySqlClient

Public Class Form2
    Dim cmd As New MySqlCommand
    Dim result As Integer
    Dim model, plateno, type As String
    Dim query As String

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles Me.Load
        databaseConnect()

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        model = txtmodel.Text
        type = txttype.Text
        plateno = txtplatenumber.Text
        query = "INSERT INTO vehicleinfo(vType," &
            "plateNo, vModel) VALUES ('" &
            type & "','" & plateno & "','" &
            model & "')"

        If type <> "" And model <> "" And plateno <> "" Then
            Try

                With cmd
                    .Connection = datacon
                    .CommandText = query
                    result = .ExecuteNonQuery
                    If result > 0 Then
                        MsgBox("saved successful!")
                        txtmodel.Clear()
                        txtplatenumber.Clear()
                        txttype.Clear()

                    Else
                        MsgBox("Failed to insert record")

                    End If

                End With
            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
        End If
        MsgBox("Fill in the info")


    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnback.Click
        Form1.Show()
        Me.Hide()
    End Sub
End Class



