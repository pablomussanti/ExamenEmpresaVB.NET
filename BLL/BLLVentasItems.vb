Imports DAL
Public Class BLLVentasItems
    Inherits Entidad

    Private _IDVenta As Integer
    Public Property IDVenta() As Integer
        Get
            Return _IDVenta
        End Get
        Set(ByVal value As Integer)
            _IDVenta = value
        End Set
    End Property

    Private _Venta As BLLVentas
    Public Property Venta() As BLLVentas
        Get
            Return _Venta
        End Get
        Set(ByVal value As BLLVentas)
            _Venta = value
        End Set
    End Property

    Private _IDProducto As Integer
    Public Property IDProducto() As Integer
        Get
            Return _IDProducto
        End Get
        Set(ByVal value As Integer)
            _IDProducto = value
        End Set
    End Property

    Private _Producto As BLLProductos
    Public Property Producto() As BLLProductos
        Get
            Return _Producto
        End Get
        Set(ByVal value As BLLProductos)
            _Producto = value
        End Set
    End Property

    Private _PrecioUnitario As Double
    Public Property PrecioUnitario() As Double
        Get
            Return _PrecioUnitario
        End Get
        Set(ByVal value As Double)
            _PrecioUnitario = value
        End Set
    End Property

    Private _Cantidad As Integer
    Public Property Cantidad() As Integer
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As Integer)
            _Cantidad = value
        End Set
    End Property

    Private _PrecioTotal As Double
    Public Property PrecioTotal() As Double
        Get
            Return _PrecioTotal
        End Get
        Set(ByVal value As Double)
            _PrecioTotal = value
        End Set
    End Property

    Public Sub Alta(ventaitem As BLLVentasItems)
        Dim base As New Data
        Dim PrecioUnitario As String = ventaitem.PrecioUnitario.ToString.Replace(",", ".")
        Dim PrecioTotal As String = ventaitem.PrecioTotal.ToString.Replace(",", ".")
        Dim ConsultaSql As String = "Insert into ventasitems (IDVenta,IDProducto,PrecioUnitario,Cantidad,PrecioTotal) values ('" & ventaitem.IDVenta & "','" & ventaitem.IDProducto & "','" & PrecioUnitario & "','" & ventaitem.Cantidad & "','" & PrecioTotal & "')"
        base.Escribir(ConsultaSql)
    End Sub

    Public Function Listar() As DataTable
        Dim odatos As New Data
        Dim sql As String = "Select ID,,IDVenta,IDProducto,PrecioUnitario,Cantidad,PrecioTotal from ventasitems"
        Return odatos.Leer(sql)
    End Function

    Public Sub GenerarDetalle(lstcarrito As List(Of BLLCarritoMuestra), ventaitem As BLLVentasItems)


        For Each item In lstcarrito
            ventaitem.IDProducto = item.ID
            ventaitem.PrecioUnitario = item.Precio
            ventaitem.Cantidad = item.Cantidad
            ventaitem.PrecioTotal = item.Cantidad * item.Precio

            Alta(ventaitem)
        Next


    End Sub

    Public Function ListarDetallePorVenta(venta As BLLVentas) As DataTable
        Dim odatos As New Data
        Dim sql As String = "Select ID,IDVenta,IDProducto,PrecioUnitario,Cantidad,PrecioTotal from ventasitems where IDVenta =  '" & venta.ID & "'"
        Return odatos.Leer(sql)
    End Function

    Public Sub EliminarDetalle(venta As BLLVentas)
        Dim base As New Data
        Dim sql As String = "Delete From ventasitems where IDVenta =  '" & venta.ID & "'"
        base.Escribir(sql)
    End Sub

    Public Function BuscarDetalleCompletoPorID(id As Integer) As BLLVentasItems
        Dim odatos As New Data
        Dim sql As String
        sql = "Select * from ventasitems where ID = '" & id & "'"
        Dim detalle As New BLLVentasItems
        Dim vnt As New BLLVentas
        Dim prd As New BLLProductos
        Dim tabla As New DataTable

        tabla = odatos.Leer(sql)

        For Each row As DataRow In tabla.Rows

            detalle.ID = CStr(row("ID"))
            detalle.IDVenta = CStr(row("IDVenta"))
            detalle.Venta = vnt.BuscarVentaCompletoPorID(detalle.IDVenta)
            detalle.IDProducto = CStr(row("IDProducto"))
            detalle.Producto = prd.BuscarProductoCompletoPorID(detalle.IDProducto)
            detalle.PrecioUnitario = CStr(row("PrecioUnitario"))
            detalle.PrecioTotal = CStr(row("PrecioTotal"))
            detalle.Cantidad = CStr(row("Cantidad"))

        Next
        Return detalle
    End Function

    Public Function VerificarIntegridad(vntitems As DataTable) As List(Of BLLVentasItems)
        Dim lstventas As New List(Of BLLVentasItems)
        Dim vnt As New BLLVentasItems

        For Each row As DataRow In vntitems.Rows
            lstventas.Add(BuscarDetalleCompletoPorID(row("ID")))

        Next
        Return lstventas
    End Function

    Public Function ListarDetallePorProducto(prod As BLLProductos) As List(Of BLLVentasItems)
        Dim odatos As New Data
        Dim sql As String
        sql = "Select * from ventasitems where IDProducto = '" & prod.ID & "'"
        Dim vnt As New BLLVentas
        Dim prd As New BLLProductos
        Dim lstdetalle As New List(Of BLLVentasItems)
        Dim tabla As New DataTable

        tabla = odatos.Leer(sql)

        For Each row As DataRow In tabla.Rows
            Dim detalle As New BLLVentasItems
            detalle.ID = CStr(row("ID"))
            detalle.IDVenta = CStr(row("IDVenta"))
            detalle.Venta = vnt.BuscarVentaCompletoPorID(detalle.IDVenta)
            detalle.IDProducto = CStr(row("IDProducto"))
            detalle.Producto = prd.BuscarProductoCompletoPorID(detalle.IDProducto)
            detalle.PrecioUnitario = CStr(row("PrecioUnitario"))
            detalle.PrecioTotal = CStr(row("PrecioTotal"))
            detalle.Cantidad = CStr(row("Cantidad"))
            lstdetalle.Add(detalle)
        Next
        Return lstdetalle
    End Function

    Public Function ProductoMayoresVentas() As DataTable
        Dim odatos As New Data
        Dim sql As String
        sql = "SELECT IDProducto,SUM(Cantidad) as Cantidad from ventasitems GROUP BY ventasitems.IDProducto ORDER BY SUM(Cantidad) DESC"
        Dim prd As New BLLProductos
        Dim tabla As New DataTable
        Dim detalle As New BLLVentasItems
        Dim datasetvista As New DataTable
        datasetvista.Columns.Add("Nombre")
        datasetvista.Columns.Add("Cantidad")

        tabla = odatos.Leer(sql)

        For Each row As DataRow In tabla.Rows
            Dim renglon As DataRow = datasetvista.NewRow()

            detalle.IDProducto = CStr(row("IDProducto"))
            detalle.Producto = prd.BuscarProductoCompletoPorID(detalle.IDProducto)
            detalle.Cantidad = CStr(row("Cantidad"))

            renglon("Nombre") = detalle.Producto.Nombre
            renglon("Cantidad") = detalle.Cantidad

            datasetvista.Rows.Add(renglon)

        Next
        Return datasetvista
    End Function

    Public Function ProductoMayoresVentasGenerado() As DataTable
        Dim odatos As New Data
        Dim sql As String
        sql = "SELECT ventasitems.IDProducto,sum(ventasitems.PrecioTotal) as Total from ventasitems join productos on productos.ID = ventasitems.IDProducto GROUP BY ventasitems.IDProducto ORDER BY SUM(ventasitems.PrecioTotal) desc"
        Dim prd As New BLLProductos
        Dim tabla As New DataTable
        Dim detalle As New BLLVentasItems
        Dim datasetvista As New DataTable
        datasetvista.Columns.Add("Nombre")
        datasetvista.Columns.Add("Total")

        tabla = odatos.Leer(sql)

        For Each row As DataRow In tabla.Rows
            Dim renglon As DataRow = datasetvista.NewRow()

            detalle.IDProducto = CStr(row("IDProducto"))
            detalle.Producto = prd.BuscarProductoCompletoPorID(detalle.IDProducto)
            detalle.PrecioTotal = CStr(row("Total"))

            renglon("Nombre") = detalle.Producto.Nombre
            renglon("Total") = detalle.PrecioTotal.ToString.Replace(",", ".")

            datasetvista.Rows.Add(renglon)

        Next
        Return datasetvista
    End Function

    Public Function MejorComprador() As DataTable
        Dim odatos As New Data
        Dim sql As String
        sql = "SELECT ventas.IDCliente, SUM(ventasitems.cantidad) as Cantidad FROM ventasitems JOIN ventas ON ventasitems.IDVenta = ventas.ID GROUP BY ventas.IDCliente ORDER BY SUM(Cantidad) desc"
        Dim vntitem As New BLLVentasItems
        Dim tabla As New DataTable
        Dim cliente As New BLLClientes
        Dim vnt As New BLLVentas
        Dim datasetvista As New DataTable
        datasetvista.Columns.Add("Nombre")
        datasetvista.Columns.Add("Cantidad")

        tabla = odatos.Leer(sql)

        For Each row As DataRow In tabla.Rows

            Dim renglon As DataRow = datasetvista.NewRow()

            vntitem.ID = CStr(row("IDCliente"))
            renglon("Nombre") = cliente.BuscarClienteCompletoPorID(vntitem.ID).Correo
            vntitem.Cantidad = CStr(row("Cantidad"))

            'renglon("Nombre") = vntitem.Producto.Nombre
            renglon("Cantidad") = vntitem.Cantidad

            datasetvista.Rows.Add(renglon)

            'vntitem.Cantidad = CStr(row("Cantidad"))
            'vnt.Cliente = cliente.BuscarClienteCompletoPorID(CStr(row("IDCliente")))
            'vntitem.Venta = vnt


        Next
        Return datasetvista
    End Function

    Public Function MejorCompradorGastado() As DataTable
        Dim odatos As New Data
        Dim sql As String
        sql = "SELECT ventas.IDCliente,sum(ventas.Total) as Gastado from ventas join clientes on clientes.ID = ventas.IDCliente  GROUP BY ventas.IDCliente ORDER BY SUM(ventas.Total) desc"
        Dim vntitem As New BLLVentasItems
        Dim tabla As New DataTable
        Dim cliente As New BLLClientes
        Dim vnt As New BLLVentas
        Dim datasetvista As New DataTable
        datasetvista.Columns.Add("Nombre")
        datasetvista.Columns.Add("Gastado")

        tabla = odatos.Leer(sql)

        For Each row As DataRow In tabla.Rows

            Dim renglon As DataRow = datasetvista.NewRow()

            vntitem.ID = CStr(row("IDCliente"))
            renglon("Nombre") = cliente.BuscarClienteCompletoPorID(vntitem.ID).Correo
            vntitem.PrecioTotal = CStr(row("Gastado"))

            'renglon("Nombre") = vntitem.Producto.Nombre
            renglon("Gastado") = vntitem.PrecioTotal.ToString.Replace(",", ".")

            datasetvista.Rows.Add(renglon)

            'vntitem.Cantidad = CStr(row("Cantidad"))
            'vnt.Cliente = cliente.BuscarClienteCompletoPorID(CStr(row("IDCliente")))
            'vntitem.Venta = vnt


        Next
        Return datasetvista
    End Function

    Public Function ProductoMenoresVentasGenerado() As DataTable
        Dim odatos As New Data
        Dim sql As String
        sql = "SELECT ventasitems.IDProducto,sum(ventasitems.PrecioTotal) as Total from ventasitems join productos on productos.ID = ventasitems.IDProducto GROUP BY ventasitems.IDProducto ORDER BY SUM(ventasitems.PrecioTotal) ASC"
        Dim prd As New BLLProductos
        Dim tabla As New DataTable
        Dim detalle As New BLLVentasItems
        Dim datasetvista As New DataTable
        datasetvista.Columns.Add("Nombre")
        datasetvista.Columns.Add("Total")

        tabla = odatos.Leer(sql)

        For Each row As DataRow In tabla.Rows
            Dim renglon As DataRow = datasetvista.NewRow()

            detalle.IDProducto = CStr(row("IDProducto"))
            detalle.Producto = prd.BuscarProductoCompletoPorID(detalle.IDProducto)
            detalle.PrecioTotal = CStr(row("Total"))

            renglon("Nombre") = detalle.Producto.Nombre
            renglon("Total") = detalle.PrecioTotal.ToString.Replace(",", ".")

            datasetvista.Rows.Add(renglon)

        Next
        Return datasetvista
    End Function

    Public Function ProductoMenoresVentas() As DataTable
        Dim odatos As New Data
        Dim sql As String
        sql = "SELECT IDProducto,SUM(Cantidad) as Cantidad from ventasitems GROUP BY ventasitems.IDProducto ORDER BY SUM(Cantidad) ASC"
        Dim prd As New BLLProductos
        Dim tabla As New DataTable
        Dim detalle As New BLLVentasItems
        Dim datasetvista As New DataTable
        datasetvista.Columns.Add("Nombre")
        datasetvista.Columns.Add("Cantidad")

        tabla = odatos.Leer(sql)

        For Each row As DataRow In tabla.Rows
            Dim renglon As DataRow = datasetvista.NewRow()

            detalle.IDProducto = CStr(row("IDProducto"))
            detalle.Producto = prd.BuscarProductoCompletoPorID(detalle.IDProducto)
            detalle.Cantidad = CStr(row("Cantidad"))

            renglon("Nombre") = detalle.Producto.Nombre
            renglon("Cantidad") = detalle.Cantidad

            datasetvista.Rows.Add(renglon)

        Next
        Return datasetvista
    End Function






End Class
