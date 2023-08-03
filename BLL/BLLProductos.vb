Imports DAL
Public Class BLLProductos
    Inherits Entidad

    Private _Nombre As String
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            _Nombre = value
        End Set
    End Property

    Private _Precio As Double
    Public Property Precio() As Double
        Get
            Return _Precio
        End Get
        Set(ByVal value As Double)
            _Precio = value
        End Set
    End Property

    Private _Categoria As String
    Public Property Categoria() As String
        Get
            Return _Categoria
        End Get
        Set(ByVal value As String)
            _Categoria = value
        End Set
    End Property

    Public Sub Alta(producto As BLLProductos)
        Dim base As New Data
        Dim valorprecio As String = producto.Precio.ToString.Replace(",", ".")
        Dim ConsultaSql As String = "Insert into productos (Nombre,Precio,Categoria) values ('" & producto.Nombre & "','" & valorprecio & "','" & producto.Categoria & "')"
        base.Escribir(ConsultaSql)
    End Sub

    Public Sub Modificar(producto As BLLProductos)
        Dim base As New Data
        Dim valorprecio As String = producto.Precio.ToString.Replace(",", ".")
        Dim ConsultaSql As String = "Update productos SET Nombre = '" & producto.Nombre & "',Precio = '" & valorprecio & "',Categoria = '" & producto.Categoria & "' where ID = " & producto.ID & ""
        base.Escribir(ConsultaSql)
    End Sub

    Public Sub Eliminar(producto As BLLProductos)
        Dim base As New Data
        Dim ConsultaSql As String = "Delete From productos where ID = " & producto.ID & ""
        base.Escribir(ConsultaSql)
    End Sub

    Public Function Listar() As DataTable
        Dim odatos As New Data
        Dim sql As String = "Select ID,Nombre,Precio,Categoria from productos"
        Return odatos.Leer(sql)
    End Function

    Public Function BuscarProductoPorNombre(nombre As String)
        Dim odatos As New Data
        Dim sql As String
        sql = "Select ID,Nombre,Precio,Categoria from productos where Nombre LIKE '" & nombre & "%'"
        Return odatos.Leer(sql)
    End Function
    Public Function BuscarProductoPorCategoria(categoria As String)
        Dim odatos As New Data
        Dim sql As String
        sql = "Select ID,Nombre,Precio,Categoria from productos where Categoria LIKE '" & categoria & "%'"
        Return odatos.Leer(sql)
    End Function

    Public Function BuscarProductoPorPrecio(precio As Double)
        Dim odatos As New Data
        Dim sql As String
        Dim valorprecio As String = precio.ToString.Replace(",", ".")
        sql = "Select ID,Nombre,Precio,Categoria from productos where Precio LIKE '" & valorprecio & "%'"
        Return odatos.Leer(sql)
    End Function

    Public Function VerificarPrecio(nombre As String) As Double
        Dim odatos As New Data
        Dim sql As String
        sql = "Select Precio from productos where Nombre = '" & nombre & "'"
        Dim valor As Double
        Dim tabla As New DataTable

        tabla = odatos.Leer(sql)

        For Each row As DataRow In tabla.Rows

            valor = CStr(row("Precio"))

        Next
        Return valor
    End Function

    Public Function BuscarProductoID(nombre As String) As Integer
        Dim odatos As New Data
        Dim sql As String
        sql = "Select ID from productos where Nombre = '" & nombre & "'"
        Dim valor As Integer
        Dim tabla As New DataTable

        tabla = odatos.Leer(sql)

        For Each row As DataRow In tabla.Rows

            valor = CStr(row("ID"))

        Next
        Return valor
    End Function

    Public Function BuscarProductoCompleto(nombre As String) As BLLProductos
        Dim odatos As New Data
        Dim sql As String
        sql = "Select * from productos where Nombre = '" & nombre & "'"
        Dim prod As New BLLProductos
        Dim tabla As New DataTable

        tabla = odatos.Leer(sql)

        For Each row As DataRow In tabla.Rows

            prod.ID = CStr(row("ID"))
            prod.Nombre = CStr(row("Nombre"))
            prod.Precio = CStr(row("Precio"))
            prod.Categoria = CStr(row("Categoria"))

        Next
        Return prod
    End Function

    Public Function VerificarExistencia(nombre As String) As Boolean
        Dim odatos As New Data
        Dim sql As String
        sql = "Select * from productos where Nombre = '" & nombre & "'"
        Dim verificador As Boolean = False
        Dim tabla As New DataTable

        tabla = odatos.Leer(sql)

        For Each row As DataRow In tabla.Rows

            verificador = True

        Next

        Return verificador
    End Function

    Public Function BuscarProductoCompletoPorID(id As Integer) As BLLProductos
        Dim odatos As New Data
        Dim sql As String
        sql = "Select * from productos where ID = '" & id & "'"
        Dim prod As New BLLProductos
        Dim tabla As New DataTable

        tabla = odatos.Leer(sql)

        For Each row As DataRow In tabla.Rows

            prod.ID = CStr(row("ID"))
            prod.Nombre = CStr(row("Nombre"))
            prod.Precio = CStr(row("Precio"))
            prod.Categoria = CStr(row("Categoria"))

        Next
        Return prod
    End Function


    Public Overrides Function ToString() As String
        Return Nombre
    End Function

End Class
