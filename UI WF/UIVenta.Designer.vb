<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UIVenta
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.TextboxCantidad = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TextboxCodigocarro = New System.Windows.Forms.TextBox()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtbuscadorcliente = New System.Windows.Forms.TextBox()
        Me.cmbbuscadorcliente = New System.Windows.Forms.ComboBox()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbbuscadorproducto = New System.Windows.Forms.ComboBox()
        Me.txtbuscadorproducto = New System.Windows.Forms.TextBox()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(31, 70)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(135, 21)
        Me.ComboBox1.TabIndex = 0
        '
        'TextboxCantidad
        '
        Me.TextboxCantidad.Location = New System.Drawing.Point(87, 85)
        Me.TextboxCantidad.Name = "TextboxCantidad"
        Me.TextboxCantidad.Size = New System.Drawing.Size(114, 20)
        Me.TextboxCantidad.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(845, 14)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 161)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Agregar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(41, 47)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(137, 21)
        Me.ComboBox2.TabIndex = 3
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(13, 191)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(928, 161)
        Me.DataGridView1.TabIndex = 4
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button2.Location = New System.Drawing.Point(987, 54)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(96, 135)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Confirmar Venta"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(44, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Cliente Seleccionado"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(49, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Producto Seleccionado"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Cantidad"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button3.Location = New System.Drawing.Point(19, 183)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(96, 161)
        Me.Button3.TabIndex = 9
        Me.Button3.Text = "Quitar"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'TextboxCodigocarro
        '
        Me.TextboxCodigocarro.Enabled = False
        Me.TextboxCodigocarro.Location = New System.Drawing.Point(5, 126)
        Me.TextboxCodigocarro.Name = "TextboxCodigocarro"
        Me.TextboxCodigocarro.Size = New System.Drawing.Size(123, 20)
        Me.TextboxCodigocarro.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Codigo del Producto"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtbuscadorcliente)
        Me.GroupBox1.Controls.Add(Me.cmbbuscadorcliente)
        Me.GroupBox1.Controls.Add(Me.DataGridView3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 371)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1087, 206)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Generacion de la Venta"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(996, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Monto Actual:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(1009, 38)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Label7"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(64, 124)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Buscador"
        '
        'txtbuscadorcliente
        '
        Me.txtbuscadorcliente.Location = New System.Drawing.Point(93, 141)
        Me.txtbuscadorcliente.Name = "txtbuscadorcliente"
        Me.txtbuscadorcliente.Size = New System.Drawing.Size(100, 20)
        Me.txtbuscadorcliente.TabIndex = 9
        '
        'cmbbuscadorcliente
        '
        Me.cmbbuscadorcliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbbuscadorcliente.FormattingEnabled = True
        Me.cmbbuscadorcliente.Items.AddRange(New Object() {"Nombre", "Correo", "Telefono"})
        Me.cmbbuscadorcliente.Location = New System.Drawing.Point(7, 140)
        Me.cmbbuscadorcliente.Name = "cmbbuscadorcliente"
        Me.cmbbuscadorcliente.Size = New System.Drawing.Size(76, 21)
        Me.cmbbuscadorcliente.TabIndex = 8
        '
        'DataGridView3
        '
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Location = New System.Drawing.Point(199, 19)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.ReadOnly = True
        Me.DataGridView3.Size = New System.Drawing.Size(773, 170)
        Me.DataGridView3.TabIndex = 7
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cmbbuscadorproducto)
        Me.GroupBox2.Controls.Add(Me.txtbuscadorproducto)
        Me.GroupBox2.Controls.Add(Me.DataGridView2)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.DataGridView1)
        Me.GroupBox2.Controls.Add(Me.ComboBox2)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.TextboxCantidad)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(947, 361)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Armado del Carrito"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(84, 126)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Buscador"
        '
        'cmbbuscadorproducto
        '
        Me.cmbbuscadorproducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbbuscadorproducto.FormattingEnabled = True
        Me.cmbbuscadorproducto.Items.AddRange(New Object() {"Nombre", "Precio", "Categoria"})
        Me.cmbbuscadorproducto.Location = New System.Drawing.Point(16, 142)
        Me.cmbbuscadorproducto.Name = "cmbbuscadorproducto"
        Me.cmbbuscadorproducto.Size = New System.Drawing.Size(82, 21)
        Me.cmbbuscadorproducto.TabIndex = 11
        '
        'txtbuscadorproducto
        '
        Me.txtbuscadorproducto.Location = New System.Drawing.Point(111, 143)
        Me.txtbuscadorproducto.Name = "txtbuscadorproducto"
        Me.txtbuscadorproducto.Size = New System.Drawing.Size(100, 20)
        Me.txtbuscadorproducto.TabIndex = 10
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(239, 14)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.Size = New System.Drawing.Size(600, 161)
        Me.DataGridView2.TabIndex = 9
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.TextboxCodigocarro)
        Me.GroupBox3.Controls.Add(Me.Button3)
        Me.GroupBox3.Location = New System.Drawing.Point(970, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(134, 353)
        Me.GroupBox3.TabIndex = 14
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Baja del Item"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(31, 77)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 13)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Seleccionado"
        '
        'UIVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(1116, 670)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "UIVenta"
        Me.Text = "UIVenta"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents TextboxCantidad As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button2 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents TextboxCodigocarro As TextBox
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents DataGridView3 As DataGridView
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents txtbuscadorcliente As TextBox
    Friend WithEvents cmbbuscadorcliente As ComboBox
    Friend WithEvents cmbbuscadorproducto As ComboBox
    Friend WithEvents txtbuscadorproducto As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
End Class
