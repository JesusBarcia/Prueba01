Imports Microsoft.VisualBasic

Public Class NavieraFicha
    Private _ID As Long
    Private _Logo As String
    Private _De As String
    Private _A As String
    Private _Horario As String
    Private _Acompanado As Boolean
    Private _NoAcompanado As Boolean
    Private _MercanciasPeligrosas As Boolean
    Private _AnimalesVivos As Boolean
    Private _CargaRefrigerada As Boolean
    Private _DatosContacto As String
    Private _InformacionReservas As String

    Public Sub New()
        Me.ID = 0
        Me.Logo = String.Empty
        Me.De = String.Empty
        Me.A = String.Empty
        Me.Horario = String.Empty
        Me.Acompanado = False
        Me.NoAcompanado = False
        Me.MercanciasPeligrosas = False
        Me.AnimalesVivos = False
        Me.CargaRefrigerada = False
        Me.DatosContacto = String.Empty
        Me.InformacionReservas = String.Empty
    End Sub
    Public Sub New(ByVal ID As Long)
        Dim dr As System.Data.DataRow = Datos.NavieraFichaByID(ID)
        With dr
            Me.ID = IIf(IsDBNull(dr.Item("ID")), 0, dr.Item("ID"))
            Me.Logo = IIf(IsDBNull(dr.Item("Logo")), "", dr.Item("Logo"))
            Me.De = IIf(IsDBNull(dr.Item("De")), "", dr.Item("De"))
            Me.A = IIf(IsDBNull(dr.Item("A")), "", dr.Item("A"))
            Me.Horario = IIf(IsDBNull(dr.Item("Horario")), "", dr.Item("Horario"))
            Me.Acompanado = IIf(IsDBNull(dr.Item("Acompanado")), False, dr.Item("Acompanado"))
            Me.NoAcompanado = IIf(IsDBNull(dr.Item("NoAcompanado")), False, dr.Item("NoAcompanado"))
            Me.MercanciasPeligrosas = IIf(IsDBNull(dr.Item("MercanciasPeligrosas")), False, dr.Item("MercanciasPeligrosas"))
            Me.AnimalesVivos = IIf(IsDBNull(dr.Item("AnimalesVivos")), False, dr.Item("AnimalesVivos"))
            Me.CargaRefrigerada = IIf(IsDBNull(dr.Item("CargaRefrigerada")), False, dr.Item("CargaRefrigerada"))
            Me.DatosContacto = IIf(IsDBNull(dr.Item("DatosContacto")), "", dr.Item("DatosContacto"))
            Me.InformacionReservas = IIf(IsDBNull(dr.Item("InformacionReservas")), "", dr.Item("InformacionReservas"))
        End With
    End Sub
    Public Property ID As Long
        Get
            Return Me._ID
        End Get
        Set(ByVal value As Long)
            Me._ID = value
        End Set
    End Property
    Public Property Logo As String
        Get
            Return Me._Logo
        End Get
        Set(ByVal value As String)
            Me._Logo = value
        End Set
    End Property
    Public Property De As String
        Get
            Return Me._De
        End Get
        Set(ByVal value As String)
            Me._De = value
        End Set
    End Property
    Public Property A As String
        Get
            Return Me._A
        End Get
        Set(ByVal value As String)
            Me._A = value
        End Set
    End Property
    Public Property Horario As String
        Get
            Return Me._Horario
        End Get
        Set(ByVal value As String)
            Me._Horario = value
        End Set
    End Property
    Public Property Acompanado As Boolean
        Get
            Return Me._Acompanado
        End Get
        Set(ByVal value As Boolean)
            Me._Acompanado = value
        End Set
    End Property
    Public Property NoAcompanado As Boolean
        Get
            Return Me._NoAcompanado
        End Get
        Set(ByVal value As Boolean)
            Me._NoAcompanado = value
        End Set
    End Property
    Public Property MercanciasPeligrosas As Boolean
        Get
            Return Me._MercanciasPeligrosas
        End Get
        Set(ByVal value As Boolean)
            Me._MercanciasPeligrosas = value
        End Set
    End Property
    Public Property AnimalesVivos As Boolean
        Get
            Return Me._AnimalesVivos
        End Get
        Set(ByVal value As Boolean)
            Me._AnimalesVivos = value
        End Set
    End Property
    Public Property CargaRefrigerada As Boolean
        Get
            Return Me._CargaRefrigerada
        End Get
        Set(ByVal value As Boolean)
            Me._CargaRefrigerada = value
        End Set
    End Property
    Public Property DatosContacto As String
        Get
            Return Me._DatosContacto
        End Get
        Set(ByVal value As String)
            Me._DatosContacto = value
        End Set
    End Property
    Public Property InformacionReservas As String
        Get
            Return Me._InformacionReservas
        End Get
        Set(ByVal value As String)
            Me._InformacionReservas = value
        End Set
    End Property
End Class

