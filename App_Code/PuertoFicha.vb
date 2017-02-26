Imports Microsoft.VisualBasic

Public Class PuertoFicha
    Private _ID As Long
    Private _Logo As String
    Private _Terminal As String
    Private _ServiciosComplementarios As String
    Private _DatosContacto As String
    Private _InformacionReservas As String
    Public Sub New()
        Me.ID = 0
        Me.Logo = ""
        Me.Terminal = ""
        Me.ServiciosComplementarios = ""
        Me.DatosContacto = ""
        Me.InformacionReservas = ""
    End Sub
    Public Sub New(ByVal ID As Long)
        Dim dr As System.Data.DataRow = Datos.PuertoFichaByID(ID)
        With dr
            Me.ID = IIf(IsDBNull(dr.Item("ID")), 0, dr.Item("ID"))
            Me.Logo = IIf(IsDBNull(dr.Item("Logo")), "", dr.Item("Logo"))
            Me.Terminal = IIf(IsDBNull(dr.Item("Terminal")), "", dr.Item("Terminal"))
            Me.ServiciosComplementarios = IIf(IsDBNull(dr.Item("ServiciosComplementarios")), "", dr.Item("ServiciosComplementarios"))
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
    Public Property Terminal As String
        Get
            Return Me._Terminal
        End Get
        Set(ByVal value As String)
            Me._Terminal = value
        End Set
    End Property
    Public Property ServiciosComplementarios As String
        Get
            Return Me._ServiciosComplementarios
        End Get
        Set(ByVal value As String)
            Me._ServiciosComplementarios = value
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

