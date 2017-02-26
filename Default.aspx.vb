
Partial Class _Default
    Inherits System.Web.UI.Page






    Protected Sub form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles form1.Load
        'Datos.GuardarCoordenadaGPS()
    End Sub


    Private Function TiempoTerrestreconDescanso(ByVal velocidad As Single, ByVal distancia As Single) As Single
        'Calcula el tiempo de trayecto para una velocidad y distancia dada
        Dim TiempoConduccion As Single = 0
        Dim TiempoConduccionRestante As Single = 0
        Dim descanso As Single = 0
        Dim descansoAcumulado As Single = 0
        Dim retorno As Single = 0
        Dim margen As Single = 0.99999
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

    Protected Sub Calcular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calcular.Click
        Me.Resultado.Text = TiempoTerrestreconDescanso(Me.txtVelocidad.Text, Me.txtDistancia.Text)
    End Sub
End Class
