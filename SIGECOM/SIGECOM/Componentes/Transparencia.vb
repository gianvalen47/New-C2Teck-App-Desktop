Imports System
Imports System.Threading

Public Class Transparencia
    Private tmr As Timer ' variable para el temporizazor
    Private WithEvents mForm As Form ' variable con evento para el formulario
    Private mAccion As Boolean ' Fade in - Fade out
    Private mIntervalo As Integer = 2 ' velocidad del timer
    Private mMaxTransparencia As Single = 1 ' valor de transparencia
    '--------------------------------------------------------
    Private m_Enabled As Boolean = True

    Public Property Formulario() As Form
        Get
            Return mForm
        End Get
        Set(ByVal value As Form)
            mForm = value
        End Set
    End Property

    Public Property ValorTransparencia() As Single
        Get
            Return mMaxTransparencia
        End Get
        Set(ByVal value As Single)
            mMaxTransparencia = value
        End Set
    End Property

    Public Property Intervalo() As Integer
        Get
            Return mIntervalo
        End Get
        Set(ByVal value As Integer)
            mIntervalo = value
        End Set
    End Property

    Public Property Enabled() As Boolean
        Get
            Return m_Enabled
        End Get
        Set(ByVal value As Boolean)
            m_Enabled = value
        End Set
    End Property
    '--------------------------------------------------------

    'declaración del delegado
    Private Delegate Sub deleg_Valor(ByVal x As Double)

    'función que utiliza el delegado
    Private Sub Transparencia(ByVal x As Double)

        Select Case mAccion
            Case True
                If mForm.Opacity >= mMaxTransparencia Then
                    ' Termina el timer
                    tmr.Dispose()
                Else
                    mForm.Opacity += x ' incrementa el Opacity
                End If
            Case False
                ' fin del timer y descarga el formulario
                If mForm.Opacity <= 0 Then
                    mForm.Close()
                    tmr.Dispose()
                Else
                    mForm.Opacity -= x ' incrementa la opcidad
                End If
        End Select
    End Sub

    ' recibe el formulario, el valor máximo de
    'transparencia (0.1 - a 1.0), y el intervalo en milisegundos
    Public Sub Comenzar(ByVal frm As Form, _
                 Optional ByVal MaxTransparencia As Single = 1, _
                 Optional ByVal Intervalo As Integer = 50)

        If mForm Is Nothing Then
            mForm = frm
            mForm.Opacity = 0
            mMaxTransparencia = MaxTransparencia
            mIntervalo = Intervalo
            m_Enabled = True
        End If
    End Sub

    ' Crea y comienza el timer
    Private Sub aplicar_Fade(ByVal Accion As Boolean)

        If Not tmr Is Nothing Then
            tmr.Dispose()
            tmr = Nothing
        End If

        mAccion = Accion

        tmr = New Timer(New TimerCallback( _
               AddressOf TimerEvent), Nothing, 0, mIntervalo)

    End Sub

    ' timer
    Private Sub TimerEvent(ByVal o As Object)
        If mForm.IsHandleCreated = True Then
            mForm.BeginInvoke(New deleg_Valor(AddressOf Transparencia), 0.05)
        End If
    End Sub

    ' cuando carga le establece el valor de Opacity en 0
    Private Sub mForm_Load(ByVal sender As System.Object, _
                           ByVal e As System.EventArgs) _
                           Handles mForm.Load
        If m_Enabled Then
            mForm.Opacity = 0
        End If
    End Sub

    ' cuando se muestra el form, le aplica el fade in
    Private Sub mForm_Shown(ByVal sender As Object, _
                            ByVal e As System.EventArgs) Handles mForm.Shown
        If m_Enabled Then
            aplicar_Fade(True)
        End If
    End Sub


    Private Sub mform_FormClosing(ByVal sender As Object, _
                                  ByVal e As System.Windows.Forms.FormClosingEventArgs) _
                                  Handles mForm.FormClosing
        If m_Enabled Then
            If mForm.Opacity <> 0 Then
                e.Cancel = True
                ' cuando cierra el form le aplica la _
                'transparencia hsata desvanecerlo
                aplicar_Fade(False)
            End If
        End If
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        If Not mForm Is Nothing Then
            mForm = Nothing
        End If
    End Sub
End Class
