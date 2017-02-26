Imports Microsoft.VisualBasic
Imports System.Collections.Generic

Public Class Linea
    Private _ID As Long
    Private _PuertoOrigen As String
    Private _PuertoDestino As String
    Private _PuertoOrigenMappoint As String
    Private _PuertoDestinoMappoint As String
    Private _PuertoOrigenobj As PuertoFicha
    Private _PuertoDestinoobj As PuertoFicha

    Private _PuertoOrigenLongitud As Single
    Private _PuertoOrigenLatitud As Single
    Private _PuertoDestinoLongitud As Single
    Private _PuertoDestinoLatitud As Single

    Private _Linea As String
    Private _Naviera As String
    Private _NavieraFicha As NavieraFicha
    Private _Frecuencia As String
    Private _FrecuenciaMensual As Integer
    Private _TipoTrafico As String
    Private _DistanciaMillas As Double
    Private _TiempoPuertoOrigen As Double
    Private _TiempoTransito As Double
    Private _TiempoPuertoDestino As Double
    Private _TiempoTotalTransporteMaritimo As Double
    Private _FleteMaritimo As Double
    Private _RecargoCabezaTractora As Double
    Private _RecargoBAF As Double
    Private _RecargoMercanciaPeligrosa As Double
    Private _RecargoCCRR As Double
    Private _CapPlataformas As Double
    Private _CapPasajeros As Double
    Private _CapCoches As Double
    Private _Fachada As String
    Private _Visible As Boolean
    Private _EnlaceComodalWeb As String
    Private _FleteMensaje As String


    Public Sub New()
        Me.ID = 0
        Me.PuertoOrigen = 0
        Me.PuertoDestino = String.Empty
        Me.PuertoOrigenMappoint = String.Empty
        Me.PuertoDestinoMappoint = String.Empty
        Me.PuertoOrigenObj = New PuertoFicha
        Me.PuertoDestinoObj = New PuertoFicha
        Me.PuertoOrigenLongitud = 0
        Me.PuertoOrigenLatitud = 0
        Me.PuertoDestinoLongitud = 0
        Me.PuertoDestinoLatitud = 0
        Me.Linea = String.Empty
        Me.Naviera = String.Empty
        Me.NavieraFicha = New NavieraFicha
        Me.Frecuencia = String.Empty
        Me.FrecuenciaMensual = 0
        Me.TipoTrafico = String.Empty
        Me.DistanciaMillas = 0
        Me.TiempoPuertoOrigen = 0
        Me.TiempoTransito = 0
        Me.TiempoPuertoDestino = 0
        Me.FleteMaritimo = 0
        Me.RecargoCabezaTractora = 0
        Me.RecargoBAF = 0
        Me.RecargoMercanciaPeligrosa = 0
        Me.RecargoCCRR = 0
        Me.CapPlataformas = 0
        Me.CapPasajeros = 0
        Me.CapCoches = 0
        Me.Fachada = String.Empty
        Me.Visible = False
        Me.EnlaceComodalWeb = String.Empty
        Me.FleteMensaje = String.Empty
    End Sub
    Public Sub New(ByVal ID As Long)
        Dim dr As System.Data.DataRow = LineaData.GetbyID(ID)
        With dr
            Me.ID = IIf(IsDBNull(dr.Item("ID")), 0, dr.Item("ID"))
            Me.PuertoOrigen = IIf(IsDBNull(dr.Item("PuertoOrigen")), String.Empty, dr.Item("PuertoOrigen"))
            Me.PuertoDestino = IIf(IsDBNull(dr.Item("PuertoDestino")), String.Empty, dr.Item("PuertoDestino"))
            Me.PuertoOrigenMappoint = IIf(IsDBNull(dr.Item("PuertoOrigenMappoint")), String.Empty, dr.Item("PuertoOrigenMappoint"))
            Me.PuertoDestinoMappoint = IIf(IsDBNull(dr.Item("PuertoDestinoMappoint")), String.Empty, dr.Item("PuertoDestinoMappoint"))
            Me.PuertoOrigenObj = IIf(IsDBNull(dr.Item("PuertoOrigenID")), New PuertoFicha, New PuertoFicha(dr.Item("PuertoOrigenID")))
            Me.PuertoDestinoObj = IIf(IsDBNull(dr.Item("PuertoDestinoID")), New PuertoFicha, New PuertoFicha(dr.Item("PuertoDestinoID")))
            'Me.PuertoOrigenLongitud = IIf(IsDBNull(dr.Item("PuertoOrigenLongitud")), 0, dr.Item("PuertoOrigenLongitud"))
            'Me.PuertoOrigenLatitud = IIf(IsDBNull(dr.Item("PuertoOrigenLatitud")), 0, dr.Item("PuertoOrigenLatitud"))
            'Me.PuertoDestinoLongitud = IIf(IsDBNull(dr.Item("PuertoDestinoLongitud")), 0, dr.Item("PuertoDestinoLongitud"))
            'Me.PuertoDestinoLatitud = IIf(IsDBNull(dr.Item("PuertoDestinoLatitud")), 0, dr.Item("PuertoDestinoLatitud"))
            Me.Linea = IIf(IsDBNull(dr.Item("Linea")), String.Empty, dr.Item("Linea"))
            Me.Naviera = IIf(IsDBNull(dr.Item("Naviera")), String.Empty, dr.Item("Naviera"))
            Me.NavieraFicha = IIf(IsDBNull(dr.Item("NavieraID")), New NavieraFicha, New NavieraFicha(dr.Item("NavieraID")))
            Me.Frecuencia = IIf(IsDBNull(dr.Item("Frecuencia")), String.Empty, dr.Item("Frecuencia"))
            Me.FrecuenciaMensual = IIf(IsDBNull(dr.Item("FrecuenciaMensual")), 0, dr.Item("FrecuenciaMensual"))
            Me.TipoTrafico = IIf(IsDBNull(dr.Item("TipoTrafico")), String.Empty, dr.Item("TipoTrafico"))
            Me.DistanciaMillas = IIf(IsDBNull(dr.Item("DistanciaMillas")), 0, dr.Item("DistanciaMillas"))
            Me.TiempoPuertoOrigen = IIf(IsDBNull(dr.Item("TiempoPuertoOrigen")), 0, dr.Item("TiempoPuertoOrigen"))
            Me.TiempoTransito = IIf(IsDBNull(dr.Item("TiempoTransito")), 0, dr.Item("TiempoTransito"))
            Me.TiempoPuertoDestino = IIf(IsDBNull(dr.Item("TiempoPuertoDestino")), 0, dr.Item("TiempoPuertoDestino"))
            Me.FleteMaritimo = IIf(IsDBNull(dr.Item("FleteMaritimo")), 0, dr.Item("FleteMaritimo"))
            Me.RecargoCabezaTractora = IIf(IsDBNull(dr.Item("RecargoCabezaTractora")), 0, dr.Item("RecargoCabezaTractora"))
            Me.RecargoBAF = IIf(IsDBNull(dr.Item("RecargoBAF")), 0, dr.Item("RecargoBAF"))
            Me.RecargoMercanciaPeligrosa = IIf(IsDBNull(dr.Item("RecargoMercanciaPeligrosa")), 0, dr.Item("RecargoMercanciaPeligrosa"))
            Me.RecargoCCRR = IIf(IsDBNull(dr.Item("RecargoCCRR")), 0, dr.Item("RecargoCCRR"))
            Me.CapPlataformas = IIf(IsDBNull(dr.Item("CapPlataformas")), 0, dr.Item("CapPlataformas"))
            Me.CapPasajeros = IIf(IsDBNull(dr.Item("CapPasajeros")), 0, dr.Item("CapPasajeros"))
            Me.CapCoches = IIf(IsDBNull(dr.Item("CapCoches")), 0, dr.Item("CapCoches"))
            Me.Fachada = IIf(IsDBNull(dr.Item("Fachada")), String.Empty, dr.Item("Fachada"))
            Me.Visible = IIf(IsDBNull(dr.Item("Visible")), False, dr.Item("Visible"))
            Me.EnlaceComodalWeb = IIf(IsDBNull(dr.Item("EnlaceComodalWeb")), String.Empty, dr.Item("EnlaceComodalWeb"))
            Me.FleteMensaje = IIf(IsDBNull(dr.Item("FleteMensaje")), String.Empty, dr.Item("FleteMensaje"))
            LineaData.GPSInicialLeer(Me)
        End With
    End Sub
    Public Sub Save()
        If Me.ID = 0 Then
            LineaData.Add(Me)
        Else
            LineaData.Edit(Me)
        End If
    End Sub
    Public Sub Delete()
        If Me.ID <> 0 Then
            LineaData.Delete(Me)
        End If
    End Sub
    '****************************************************************************
    'FUNCTIONES COMPARTIDAS
    '****************************************************************************

    Public Shared Function GetByID(ByVal ID As Long) As Linea
        Return New Linea(ID)
    End Function

    Public Shared Function Lista(Optional ByVal condicion As String = "", Optional ByVal Orden As String = "") As List(Of Linea)
        Dim dt As System.Data.DataTable = LineaData.Lista(condicion, Orden)
        Dim list As New List(Of Linea)
        For Each dr As System.Data.DataRow In dt.Rows
            Dim obj As New Linea(dr.Item("ID"))
            list.Add(obj)
        Next
        Return list
    End Function

    '****************************************************************************
    'FUNCTIONES PRIVADAS
    '****************************************************************************
    Public Property ID As Long
        Get
            Return Me._ID
        End Get
        Set(ByVal value As Long)
            Me._ID = value
        End Set
    End Property
    Public Property PuertoOrigen As String
        Get
            Return Me._PuertoOrigen.Trim
        End Get
        Set(value As String)
            Me._PuertoOrigen = value.Trim
        End Set
    End Property
    Public Property PuertoDestino As String
        Get
            Return Me._PuertoDestino.Trim
        End Get
        Set(value As String)
            Me._PuertoDestino = value.Trim
        End Set
    End Property
    Public Property PuertoOrigenMappoint As String
        Get
            Return Me._PuertoOrigenMappoint.Trim
        End Get
        Set(value As String)
            Me._PuertoOrigenMappoint = value.Trim
        End Set
    End Property
    Public Property PuertoDestinoMappoint As String
        Get
            Return Me._PuertoDestinoMappoint.Trim
        End Get
        Set(value As String)
            Me._PuertoDestinoMappoint = value.Trim
        End Set
    End Property
    Public Property PuertoOrigenObj As PuertoFicha
        Get
            Return Me._PuertoOrigenobj
        End Get
        Set(value As PuertoFicha)
            Me._PuertoOrigenobj = value
        End Set
    End Property
    Public Property PuertoDestinoObj As PuertoFicha
        Get
            Return Me._PuertoDestinoobj
        End Get
        Set(value As PuertoFicha)
            Me._PuertoDestinoobj = value
        End Set
    End Property
    Public Property PuertoOrigenLongitud As Single
        Get
            Return Me._PuertoOrigenLongitud
        End Get
        Set(value As Single)
            Me._PuertoOrigenLongitud = value
        End Set
    End Property
    Public Property PuertoOrigenLatitud As Single
        Get
            Return Me._PuertoOrigenLatitud
        End Get
        Set(value As Single)
            Me._PuertoOrigenLatitud = value
        End Set
    End Property
    Public Property PuertoDestinoLongitud As Single
        Get
            Return Me._PuertoDestinoLongitud
        End Get
        Set(value As Single)
            Me._PuertoDestinoLongitud = value
        End Set
    End Property
    Public Property PuertoDestinoLatitud As Single
        Get
            Return Me._PuertoDestinoLatitud
        End Get
        Set(value As Single)
            Me._PuertoDestinoLatitud = value
        End Set
    End Property
    Public Property Linea As String
        Get
            Return Me._Linea.Trim
        End Get
        Set(value As String)
            Me._Linea = value.Trim
        End Set
    End Property
    Public Property Naviera As String
        Get
            Return Me._Naviera
        End Get
        Set(value As String)
            Me._Naviera = value
        End Set
    End Property
    Public Property NavieraFicha As NavieraFicha
        Get
            Return Me._NavieraFicha
        End Get
        Set(value As NavieraFicha)
            Me._NavieraFicha = value
        End Set
    End Property
    Public Property Frecuencia As String
        Get
            Return Me._Frecuencia.Trim
        End Get
        Set(value As String)
            Me._Frecuencia = value.Trim
        End Set
    End Property
    Public Property FrecuenciaMensual As Double
        Get
            Return Me._FrecuenciaMensual
        End Get
        Set(value As Double)
            Me._FrecuenciaMensual = value
        End Set
    End Property
    Public Property TipoTrafico As String
        Get
            Return Me._TipoTrafico.Trim
        End Get
        Set(value As String)
            Me._TipoTrafico = value.Trim
        End Set
    End Property
    Public Property DistanciaMillas As Double
        Get
            Return Me._DistanciaMillas
        End Get
        Set(value As Double)
            Me._DistanciaMillas = value
        End Set
    End Property
    Public Property TiempoPuertoOrigen As Double
        Get
            Return Me._TiempoPuertoOrigen
        End Get
        Set(value As Double)
            Me._TiempoPuertoOrigen = value
        End Set
    End Property
    Public Property TiempoTransito As Double
        Get
            Return Me._TiempoTransito
        End Get
        Set(value As Double)
            Me._TiempoTransito = value
        End Set
    End Property
    Public Property TiempoPuertoDestino As Double
        Get
            Return Me._TiempoPuertoDestino
        End Get
        Set(value As Double)
            Me._TiempoPuertoDestino = value
        End Set
    End Property
    ReadOnly Property TiempoTotalTransporteMaritimo As Double
        Get
            Return CType(Me.TiempoPuertoOrigen, Double) + CType(Me.TiempoTransito, Double) + CType(Me.TiempoPuertoDestino, Double)
        End Get
    End Property
    Public Property FleteMaritimo As Double
        Get
            Return Me._FleteMaritimo
        End Get
        Set(value As Double)
            Me._FleteMaritimo = value
        End Set
    End Property
    Public Property RecargoCabezaTractora As Double
        Get
            Return Me._RecargoCabezaTractora
        End Get
        Set(value As Double)
            Me._RecargoCabezaTractora = value
        End Set
    End Property
    Public Property RecargoBAF As Double
        Get
            Return Me._RecargoBAF
        End Get
        Set(value As Double)
            Me._RecargoBAF = value
        End Set
    End Property
    Public Property RecargoMercanciaPeligrosa As Double
        Get
            Return Me._RecargoMercanciaPeligrosa
        End Get
        Set(value As Double)
            Me._RecargoMercanciaPeligrosa = value
        End Set
    End Property
    Public Property RecargoCCRR As Double
        Get
            Return Me._RecargoCCRR
        End Get
        Set(value As Double)
            Me._RecargoCCRR = value
        End Set
    End Property
    Public Property CapPlataformas As Double
        Get
            Return Me._CapPlataformas
        End Get
        Set(value As Double)
            Me._CapPlataformas = value
        End Set
    End Property
    Public Property CapPasajeros As Double
        Get
            Return Me._CapPasajeros
        End Get
        Set(value As Double)
            Me._CapPasajeros = value
        End Set
    End Property
    Public Property CapCoches As Double
        Get
            Return Me._CapCoches
        End Get
        Set(value As Double)
            Me._CapCoches = value
        End Set
    End Property
    Public Property Fachada As String
        Get
            Return Me._Fachada.Trim
        End Get
        Set(value As String)
            Me._Fachada = value.Trim
        End Set
    End Property
    Public Property Visible As Boolean
        Get
            Return Me._Visible
        End Get
        Set(value As Boolean)
            Me._Visible = value
        End Set
    End Property
    Public Property EnlaceComodalWeb As String
        Get
            Return Me._EnlaceComodalWeb.Trim
        End Get
        Set(value As String)
            Me._EnlaceComodalWeb = value.Trim
        End Set
    End Property
    Public Property FleteMensaje As String
        Get
            Return Me._FleteMensaje.Trim
        End Get
        Set(value As String)
            Me._FleteMensaje = value.Trim
        End Set
    End Property

End Class

