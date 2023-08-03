Imports BLL

Public Class UIVentaCancelar
    Dim Venta As New BLLVentas
    Dim ventasitems As New BLLVentasItems

    Public Sub ActualizarListaVentas()
        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.DataSource = Venta.VerificarIntegridad(Venta.Listar())
        Me.DataGridView1.Columns(1).Visible = False
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged

        Dim l As DataGridViewSelectedRowCollection = Me.DataGridView1.SelectedRows

        If l.Count = 1 Then
            MessageBox.Show(String.Format("Se ha seleccionado la venta {0}", DataGridView1.CurrentRow.Cells.Item(4).Value.ToString))
            TextboxCodigo.Text = DataGridView1.CurrentRow.Cells.Item(4).Value.ToString
        End If


    End Sub

    Private Sub UIVentaCancelar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActualizarListaVentas()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim vnt As New BLLVentas
            vnt.ID = TextboxCodigo.Text

            ventasitems.EliminarDetalle(vnt)
            Venta.EliminarVenta(vnt)

            ActualizarListaVentas()
            MsgBox(String.Format("Se elimino con exito la Venta N° {0}", vnt.ID), MsgBoxStyle.Information, "CANCELAR OK")
        Catch ex As Exception
            MsgBox(String.Format("Hubo un error al realizar la tarea, {0}", ex), MsgBoxStyle.Information, "CANCELAR ERROR")
        End Try
    End Sub


End Class