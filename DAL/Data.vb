Imports System.Configuration
Imports System.Data.SqlClient
Public Class Data

    Private conexion As SqlConnection
    Public Sub Abrir()
        conexion = New SqlConnection()
        conexion.ConnectionString = ConfigurationManager.ConnectionStrings("dbContext").ConnectionString
        conexion.Open()
    End Sub

    Public Sub Cerrar()
        conexion.Close()
        conexion.Dispose()
        conexion = Nothing
        GC.Collect()
    End Sub

    Public Function Leer(consulta As String) As DataTable
        Dim tabla As New DataTable()
        Try
            Abrir()
            Dim Da As New SqlDataAdapter(consulta, conexion)
            Da.Fill(tabla)
            Cerrar()
        Catch ex As SqlException
            MsgBox(ex)
        Catch ex As Exception
            MsgBox(ex)
        End Try
        Return tabla
    End Function

    Public Function Escribir(SQL As String) As Integer
        Dim filasAfectadas As Integer = 0
        Abrir()
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.Text
        cmd.Connection = conexion
        cmd.CommandText = SQL
        Try
            filasAfectadas = cmd.ExecuteNonQuery()
        Catch
            filasAfectadas = -1
        End Try
        Cerrar()
        Return filasAfectadas
    End Function

End Class
