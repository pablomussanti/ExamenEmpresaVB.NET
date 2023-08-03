Imports DAL
Public Class BLLVentas
    Inherits Entidad

    Private _Cliente As BLLClientes
    Public Property Cliente() As BLLClientes
        Get
            Return _Cliente
        End Get
        Set(ByVal value As BLLClientes)
            _Cliente = value
        End Set
    End Property

    Private _IDCliente As Integer
    Public Property IDCliente() As Integer
        Get
            Return _IDCliente
        End Get
        Set(ByVal value As Integer)
            _IDCliente = value
        End Set
    End Property

    Private _Fecha As Date
    Public Property Fecha() As Date
        Get
            Return _Fecha
        End Get
        Set(ByVal value As Date)
            _Fecha = value
        End Set
    End Property

    Private _Total As Double
    Public Property Total() As Double
        Get
            Return _Total
        End Get
        Set(ByVal value As Double)
            _Total = value
        End Set
    End Property


    Public Sub Alta(venta As BLLVentas)
        Dim base As New Data
        Dim valorprecio As String = venta.Total.ToString.Replace(",", ".")
        Dim ConsultaSql As String = "Insert into ventas (IDCliente,Fecha,Total) values ('" & venta.IDCliente & "','" & venta.Fecha & "','" & valorprecio & "')"
        base.Escribir(ConsultaSql)
    End Sub

    'Public Sub Modificar(venta As BLLVentas)
    '    Dim base As New Data
    '    Dim ConsultaSql As String = "Update ventas SET IDCliente = '" & venta.IDCliente & "',Fecha = '" & venta.Fecha & "',Total = '" & venta.Total & "' where ID = " & venta.ID & ""
    '    base.Escribir(ConsultaSql)
    'End Sub

    Public Sub EliminarVenta(venta As BLLVentas)
        Dim base As New Data
        Dim ConsultaSql As String = "Delete From ventas where ID = '" & venta.ID & "'"
        base.Escribir(ConsultaSql)
    End Sub

    Public Function Listar() As DataTable
        Dim odatos As New Data
        Dim sql As String = "Select ID,IDCliente,Fecha,Total from ventas"
        Return odatos.Leer(sql)
    End Function

    Public Function TraerUltimaVenta() As Integer
        Dim odatos As New Data
        Dim sql As String = "SELECT ID FROM ventas WHERE ID = (SELECT MAX(ID) FROM ventas)"
        Dim valor As Integer
        Dim tabla As New DataTable

        tabla = odatos.Leer(sql)

        For Each row As DataRow In tabla.Rows

            valor = CStr(row("ID"))

        Next

        Return valor
    End Function

    Public Function TraerVentasPorCliente(cliente As BLLClientes) As List(Of BLLVentas)
        Dim odatos As New Data
        Dim sql As String = "SELECT ID,IDCliente,Fecha,Total FROM ventas WHERE IDCliente = '" & cliente.ID & "'"
        Dim venta As New List(Of BLLVentas)
        Dim cli As New BLLClientes
        Dim tabla As New DataTable

        tabla = odatos.Leer(sql)

        For Each row As DataRow In tabla.Rows
            Dim vnt As New BLLVentas
            vnt.ID = CStr(row("ID"))
            vnt.IDCliente = CStr(row("IDCliente"))
            vnt.Cliente = cli.BuscarClienteCompletoPorID(vnt.IDCliente)
            vnt.Fecha = CStr(row("Fecha"))
            vnt.Total = CStr(row("Total"))
            venta.Add(vnt)
        Next

        Return venta
    End Function

    Public Function BuscarVentaCompletoPorID(id As Integer) As BLLVentas
        Dim odatos As New Data
        Dim sql As String
        sql = "Select * from ventas where ID = '" & id & "'"
        Dim vnt As New BLLVentas
        Dim cli As New BLLClientes
        Dim tabla As New DataTable

        tabla = odatos.Leer(sql)

        For Each row As DataRow In tabla.Rows

            vnt.ID = CStr(row("ID"))
            vnt.IDCliente = CStr(row("IDCliente"))
            vnt.Cliente = cli.BuscarClienteCompletoPorID(vnt.IDCliente)
            vnt.Fecha = CStr(row("Fecha"))
            vnt.Total = CStr(row("Total"))

        Next

        Return vnt
    End Function

    Public Function VerificarIntegridad(vntitems As DataTable) As List(Of BLLVentas)
        Dim lstventas As New List(Of BLLVentas)
        Dim vnt As New BLLVentas

        For Each row As DataRow In vntitems.Rows
            lstventas.Add(BuscarVentaCompletoPorID(row("ID")))

        Next
        Return lstventas
    End Function

    Public Function TotalVentasPorMes() As DataTable
        Dim odatos As New Data
        Dim sql As String
        sql = "SELECT sum(Total) AS total,MONTH(fecha) as Mes,YEAR(fecha) as Año  FROM ventas group by MONTH(fecha),Year(Fecha) order by Year(Fecha) DESC,MONTH(fecha) DESC"
        Dim prd As New BLLProductos
        Dim tabla As New DataTable
        Dim vnt As New BLLVentas
        Dim datasetvista As New DataTable
        datasetvista.Columns.Add("Mes")
        datasetvista.Columns.Add("Total")

        tabla = odatos.Leer(sql)

        For Each row As DataRow In tabla.Rows
            Dim renglon As DataRow = datasetvista.NewRow()
            Dim fechacompleta As String
            fechacompleta = row("Mes")
            renglon("Mes") = fechacompleta
            vnt.Total = CStr(row("Total"))
            renglon("Total") = vnt.Total.ToString.Replace(",", ".")

            datasetvista.Rows.Add(renglon)

        Next
        Return datasetvista
    End Function

    Public Overrides Function ToString() As String
        Return ID
    End Function

End Class
