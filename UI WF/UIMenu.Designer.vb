<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UIMenu
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClienteABMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductoABMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VentasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ABMVentasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelarVentaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarVentaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EstadisticasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.HotTrack
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClientesToolStripMenuItem, Me.ProductosToolStripMenuItem, Me.VentasToolStripMenuItem, Me.EstadisticasToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ClientesToolStripMenuItem
        '
        Me.ClientesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClienteABMToolStripMenuItem})
        Me.ClientesToolStripMenuItem.Name = "ClientesToolStripMenuItem"
        Me.ClientesToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.ClientesToolStripMenuItem.Text = "Clientes"
        '
        'ClienteABMToolStripMenuItem
        '
        Me.ClienteABMToolStripMenuItem.Name = "ClienteABMToolStripMenuItem"
        Me.ClienteABMToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ClienteABMToolStripMenuItem.Text = "Cliente ABM"
        '
        'ProductosToolStripMenuItem
        '
        Me.ProductosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProductoABMToolStripMenuItem})
        Me.ProductosToolStripMenuItem.Name = "ProductosToolStripMenuItem"
        Me.ProductosToolStripMenuItem.Size = New System.Drawing.Size(73, 20)
        Me.ProductosToolStripMenuItem.Text = "Productos"
        '
        'ProductoABMToolStripMenuItem
        '
        Me.ProductoABMToolStripMenuItem.Name = "ProductoABMToolStripMenuItem"
        Me.ProductoABMToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.ProductoABMToolStripMenuItem.Text = "Producto ABM"
        '
        'VentasToolStripMenuItem
        '
        Me.VentasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ABMVentasToolStripMenuItem, Me.CancelarVentaToolStripMenuItem, Me.BuscarVentaToolStripMenuItem})
        Me.VentasToolStripMenuItem.Name = "VentasToolStripMenuItem"
        Me.VentasToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.VentasToolStripMenuItem.Text = "Ventas"
        '
        'ABMVentasToolStripMenuItem
        '
        Me.ABMVentasToolStripMenuItem.Name = "ABMVentasToolStripMenuItem"
        Me.ABMVentasToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ABMVentasToolStripMenuItem.Text = "Generar Venta"
        '
        'CancelarVentaToolStripMenuItem
        '
        Me.CancelarVentaToolStripMenuItem.Name = "CancelarVentaToolStripMenuItem"
        Me.CancelarVentaToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CancelarVentaToolStripMenuItem.Text = "Cancelar Venta"
        '
        'BuscarVentaToolStripMenuItem
        '
        Me.BuscarVentaToolStripMenuItem.Name = "BuscarVentaToolStripMenuItem"
        Me.BuscarVentaToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.BuscarVentaToolStripMenuItem.Text = "Buscar Venta"
        '
        'EstadisticasToolStripMenuItem
        '
        Me.EstadisticasToolStripMenuItem.Name = "EstadisticasToolStripMenuItem"
        Me.EstadisticasToolStripMenuItem.Size = New System.Drawing.Size(79, 20)
        Me.EstadisticasToolStripMenuItem.Text = "Estadisticas"
        '
        'UIMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "UIMenu"
        Me.Text = "UIMenu"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ClientesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProductosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VentasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClienteABMToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProductoABMToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ABMVentasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BuscarVentaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CancelarVentaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EstadisticasToolStripMenuItem As ToolStripMenuItem
End Class
