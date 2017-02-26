Imports Microsoft.VisualBasic
Imports System.Collections
Imports System.Collections.Generic

Public Class Naviera
    Dim _ID As Long
    Dim _De As String
    Dim _A As String
    Dim _Horario As String
    Dim _DatosContacto As String
    Dim _InformacionReservas As String
    Dim _Logo As String

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
            Me.ID = NavieraData.Add(Me)
        Else
            Me.ID = NavieraData.Edit(Me)
        End If
    End Sub

    Public Sub Delete()
        If Me.ID = 0 Then '
            'No existe en la base de datos. No se hace nada
        Else
            NavieraData.Delete(Me)
        End If
    End Sub
    '****************************************************************************
    'FUNCTIONES COMPARTIDAS
    '****************************************************************************

    Public Shared Function GetByID(ByVal ID As Long) As Naviera
        Return New Naviera(ID)
    End Function

    Public Shared Function Lista(Optional ByVal condicion As String = "", Optional ByVal Orden As String = "") As List(Of Naviera)
        Dim dt As System.Data.DataTable = NavieraData.Lista(condicion, Orden)
        Dim list As New List(Of Naviera)
        For Each dr As System.Data.DataRow In dt.Rows
            Dim oNaviera As New Naviera(dr.Item("ID"))
            list.Add(oNaviera)
        Next
        Return list
    End Function


    '****************************************************************************
    'FUNCTIONES PRIVADAS
    '****************************************************************************
    Private Sub blanco()
        'Borra todos los campos del objeto
        Me.De = ""
        Me.A = ""
        Me.Horario = ""
        Me.DatosContacto = ""
        Me.InformacionReservas = ""
        Me.Logo = ""
    End Sub
    Private Sub LookforID(ByVal id As Long)
        'Busca en la base de datos por ID y rellena los campos del objeto
        Dim dr As System.Data.DataRow = NavieraData.GetbyID(id)
        With Me
            .ID = IIf(IsDBNull(dr("ID")), 0, dr("Id"))
            .De = IIf(IsDBNull(dr("De")), "", dr("De"))
            .A = IIf(IsDBNull(dr("A")), "", dr("A"))
            .Horario = IIf(IsDBNull(dr("Horario")), "", dr("Horario"))
            .DatosContacto = IIf(IsDBNull(dr("DatosContacto")), "", dr("DatosContacto"))
            .InformacionReservas = IIf(IsDBNull(dr("InformacionReservas")), "", dr("InformacionReservas"))
            .Logo = IIf(IsDBNull(dr("Logo")), "", dr("Logo"))
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
    Property De() As String
        Get
            Return Me._De
        End Get
        Set(ByVal value As String)
            Me._De = value
        End Set
    End Property
    Property A() As String
        Get
            Return Me._A
        End Get
        Set(ByVal value As String)
            Me._A = value
        End Set
    End Property
    Property Horario() As String
        Get
            Return Me._Horario
        End Get
        Set(ByVal value As String)
            Me._Horario = value
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
    Property Logo() As String
        Get
            Return Me._Logo
        End Get
        Set(ByVal value As String)
            Me._Logo = value
        End Set
    End Property
End Class

