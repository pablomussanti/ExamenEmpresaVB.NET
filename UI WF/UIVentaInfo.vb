Imports BLL
Public Class UIVentaInfo
    Dim Cliente As New BLLClientes
    Dim Venta As New BLLVentas
    Dim Producto As New BLLProductos
    Dim ventaitems As New BLLVentasItems
    Dim carritomuestra As New BLLCarritoMuestra
    Dim lstCarrito As New List(Of BLLCarritoMuestra)

    Public Sub ListarVentas()
        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.DataSource = Cliente.BuscarClientePorEmail("", True)
        Me.DataGridView1.Columns(0).Visible = False


        Me.ComboBox1.DataSource = DataGridView1.DataSource
        Me.ComboBox1.DisplayMember = "Correo"


    End Sub


    Private Sub UIVentaInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarVentas()
        ComboBox2.Enabled = False
        Button2.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim cli As New BLLClientes
            Dim ventasdelcliente As New List(Of BLLVentas)

            cli.ID = Cliente.BuscarClienteID(ComboBox1.Text)
            ventasdelcliente = Venta.TraerVentasPorCliente(cli)

            Me.DataGridView3.DataSource = Nothing
            Me.DataGridView3.DataSource = ventasdelcliente
            Me.DataGridView3.Columns(1).Visible = False
            Me.DataGridView2.DataSource = Nothing

            ComboBox2.Enabled = True
            Button2.Enabled = True

            Me.ComboBox2.DataSource = Nothing
            Me.ComboBox2.DataSource = ventasdelcliente
            Me.ComboBox2.DisplayMember = "ID"
        Catch ex As Exception
            MsgBox(String.Format("Hubo un error al realizar la tarea, {0}", ex), MsgBoxStyle.Information, "CANCELAR ERROR")
        End Try


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim vnt As New BLLVentas

            vnt.ID = ComboBox2.Text

            Me.DataGridView2.DataSource = Nothing
            Me.DataGridView2.DataSource = ventaitems.VerificarIntegridad(ventaitems.ListarDetallePorVenta(vnt))
            Me.DataGridView2.Columns(0).Visible = False
            Me.DataGridView2.Columns(2).Visible = False
            Me.DataGridView2.Columns(7).Visible = False

        Catch ex As Exception
            MsgBox(String.Format("Hubo un error al realizar la tarea, {0}", ex), MsgBoxStyle.Information, "CANCELAR ERROR")
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            Cliente = New BLLClientes

            If cmbbusquedacliente.Text = "Nombre" Then
                Cliente.Cliente = TextBox1.Text
                DataGridView1.DataSource = Cliente.BuscarClientePorNombre(Cliente.Cliente, True)
            End If
            If cmbbusquedacliente.Text = "Correo" Then
                Cliente.Correo = TextBox1.Text
                DataGridView1.DataSource = Cliente.BuscarClientePorEmail(Cliente.Correo, True)
            End If
            If cmbbusquedacliente.Text = "Telefono" Then
                Cliente.Telefono = TextBox1.Text
                DataGridView1.DataSource = Cliente.BuscarClientePorTelefono(Cliente.Telefono, True)
            End If
            Me.DataGridView1.Columns(0).Visible = False
            Me.ComboBox1.DataSource = Nothing
            Me.ComboBox1.DataSource = DataGridView1.DataSource
            Me.ComboBox1.DisplayMember = "Correo"
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbbusquedacliente.SelectedIndexChanged
        Try
            Cliente = New BLLClientes

            If cmbbusquedacliente.Text = "Nombre" Then
                Cliente.Cliente = TextBox1.Text
                DataGridView1.DataSource = Cliente.BuscarClientePorNombre(Cliente.Cliente, True)
            End If
            If cmbbusquedacliente.Text = "Correo" Then
                Cliente.Correo = TextBox1.Text
                DataGridView1.DataSource = Cliente.BuscarClientePorEmail(Cliente.Correo, True)
            End If
            If cmbbusquedacliente.Text = "Telefono" Then
                Cliente.Telefono = TextBox1.Text
                DataGridView1.DataSource = Cliente.BuscarClientePorTelefono(Cliente.Telefono, True)
            End If
            Me.DataGridView1.Columns(0).Visible = False
            Me.ComboBox1.DataSource = Nothing
            Me.ComboBox1.DataSource = DataGridView1.DataSource
            Me.ComboBox1.DisplayMember = "Correo"
        Catch ex As Exception

        End Try

    End Sub
End Class