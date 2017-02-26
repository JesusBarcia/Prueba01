Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections
Imports System.Collections.Generic

Partial Class PuertoListado
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            ViewState("SortDirection") = "ASC"
            ViewState("SortExpression") = "ID"
            ViewState("Filtro") = ""
            Me.GridView1.Visible = False
        End If
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Me.GridView1.PageIndex = e.NewPageIndex()
        ReBind()
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try
            Dim id As Integer = Convert.ToInt32(CType(sender, GridView).DataKeys(Convert.ToInt32(e.CommandArgument)).Value)
            Select Case e.CommandName
                Case "EDIT"
                    Response.Redirect("PuertoGestion.aspx?ID=" & id & "&accion=EDIT")
                Case "DELETE"
                    Response.Redirect("PuertoGestion.aspx?ID=" & id & "&accion=DELETE")
                Case "VER"
                    Response.Redirect("..\verPuerto.aspx?ID=" & id, True)
            End Select
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ReBind()
        Dim lastDirection As String = TryCast(ViewState("SortDirection"), String)
        Dim sortExpression As String = TryCast(ViewState("SortExpression"), String)
        Dim filtro As String = TryCast(ViewState("Filtro"), String)

        If lastDirection = String.Empty Then
            lastDirection = "ASC"
        End If
        If sortExpression = String.Empty Then
            lastDirection = "ID"
        End If
        Dim list As List(Of Puerto) = Puerto.Lista(filtro, sortExpression & " " & lastDirection)
        Me.GridView1.DataSource = list
        Me.GridView1.DataBind()
    End Sub
    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        ViewState("SortDirection") = GetSortDirection(e.SortExpression)
        ViewState("SortExpression") = e.SortExpression
        ReBind()
    End Sub

    Private Function GetSortDirection(ByVal column As String) As String

        ' By default, set the sort direction to ascending.
        Dim sortDirection = "ASC"

        ' Retrieve the last column that was sorted.
        Dim sortExpression = TryCast(ViewState("SortExpression"), String)

        If sortExpression IsNot Nothing Then
            ' Check if the same column is being sorted.
            ' Otherwise, the default value can be returned.
            If sortExpression = column Then
                Dim lastDirection = TryCast(ViewState("SortDirection"), String)
                If lastDirection IsNot Nothing _
                  AndAlso lastDirection = "ASC" Then

                    sortDirection = "DESC"

                End If
            End If
        End If

        ' Save new values in ViewState.
        ViewState("SortDirection") = sortDirection
        ViewState("SortExpression") = column

        Return sortDirection

    End Function
    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        If Me.txtFiltro.Text = String.Empty Then
            ViewState("Filtro") = ""
        Else
            Dim cFiltro As String
            cFiltro = " DE like '%" & Me.txtFiltro.Text & "%' OR "
            cFiltro = cFiltro & " A like '%" & Me.txtFiltro.Text & "%' OR "
            cFiltro = cFiltro & " Horario like '%" & Me.txtFiltro.Text & "%' OR "
            cFiltro = cFiltro & " InformacionReservas like '%" & Me.txtFiltro.Text & "%' OR "
            cFiltro = cFiltro & " DatosContacto like '%" & Me.txtFiltro.Text & "%' "
            ViewState("Filtro") = cFiltro
        End If
        Me.GridView1.Visible = True
        ReBind()
    End Sub
End Class
