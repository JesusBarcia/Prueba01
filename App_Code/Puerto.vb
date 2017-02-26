Imports Microsoft.VisualBasic
Imports System.Collections
Imports System.Collections.Generic

Public Class Puerto
    Dim _ID As Long
    Dim _Logo As String
    Dim _Nombre As String
    Dim _Terminal As String
    Dim _ServiciosComplementarios As String
    Dim _DatosContacto As String
    Dim _InformacionReservas As String

    Public Sub New()
        Me.blanco()
    End Sub
    Public Sub New(ByVal id As Long)
        Me.blanco() ' Primero se borra el objeto
        LookforID(id)
    End Sub
    Public Sub Save()
        'Añade un objeto si la instancia tiene id=0 o modifica si id<>0
        If Me.ID = 0 Then
            Me.ID = PuertoData.Add(Me)
        Else
            Me.ID = PuertoData.Edit(Me)
        End If
    End Sub

    Public Sub Delete()
        If Me.ID = 0 Then '
            'No existe en la base de datos. No se hace nada
        Else
            PuertoData.Delete(Me.ID)
        End If
    End Sub
    '****************************************************************************
    'FUNCTIONES COMPARTIDAS
    '****************************************************************************

    Public Shared Function GetByID(ByVal ID As Long) As Puerto
        Return New Puerto(ID)
    End Function

    Public Shared Function Lista(Optional ByVal condicion As String = "", Optional ByVal Orden As String = "") As List(Of Puerto)
        Dim dt As System.Data.DataTable = PuertoData.Lista(condicion, Orden)
        Dim list As New List(Of Puerto)
        For Each dr As System.Data.DataRow In dt.Rows
            Dim obj As New Puerto(dr.Item("ID"))
            list.Add(obj)
        Next
        Return list
    End Function


    '****************************************************************************
    'FUNCTIONES PRIVADAS
    '****************************************************************************
    Private Sub blanco()
        'Borra todos los campos del objeto
        Me.Nombre = ""
        Me.Logo = ""
        Me.Terminal = ""
        Me.ServiciosComplementarios = ""
        Me.DatosContacto = ""
        Me.InformacionReservas = ""
    End Sub
    Private Sub LookforID(ByVal id As Long)
        'Busca en la base de datos por ID y rellena los campos del objeto
        Dim dr As System.Data.DataRow = PuertoData.GetbyID(id)
        With Me
            .ID = IIf(IsDBNull(dr("ID")), 0, dr("Id"))
            .Logo = IIf(IsDBNull(dr("Logo")), "", dr("Logo"))
            .Nombre = IIf(IsDBNull(dr("Nombre")), "", dr("nombre"))
            .Terminal = IIf(IsDBNull(dr("Terminal")), "", dr("Terminal"))
            .ServiciosComplementarios = IIf(IsDBNull(dr("ServiciosComplementarios")), "", dr("ServiciosComplementarios"))
            .DatosContacto = IIf(IsDBNull(dr("DatosContacto")), "", dr("DatosContacto"))
            .InformacionReservas = IIf(IsDBNull(dr("InformacionReservas")), "", dr("InformacionReservas"))
        End With
    End Sub

    '****************************************************************************
    'PROPIEDADES
    '****************************************************************************
    Property ID() As Long
        Get
            Return _ID
        End Get
        Set(ByVal value As Long)
            Me._ID = value
        End Set
    End Property
    Property Nombre() As String
        Get
            Return Me._Nombre
        End Get
        Set(value As String)
            Me._Nombre = value
        End Set
    End Property
    Property Logo() As String
        Get
            Return Me._Logo
        End Get
        Set(value As String)
            Me._Logo = value
        End Set
    End Property
    Property Terminal() As String
        Get
            Return Me._Terminal
        End Get
        Set(ByVal value As String)
            Me._Terminal = value
        End Set
    End Property
    Property ServiciosComplementarios() As String
        Get
            Return Me._ServiciosComplementarios
        End Get
        Set(ByVal value As String)
            Me._ServiciosComplementarios = value
        End Set
    End Property
    Property DatosContacto() As String
        Get
            Return Me._DatosContacto
        End Get
        Set(ByVal value As String)
            Me._DatosContacto = value
        End Set
    End Property
    Property InformacionReservas() As String
        Get
            Return Me._InformacionReservas
        End Get
        Set(ByVal value As String)
            Me._InformacionReservas = value
        End Set
    End Property

End Class

