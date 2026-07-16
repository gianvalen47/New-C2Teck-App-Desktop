Imports System.ServiceModel
Imports System.Windows.Forms

Public Class frmImportacionDet
    Public pIdDetImportacion As Integer
    Private ObjImportacionDet As New ImportacionDetService.ImportacionDetServiceClient
    Private ImportacionDet As New ImportacionDetService.ImportacionDet
    Private oPartidaService As New PartidaService.PartidaServiceClient

    Private CodPar As String

    Private Sub frmImportacionDet_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            ObjImportacionDet.Close()
            oPartidaService.Close()
        Catch ex As TimeoutException
            ObjImportacionDet.Abort()
            oPartidaService.Abort()
        Catch ex As CommunicationException
            ObjImportacionDet.Abort()
            oPartidaService.Abort()
        End Try
        '  Me.Close()
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub txtCodPar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodPar.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarPartida.Enabled = True Then
                btnBuscarPartida_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub frmImportacionDet_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            txtCodPar.KeyPress _
            , txtCanFac.KeyPress _
            , mkPeso.KeyPress _
            , mkCosDol.KeyPress _
            , mkCosSol.KeyPress _
            , mkFleteInterno.KeyPress _
            , mkGestionCompra.KeyPress _
            , mkPreMer.KeyPress _
            , mkNucleo.KeyPress _
            , mkOtroGasto.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmImportacionDet_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            ' Close()
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmImportacionDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Llenardetalles()
        txtCodPar.Select()

        ' Deshabilitar()
    End Sub

    Private Sub Llenardetalles()
        Try
            ImportacionDet = ObjImportacionDet.MostrarPorId(pIdDetImportacion)
            txtCodigo.Text = ImportacionDet.Mercaderia.CodMer
            txtDesMer.Text = ImportacionDet.Mercaderia.DesMer1
            txtUnidad.Text = ImportacionDet.Mercaderia.UnidadMedida.CodUniMed
            txtCodPar.Text = ImportacionDet.Mercaderia.Partida.CodPar
            txtDesPar.Text = ImportacionDet.Mercaderia.Partida.ParPar
            txtCanFac.Text = ImportacionDet.CanFac
            txtCanMer.Text = ImportacionDet.CanMer
            mkPreMer.Text = ImportacionDet.PreMer
            mkCosDol.Text = ImportacionDet.CosDol
            mkCosSol.Text = ImportacionDet.CosSol
            mkPeso.Text = ImportacionDet.PesMer
            txtNomPed.Text = ImportacionDet.NomPed
            mkFleteInterno.Text = ImportacionDet.PreFle
            CkGestion.Checked = ImportacionDet.ApliGes
            mkGestionCompra.Text = ImportacionDet.PreGes
            mkNucleo.Text = ImportacionDet.PreNucleo
            mkOtroGasto.Text = ImportacionDet.PreGasto
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try


    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Guardar") = MsgBoxResult.Yes Then
            Try
                Dim Registro As New ImportacionDetService.ImportacionDet
                Dim Mercaderia As New ImportacionDetService.Mercaderia
                Dim Importacion As New ImportacionDetService.Importacion
                Dim Partida As New ImportacionDetService.Partida

                Registro.IdDetImportacion = pIdDetImportacion
                Importacion.IdImportacion = ImportacionDet.Importacion.IdImportacion
                Registro.Importacion = Importacion
                Mercaderia.CodMer = ImportacionDet.Mercaderia.CodMer
                Registro.Mercaderia = Mercaderia
                Partida.CodPar = txtCodPar.Text
                Registro.Mercaderia.Partida = Partida
                Registro.Item = ImportacionDet.Item
                Registro.CanFac = ImportacionDet.CanFac
                Registro.CanMer = ImportacionDet.CanMer
                Registro.PreMer = ImportacionDet.PreMer
                Registro.PesMer = mkPeso.Text
                Registro.CosDol = mkCosDol.Text
                Registro.CosSol = mkCosSol.Text
                Registro.PreMer = mkPreMer.Text
                Registro.PreFle = mkFleteInterno.Text
                Registro.ApliGes = CkGestion.Checked
                Registro.PreGes = mkGestionCompra.Text
                Registro.PreNucleo = mkNucleo.Text
                Registro.PreGasto = mkOtroGasto.Text
                Registro.CodUsu = Session.sCodUsu
                Registro.NomPc = Session.sNomPc
                Registro.DirIp = Session.sDirIp

                ObjImportacionDet.ActualizarFactura(Registro)

                Deshabilitar()
                '  MsgBox("Se Grabo con Exito", MsgBoxStyle.Information)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    Friend Sub Habilitar()
        mkPeso.Enabled = True
        mkCosDol.Enabled = True
        mkCosSol.Enabled = True
        mkFleteInterno.Enabled = True
        CkGestion.Enabled = True 
        'mkGestionCompra.Enabled = IIf(CkGestion.Checked, True, False)
        mkNucleo.Enabled = True
        mkOtroGasto.Enabled = True
        mkPreMer.Enabled = True
        btnGuardar.Enabled = True
        btnBuscarPartida.Enabled = True
        txtCodPar.ReadOnly = False
    End Sub

    Private Sub Deshabilitar()
        mkPeso.Enabled = False
        mkCosDol.Enabled = False
        mkCosSol.Enabled = False
        mkFleteInterno.Enabled = False
        CkGestion.Enabled = False
        mkGestionCompra.Enabled = False
        mkNucleo.Enabled = False
        mkOtroGasto.Enabled = False
        mkPreMer.Enabled = False
        btnGuardar.Enabled = False
    End Sub

    Private Sub CkGestion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CkGestion.CheckedChanged
        If CkGestion.Enabled Then
            If CkGestion.Checked Then
                mkGestionCompra.Enabled = True
            Else
                mkGestionCompra.Enabled = False
                mkGestionCompra.Text = 0
            End If
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnBuscarPartida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPartida.Click
        Dim frm As New frmBuscarPartida
        frm.txtCodPar.Text = toBlank(CodPar)
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtDesPar.Text = frm.descripcion
            txtDesPar.BackColor = System.Drawing.SystemColors.Control
            CodPar = frm.codigo
            txtCodPar.Text = CodPar
        End If
        txtCodPar.Select()
    End Sub

    Private Sub txtCodPar_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodPar.Validating
        Try
            If Len(Trim(txtCodPar.Text)) > 0 Then
                Dim Partida As New PartidaService.Partida
                Partida.CodPar = Trim(txtCodPar.Text)
                If oPartidaService.Buscar(Partida) Then
                    Partida = oPartidaService.MostrarPorCodigo(Trim(txtCodPar.Text))
                    txtCodPar.Text = Partida.CodPar
                    txtDesPar.Text = Partida.ParPar
                Else
                    MsgBox("Código no Existe, Verifique...", MsgBoxStyle.Critical, "No Existe")
                    txtCodPar.Select()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Mostrar")
        End Try
    End Sub

End Class