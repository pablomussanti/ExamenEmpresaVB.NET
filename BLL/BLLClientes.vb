Imports DAL
Public Class BLLClientes
    Inherits Entidad

    Private _Cliente As String
    Public Property Cliente() As String
        Get
            Return _Cliente
        End Get
        Set(ByVal value As String)
            _Cliente = value
        End Set
    End Property

    Private _Telefono As String
    Public Property Telefono() As String
        Get
            Return _Telefono
        End Get
        Set(ByVal value As String)
            _Telefono = value
        End Set
    End Property

    Private _Correo As String
    Public Property Correo() As String
        Get
            Return _Correo
        End Get
        Set(ByVal value As String)
            _Correo = value
        End Set
    End Property

    Public Sub Alta(cliente As BLLClientes)
        Dim base As New Data
        Dim ConsultaSql As String = "Insert into clientes (Cliente,Telefono,Correo) values ('" & cliente.Cliente & "','" & cliente.Telefono & "','" & cliente.Correo & "')"
        base.Escribir(ConsultaSql)
    End Sub

    Public Sub Modificar(cliente As BLLClientes)
        Dim base As New Data
        Dim ConsultaSql As String = "Update clientes SET Cliente = '" & cliente.Cliente & "',Telefono = '" & cliente.Telefono & "',Correo = '" & cliente.Correo & "' where ID = " & cliente.ID & ""
        base.Escribir(ConsultaSql)
    End Sub

    Public Sub Eliminar(cliente As BLLClientes)
        Dim base As New Data
        Dim ConsultaSql As String = "Delete From clientes where ID = " & cliente.ID & ""
        base.Escribir(ConsultaSql)
    End Sub

    Public Function Listar() As DataTable
        Dim odatos As New Data
        Dim sql As String = "Select ID,Cliente,Telefono,Correo from clientes"
        Return odatos.Leer(sql)
    End Function

    Public Function BuscarClientePorEmail(email As String, filtro As Boolean)
        Dim odatos As New Data
        Dim sql As String
        If filtro = True Then
            sql = "Select DISTINCT cli.ID,cli.Cliente,cli.Telefono,cli.Correo from clientes as cli inner join ventas as vent on vent.IDCliente = cli.ID where cli.Correo LIKE '" & email & "%'"
        Else
            sql = "Select ID,Cliente,Telefono,Correo from clientes where Correo LIKE '" & email & "%'"
        End If
        Return odatos.Leer(sql)
    End Function

    Public Function BuscarClientePorTelefono(telefono As String, filtro As Boolean)
        Dim odatos As New Data
        Dim sql As String
        If filtro = True Then
            sql = "Select DISTINCT cli.ID,cli.Cliente,cli.Telefono,cli.Correo from clientes as cli inner join ventas as vent on vent.IDCliente = cli.ID where cli.Telefono LIKE '" & telefono & "%'"
        Else
            sql = "Select ID,Cliente,Telefono,Correo from clientes where Telefono LIKE '" & telefono & "%'"
        End If
        Return odatos.Leer(sql)
    End Function

    Public Function BuscarClientePorNombre(nombre As String, filtro As Boolean)
        Dim odatos As New Data
        Dim sql As String
        If filtro = True Then
            sql = "Select DISTINCT cli.ID,cli.Cliente,cli.Telefono,cli.Correo from clientes as cli inner join ventas as vent on vent.IDCliente = cli.ID where cli.Correo LIKE '" & nombre & "%'"
        Else
            sql = "Select ID,Cliente,Telefono,Correo from clientes where Correo LIKE '" & nombre & "%'"
        End If
        Return odatos.Leer(sql)
    End Function


    Public Function BuscarClienteID(email As String) As Integer
        Dim odatos As New Data
        Dim sql As String
        sql = "Select ID,Cliente,Telefono,Correo from clientes where Correo LIKE '" & email & "%'"
        Dim valor As Integer
        Dim tabla As New DataTable

        tabla = odatos.Leer(sql)

        For Each row As DataRow In tabla.Rows

            valor = CStr(row("ID"))

        Next
        Return valor
    End Function

    Public Function VerificarExistencia(nombre As String) As Boolean
        Dim odatos As New Data
        Dim sql As String
        sql = "Select * from clientes where Correo = '" & nombre & "'"
        Dim verificador As Boolean = False
        Dim tabla As New DataTable

        tabla = odatos.Leer(sql)

        For Each row As DataRow In tabla.Rows

            verificador = True

        Next

        Return verificador
    End Function

    Public Function BuscarClienteCompletoPorID(id As Integer) As BLLClientes
        Dim odatos As New Data
        Dim sql As String
        sql = "Select * from clientes where ID = '" & id & "'"
        Dim cli As New BLLClientes
        Dim tabla As New DataTable

        tabla = odatos.Leer(sql)

        For Each row As DataRow In tabla.Rows

            cli.ID = CStr(row("ID"))
            cli.Cliente = CStr(row("Cliente"))
            cli.Telefono = CStr(row("Telefono"))
            cli.Correo = CStr(row("Correo"))

        Next
        Return cli
    End Function

    Public Overrides Function ToString() As String
        Return Correo
    End Function
End Class
