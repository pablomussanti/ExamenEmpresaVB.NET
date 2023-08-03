Imports BLL
Public Class UIMenu

    Private Sub UIMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ClienteABMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClienteABMToolStripMenuItem.Click
        Dim n As New UICliente
        n.MdiParent = Me
        n.Show()
    End Sub

    Private Sub ProductoABMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductoABMToolStripMenuItem.Click
        Dim n As New UIProducto
        n.MdiParent = Me
        n.Show()
    End Sub

    Private Sub ABMVentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ABMVentasToolStripMenuItem.Click
        Dim n As New UIVenta
        n.MdiParent = Me
        n.Show()
    End Sub

    Private Sub BuscarVentaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarVentaToolStripMenuItem.Click
        Dim n As New UIVentaInfo
        n.MdiParent = Me
        n.Show()
    End Sub

    Private Sub CancelarVentaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelarVentaToolStripMenuItem.Click
        Dim n As New UIVentaCancelar
        n.MdiParent = Me
        n.Show()
    End Sub

    Private Sub EstadisticasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EstadisticasToolStripMenuItem.Click
        Dim n As New UIEstadisticas
        n.MdiParent = Me
        n.Show()
    End Sub
End Class