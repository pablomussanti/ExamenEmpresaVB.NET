Imports System.Text.RegularExpressions
Imports BLL
Public Class UIVenta
    Dim Cliente As New BLLClientes
    Dim Venta As New BLLVentas
    Dim Producto As New BLLProductos
    Dim ventaitems As New BLLVentasItems
    Dim carritomuestra As New BLLCarritoMuestra
    Dim lstCarrito As New List(Of BLLCarritoMuestra)
    Private Sub UIVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ListarCombo()

        ActualizarBuscador()

    End Sub

    Public Sub ListarCombo()
        Me.ComboBox1.DataSource = Nothing
        Me.ComboBox1.DataSource = Cliente.BuscarClientePorEmail("", False)
        Me.ComboBox1.DisplayMember = "Correo"

        Me.ComboBox2.DataSource = Nothing
        Me.ComboBox2.DataSource = Producto.Listar()
        Me.ComboBox2.DisplayMember = "Nombre"
    End Sub

    Public Sub ActualizarListaPRD()
        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.DataSource = lstCarrito
        Me.DataGridView1.Columns(0).Visible = False
    End Sub

    Public Sub ActualizarBuscador()
        Me.DataGridView2.DataSource = Nothing
        Me.DataGridView2.DataSource = Producto.Listar()
        Me.DataGridView2.Columns(0).Visible = False

        Me.DataGridView3.DataSource = Nothing
        Me.DataGridView3.DataSource = Cliente.Listar()
        Me.DataGridView3.Columns(0).Visible = False

        Me.ComboBox2.DataSource = DataGridView2.DataSource
        Me.ComboBox1.DataSource = DataGridView3.DataSource

        txtbuscadorcliente.Text = ""
        txtbuscadorproducto.Text = ""
        TextboxCantidad.Text = ""
        TextboxCodigocarro.Text = ""

        Label7.Text = "0"

    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged

        Dim l As DataGridViewSelectedRowCollection = Me.DataGridView1.SelectedRows

        If l.Count = 1 Then
            MessageBox.Show(String.Format("Se ha seleccionado el Producto {0}", DataGridView1.CurrentRow.Cells.Item(0).Value.ToString))
            TextboxCodigocarro.Text = DataGridView1.CurrentRow.Cells.Item(0).Value.ToString
        End If


    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim prdmuestra As New BLLCarritoMuestra

            If TextboxCantidad.Text = "" Then
                MsgBox("Agregue la cantidad del Producto", MsgBoxStyle.Information, "VALIDACION ERROR")
                Exit Sub
            End If

            'verifico que el txtboxcantidad contenga valores numericos
            Dim respuesta As Boolean = Regex.IsMatch(TextboxCantidad.Text, "^([0-9]+$)")

            If respuesta = False Then
                MsgBox("Cantidad: Se escribio un texto", MsgBoxStyle.Information, "VALIDACION ERROR")
                Exit Sub
            Else

            End If

            prdmuestra.Cantidad = TextboxCantidad.Text
            prdmuestra.Nombre = ComboBox2.Text
            prdmuestra.Precio = Producto.VerificarPrecio(prdmuestra.Nombre)
            prdmuestra.ID = Producto.BuscarProductoID(prdmuestra.Nombre)

            carritomuestra.AgregarProducto(prdmuestra, lstCarrito)

            ActualizarListaPRD()
            Label7.Text = carritomuestra.ObtenerValorTotal(lstCarrito)
            'MsgBox(String.Format("Se realizo la tarea con exito."), MsgBoxStyle.Information, "AGREGAR PRODUCTO OK")

        Catch ex As Exception
            MsgBox(String.Format("Hubo un error al realizar la tarea, {0}", ex), MsgBoxStyle.Information, "AGREGAR PRODUCTO ERROR")
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If TextboxCodigocarro.Text = "" Then
                MessageBox.Show("Seleccione un producto")
                Exit Sub
            End If

            Dim prd As New BLLCarritoMuestra

            prd.ID = TextboxCodigocarro.Text

            carritomuestra.SacarProducto(prd, lstCarrito)

            ActualizarListaPRD()
            Label7.Text = carritomuestra.ObtenerValorTotal(lstCarrito)
            TextboxCodigocarro.Text = ""

            'MsgBox(String.Format("Se realizo la tarea con exito."), MsgBoxStyle.Information, "SACAR PRODUCTO OK")

        Catch ex As Exception
            MsgBox(String.Format("Hubo un error al realizar la tarea, {0}", ex), MsgBoxStyle.Information, "SACAR PRODUCTO ERROR")
        End Try


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If lstCarrito.Count = 0 Then
                MessageBox.Show("Agregue cosas al Carrito")
                Exit Sub
            End If

            Dim vnta As New BLLVentas
            Dim detalle As New BLLVentasItems

            vnta.IDCliente = Cliente.BuscarClienteID(ComboBox1.Text)
            vnta.Fecha = DateTime.Now()
            vnta.Total = carritomuestra.ObtenerValorTotal(lstCarrito)

            Venta.Alta(vnta)

            detalle.IDVenta = Venta.TraerUltimaVenta()

            ventaitems.GenerarDetalle(lstCarrito, detalle)

            lstCarrito.Clear()

            ActualizarListaPRD()
            ActualizarBuscador()

            MsgBox(String.Format("Se realizo la tarea con exito."), MsgBoxStyle.Information, "CREAR OK")

        Catch ex As Exception
            MsgBox(String.Format("Hubo un error al realizar la tarea, {0}", ex), MsgBoxStyle.Information, "CREAR ERROR")
        End Try


    End Sub

    Private Sub txtbuscadorproducto_TextChanged(sender As Object, e As EventArgs) Handles txtbuscadorproducto.TextChanged
        Try
            Producto = New BLLProductos

            If cmbbuscadorproducto.Text = "Nombre" Then
                Producto.Nombre = txtbuscadorproducto.Text
                DataGridView2.DataSource = Producto.BuscarProductoPorNombre(Producto.Nombre)
            End If
            If cmbbuscadorproducto.Text = "Precio" Then
                Dim respuesta As Boolean = Regex.IsMatch(txtbuscadorproducto.Text, "^[0-9]+([,][0-9]+)?$")

                If respuesta = False Then
                    DataGridView2.DataSource = Producto.BuscarProductoPorNombre("")
                    Exit Sub
                End If

                Producto.Precio = txtbuscadorproducto.Text
                DataGridView2.DataSource = Producto.BuscarProductoPorPrecio(Producto.Precio)

            End If
            If cmbbuscadorproducto.Text = "Categoria" Then
                Producto.Categoria = txtbuscadorproducto.Text
                DataGridView2.DataSource = Producto.BuscarProductoPorCategoria(Producto.Categoria)
            End If
            Me.DataGridView2.Columns(0).Visible = False
            Me.ComboBox2.DataSource = Nothing
            Me.ComboBox2.DataSource = DataGridView2.DataSource
            Me.ComboBox2.DisplayMember = "Nombre"
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmbbuscadorproducto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbbuscadorproducto.SelectedIndexChanged
        Try
            Producto = New BLLProductos

            If cmbbuscadorproducto.Text = "Nombre" Then
                Producto.Nombre = txtbuscadorproducto.Text
                DataGridView2.DataSource = Producto.BuscarProductoPorNombre(Producto.Nombre)
            End If
            If cmbbuscadorproducto.Text = "Precio" Then
                Dim respuesta As Boolean = Regex.IsMatch(txtbuscadorproducto.Text, "^[0-9]+([,][0-9]+)?$")

                If respuesta = False Then
                    DataGridView2.DataSource = Producto.BuscarProductoPorNombre("")
                    Exit Sub
                End If

                Producto.Precio = txtbuscadorproducto.Text
                DataGridView2.DataSource = Producto.BuscarProductoPorPrecio(Producto.Precio)

            End If
            If cmbbuscadorproducto.Text = "Categoria" Then
                Producto.Categoria = txtbuscadorproducto.Text
                DataGridView2.DataSource = Producto.BuscarProductoPorCategoria(Producto.Categoria)
            End If
            Me.DataGridView2.Columns(0).Visible = False
            Me.ComboBox2.DataSource = Nothing
            Me.ComboBox2.DataSource = DataGridView2.DataSource
            Me.ComboBox2.DisplayMember = "Nombre"
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtbuscadorcliente_TextChanged(sender As Object, e As EventArgs) Handles txtbuscadorcliente.TextChanged
        Try
            Cliente = New BLLClientes

            If cmbbuscadorcliente.Text = "Nombre" Then
                Cliente.Cliente = txtbuscadorcliente.Text
                DataGridView3.DataSource = Cliente.BuscarClientePorNombre(Cliente.Cliente, False)
            End If
            If cmbbuscadorcliente.Text = "Correo" Then
                Cliente.Correo = txtbuscadorcliente.Text
                DataGridView3.DataSource = Cliente.BuscarClientePorEmail(Cliente.Correo, False)
            End If
            If cmbbuscadorcliente.Text = "Telefono" Then
                Cliente.Telefono = txtbuscadorcliente.Text
                DataGridView3.DataSource = Cliente.BuscarClientePorTelefono(Cliente.Telefono, False)
            End If
            Me.DataGridView3.Columns(0).Visible = False
            Me.ComboBox1.DataSource = Nothing
            Me.ComboBox1.DataSource = DataGridView3.DataSource
            Me.ComboBox1.DisplayMember = "Correo"
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmbbuscadorcliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbbuscadorcliente.SelectedIndexChanged
        Try
            Cliente = New BLLClientes

            If cmbbuscadorcliente.Text = "Nombre" Then
                Cliente.Cliente = txtbuscadorcliente.Text
                DataGridView3.DataSource = Cliente.BuscarClientePorNombre(Cliente.Cliente, False)
            End If
            If cmbbuscadorcliente.Text = "Correo" Then
                Cliente.Correo = txtbuscadorcliente.Text
                DataGridView3.DataSource = Cliente.BuscarClientePorEmail(Cliente.Correo, False)
            End If
            If cmbbuscadorcliente.Text = "Telefono" Then
                Cliente.Telefono = txtbuscadorcliente.Text
                DataGridView3.DataSource = Cliente.BuscarClientePorTelefono(Cliente.Telefono, False)
            End If
            Me.DataGridView3.Columns(0).Visible = False
            Me.ComboBox1.DataSource = Nothing
            Me.ComboBox1.DataSource = DataGridView3.DataSource
            Me.ComboBox1.DisplayMember = "Correo"
        Catch ex As Exception

        End Try

    End Sub


End Class