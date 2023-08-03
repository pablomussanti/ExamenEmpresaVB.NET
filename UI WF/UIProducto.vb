Imports System.Text.RegularExpressions
Imports BLL
Public Class UIProducto
    Dim producto As New BLLProductos
    Private Sub Enlazar()
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = producto.Listar()
        Me.DataGridView1.Columns(0).Visible = False


    End Sub

    Private Sub Asignar()

        If TextboxCodigo.Text <> "" Then
            producto.ID = TextboxCodigo.Text
        Else
            producto.ID = 0
        End If

        producto.Nombre = TextboxNombre.Text
        If TextboxPrecio.Text = "" Then
            producto.Precio = 0
        Else
            producto.Precio = CDbl(TextboxPrecio.Text)

        End If

        producto.Categoria = TextboxCategoria.Text

    End Sub

    Private Sub Limpiartxt()
        TextboxCodigo.Text = ""
        TextboxNombre.Text = ""
        TextboxPrecio.Text = ""
        TextboxCategoria.Text = ""
    End Sub

    Private Function Verificacioncampos()
        Dim i As Integer = 0
        If TextboxNombre.Text = "" Then
            MessageBox.Show("Falta completar el campo Nombre")
            i = 1
        End If
        If TextboxPrecio.Text = "" Then
            MessageBox.Show("Falta completar el campo Precio")
            i = 1
        End If
        If TextboxCategoria.Text = "" Then
            MessageBox.Show("Falta completar el campo Categoria")
            i = 1
        End If
        Return i
    End Function

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged

        Dim l As DataGridViewSelectedRowCollection = Me.DataGridView1.SelectedRows

        If l.Count = 1 Then
            MessageBox.Show(String.Format("Se ha seleccionado el Producto {0}", DataGridView1.CurrentRow.Cells.Item(0).Value.ToString))

            TextboxCodigo.Text = DataGridView1.CurrentRow.Cells.Item(0).Value.ToString
            TextboxNombre.Text = DataGridView1.CurrentRow.Cells.Item(1).Value.ToString
            TextboxPrecio.Text = DataGridView1.CurrentRow.Cells.Item(2).Value.ToString
            TextboxCategoria.Text = DataGridView1.CurrentRow.Cells.Item(3).Value.ToString
        End If


    End Sub


    Private Sub UIProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Enlazar()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            'verifico que el txtboxprecio contenga valores numericos
            Dim respuesta As Boolean = Regex.IsMatch(TextboxPrecio.Text, "^[0-9]+([,][0-9]+)?$")

            If respuesta = False Then
                MsgBox("Precio: Se escribio un texto", MsgBoxStyle.Information, "VALIDACION ERROR")
                Exit Sub
            Else

            End If

            Asignar()

            If Verificacioncampos() = 1 Then
                Exit Sub
            End If


            If producto.ID = 0 Then
                If producto.VerificarExistencia(TextboxNombre.Text) = True Then
                    MsgBox("El Producto ya existe", MsgBoxStyle.Information, "VALIDACION ERROR")
                    Exit Sub
                End If
                producto.Alta(producto)
                MsgBox(String.Format("Se realizo la tarea con exito."), MsgBoxStyle.Information, "ALTA OK")
            Else
                producto.Modificar(producto)
                MsgBox(String.Format("Se realizo la tarea con exito."), MsgBoxStyle.Information, "MODIFICACION OK")
            End If

            Enlazar()

            Limpiartxt()


        Catch ex As Exception
            MsgBox(String.Format("Hubo un error al realizar la tarea, {0}", ex), MsgBoxStyle.Information, "ALTA/MODIFICACION ERROR")
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try

            Asignar()

            If producto.ID = 0 Then
                MessageBox.Show("Seleccione un Producto")
                Exit Sub
            Else
                producto.Eliminar(producto)

                Dim detalle As New BLLVentasItems
                Dim vnt As New BLLVentas

                'eliminacion improvisada para no tener inconsistencia en la base de datos, estaria mejor una baja logica
                For Each item In detalle.ListarDetallePorProducto(producto)
                    detalle.EliminarDetalle(item.Venta)
                    vnt.EliminarVenta(item.Venta)
                Next


                Enlazar()
            End If

            Limpiartxt()

            MsgBox(String.Format("Se realizo la tarea con exito."), MsgBoxStyle.Information, "VALIDACION OK")

        Catch ex As Exception
            MsgBox(String.Format("Hubo un error al realizar la tarea, {0}", ex), MsgBoxStyle.Information, "ELIMINACION ERROR")
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Limpiartxt()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            producto = New BLLProductos

            If ComboBox1.Text = "Nombre" Then
                producto.Nombre = TextBox1.Text
                DataGridView1.DataSource = producto.BuscarProductoPorNombre(producto.Nombre)
            End If
            If ComboBox1.Text = "Precio" Then
                Dim respuesta As Boolean = Regex.IsMatch(TextBox1.Text, "^[0-9]+([,][0-9]+)?$")

                If respuesta = False Then
                    DataGridView1.DataSource = producto.BuscarProductoPorNombre("")
                    Exit Sub
                End If

                producto.Precio = TextBox1.Text
                DataGridView1.DataSource = producto.BuscarProductoPorPrecio(producto.Precio)

            End If
            If ComboBox1.Text = "Categoria" Then
                producto.Categoria = TextBox1.Text
                DataGridView1.DataSource = producto.BuscarProductoPorCategoria(producto.Categoria)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            producto = New BLLProductos

            If ComboBox1.Text = "Nombre" Then
                producto.Nombre = TextBox1.Text
                DataGridView1.DataSource = producto.BuscarProductoPorNombre(producto.Nombre)
            End If
            If ComboBox1.Text = "Precio" Then
                If TextBox1.Text = "" Then
                    Exit Sub
                End If
                Dim respuesta As Boolean = Regex.IsMatch(TextBox1.Text, "^[0-9]+([,][0-9]+)?$")

                If respuesta = False Then
                    DataGridView1.DataSource = producto.BuscarProductoPorNombre("")
                    Exit Sub
                End If

                producto.Precio = TextBox1.Text
                DataGridView1.DataSource = producto.BuscarProductoPorPrecio(producto.Precio)
            End If
            If ComboBox1.Text = "Categoria" Then
                producto.Categoria = TextBox1.Text
                DataGridView1.DataSource = producto.BuscarProductoPorCategoria(producto.Categoria)
            End If
        Catch ex As Exception

        End Try

    End Sub
End Class