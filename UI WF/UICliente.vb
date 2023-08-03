Imports System.Text.RegularExpressions
Imports BLL
Public Class UICliente
    Dim cliente As New BLLClientes
    Private Sub Enlazar()
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = cliente.Listar()
        Me.DataGridView1.Columns(0).Visible = False

    End Sub

    Private Sub Asignar()
        If TextBoxCodigo.Text <> "" Then
            cliente.ID = TextBoxCodigo.Text
        Else
            cliente.ID = 0
        End If

        cliente.Cliente = TextBoxCliente.Text
        cliente.Telefono = TextBoxTelefono.Text
        cliente.Correo = TextBoxCorreo.Text

    End Sub

    Private Sub Limpiartxt()
        TextBoxCliente.Text = ""
        TextBoxTelefono.Text = ""
        TextBoxCorreo.Text = ""
        TextBoxCodigo.Text = ""
    End Sub

    Private Function Verificacioncampos()
        Dim i As Integer = 0
        If TextBoxCliente.Text = "" Then
            MsgBox("Falta completar el campo Nombre", MsgBoxStyle.Information, "VALIDACION ERROR")
            i = 1
        End If
        If TextBoxCorreo.Text = "" Then
            MsgBox("Falta completar el campo Correo", MsgBoxStyle.Information, "VALIDACION ERROR")
            i = 1
        End If
        If TextBoxTelefono.Text = "" Then
            MsgBox("Falta completar el campo Telefono", MsgBoxStyle.Information, "VALIDACION ERROR")
            i = 1
        End If
        Return i
    End Function

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged

        Dim l As DataGridViewSelectedRowCollection = Me.DataGridView1.SelectedRows

        If l.Count = 1 Then
            MessageBox.Show(String.Format("Se ha seleccionado el cliente {0}", DataGridView1.CurrentRow.Cells.Item(0).Value.ToString))
            TextBoxCodigo.Text = DataGridView1.CurrentRow.Cells.Item(0).Value.ToString
            TextBoxCliente.Text = DataGridView1.CurrentRow.Cells.Item(1).Value.ToString
            TextBoxTelefono.Text = DataGridView1.CurrentRow.Cells.Item(2).Value.ToString
            TextBoxCorreo.Text = DataGridView1.CurrentRow.Cells.Item(3).Value.ToString
        End If


    End Sub

    Private Sub UICliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Enlazar()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Limpiartxt()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            'verifico que el txtboxtelefono contenga valores numericos
            Dim respuesta As Boolean = Regex.IsMatch(TextBoxTelefono.Text, "^([0-9]+$)")

            If respuesta = False Then
                MsgBox("Telefono: Se escribio un texto", MsgBoxStyle.Information, "VALIDACION ERROR")
                Exit Sub
            Else

            End If

            Asignar()

            If Verificacioncampos() = 1 Then
                Exit Sub
            End If


            If cliente.ID = 0 Then
                If cliente.VerificarExistencia(TextBoxCorreo.Text) = True Then
                    MsgBox("Ya hay un cliente cargado con ese correo", MsgBoxStyle.Information, "VALIDACION ERROR")
                    Exit Sub
                End If
                cliente.Alta(cliente)
                MsgBox(String.Format("Se realizo la tarea con exito."), MsgBoxStyle.Information, "ALTA OK")
            Else
                cliente.Modificar(cliente)
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

            If cliente.ID = 0 Then
                MsgBox("Seleccione un Cliente", MsgBoxStyle.Information, "VALIDACION ERROR")
                Exit Sub
            Else
                cliente.Eliminar(cliente)

                Dim vnt As New BLLVentas
                Dim detalle As New BLLVentasItems

                'eliminacion improvisada para no tener inconsistencia en la base de datos, estaria mejor una baja logica
                For Each item In vnt.TraerVentasPorCliente(cliente)
                    vnt.EliminarVenta(item)
                    detalle.EliminarDetalle(item)
                Next




                Enlazar()
            End If

            Limpiartxt()

            MsgBox(String.Format("Se realizo la tarea con exito."), MsgBoxStyle.Information, "ELIMINACION OK")

        Catch ex As Exception
            MsgBox(String.Format("Hubo un error al realizar la tarea, {0}", ex), MsgBoxStyle.Information, "ELIMINACION ERROR")
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            cliente = New BLLClientes

            If ComboBox1.Text = "Nombre" Then
                cliente.Cliente = TextBox1.Text
                DataGridView1.DataSource = cliente.BuscarClientePorNombre(cliente.Cliente, CheckBox1.Checked)
            End If
            If ComboBox1.Text = "Correo" Then
                cliente.Correo = TextBox1.Text
                DataGridView1.DataSource = cliente.BuscarClientePorEmail(cliente.Correo, CheckBox1.Checked)
            End If
            If ComboBox1.Text = "Telefono" Then
                cliente.Telefono = TextBox1.Text
                DataGridView1.DataSource = cliente.BuscarClientePorTelefono(cliente.Telefono, CheckBox1.Checked)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            cliente = New BLLClientes

            If ComboBox1.Text = "Nombre" Then
                cliente.Cliente = TextBox1.Text
                DataGridView1.DataSource = cliente.BuscarClientePorNombre(cliente.Cliente, CheckBox1.Checked)
            End If
            If ComboBox1.Text = "Correo" Then
                cliente.Correo = TextBox1.Text
                DataGridView1.DataSource = cliente.BuscarClientePorEmail(cliente.Correo, CheckBox1.Checked)
            End If
            If ComboBox1.Text = "Telefono" Then
                cliente.Telefono = TextBox1.Text
                DataGridView1.DataSource = cliente.BuscarClientePorTelefono(cliente.Telefono, CheckBox1.Checked)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Try
            DataGridView1.DataSource = Nothing
            If TextBox1.Text = "" Then
                DataGridView1.DataSource = cliente.BuscarClientePorEmail("", CheckBox1.Checked)
            End If

            If cliente.Cliente <> Nothing And cliente.Cliente <> "" Then
                DataGridView1.DataSource = cliente.BuscarClientePorNombre(cliente.Cliente, CheckBox1.Checked)
            End If

            If cliente.Correo <> Nothing And cliente.Correo <> "" Then
                DataGridView1.DataSource = cliente.BuscarClientePorEmail(cliente.Correo, CheckBox1.Checked)
            End If

            If cliente.Telefono <> Nothing And cliente.Telefono <> "" Then
                DataGridView1.DataSource = cliente.BuscarClientePorTelefono(cliente.Telefono, CheckBox1.Checked)
            End If
        Catch ex As Exception

        End Try

    End Sub
End Class