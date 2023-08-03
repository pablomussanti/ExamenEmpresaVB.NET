Imports BLL
Public Class UIEstadisticas
    Dim venta As New BLLVentas
    Dim detalle As New BLLVentasItems
    Dim producto As New BLLProductos
    Private Sub UIEstadisticas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim mejorproductoventas As New BLLVentasItems
            Dim mejorclienteventas As New BLLVentasItems
            Dim ventasrecaudado As New BLLVentas


            Dim valoresmayoresventas As DataTable = mejorproductoventas.ProductoMayoresVentas()

            Dim miview As DataView = New DataView(valoresmayoresventas)
            For x = 0 To miview.Count - 1
                Dim contador As Integer
                If contador <= 4 Then
                    Me.Chart1.Series("Cantidad").Points.AddXY(miview(x)("Nombre"), miview(x)("Cantidad"))
                    contador = contador + 1
                End If

            Next


            Dim valormayorescompradores As DataTable = mejorclienteventas.MejorComprador()

            Dim miview2 As DataView = New DataView(valormayorescompradores)
            For y = 0 To miview2.Count - 1
                Dim contador As Integer
                If contador <= 2 Then
                    Me.Chart2.Series("Cantidad").Points.AddXY(miview2(y)("Nombre"), miview2(y)("Cantidad"))
                    contador = contador + 1
                End If
            Next

            Dim valormayorescompradoresdinero As DataTable = mejorclienteventas.MejorCompradorGastado()

            Dim miview3 As DataView = New DataView(valormayorescompradoresdinero)
            For z = 0 To miview3.Count - 1
                Dim contador As Integer
                If contador <= 2 Then
                    Me.Chart3.Series("Recaudado").Points.AddXY(miview3(z)("Nombre"), miview3(z)("Gastado"))
                    contador = contador + 1
                End If
            Next

            Dim valoresmayoresventasrecaudado As DataTable = mejorproductoventas.ProductoMayoresVentasGenerado()

            Dim miview4 As DataView = New DataView(valoresmayoresventasrecaudado)
            For f = 0 To miview4.Count - 1
                Dim contador As Integer
                If contador <= 4 Then
                    Me.Chart4.Series("Recaudado").Points.AddXY(miview4(f)("Nombre"), miview4(f)("Total"))
                    contador = contador + 1
                End If

            Next

            Dim valoresmenoresventasrecaudado As DataTable = mejorproductoventas.ProductoMenoresVentasGenerado()

            Dim miview5 As DataView = New DataView(valoresmenoresventasrecaudado)
            For t = 0 To miview5.Count - 1
                Dim contador As Integer
                If contador <= 4 Then
                    Me.Chart5.Series("Recaudado").Points.AddXY(miview5(t)("Nombre"), miview5(t)("Total"))
                    contador = contador + 1
                End If

            Next

            Dim valoresmenoresventas As DataTable = mejorproductoventas.ProductoMenoresVentas()

            Dim miview6 As DataView = New DataView(valoresmenoresventas)
            For u = 0 To miview6.Count - 1
                Dim contador As Integer
                If contador <= 4 Then
                    Me.Chart6.Series("Cantidad").Points.AddXY(miview6(u)("Nombre"), miview6(u)("Cantidad"))
                    contador = contador + 1
                End If

            Next

            Dim recaudadopormes As DataTable = ventasrecaudado.TotalVentasPorMes()

            Dim miview7 As DataView = New DataView(recaudadopormes)
            For p = 0 To miview7.Count - 1
                Dim contador As Integer
                If contador <= 11 Then
                    Me.Chart7.Series("Recaudado").Points.AddXY(miview7(p)("Mes"), miview7(p)("Total"))
                    contador = contador + 1
                End If

            Next
        Catch ex As Exception

        End Try



    End Sub


End Class