Public Class BLLCarritoMuestra

    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property

    Private _Nombre As String
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            _Nombre = value
        End Set
    End Property

    Private _Precio As Double
    Public Property Precio() As Double
        Get
            Return _Precio
        End Get
        Set(ByVal value As Double)
            _Precio = value
        End Set
    End Property

    Private _Cantidad As Double
    Public Property Cantidad() As Double
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As Double)
            _Cantidad = value
        End Set
    End Property

    Public Function AgregarProducto(producto As BLLCarritoMuestra, lst As List(Of BLLCarritoMuestra)) As List(Of BLLCarritoMuestra)
        Dim verificador As Integer = 0

        For Each prdlst In lst
            If producto.ID = prdlst.ID Then
                prdlst.Cantidad = prdlst.Cantidad + producto.Cantidad
                verificador = 1
            End If

        Next

        If verificador = 0 Then
            lst.Add(producto)
        End If

        Return lst
    End Function

    Public Function SacarProducto(producto As BLLCarritoMuestra, lst As List(Of BLLCarritoMuestra)) As List(Of BLLCarritoMuestra)
        Dim item As New BLLCarritoMuestra
        Dim verificador As Integer

        For Each prdlst In lst
            If producto.ID = prdlst.ID Then
                item = prdlst
                verificador = 1
            End If

        Next

        If verificador = 1 Then
            lst.Remove(item)
        End If

        Return lst
    End Function

    Public Function ObtenerValorTotal(lst As List(Of BLLCarritoMuestra)) As Double
        'Dim item As BLLCarritoMuestra
        'Dim verificador As Integer
        Dim total As Double

        For Each prdlst In lst
            total = total + (prdlst.Cantidad * prdlst.Precio)
        Next


        Return total
    End Function

End Class
