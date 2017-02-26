Imports System.Data
Public Class viaje
    Private _origen As String
    Private _destino As String
    Private _origenOriginal As String
    Private _destinoOriginal As String
    Private _distanciaTerrestre As Single
    Private _costeKm As Single
    Private _costeKmAcarreoOrigen As Single
    Private _costeKmAcarreoDestino As Single
    Private _Velocidad As Single
    Private _VelocidadAcarreoOrigen As Single
    Private _VelocidadAcarreoDestino As Single
    Private _CarreteraHoras As Single
    Private _puerto As DataRow
    Private _MisViajes As DataTable
    Private _RecargoCabezaTractora As Boolean
    Private _RecargoRefrigerado As Boolean
    Private _RecargoMercanciaPeligrosa As Boolean
    Private _RecargoAnimalesVivos As Boolean
    Private _Peajes As Double
    Private _FachadaAtlantica As Boolean
    Private _FachadaMediterranea As Boolean
    Private _FachadaCantabrica As Boolean
    Private _AltaFrecuencia As Boolean
    Private _Naviera As String
    Private _WhereMisViajes As String
    Private _WhereMisViajesCondicion As String
    Private _costeExternoKmTnCarretera As Double
    Private _costeExternoKmTnMaritimo As Double
    Private _costeEmisionCO2KmTnCarretera As Double
    Private _costeEmisionCO2KmTnMaritimo As Double
    Private _ToneladasTransportadas As Double
    Private _ResultadosOrden As String

    Sub New(ByVal cOrigen As String, ByVal cDestino As String)
        Me.origen = cOrigen.ToUpper
        Me.destino = cDestino.ToUpper
        Me.Velocidad = 65
        Me.VelocidadAcarreoOrigen = 65
        Me.VelocidadAcarreoDestino = 65
        Me.costeKm = 1.1
        RecargoCabezaTractora = False
        RecargoRefrigerado = False
        RecargoMercanciaPeligrosa = False
        Me.FachadaAtlantica = True
        Me.FachadaCantabrica = True
        Me.FachadaMediterranea = True
        Me.AltaFrecuencia = False
        Me.Naviera = ""
        Me.WhereMisViajes = ""
        Me.WhereMisViajesCondicion = String.Empty
        Me.Peajes = 0
        Me.costeExternoKmTnCarretera = 0
        Me.costeExternoKmTnMaritimo = 0
        Me.costeEmisionCO2KmTnCarretera = 0
        Me.costeEmisionCO2KmTnMaritimo = 0
        Me.toneladasTransportadas = 18
        Me.ResultadosOrden = ""
    End Sub
    Public Property ResultadosOrden As String
        Get
            Return Me._ResultadosOrden
        End Get
        Set(ByVal value As String)
            Me._ResultadosOrden = value
        End Set
    End Property

    Public Property Peajes As Double
        Get
            Return Me._Peajes
        End Get
        Set(ByVal value As Double)
            Me._Peajes = CType(value, String)
        End Set
    End Property
    Public Property WhereMisViajes As String
        Get
            Return Me._WhereMisViajes
        End Get
        Set(ByVal value As String)
            Me._WhereMisViajes = value
        End Set
    End Property
    Public Property WhereMisViajesCondicion As String
        Get
            Return Me._WhereMisViajesCondicion
        End Get
        Set(ByVal value As String)
            Me._WhereMisViajesCondicion = value
        End Set
    End Property

    Public Property Naviera As String
        Get
            Return Me._Naviera
        End Get
        Set(ByVal value As String)
            Me._Naviera = value
        End Set
    End Property
    Public Property AltaFrecuencia As Boolean
        Get
            Return Me._AltaFrecuencia
        End Get
        Set(ByVal value As Boolean)
            Me._AltaFrecuencia = value
        End Set
    End Property

    Public Property FachadaAtlantica As Boolean
        Get
            Return Me._FachadaAtlantica
        End Get
        Set(ByVal value As Boolean)
            Me._FachadaAtlantica = value
        End Set
    End Property
    Public Property FachadaMediterranea As Boolean
        Get
            Return Me._FachadaMediterranea
        End Get
        Set(ByVal value As Boolean)
            Me._FachadaMediterranea = value
        End Set
    End Property
    Public Property FachadaCantabrica As Boolean
        Get
            Return Me._FachadaCantabrica
        End Get
        Set(ByVal value As Boolean)
            Me._FachadaCantabrica = value
        End Set
    End Property
    Public Property origen() As String
        Get
            Return _origen
        End Get
        Set(ByVal value As String)
            _origen = value
        End Set
    End Property
    Public Property destino() As String
        Get
            Return _destino
        End Get
        Set(ByVal value As String)
            _destino = value
            _distanciaTerrestre = Funciones.Distancia(Me.origen, Me.destino)
        End Set
    End Property
    Public Property Puerto() As DataRow
        Get
            Return _puerto
        End Get
        Set(ByVal value As DataRow)
            _puerto = value
        End Set
    End Property

    Public Property origenOriginal() As String
        Get
            Return _origenOriginal
        End Get
        Set(ByVal value As String)
            _origenOriginal = value
        End Set
    End Property
    Public Property destinoOriginal() As String
        Get
            Return _destinoOriginal
        End Get
        Set(ByVal value As String)
            _destinoOriginal = value
        End Set
    End Property
    Public Property CarreteraHoras() As String
        Get
            Return _CarreteraHoras
        End Get
        Set(ByVal value As String)
            _CarreteraHoras = value
        End Set
    End Property
    Public Property misViajes() As DataTable
        Get
            Return _MisViajes
        End Get
        Set(ByVal value As DataTable)
            _MisViajes = value
        End Set
    End Property
    Public ReadOnly Property distanciaTerrestre() As String
        Get
            Return _distanciaTerrestre
        End Get
    End Property
    Public ReadOnly Property tiempoTerrestre() As Single
        Get
            If Me.CarreteraHoras Is Nothing Or Me.CarreteraHoras = 0 Then
                Return TiempoTerrestreconDescanso(Me.Velocidad, Me.distanciaTerrestre)
            Else
                Return Me.CarreteraHoras
            End If
        End Get
    End Property
    Public Property costeKm() As Single
        Get
            Return _costeKm
        End Get
        Set(ByVal value As Single)
            _costeKm = value
        End Set
    End Property
    Public Property costeKmAcarreoOrigen() As Single
        Get
            Return _costeKmAcarreoOrigen
        End Get
        Set(ByVal value As Single)
            _costeKmAcarreoOrigen = value
        End Set
    End Property
    Public Property costeKmAcarreoDestino() As Single
        Get
            Return _costeKmAcarreoDestino
        End Get
        Set(ByVal value As Single)
            _costeKmAcarreoDestino = value
        End Set
    End Property
    Public Property Velocidad() As Single
        Get
            Return _Velocidad
        End Get
        Set(ByVal value As Single)
            _Velocidad = value
        End Set
    End Property
    Public Property VelocidadAcarreoOrigen() As Single
        Get
            Return Me._VelocidadAcarreoOrigen
        End Get
        Set(ByVal value As Single)
            Me._VelocidadAcarreoOrigen = value
        End Set
    End Property
    Public Property VelocidadAcarreoDestino() As Single
        Get
            Return Me._VelocidadAcarreoDestino
        End Get
        Set(ByVal value As Single)
            Me._VelocidadAcarreoDestino = value
        End Set
    End Property

    Public Property RecargoMercanciaPeligrosa() As Boolean
        Get
            Return _RecargoMercanciaPeligrosa
        End Get
        Set(ByVal value As Boolean)
            _RecargoMercanciaPeligrosa = value
        End Set
    End Property
    Public Property RecargoRefrigerado() As Boolean
        Get
            Return _RecargoRefrigerado
        End Get
        Set(ByVal value As Boolean)
            _RecargoRefrigerado = value
        End Set
    End Property
    Public Property RecargoCabezaTractora() As Boolean
        Get
            Return _RecargoCabezaTractora
        End Get
        Set(ByVal value As Boolean)
            _RecargoCabezaTractora = value
        End Set
    End Property
    Public Property RecargoAnimalesVivos() As Boolean
        Get
            Return _RecargoAnimalesVivos
        End Get
        Set(ByVal value As Boolean)
            Me._RecargoAnimalesVivos = value
        End Set
    End Property
    Public Property costeExternoKmTnCarretera As Double
        Get
            Return Me._costeExternoKmTnCarretera
        End Get
        Set(ByVal value As Double)
            Me._costeExternoKmTnCarretera = value
        End Set
    End Property
    Public Property costeExternoKmTnMaritimo As Double
        Get
            Return Me._costeExternoKmTnMaritimo
        End Get
        Set(ByVal value As Double)
            Me._costeExternoKmTnMaritimo = value
        End Set
    End Property
    Public Property costeEmisionCO2KmTnCarretera As Double
        Get
            Return Me._costeEmisionCO2KmTnCarretera
        End Get
        Set(ByVal value As Double)
            Me._costeEmisionCO2KmTnCarretera = value
        End Set
    End Property
    Public Property costeEmisionCO2KmTnMaritimo As Double
        Get
            Return Me._costeEmisionCO2KmTnMaritimo
        End Get
        Set(ByVal value As Double)
            Me._costeEmisionCO2KmTnMaritimo = value
        End Set
    End Property
    Public Property toneladasTransportadas As Double
        Get
            Return Me._toneladasTransportadas
        End Get
        Set(ByVal value As Double)
            Me._toneladasTransportadas = value
        End Set
    End Property
    Sub CalcularMisViajes()
        Dim miTabla As New DataTable

        ' Create DataColumn objects of data types.
        Dim colID As DataColumn = New DataColumn("ID")
        colID.DataType = System.Type.GetType("System.Single")
        miTabla.Columns.Add(colID)

        Dim colLineaID As DataColumn = New DataColumn("LineaID")
        colLineaID.DataType = System.Type.GetType("System.Single")
        miTabla.Columns.Add(colLineaID)

        Dim colOrigen As DataColumn = New DataColumn("Origen")
        colOrigen.DataType = System.Type.GetType("System.String")
        miTabla.Columns.Add(colOrigen)

        Dim colDestino As DataColumn = New DataColumn("Destino")
        colDestino.DataType = System.Type.GetType("System.String")
        miTabla.Columns.Add(colDestino)

        Dim colLinea As DataColumn = New DataColumn("Linea")
        colLinea.DataType = System.Type.GetType("System.String")
        miTabla.Columns.Add(colLinea)

        Dim colPuertoOrigen As DataColumn = New DataColumn("PuertoOrigen")
        colPuertoOrigen.DataType = System.Type.GetType("System.String")
        miTabla.Columns.Add(colPuertoOrigen)

        Dim colPuertoDestino As DataColumn = New DataColumn("PuertoDestino")
        colPuertoDestino.DataType = System.Type.GetType("System.String")
        miTabla.Columns.Add(colPuertoDestino)

        Dim colNaviera As DataColumn = New DataColumn("Naviera")
        colNaviera.DataType = System.Type.GetType("System.String")
        miTabla.Columns.Add(colNaviera)

        Dim colVelocidad As DataColumn = New DataColumn("Velocidad")
        colVelocidad.DataType = System.Type.GetType("System.Single")
        miTabla.Columns.Add(colVelocidad)

        Dim colVelocidadAcarreoOrigen As DataColumn = New DataColumn("VelocidadAcarreoOrigen")
        colVelocidadAcarreoOrigen.DataType = System.Type.GetType("System.Single")
        miTabla.Columns.Add(colVelocidadAcarreoOrigen)

        Dim colVelocidadAcarreoDestino As DataColumn = New DataColumn("VelocidadAcarreoDestino")
        colVelocidadAcarreoDestino.DataType = System.Type.GetType("System.Single")
        miTabla.Columns.Add(colVelocidadAcarreoDestino)

        Dim colCosteKmTerrestre As DataColumn = New DataColumn("CosteKmTerrestre")
        colCosteKmTerrestre.DataType = System.Type.GetType("System.Single")
        miTabla.Columns.Add(colCosteKmTerrestre)

        Dim colCosteKmMaritimo As DataColumn = New DataColumn("CosteKmMaritimo")
        colCosteKmMaritimo.DataType = System.Type.GetType("System.Single")
        miTabla.Columns.Add(colCosteKmMaritimo)

        Dim colCosteParalizacionHora As DataColumn = New DataColumn("CosteParalizacionHora")
        colCosteParalizacionHora.DataType = System.Type.GetType("System.Single")
        miTabla.Columns.Add(colCosteParalizacionHora)

        Dim colDistanciaOrigenPuerto As DataColumn = New DataColumn("distanciaOrigenPuerto")
        colDistanciaOrigenPuerto.DataType = System.Type.GetType("System.Single")
        miTabla.Columns.Add(colDistanciaOrigenPuerto)

        Dim colDistanciaPuertoPuerto As DataColumn = New DataColumn("DistanciaPuertoPuerto")
        colDistanciaPuertoPuerto.DataType = System.Type.GetType("System.Single")
        miTabla.Columns.Add(colDistanciaPuertoPuerto)

        Dim colDistanciaPuertoDestino As DataColumn = New DataColumn("DistanciaPuertoDestino")
        colDistanciaPuertoDestino.DataType = System.Type.GetType("System.Single")
        miTabla.Columns.Add(colDistanciaPuertoDestino)

        Dim colTiempoOrigenPuerto As DataColumn = New DataColumn("tiempoOrigenPuerto")
        colTiempoOrigenPuerto.DataType = System.Type.GetType("System.Single")
        miTabla.Columns.Add(colTiempoOrigenPuerto)

        Dim colTiempoPuertoPuerto As DataColumn = New DataColumn("TiempoPuertoPuerto")
        colTiempoPuertoPuerto.DataType = System.Type.GetType("System.Single")
        miTabla.Columns.Add(colTiempoPuertoPuerto)

        Dim colTiempoPuertoDestino As DataColumn = New DataColumn("TiempoPuertoDestino")
        colTiempoPuertoDestino.DataType = System.Type.GetType("System.Single")
        miTabla.Columns.Add(colTiempoPuertoDestino)

        Dim colCosteOrigenPuerto As DataColumn = New DataColumn("costeOrigenPuerto")
        colCosteOrigenPuerto.DataType = System.Type.GetType("System.Single")
        miTabla.Columns.Add(colCosteOrigenPuerto)

        Dim colCostePuertoPuerto As DataColumn = New DataColumn("CostePuertoPuerto")
        colCostePuertoPuerto.DataType = System.Type.GetType("System.Single")
        miTabla.Columns.Add(colCostePuertoPuerto)

        Dim colCostePuertoPuertoconRecargos As DataColumn = New DataColumn("CostePuertoPuertoconRecargos")
        colCostePuertoPuertoconRecargos.DataType = System.Type.GetType("System.Single")
        miTabla.Columns.Add(colCostePuertoPuertoconRecargos)

        Dim colCostePuertoDestino As DataColumn = New DataColumn("CostePuertoDestino")
        colCostePuertoDestino.DataType = System.Type.GetType("System.Single")
        miTabla.Columns.Add(colCostePuertoDestino)

        Dim colPeajes As DataColumn = New DataColumn("Peajes")
        colPeajes.DataType = System.Type.GetType("System.Single")
        miTabla.Columns.Add(colPeajes)

        Dim colRecargoCabezaTractora As DataColumn = New DataColumn("RecargoCabezaTractora")
        colRecargoCabezaTractora.DataType = System.Type.GetType("System.Single")
        miTabla.Columns.Add(colRecargoCabezaTractora)

        Dim colRecargoRefrigerado As DataColumn = New DataColumn("RecargoRefrigerado")
        colRecargoRefrigerado.DataType = System.Type.GetType("System.Single")
        miTabla.Columns.Add(colRecargoRefrigerado)

        Dim colRecargoMercanciaPeligrosa As DataColumn = New DataColumn("RecargoMercanciaPeligrosa")
        colRecargoMercanciaPeligrosa.DataType = System.Type.GetType("System.Single")
        miTabla.Columns.Add(colRecargoMercanciaPeligrosa)

        Dim colAnimalesVivos As DataColumn = New DataColumn("RecargoAnimalesVivos")
        colAnimalesVivos.DataType = System.Type.GetType("System.Single")
        miTabla.Columns.Add(colAnimalesVivos)

        Dim colDistanciaTotal As DataColumn = New DataColumn("DistanciaTotal")
        colDistanciaTotal.DataType = System.Type.GetType("System.Single")
        miTabla.Columns.Add(colDistanciaTotal)

        Dim colTiempoTotal As DataColumn = New DataColumn("TiempoTotal")
        colTiempoTotal.DataType = System.Type.GetType("System.Single")
        miTabla.Columns.Add(colTiempoTotal)

        Dim colCosteTotalsinRecargos As DataColumn = New DataColumn("CosteTotalsinRecargos")
        colCosteTotalsinRecargos.DataType = System.Type.GetType("System.Single")
        miTabla.Columns.Add(colCosteTotalsinRecargos)

        Dim colCosteTotal As DataColumn = New DataColumn("CosteTotal")
        colCosteTotal.DataType = System.Type.GetType("System.Single")
        miTabla.Columns.Add(colCosteTotal)

        Dim colObservaciones As DataColumn = New DataColumn("Observaciones")
        colObservaciones.DataType = System.Type.GetType("System.String")
        miTabla.Columns.Add(colObservaciones)

        Dim colWeb As DataColumn = New DataColumn("Web")
        colWeb.DataType = System.Type.GetType("System.String")
        miTabla.Columns.Add(colWeb)

        Dim colFachada As DataColumn = New DataColumn("Fachada")
        colFachada.DataType = System.Type.GetType("System.String")
        miTabla.Columns.Add(colFachada)

        Dim colFrecuenciaMensual As DataColumn = New DataColumn("FrecuenciaMensual")
        colFrecuenciaMensual.DataType = System.Type.GetType("System.Single")
        miTabla.Columns.Add(colFrecuenciaMensual)

        Dim colCostesExternosTerrestre As DataColumn = New DataColumn("CostesExternosTerrestre")
        colCostesExternosTerrestre.DataType = System.Type.GetType("System.Double")
        miTabla.Columns.Add(colCostesExternosTerrestre)

        Dim colCostesExternosOrigenPuerto As DataColumn = New DataColumn("CostesExternosOrigenPuerto")
        colCostesExternosOrigenPuerto.DataType = System.Type.GetType("System.Double")
        miTabla.Columns.Add(colCostesExternosOrigenPuerto)

        Dim colCostesExternosPuertoDestino As DataColumn = New DataColumn("CostesExternosPuertoDestino")
        colCostesExternosPuertoDestino.DataType = System.Type.GetType("System.Double")
        miTabla.Columns.Add(colCostesExternosPuertoDestino)

        Dim colCostesExternosPuertoPuerto As DataColumn = New DataColumn("CostesExternosPuertoPuerto")
        colCostesExternosPuertoPuerto.DataType = System.Type.GetType("System.Double")
        miTabla.Columns.Add(colCostesExternosPuertoPuerto)

        Dim colCostesExternosTotal As DataColumn = New DataColumn("CostesExternosTotal")
        colCostesExternosTotal.DataType = System.Type.GetType("System.Double")
        miTabla.Columns.Add(colCostesExternosTotal)


        Dim colCosteEmisionCO2Terrestre As DataColumn = New DataColumn("CosteEmisionCO2Terrestre")
        colCosteEmisionCO2Terrestre.DataType = System.Type.GetType("System.Double")
        miTabla.Columns.Add(colCosteEmisionCO2Terrestre)

        Dim colCosteEmisionCO2OrigenPuerto As DataColumn = New DataColumn("CosteEmisionCO2OrigenPuerto")
        colCosteEmisionCO2OrigenPuerto.DataType = System.Type.GetType("System.Double")
        miTabla.Columns.Add(colCosteEmisionCO2OrigenPuerto)

        Dim colCosteEmisionCO2PuertoDestino As DataColumn = New DataColumn("CosteEmisionCO2PuertoDestino")
        colCosteEmisionCO2PuertoDestino.DataType = System.Type.GetType("System.Double")
        miTabla.Columns.Add(colCosteEmisionCO2PuertoDestino)

        Dim colCosteEmisionCO2PuertoPuerto As DataColumn = New DataColumn("CosteEmisionCO2PuertoPuerto")
        colCosteEmisionCO2PuertoPuerto.DataType = System.Type.GetType("System.Double")
        miTabla.Columns.Add(colCosteEmisionCO2PuertoPuerto)

        Dim colCosteEmisionCO2Total As DataColumn = New DataColumn("CosteEmisionCO2Total")
        colCosteEmisionCO2Total.DataType = System.Type.GetType("System.Double")
        miTabla.Columns.Add(colCosteEmisionCO2Total)


        Dim colNavieraID As DataColumn = New DataColumn("NavieraID")
        colNavieraID.DataType = System.Type.GetType("System.Single")
        miTabla.Columns.Add(colNavieraID)

        Dim colPuertoOrigenID As DataColumn = New DataColumn("PuertoOrigenID")
        colPuertoOrigenID.DataType = System.Type.GetType("System.Single")
        miTabla.Columns.Add(colPuertoOrigenID)

        Dim colPuertoDestinoID As DataColumn = New DataColumn("PuertoDestinoID")
        colPuertoDestinoID.DataType = System.Type.GetType("System.Single")
        miTabla.Columns.Add(colPuertoDestinoID)

        Dim colNavieraIDEnlace As DataColumn = New DataColumn("NavieraIDEnlace")
        colNavieraIDEnlace.DataType = System.Type.GetType("System.String")
        miTabla.Columns.Add(colNavieraIDEnlace)

        Dim colPuertoOrigenIDEnlace As DataColumn = New DataColumn("PuertoOrigenIDEnlace")
        colPuertoOrigenIDEnlace.DataType = System.Type.GetType("System.String")
        miTabla.Columns.Add(colPuertoOrigenIDEnlace)

        Dim colPuertoDestinoIDEnlace As DataColumn = New DataColumn("PuertoDestinoIDEnlace")
        colPuertoDestinoIDEnlace.DataType = System.Type.GetType("System.String")
        miTabla.Columns.Add(colPuertoDestinoIDEnlace)



        Dim colEnlaceComodalWeb As DataColumn = New DataColumn("EnlaceComodalWeb")
        colEnlaceComodalWeb.DataType = System.Type.GetType("System.String")
        miTabla.Columns.Add(colEnlaceComodalWeb)

        Dim colFleteMensaje As DataColumn = New DataColumn("FleteMensaje")
        colFleteMensaje.DataType = System.Type.GetType("System.String")
        miTabla.Columns.Add(colFleteMensaje)

        Dim colSeleccionado As DataColumn = New DataColumn("Seleccionado")
        colSeleccionado.DataType = System.Type.GetType("System.Boolean")
        miTabla.Columns.Add(colSeleccionado)

        Dim dt As DataTable = Datos.PuertoLista(Me.WhereMisViajes)
        Dim dr As DataRow
        Dim contador As Integer = 0

        For Each dr In dt.Rows

            Dim miNewRow As DataRow = miTabla.NewRow()
            Dim distanciaOrigenPuerto As Single, distanciaPuertoDestino As Single, distanciaTotal As Single
            Dim tiempoOrigenPuerto As Single, tiempoPuertoDestino As Single
            Dim costeOrigenPuerto As Single, costePuertoDestino As Single
            Dim distanciaPuertoPuerto As Single, costePuertoPuerto As Single, tiempoPuertoPuerto As Single
            Dim costeTotal As Single = 0
            Dim costeRecargos As Single = 0


            If Me.RecargoCabezaTractora Then costeRecargos += IIf(IsDBNull(dr.Item("RecargoCabezaTractora")), 0, Funciones.Coma2Punto(dr.Item("RecargoCabezaTractora")))
            If Me.RecargoRefrigerado Then costeRecargos += IIf(IsDBNull(dr.Item("RecargoCCRR")), 0, Funciones.Coma2Punto(dr.Item("RecargoCCRR")))
            If Me.RecargoMercanciaPeligrosa Then costeRecargos += IIf(IsDBNull(dr.Item("RecargoMercanciaPeligrosa")), 0, Funciones.Coma2Punto(dr.Item("RecargoMercanciaPeligrosa")))
            If Me.RecargoAnimalesVivos Then costeRecargos += IIf(IsDBNull(dr.Item("RecargoAnimalesVivos")), 0, Funciones.Coma2Punto(dr.Item("RecargoAnimalesVivos")))
            costeRecargos += Me.Peajes

            distanciaOrigenPuerto = Funciones.Distancia(Me.origen, dr.Item("PuertoOrigenMappoint"))
            distanciaPuertoPuerto = CType(IIf(IsDBNull(dr.Item("DistanciaMillas")), 0, Funciones.Coma2Punto(dr.Item("DistanciaMillas"))), Single) * 1.8520000000000001
            distanciaPuertoDestino = Funciones.Distancia(dr.Item("PuertoDestinoMappoint"), Me.destino)


            '******************************************************************
            'MODIFICACION PARA CALCULAR EL PUERTO MAS CERCANO AL ORIGEN         Sep-2007
            '******************************************************************
            Dim distanciaOrigenPuerto2 As Single
            Dim cPuertoOrigen As String, cPuertoDestino As String
            cPuertoOrigen = dr.Item("PuertoOrigen")
            cPuertoDestino = dr.Item("PuertoDestino")
            'distanciaOrigenPuerto2 = Funciones.Distancia(Me.origen, dr.Item("PuertoDestinoMappoint"))
            'If distanciaOrigenPuerto > distanciaOrigenPuerto2 Then
            ' cPuertoOrigen = dr.Item("PuertoDestino")
            ' cPuertoDestino = dr.Item("PuertoOrigen")
            'distanciaOrigenPuerto = distanciaOrigenPuerto2
            'distanciaPuertoDestino = Funciones.Distancia(Me.destino, dr.Item("PuertoOrigenMappoint"))
            'End If
            '******************************************************************

            tiempoOrigenPuerto = TiempoTerrestreconDescanso(Me.VelocidadAcarreoOrigen, distanciaOrigenPuerto)
            tiempoPuertoPuerto = CType(IIf(IsDBNull(dr.Item("TiempoTotalTransporteMaritimo")), 0, Funciones.Coma2Punto(dr.Item("TiempoTotalTransporteMaritimo"))), Single)
            tiempoPuertoDestino = TiempoTerrestreconDescanso(Me.VelocidadAcarreoDestino, distanciaPuertoDestino)
            costeOrigenPuerto = CType(Me.costeKmAcarreoOrigen, Single) * distanciaOrigenPuerto
            costePuertoPuerto = CType(IIf(IsDBNull(dr.Item("FleteMaritimo")), 0, Funciones.Coma2Punto(dr.Item("FleteMaritimo"))), Single)
            costePuertoDestino = CType(Me.costeKmAcarreoDestino, Single) * distanciaPuertoDestino

            costeTotal = costeOrigenPuerto + costePuertoPuerto + costePuertoDestino + costeRecargos

            contador += 1
            miNewRow.Item("LineaID") = contador
            miNewRow.Item("ID") = dr.Item("ID")
            miNewRow.Item("Origen") = Me.origenOriginal
            miNewRow.Item("Destino") = Me.destinoOriginal

            miNewRow.Item("Linea") = dr.Item("PuertoOrigen") + " ** " + dr.Item("PuertoDestino")
            miNewRow.Item("PuertoOrigen") = cPuertoOrigen
            miNewRow.Item("PuertoDestino") = cPuertoDestino
            miNewRow.Item("Naviera") = IIf(IsDBNull(dr.Item("Naviera")), "", dr.Item("Naviera"))
            miNewRow.Item("Velocidad") = Me.Velocidad
            miNewRow.Item("VelocidadAcarreoOrigen") = Me.VelocidadAcarreoOrigen
            miNewRow.Item("VelocidadAcarreoDestino") = Me.VelocidadAcarreoDestino
            miNewRow.Item("CosteKmTerrestre") = Me.costeKm
            miNewRow.Item("CosteKmMaritimo") = CType(IIf(IsDBNull(dr.Item("FleteMaritimo")), 0, Funciones.Coma2Punto(dr.Item("FleteMaritimo"))), Single) / _
                                              (CType(IIf(IsDBNull(dr.Item("DistanciaMillas")), 0, Funciones.Coma2Punto(dr.Item("DistanciaMillas"))), Single) * _
                                              1.852)
            miNewRow.Item("CosteParalizacionHora") = 0
            miNewRow.Item("distanciaOrigenPuerto") = distanciaOrigenPuerto
            miNewRow.Item("distanciaPuertoDestino") = distanciaPuertoDestino
            miNewRow.Item("tiempoOrigenPuerto") = tiempoOrigenPuerto
            miNewRow.Item("tiempoPuertoDestino") = tiempoPuertoDestino
            miNewRow.Item("costeOrigenPuerto") = costeOrigenPuerto
            miNewRow.Item("costePuertoDestino") = costePuertoDestino
            miNewRow.Item("distanciaPuertoPuerto") = distanciaPuertoPuerto
            miNewRow.Item("costePuertoPuerto") = costePuertoPuerto
            miNewRow.Item("costePuertoPuertoconRecargos") = costePuertoPuerto + costeRecargos
            miNewRow.Item("tiempoPuertoPuerto") = tiempoPuertoPuerto
            miNewRow.Item("RecargoCabezaTractora") = IIf(IsDBNull(dr.Item("RecargoCabezaTractora")), 0, Funciones.Coma2Punto(dr.Item("RecargoCabezaTractora")))
            miNewRow.Item("RecargoRefrigerado") = IIf(IsDBNull(dr.Item("RecargoCCRR")), 0, Funciones.Coma2Punto(dr.Item("RecargoCCRR")))
            miNewRow.Item("RecargoMercanciaPeligrosa") = IIf(IsDBNull(dr.Item("RecargoMercanciaPeligrosa")), 0, Funciones.Coma2Punto(dr.Item("RecargoMercanciaPeligrosa")))
            miNewRow.Item("Peajes") = Me.Peajes
            distanciaTotal = distanciaOrigenPuerto + distanciaPuertoPuerto + distanciaPuertoDestino
            If distanciaTotal > 99999 Then distanciaTotal = 99999
            miNewRow.Item("DistanciaTotal") = distanciaTotal
            miNewRow.Item("TiempoTotal") = tiempoOrigenPuerto + tiempoPuertoPuerto + tiempoPuertoDestino
            miNewRow.Item("CosteTotalsinRecargos") = costeOrigenPuerto + costePuertoPuerto + costePuertoDestino

            miNewRow.Item("CosteTotal") = costeTotal
            miNewRow.Item("Observaciones") = "" 'dr.Item("Observaciones")
            miNewRow.Item("Web") = "" 'dr.Item("Web")
            miNewRow.Item("Fachada") = IIf(IsDBNull(dr.Item("Fachada")), "", dr.Item("Fachada"))
            miNewRow.Item("FrecuenciaMensual") = IIf(IsDBNull(dr.Item("FrecuenciaMensual")), 0, dr.Item("FrecuenciaMensual"))
            miNewRow.Item("NavieraID") = IIf(IsDBNull(dr.Item("NavieraID")), 0, dr.Item("NavieraID"))
            miNewRow.Item("PuertoOrigenID") = IIf(IsDBNull(dr.Item("PuertoOrigenID")), 0, dr.Item("PuertoOrigenID"))
            miNewRow.Item("PuertoDestinoID") = IIf(IsDBNull(dr.Item("PuertoDestinoID")), 0, dr.Item("PuertoDestinoID"))
            miNewRow.Item("EnlaceComodalWeb") = IIf(IsDBNull(dr.Item("EnlaceComodalWeb")), 0, dr.Item("EnlaceComodalWeb"))

            If miNewRow.Item("NavieraID") = 0 Then
                miNewRow.Item("NavieraIDEnlace") = ""
            Else
                miNewRow.Item("NavieraIDEnlace") = " <a href=""./verNaviera.aspx?id=" & miNewRow.Item("NavieraID") & """ target=""_blank"">" & _
                                "Información sobre la Naviera y el Servicio Marítimo.</a>"
            End If
            If miNewRow.Item("PuertoOrigenID") = 0 Then
                miNewRow.Item("PuertoOrigenIDEnlace") = "Puerto de Origen: Puerto de " & miNewRow.Item("PuertoOrigen")
            Else
                miNewRow.Item("PuertoOrigenIDEnlace") = "<a href=""./verPuerto.aspx?id=" & miNewRow.Item("PuertoOrigenID") & """ target=""_blank"">" & _
                                "Información sobre el Puerto de Origen: Puerto de " & miNewRow.Item("PuertoOrigen") & ".</a>"
            End If

            If miNewRow.Item("PuertoDestinoID") = 0 Then
                miNewRow.Item("PuertoDestinoIDEnlace") = "Puerto de Destino: Puerto de " & miNewRow.Item("PuertoDestino")
            Else
                miNewRow.Item("PuertoOrigenIDEnlace") = "<a href=""./verPuerto.aspx?id=" & miNewRow.Item("PuertoDestinoID") & """ target=""_blank"">" & _
                                "Información sobre el Puerto de Origen: Puerto de " & miNewRow.Item("PuertoDestino") & ".</a>"
            End If


            miNewRow.Item("CostesExternosTerrestre") = Me.costeExternoKmTnCarretera * Me.toneladasTransportadas * Me.distanciaTerrestre
            miNewRow.Item("CostesExternosOrigenPuerto") = Me.costeExternoKmTnCarretera * Me.toneladasTransportadas * distanciaOrigenPuerto
            miNewRow.Item("CostesExternosPuertoDestino") = Me.costeExternoKmTnCarretera * Me.toneladasTransportadas * distanciaPuertoDestino
            miNewRow.Item("CostesExternosPuertoPuerto") = Me.costeExternoKmTnMaritimo * Me.toneladasTransportadas * distanciaPuertoPuerto
            miNewRow.Item("CostesExternosTotal") = miNewRow.Item("CostesExternosOrigenPuerto") + miNewRow.Item("CostesExternosPuertoDestino") + miNewRow.Item("CostesExternosPuertoPuerto")

            miNewRow.Item("CosteEmisionCO2Terrestre") = Me.costeEmisionCO2KmTnCarretera * Me.toneladasTransportadas * Me.distanciaTerrestre
            miNewRow.Item("CosteEmisionCO2OrigenPuerto") = Me.costeEmisionCO2KmTnCarretera * Me.toneladasTransportadas * distanciaOrigenPuerto
            miNewRow.Item("CosteEmisionCO2PuertoDestino") = Me.costeEmisionCO2KmTnCarretera * Me.toneladasTransportadas * distanciaPuertoDestino
            miNewRow.Item("CosteEmisionCO2PuertoPuerto") = Me.costeEmisionCO2KmTnMaritimo * Me.toneladasTransportadas * distanciaPuertoPuerto
            miNewRow.Item("CosteEmisionCO2Total") = miNewRow.Item("CosteEmisionCO2OrigenPuerto") + miNewRow.Item("CosteEmisionCO2PuertoDestino") + miNewRow.Item("CosteEmisionCO2PuertoPuerto")
            miNewRow.Item("FleteMensaje") = IIf(IsDBNull(dr.Item("FleteMensaje")), "El coste del transporte marítimo es orientativo, para mayor precisión por favor consulte a la naviera.", dr.Item("FleteMensaje"))
            miNewRow.Item("Seleccionado") = True

            miTabla.Rows.Add(miNewRow)
            miNewRow = Nothing
        Next
        Dim cFiltro As String
        cFiltro = Me.WhereMisViajes
        If Me.WhereMisViajesCondicion <> String.Empty Then
            If cFiltro <> String.Empty Then cFiltro = cFiltro & " AND "
            cFiltro = cFiltro & Me.WhereMisViajesCondicion
        End If
        cFiltro = cFiltro.Replace("LineaID", "ID")
        miTabla.DefaultView.RowFilter = cFiltro
        If Me.ResultadosOrden <> String.Empty Then
            miTabla.DefaultView.Sort = Me.ResultadosOrden
        End If
        Me.misViajes = miTabla.DefaultView.ToTable
    End Sub

    Shared Function ORigenes() As DataTable
        'Devuelve una tabla con los puertos más cercanos a la ciudad introducida
        'Return Datos.Origenes
        Return New DataTable
    End Function

    Shared Function TodosPuertos() As DataTable
        'Devuelve una tabla con los puertos más cercanos a la ciudad introducida
        Return Datos.PuertoLista
    End Function
    Private Function TiempoTerrestreconDescansoOLD(ByVal velocidad As Single, ByVal distancia As Single) As Single
        'Calcula el tiempo de trayecto para una velocidad y distancia dada
        ' Toma 4,5 de conduccion, 1 de descanso, 4,5 de conducción, 10 de descanso
        Dim resultado As Single = 0
        Dim tiempo As Single = distancia / velocidad
        While tiempo > 9
            tiempo -= 9
            resultado = resultado + 20
        End While
        resultado = resultado + tiempo
        If tiempo > 4.5 Then
            resultado += 1
        End If
        Return resultado
    End Function
    Private Function TiempoTerrestreconDescanso(ByVal velocidad As Single, ByVal distancia As Single) As Single
        'Calcula el tiempo de trayecto para una velocidad y distancia dada
        Dim TiempoConduccion As Single = 0
        Dim TiempoConduccionRestante As Single = 0
        Dim descanso As Single = 0
        Dim descansoAcumulado As Single = 0
        Dim retorno As Single = 0
        Dim margen As Single = 0.99999000000000005
        'Calcula el tiempo de conducción sin descanso
        TiempoConduccion = distancia / velocidad
        TiempoConduccionRestante = TiempoConduccion
        'Calcula el tiempo de descanso para 6 días
        While TiempoConduccionRestante >= 54
            TiempoConduccionRestante -= 54
            descansoAcumulado += 96.5 '59.5
        End While
        'Calculo del descanso del resto de tiempo
        Select Case TiempoConduccionRestante
            Case Is < 4.5
                descanso = 0
            Case Is < (4.5 + margen)
                descanso = 0.75
            Case Is < 9
                descanso = 0.75
            Case Is < (9 + margen)
                descanso = 0.75 + 0.75
            Case Is < 13.5
                descanso = 11.75
            Case Is < (13.5 + margen)
                descanso = 11.75 + 0.75
            Case Is < 18
                descanso = 12.5
            Case Is < (18 + margen)
                descanso = 12.5 + 0.75
            Case Is < 22.5
                descanso = 23.5
            Case Is < (22.5 + margen)
                descanso = 23.5 + 0.75
            Case Is < 27
                descanso = 24.25
            Case Is < (27 + margen)
                descanso = 24.25 + 0.75
            Case Is < 31.5
                descanso = 35.25
            Case Is < (31.5 + margen)
                descanso = 35.25 + 0.75
            Case Is < 36
                descanso = 36
            Case Is < (36 + margen)
                descanso = 36 + 0.75
            Case Is < 40.5
                descanso = 47
            Case Is < (40.5 + margen)
                descanso = 47 + 0.75
            Case Is < 45
                descanso = 47.75
            Case Is < (45 + margen)
                descanso = 47.75 + 0.75
            Case Is < 49.5
                descanso = 95.75
            Case Is < (49.5 + margen)
                descanso = 95.75 + 0.75
            Case Is < 54
                descanso = 96.5
            Case Is < (54 + margen)
                descanso = 96.5 + 0.75
        End Select
        retorno = TiempoConduccion + descansoAcumulado + descanso
        Return retorno

    End Function



    'Shared Function ComprobarLocalidad(ByVal cLocalidad As String) As String()
    ' 'Return Datos.ComprobarLocalidad(cLocalidad)
    ' Dim retorno() As String
    '     Return retorno
    ' End Function
    '

    'Private Function TiempoTerrestreconDescanso(ByVal velocidad As Single, ByVal distancia As Single) As Single
    '    'Calcula el tiempo de trayecto para una velocidad y distancia dada
    '    Dim TiempoConduccion As Single = 0
    '    Dim descanso As Single = 0
    '    Dim descansoAcumulado As Single = 0
    '    Dim retorno As Single = 0
    '    'Calcula el tiempo de conducción sin descanso
    '    TiempoConduccion = distancia / velocidad
    '    'Calcula el tiempo de descanso para 6 días
    '    While TiempoConduccion >= 54
    '        TiempoConduccion -= 54
    '        descansoAcumulado += 59.5
    '    End While
    '    'Calculo del descanso del resto de tiempo
    '    Select Case TiempoConduccion
    '        Case Is < 4.5
    '            descanso = 0
    '        Case Is < 9
    '            descanso = 0.75
    '        Case Is < 13.5
    '            descanso = 11.8
    '        Case Is < 18
    '            descanso = 12.5
    '        Case Is < 22.5
    '            descanso = 23.5
    '        Case Is < 27
    '            descanso = 24.3
    '        Case Is < 31.5
    '            descanso = 35.3
    '        Case Is < 36
    '            descanso = 36
    '        Case Is < 40.5
    '            descanso = 47
    '        Case Is < 45
    '            descanso = 47.8
    '        Case Is < 49.5
    '            descanso = 58.8
    '        Case Is < 54
    '            descanso = 59.5
    '    End Select
    '    retorno = TiempoConduccion + descansoAcumulado + descanso
    '    Return retorno
    'End Function

End Class