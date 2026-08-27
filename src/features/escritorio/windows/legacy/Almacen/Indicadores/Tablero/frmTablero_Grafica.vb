Imports System.Windows.Forms
Imports System.ServiceModel
Imports AxMSChart20Lib

Public Class frmTablero_Grafica

    '===========================Servicios====================================================
    Private oIndicadoresAlmacenService As New IndicadoresAlmacenService.IndicadoresAlmacenServiceClient
    '======================Declaración de Variables==============================================

    Private dtDatos As DataTable
    Private dtTablero As DataTable
    Private dtMotivos As DataTable
    Public iFecha As Date
    Public iCodRub As String
    Public iGrupo As String
    Public iSemana As Integer
    Public IdLocacion As Integer

    Public DesIndicador As String          '------------ Agregado el 11/04/2013

    Private Sub frmTablero_Grafica_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            txtIndicador.Text = DesIndicador

            ChartGrafico.Enabled = False
            ChartMotivo.Enabled = False

            'dgvTablero.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
            dgvMotivos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
            'ChartGrafico.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
            'ChartMotivo.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

            '--------------------------------------------------------------------------COBERTURA---------------------------------------------------------------------------
            If iGrupo = "1" Then
                Me.Size = New System.Drawing.Size(861, 431)
                '--------------------------------------------------------------------------General-------------------------------------------------------------------------------
                If iCodRub = "00" Then
                    dtDatos = oIndicadoresAlmacenService.ConsultasTablero(Session.sCodEmp, IdLocacion, iCodRub, iFecha, 7).Tables(0)
                    dtTablero = oIndicadoresAlmacenService.ConsultasTablero(Session.sCodEmp, IdLocacion, iCodRub, iFecha, 13).Tables(0)
                    dgvGrafica.DataSource = dtDatos
                    dgvTablero.DataSource = dtTablero
                    Dim estilo1 As New Estilo
                    estilo1.cargaEstiloDataDrid(dgvTablero)
                    MostrarGraficoCobertura()
                    '----------------------------------------------------------------------X Rubro--------------------------------------------------------------------------------
                Else
                    dtDatos = oIndicadoresAlmacenService.ConsultasTablero(Session.sCodEmp, IdLocacion, iCodRub, iFecha, 8).Tables(0)
                    dtTablero = oIndicadoresAlmacenService.ConsultasTablero(Session.sCodEmp, IdLocacion, iCodRub, iFecha, 14).Tables(0)
                    dgvGrafica.DataSource = dtDatos
                    dgvTablero.DataSource = dtTablero
                    Dim estilo1 As New Estilo
                    estilo1.cargaEstiloDataDrid(dgvTablero)
                    MostrarGraficoCobertura()
                End If

                '----------------------------------------------------------------CONFIABILIDAD-------------------------------------------------------------------------
            ElseIf iGrupo = "2" Then
                '----------------------------------------------------------------------General--------------------------------------------------------------------------------
                If iCodRub = "00" Then
                    dtDatos = oIndicadoresAlmacenService.ConsultasTablero(Session.sCodEmp, IdLocacion, iCodRub, iFecha, 9).Tables(0)
                    dtTablero = oIndicadoresAlmacenService.ConsultasTablero(Session.sCodEmp, IdLocacion, iCodRub, iFecha, 15).Tables(0)
                    dtMotivos = oIndicadoresAlmacenService.ConsultasTablero(Session.sCodEmp, IdLocacion, iCodRub, iFecha, 11).Tables(0)
                    dgvGrafica.DataSource = dtDatos
                    dgvTablero.DataSource = dtTablero
                    dgvMotivos.DataSource = dtMotivos
                    Dim estilo1 As New Estilo
                    estilo1.cargaEstiloDataDrid(dgvTablero)
                    Dim estilo As New Estilo
                    estilo.cargaEstiloDataDrid(dgvMotivos)
                    MostrarGraficoConfiabilidad()
                    MostrarGraficoMotivos()
                    If dgvMotivos.RowCount = 0 Then
                        Me.Size = New System.Drawing.Size(861, 431)
                    Else
                        Me.Size = New System.Drawing.Size(861, 751)
                    End If
                    '----------------------------------------------------------------------X Rubro--------------------------------------------------------------------------------
                Else
                    dtDatos = oIndicadoresAlmacenService.ConsultasTablero(Session.sCodEmp, IdLocacion, iCodRub, iFecha, 10).Tables(0)
                    dtTablero = oIndicadoresAlmacenService.ConsultasTablero(Session.sCodEmp, IdLocacion, iCodRub, iFecha, 16).Tables(0)
                    dtMotivos = oIndicadoresAlmacenService.ConsultasTablero(Session.sCodEmp, IdLocacion, iCodRub, iFecha, 12).Tables(0)
                    dgvGrafica.DataSource = dtDatos
                    dgvTablero.DataSource = dtTablero
                    dgvMotivos.DataSource = dtMotivos
                    Dim estilo1 As New Estilo
                    estilo1.cargaEstiloDataDrid(dgvTablero)
                    Dim estilo As New Estilo
                    estilo.cargaEstiloDataDrid(dgvMotivos)
                    MostrarGraficoConfiabilidad()
                    MostrarGraficoMotivos()
                    If dgvMotivos.RowCount = 0 Then
                        Me.Size = New System.Drawing.Size(861, 431)
                    Else
                        Me.Size = New System.Drawing.Size(861, 751)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL CARGAR TABLERO GRÁFICO : " + ex.Message)
        End Try
    End Sub

    Private Sub MostrarGraficoCobertura()
        Try
            If dtDatos.Rows.Count = 0 Then
                ChartGrafico.Visible = False
            Else
                Dim cont As Integer = 0
                Dim semana As Integer = 0

                '--------------------------------------------Formato de Gráfico------------------------------------------------------
                ChartGrafico.Visible = True
                ChartGrafico.chartType = MSChart20Lib.VtChChartType.VtChChartType2dBar
                ChartGrafico.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdY).Labels(1).Format = "0"
                ChartGrafico.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdY).AxisTitle.Visible = False
                ChartGrafico.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdX).AxisTitle.Visible = True
                ChartGrafico.Footnote.Location.Visible = False
                ChartGrafico.Legend.Location.LocationType = MSChart20Lib.VtChLocationType.VtChLocationTypeTop
                ChartGrafico.Title.Text = "DATOS DE COBERTURA"
                '-----------------------------------------------------------------------------------------------------------------------------

                '----------------------------------------Cambiar color de Gráfico-------------------------------------------------
                ChartGrafico.Plot.Backdrop.Fill.Style = MSChart20Lib.VtFillStyle.VtFillStyleBrush
                ChartGrafico.Plot.Backdrop.Fill.Brush.Style = MSChart20Lib.VtBrushStyle.VtBrushStyleSolid
                ChartGrafico.Plot.Backdrop.Fill.Brush.FillColor.Set(245, 245, 220)
                '-----------------------------------------------------------------------------------------------------------------------------

                '------------------------------------------Número de Semanas--------------------------------------------
                For I = 0 To dgvGrafica.Rows.Count - 2
                    If dgvGrafica.Rows(I).Cells("Semana").Value() <> semana Then
                        semana = dgvGrafica.Rows(I).Cells("Semana").Value
                        cont = cont + 1
                    End If
                Next
                '---------------------------------------------------------------------------------------------------------------------

                '----------------------------------------Filas y Columnas del Gráfico----------------------------------
                ChartGrafico.RowCount = cont + 2
                ChartGrafico.ColumnCount = 3

                ChartGrafico.Plot.SeriesCollection(1).LegendText = "PB"
                ChartGrafico.Plot.SeriesCollection(2).LegendText = "Cobertura de Inventario"
                ChartGrafico.Plot.SeriesCollection(3).LegendText = "Objetivo"
                '-------------------------------------------------------------------------------------------------------------------

                '---------------------------------------------PB-----------------------------------------------------
                ChartGrafico.Row = 1
                ChartGrafico.RowLabel = "PB"
                ChartGrafico.Column = 1
                ChartGrafico.Data = dgvGrafica.Rows(0).Cells("PBInv").Value()

                ChartGrafico.Column = 2
                ChartGrafico.Data = 0
                ChartGrafico.Column = 3
                ChartGrafico.Data = 0
                '-----------------------------------------------------------------------------------------------------

                '------------------------------Cobertura de Inventario-------------------------------------
                semana = 0
                cont = 2
                For I = 0 To dgvGrafica.Rows.Count - 2
                    If dgvGrafica.Rows(I).Cells("Semana").Value() <> semana Then
                        ChartGrafico.Row = cont
                        ChartGrafico.RowLabel = dgvGrafica.Rows(I).Cells("Semana").Value()

                        ChartGrafico.Column = 1
                        ChartGrafico.Data = 0
                        ChartGrafico.Column = 2
                        ChartGrafico.Data = dgvGrafica.Rows(I).Cells("RealInv").Value()
                        ChartGrafico.Column = 3
                        ChartGrafico.Data = 0
                        semana = dgvGrafica.Rows(I).Cells("Semana").Value()
                        cont = cont + 1
                    End If
                Next
                '----------------------------------------------------------------------------------------------------

                '-----------------------------------------Objetivo-----------------------------------------------
                ChartGrafico.Row = ChartGrafico.RowCount
                ChartGrafico.RowLabel = "Objetivo"

                ChartGrafico.Column = 1
                ChartGrafico.Data = 0
                ChartGrafico.Column = 2
                ChartGrafico.Data = 0
                ChartGrafico.Column = 3
                ChartGrafico.Data = dgvGrafica.Rows(0).Cells("ObjetivoInv").Value()
                '----------------------------------------------------------------------------------------------------

                '-----------------------------------------------------------------------------Total por Barra-------------------------------------------------------------------------------------
                For iIndex = 1 To ChartGrafico.Plot.SeriesCollection.Count
                    ChartGrafico.Plot.SeriesCollection(iIndex).DataPoints(-1).DataPointLabel.LocationType = MSChart20Lib.VtChLabelLocationType.VtChLabelLocationTypeBase
                    'ChartGrafico.Plot.SeriesCollection(iIndex).DataPoints(-1).DataPointLabel.VtFont.Style = MSChart20Lib.VtFontStyle.VtFontStyleBold
                    ChartGrafico.Plot.SeriesCollection(iIndex).DataPoints(-1).DataPointLabel.VtFont.VtColor.Set(245, 245, 220)
                Next iIndex
                '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR GRÁFICA DE COBERTURA : " + ex.Message)
        End Try
    End Sub

    Private Sub MostrarGraficoConfiabilidad()
        Try
            If dtDatos.Rows.Count = 0 Then
                ChartGrafico.Visible = False
            Else
                Dim cont As Integer = 0
                Dim semana As Integer = 0

                '--------------------------------------------Formato de Gráfico------------------------------------------------------
                ChartGrafico.Visible = True
                ChartGrafico.chartType = MSChart20Lib.VtChChartType.VtChChartType2dBar
                ChartGrafico.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdY).Labels(1).Format = "0"
                ChartGrafico.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdY).AxisTitle.Visible = False
                ChartGrafico.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdX).AxisTitle.Visible = True
                ChartGrafico.Footnote.Location.Visible = False
                ChartGrafico.Legend.Location.LocationType = MSChart20Lib.VtChLocationType.VtChLocationTypeTop
                ChartGrafico.Title.Text = "DATOS DE CONFIABILIDAD"
                '-----------------------------------------------------------------------------------------------------------------------------

                '----------------------------------------Cambiar color de Gráfico-------------------------------------------------
                ChartGrafico.Plot.Backdrop.Fill.Style = MSChart20Lib.VtFillStyle.VtFillStyleBrush
                ChartGrafico.Plot.Backdrop.Fill.Brush.Style = MSChart20Lib.VtBrushStyle.VtBrushStyleSolid
                ChartGrafico.Plot.Backdrop.Fill.Brush.FillColor.Set(245, 245, 220)
                '-----------------------------------------------------------------------------------------------------------------------------

                '------------------------------------------Número de Semanas--------------------------------------------
                For I = 0 To dgvGrafica.Rows.Count - 2
                    If dgvGrafica.Rows(I).Cells("Semana").Value() <> semana Then
                        semana = dgvGrafica.Rows(I).Cells("Semana").Value
                        cont = cont + 1
                    End If
                Next
                '--------------------------------------------------------------------------------------------------------------------

                '----------------------------------------Filas y Columnas del Gráfico----------------------------------
                ChartGrafico.RowCount = cont + 2
                ChartGrafico.ColumnCount = 3

                ChartGrafico.Plot.SeriesCollection(1).LegendText = "PB"
                ChartGrafico.Plot.SeriesCollection(2).LegendText = "Confiabilidad de Inventario"
                ChartGrafico.Plot.SeriesCollection(3).LegendText = "Objetivo"
                '-------------------------------------------------------------------------------------------------------------------

                '---------------------------------------------PB-----------------------------------------------------
                ChartGrafico.Row = 1
                ChartGrafico.RowLabel = "PB"
                ChartGrafico.Column = 1
                ChartGrafico.Data = dgvGrafica.Rows(0).Cells("PBase").Value()

                ChartGrafico.Column = 2
                ChartGrafico.Data = 0
                ChartGrafico.Column = 3
                ChartGrafico.Data = 0
                '-----------------------------------------------------------------------------------------------------

                '------------------------------Cobertura de Inventario-------------------------------------
                semana = 0
                cont = 2
                For I = 0 To dgvGrafica.Rows.Count - 2
                    If dgvGrafica.Rows(I).Cells("Semana").Value() <> semana Then
                        ChartGrafico.Row = cont
                        ChartGrafico.RowLabel = dgvGrafica.Rows(I).Cells("Semana").Value()

                        ChartGrafico.Column = 1
                        ChartGrafico.Data = 0
                        ChartGrafico.Column = 2
                        ChartGrafico.Data = dgvGrafica.Rows(I).Cells("Real").Value()
                        ChartGrafico.Column = 3
                        ChartGrafico.Data = 0
                        semana = dgvGrafica.Rows(I).Cells("Semana").Value()
                        cont = cont + 1
                    End If
                Next
                '----------------------------------------------------------------------------------------------------

                '-----------------------------------------Objetivo-----------------------------------------------
                ChartGrafico.Row = ChartGrafico.RowCount
                ChartGrafico.RowLabel = "Objetivo"

                ChartGrafico.Column = 1
                ChartGrafico.Data = 0
                ChartGrafico.Column = 2
                ChartGrafico.Data = 0
                ChartGrafico.Column = 3
                ChartGrafico.Data = dgvGrafica.Rows(0).Cells("Objetivo").Value()
                '----------------------------------------------------------------------------------------------------

                '-----------------------------------------------------------------------Total por Barra-------------------------------------------------------------------------------------
                For iIndex = 1 To ChartGrafico.Plot.SeriesCollection.Count
                    ChartGrafico.Plot.SeriesCollection(iIndex).DataPoints(-1).DataPointLabel.LocationType = MSChart20Lib.VtChLabelLocationType.VtChLabelLocationTypeBase
                    'ChartGrafico.Plot.SeriesCollection(iIndex).DataPoints(-1).DataPointLabel.VtFont.Style = MSChart20Lib.VtFontStyle.VtFontStyleBold
                    ChartGrafico.Plot.SeriesCollection(iIndex).DataPoints(-1).DataPointLabel.VtFont.VtColor.Set(245, 245, 220)
                Next iIndex
                '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR GRÁFICA DE CONFIABILIDAD : " + ex.Message)
        End Try
    End Sub

    Private Sub MostrarGraficoMotivos()
        Try
            If dtMotivos.Rows.Count = 0 Then
                ChartMotivo.Visible = False
            Else
                '-----------------------------------------------------Formato de Gráfico---------------------------------------------------------
                ChartMotivo.Visible = True
                'ChartMotivo.chartType = MSChart20Lib.VtChChartType.VtChChartType2dBar
                'ChartMotivo.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdY).Labels(1).Format = "0"                
                ChartMotivo.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdY).AxisTitle.Visible = False
                ChartMotivo.Plot.Axis(MSChart20Lib.VtChAxisId.VtChAxisIdX).AxisTitle.Visible = True
                ChartMotivo.Footnote.Location.Visible = False
                'ChartMotivo.Legend.Location.LocationType = MSChart20Lib.VtChLocationType.VtChLocationTypeBottom
                ChartMotivo.Title.Text = "CAUSAS DE NO CONFIABILIDAD (INDICADOR RELACIONADO)"
                '------------------------------------------------------------------------------------------------------------------------------------------

                '----------------------------------------Cambiar color de Gráfico-------------------------------------------------
                ChartMotivo.Plot.Backdrop.Fill.Style = MSChart20Lib.VtFillStyle.VtFillStyleBrush
                ChartMotivo.Plot.Backdrop.Fill.Brush.Style = MSChart20Lib.VtBrushStyle.VtBrushStyleSolid
                ChartMotivo.Plot.Backdrop.Fill.Brush.FillColor.Set(245, 245, 220)
                '-----------------------------------------------------------------------------------------------------------------------------

                '----------------------------------------------------------------------Filas y Columnas del Gráfico--------------------------------------------------------------
                ChartMotivo.ColumnCount = dtMotivos.Rows.Count
                ChartMotivo.RowCount = dgvMotivos.ColumnCount - 1 'Se resta dos columnas (Motivo) para tener la cantidad de Semanas

                Dim cont As Integer = 1
                For I = 0 To ChartMotivo.ColumnCount - 1
                    ChartMotivo.Plot.SeriesCollection(cont).LegendText = dgvMotivos.Rows(I).Cells("Motivo").Value
                    cont = cont + 1
                Next
                '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

                '---------------------------------------------------------------------------------------Datos de Gráfico---------------------------------------------------------------------------
                cont = 0
                For J = 0 To dgvMotivos.ColumnCount - 2
                    cont = cont + 1
                    If cont > 0 Then
                        ChartMotivo.Row = cont
                        ChartMotivo.RowLabel = dgvMotivos.Columns(cont).HeaderText
                        For I = 0 To dgvMotivos.Rows.Count - 1
                            ChartMotivo.Column = I + 1
                            ChartMotivo.Data = IIf(dgvMotivos(cont, I).Value Is Nothing Or dgvMotivos(cont, I).Value.ToString = "" Or IsDBNull(dgvMotivos(cont, I).Value), 0, dgvMotivos(cont, I).Value)
                        Next
                    End If
                Next
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR GRÁFICA DE MOTIVOS : " + ex.Message)
        End Try
    End Sub

    Private Sub frmTablero_Grafica_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
End Class