Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Reflection
Imports System.Windows.Forms
Imports System.Runtime.InteropServices




Public Class NotifyWindow

    Inherits System.Windows.Forms.Form
#Region "Public Variables"
    ''' <summary>
    ''' Gets or sets the title text to be displayed in the NotifyWindow.
    ''' </summary>
    Public Title As String
    ''' <summary>
    ''' Gets or sets the Font used for the title text.
    ''' </summary>
    Public TitleFont As System.Drawing.Font
    ''' <summary>
    ''' Gets or sets the Font used when the mouse hovers over the main body of text.
    ''' </summary>
    Public HoverFont As System.Drawing.Font
    ''' <summary>
    ''' Gets or sets the Font used when the mouse hovers over the title text.
    ''' </summary>
    Public TitleHoverFont As System.Drawing.Font
    ''' <summary>
    ''' Gets or sets the style used when drawing the background of the NotifyWindow.
    ''' </summary>
    Public BackgroundStyle As BackgroundStyles
    ''' <summary>
    ''' Gets or sets the Blend used when drawing a gradient background for the NotifyWindow.
    ''' </summary>
    Public Blend As System.Drawing.Drawing2D.Blend
    ''' <summary>
    ''' Gets or sets the StringFormat used when drawing text in the NotifyWindow.
    ''' </summary>
    Public StringFormat As System.Drawing.StringFormat
    ''' <summary>
    ''' Gets or sets a value specifiying whether or not the window should continue to be displayed if the mouse cursor is inside the bounds
    ''' of the NotifyWindow.
    ''' </summary>
    Public WaitOnMouseOver As Boolean
    ''' <summary>
    ''' An EventHandler called when the NotifyWindow main text is clicked.
    ''' </summary>
    Public Event TextClicked As System.EventHandler
    ''' <summary>
    ''' An EventHandler called when the NotifyWindow title text is clicked.
    ''' </summary>
    Public Event TitleClicked As System.EventHandler
    ''' <summary>
    ''' Gets or sets the color of the title text.
    ''' </summary>
    Public TitleColor As System.Drawing.Color
    ''' <summary>
    ''' Gets or sets the color of the NotifyWindow main text.
    ''' </summary>
    Public TextColor As System.Drawing.Color
    ''' <summary>
    ''' Gets or sets the gradient color which will be blended in drawing the background.
    ''' </summary>
    Public GradientColor As System.Drawing.Color
    ''' <summary>
    ''' Gets or sets the color of text when the user clicks on it.
    ''' </summary>
    Public PressedColor As System.Drawing.Color
    ''' <summary>
    ''' Gets or sets the amount of milliseconds to display the NotifyWindow for.
    ''' </summary>
    Public WaitTime As Integer
    ''' <summary>
    ''' Gets or sets the full height of the NotifyWindow, used after the opening animation has been completed.
    ''' </summary>
    Public ActualHeight As Integer
    ''' <summary>
    ''' Gets or sets the full width of the NotifyWindow.
    ''' </summary>
    Public ActualWidth As Integer

    Public Enum BackgroundStyles
        BackwardDiagonalGradient
        ForwardDiagonalGradient
        HorizontalGradient
        VerticalGradient
        Solid
    End Enum
    Public Enum ClockStates
        Opening
        Closing
        Showing
        None
    End Enum
    Public ClockState As ClockStates
#End Region

#Region "Protected Variables"
    Protected closePressed As Boolean = False, textPressed As Boolean = False, titlePressed As Boolean = False, closeHot As Boolean = False, textHot As Boolean = False, titleHot As Boolean = False
    Protected rClose As Rectangle, rText As Rectangle, rTitle As Rectangle, rDisplay As Rectangle, rScreen As Rectangle, rGlobClose As Rectangle, _
     rGlobText As Rectangle, rGlobTitle As Rectangle, rGlobDisplay As Rectangle
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Protected viewClock As System.Windows.Forms.Timer
#End Region

#Region "Constructor"
    ''' <param name="title">Title text displayed in the NotifyWindow</param>
    ''' <param name="text">Main text displayedin the NotifyWindow</param>
    Public Sub New(ByVal title__1 As String, ByVal text__2 As String)
        Me.New()
        Title = title__1
        Text = text__2
    End Sub
    ''' <param name="text">Text displayed in the NotifyWindow</param>
    Public Sub New(ByVal text__1 As String)
        Me.New()
        Text = text__1
    End Sub

    'Aca se modifica la ventana emergente 
    Public Sub New()
        SetStyle(ControlStyles.UserMouse, True)
        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        ' WmPaint calls OnPaint and OnPaintBackground
        SetStyle(ControlStyles.DoubleBuffer, True)

        ShowInTaskbar = False
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.None

        'FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        StartPosition = System.Windows.Forms.FormStartPosition.Manual

        ' Default values
        BackgroundStyle = BackgroundStyles.VerticalGradient
        ClockState = ClockStates.None
        BackColor = SystemColors.Control 'Color.LightGray
        'BackgroundImage = Image.FromFile("C:\LogoMTU3.png")
        'BackColor = Color.SteelBlue
        GradientColor = Color.WhiteSmoke
        PressedColor = Color.Gray
        TitleColor = Color.Black
        'TitleColor = Color.SteelBlue
        'TitleColor = SystemColors.ControlText
        
        TextColor = SystemColors.ControlText
        WaitOnMouseOver = True
        ActualWidth = 180           '130
        ActualHeight = 160          '110
        WaitTime = 12000 '6000  '11000       'Tiempo activo de la ventana
    End Sub
#End Region

#Region "Public Methods"
    ''' <summary>
    ''' Sets the width and height of the NotifyWindow.
    ''' </summary>
    Public Sub SetDimensions(ByVal width As Integer, ByVal height As Integer)
        ActualWidth = width
        ActualHeight = height
    End Sub

    ''' <summary>
    ''' Displays the NotifyWindow.
    ''' </summary>
    Public Sub Notify()
        If Text Is Nothing OrElse Text.Length < 1 Then
            Throw New System.Exception("You must set NotifyWindow.Text before calling Notify()")
        End If

        Width = ActualWidth
        rScreen = Screen.GetWorkingArea(Screen.PrimaryScreen.Bounds)
        Height = 0
        Top = rScreen.Bottom
        Left = rScreen.Width - Width - 11

        If HoverFont Is Nothing Then
            HoverFont = New Font(Font, Font.Style Or FontStyle.Bold)
            'HoverFont = New Font(Font, Font.Style Or FontStyle.Underline)
        End If
        If TitleFont Is Nothing Then
            TitleFont = Font
        End If
        If TitleHoverFont Is Nothing Then
            TitleHoverFont = New Font(TitleFont, TitleFont.Style Or FontStyle.Underline)
            'TitleHoverFont = New Font(TitleFont, TitleFont.Style Or FontStyle.Underline)
        End If
        If Me.StringFormat Is Nothing Then
            Me.StringFormat = New StringFormat()
            Me.StringFormat.Alignment = StringAlignment.Center
            Me.StringFormat.LineAlignment = StringAlignment.Center
            Me.StringFormat.Trimming = StringTrimming.EllipsisWord
        End If

        rDisplay = New Rectangle(0, 0, Width, ActualHeight)
        'Comentado para que no muestre el boton de cerrar ---------------------------------->
        rClose = New Rectangle(Width - 21, 10, 13, 13)

        Dim offset As Integer
        If Title IsNot Nothing Then
            Using fx As Graphics = CreateGraphics()
                Dim sz As SizeF = fx.MeasureString(Title, TitleFont, ActualWidth - rClose.Width - 22, Me.StringFormat)
                rTitle = New Rectangle(11, 12, CInt(Math.Truncate(Math.Ceiling(sz.Width))), CInt(Math.Truncate(Math.Ceiling(sz.Height))))

                offset = CInt(Math.Truncate(Math.Max(Math.Ceiling(sz.Height + rTitle.Top + 2), rClose.Bottom + 5)))
            End Using
        Else
            offset = rClose.Bottom + 1
            rTitle = New Rectangle(-1, -1, 1, 1)
        End If

        rText = New Rectangle(11, offset, ActualWidth - 22, ActualHeight - CInt(Math.Truncate(offset * 1.5)))

        ' rGlob* are Rectangle's Offset'ed to their actual position on the screen, for use with Cursor.Position.
        rGlobClose = rClose
        rGlobClose.Offset(Left, rScreen.Bottom - ActualHeight)
        rGlobText = rText
        rGlobText.Offset(Left, rScreen.Bottom - ActualHeight)
        rGlobTitle = rTitle
        If Title IsNot Nothing Then
            rGlobTitle.Offset(Left, rScreen.Bottom - ActualHeight)
        End If
        rGlobDisplay = rDisplay
        rGlobDisplay.Offset(Left, rScreen.Bottom - ActualHeight)
        rGlobClose = rClose
        rGlobClose.Offset(Left, rScreen.Bottom - ActualHeight)
        rGlobDisplay = rDisplay
        rGlobDisplay.Offset(Left, rScreen.Bottom - ActualHeight)

        ' Use unmanaged ShowWindow() and SetWindowPos() instead of the managed Show() to display the window - this method will display
        ' the window TopMost, but without stealing focus (namely the SW_SHOWNOACTIVATE and SWP_NOACTIVATE flags)
        ShowWindow(Handle, SW_SHOWNOACTIVATE)
        SetWindowPos(Handle, HWND_TOPMOST, rScreen.Width - ActualWidth - 11, rScreen.Bottom, ActualWidth, 0, _
         SWP_NOACTIVATE)

        viewClock = New System.Windows.Forms.Timer()
        AddHandler viewClock.Tick, New System.EventHandler(AddressOf viewTimer)
        viewClock.Interval = 1
        viewClock.Start()

        ClockState = ClockStates.Opening
    End Sub
#End Region

#Region "Drawing"
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        ' Draw the close button and text.
        drawCloseButton(e.Graphics)

        Dim useFont As Font
        Dim useColor As Color
        If Title IsNot Nothing Then
            If titleHot Then
                useFont = TitleHoverFont
            Else
                useFont = TitleFont
            End If
            If titlePressed Then
                useColor = PressedColor
            Else
                useColor = TitleColor
            End If
            Using sb As New SolidBrush(useColor)
                e.Graphics.DrawString(Title, useFont, sb, rTitle, Me.StringFormat)
            End Using
        End If

        If textHot Then
            useFont = HoverFont
        Else
            useFont = Font
        End If
        If textPressed Then
            useColor = PressedColor
        Else
            useColor = TextColor
        End If
        Using sb As New SolidBrush(useColor)
            e.Graphics.DrawString(Text, useFont, sb, rText, Me.StringFormat)
        End Using
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As System.Windows.Forms.PaintEventArgs)
        ' First paint the background
        If BackgroundStyle = BackgroundStyles.Solid Then
            Using sb As New SolidBrush(BackColor)
                e.Graphics.FillRectangle(sb, rDisplay)
            End Using
        Else
            Dim lgm As LinearGradientMode
            Select Case BackgroundStyle
                Case BackgroundStyles.BackwardDiagonalGradient
                    lgm = LinearGradientMode.BackwardDiagonal
                    Exit Select
                Case BackgroundStyles.ForwardDiagonalGradient
                    lgm = LinearGradientMode.ForwardDiagonal
                    Exit Select
                Case BackgroundStyles.HorizontalGradient
                    lgm = LinearGradientMode.Horizontal
                    Exit Select
                Case BackgroundStyles.VerticalGradient
                    lgm = LinearGradientMode.Vertical
                    Exit Select
            End Select
            Using lgb As New LinearGradientBrush(rDisplay, GradientColor, BackColor, lgm)
                If Me.Blend IsNot Nothing Then
                    lgb.Blend = Me.Blend
                End If
                e.Graphics.FillRectangle(lgb, rDisplay)
            End Using
        End If

        ' Next draw borders...
        drawBorder(e.Graphics)
    End Sub

    Protected Overridable Sub drawBorder(ByVal fx As Graphics)
        fx.DrawRectangle(Pens.Silver, 2, 2, Width - 4, ActualHeight - 4)

        ' Top border
        fx.DrawLine(Pens.Silver, 0, 0, Width, 0)
        fx.DrawLine(Pens.White, 0, 1, Width, 1)
        fx.DrawLine(Pens.DarkGray, 3, 3, Width - 4, 3)
        fx.DrawLine(Pens.DimGray, 4, 4, Width - 5, 4)

        ' Left border
        fx.DrawLine(Pens.Silver, 0, 0, 0, ActualHeight)
        fx.DrawLine(Pens.White, 1, 1, 1, ActualHeight)
        fx.DrawLine(Pens.DarkGray, 3, 3, 3, ActualHeight - 4)
        fx.DrawLine(Pens.DimGray, 4, 4, 4, ActualHeight - 5)

        ' Bottom border
        fx.DrawLine(Pens.DarkGray, 1, ActualHeight - 1, Width - 1, ActualHeight - 1)
        fx.DrawLine(Pens.White, 3, ActualHeight - 3, Width - 3, ActualHeight - 3)
        fx.DrawLine(Pens.Silver, 4, ActualHeight - 4, Width - 4, ActualHeight - 4)

        ' Right border
        fx.DrawLine(Pens.DarkGray, Width - 1, 1, Width - 1, ActualHeight - 1)
        fx.DrawLine(Pens.White, Width - 3, 3, Width - 3, ActualHeight - 3)
        fx.DrawLine(Pens.Silver, Width - 4, 4, Width - 4, ActualHeight - 4)
    End Sub

    Protected Overridable Sub drawCloseButton(ByVal fx As Graphics)
        If visualStylesEnabled() Then
            drawThemeCloseButton(fx)
        Else
            drawLegacyCloseButton(fx)
        End If
    End Sub

    ''' <summary>
    ''' Draw a Windows XP style close button.
    ''' </summary>
    Protected Sub drawThemeCloseButton(ByVal fx As Graphics)
        Dim hTheme As IntPtr = OpenThemeData(Handle, "Window")
        If hTheme = IntPtr.Zero Then
            drawLegacyCloseButton(fx)
            Return
        End If
        Dim stateId As Integer
        If closePressed Then
            stateId = CBS_PUSHED
        ElseIf closeHot Then
            stateId = CBS_HOT
        Else
            stateId = CBS_NORMAL
        End If
        Dim reClose As New RECT(rClose)
        Dim reClip As RECT = reClose
        ' should fx.VisibleClipBounds be used here?
        Dim hDC As IntPtr = fx.GetHdc()
        DrawThemeBackground(hTheme, hDC, WP_CLOSEBUTTON, stateId, reClose, reClip)
        fx.ReleaseHdc(hDC)
        CloseThemeData(hTheme)
    End Sub

    ''' <summary>
    ''' Draw a Windows 95 style close button.
    ''' </summary>
    Protected Sub drawLegacyCloseButton(ByVal fx As Graphics)
        Dim bState As ButtonState
        If closePressed Then
            bState = ButtonState.Pushed
        Else
            'the Windows 95 theme doesn't have a "hot" button
            bState = ButtonState.Normal
        End If
        ControlPaint.DrawCaptionButton(fx, rClose, CaptionButton.Close, bState)
    End Sub

    ''' <summary>
    ''' Determine whether or not XP Visual Styles are active.  Compatible with pre-UxTheme.dll versions of Windows.
    ''' </summary>
    Protected Function visualStylesEnabled() As Boolean
        Try
            If IsThemeActive() = 1 Then
                Return True
            Else
                Return False
            End If
        Catch generatedExceptionName As System.DllNotFoundException
            ' pre-XP systems which don't have UxTheme.dll
            Return False
        End Try
    End Function
#End Region

#Region "Timers and EventHandlers"
    Protected Sub viewTimer(ByVal sender As Object, ByVal e As System.EventArgs)
        Select Case ClockState
            Case ClockStates.Opening
                If Top - 2 <= rScreen.Height - ActualHeight Then
                    Top = rScreen.Height - ActualHeight
                    Height = ActualHeight
                    ClockState = ClockStates.Showing
                    viewClock.Interval = WaitTime
                Else
                    Top -= 2
                    Height += 2
                End If
                Exit Select

            Case ClockStates.Showing
                If Not WaitOnMouseOver OrElse Not rGlobDisplay.Contains(Cursor.Position) Then
                    viewClock.Interval = 1
                    ClockState = ClockStates.Closing
                End If
                Exit Select

            Case ClockStates.Closing
                Top += 2
                Height -= 2
                If Top >= rScreen.Height Then
                    ClockState = ClockStates.None
                    viewClock.[Stop]()
                    viewClock.Dispose()
                    Close()
                End If
                Exit Select
        End Select
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        If Title IsNot Nothing AndAlso rGlobTitle.Contains(Cursor.Position) AndAlso Not textPressed AndAlso Not closePressed Then
            Cursor = Cursors.Hand
            titleHot = True
            textHot = False
            closeHot = False
            Invalidate()
        ElseIf rGlobText.Contains(Cursor.Position) AndAlso Not titlePressed AndAlso Not closePressed Then
            Cursor = Cursors.Hand
            textHot = True
            titleHot = False
            closeHot = False
            Invalidate()
        ElseIf rGlobClose.Contains(Cursor.Position) AndAlso Not titlePressed AndAlso Not textPressed Then
            Cursor = Cursors.Hand
            closeHot = True
            titleHot = False
            textHot = False
            Invalidate()
        ElseIf (textHot OrElse titleHot OrElse closeHot) AndAlso (Not titlePressed AndAlso Not textPressed AndAlso Not closePressed) Then
            Cursor = Cursors.[Default]
            titleHot = False
            textHot = False
            closeHot = False
            Invalidate()
        End If
        MyBase.OnMouseMove(e)
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            If rGlobClose.Contains(Cursor.Position) Then
                closePressed = True
                closeHot = False
                Invalidate()
            ElseIf rGlobText.Contains(Cursor.Position) Then
                textPressed = True
                Invalidate()
            ElseIf Title IsNot Nothing AndAlso rGlobTitle.Contains(Cursor.Position) Then
                titlePressed = True
                Invalidate()
            End If
        End If
        MyBase.OnMouseDown(e)
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            If closePressed Then
                Cursor = Cursors.[Default]
                closePressed = False
                closeHot = False
                Invalidate()
                If rGlobClose.Contains(Cursor.Position) Then
                    Close()
                End If
            ElseIf textPressed Then
                Cursor = Cursors.[Default]
                textPressed = False
                textHot = False
                Invalidate()
                If rGlobText.Contains(Cursor.Position) Then
                    Close()
                    RaiseEvent TextClicked(Me, New System.EventArgs())
                End If
            ElseIf titlePressed Then
                Cursor = Cursors.[Default]
                titlePressed = False
                titleHot = False
                Invalidate()
                If rGlobTitle.Contains(Cursor.Position) Then
                    Close()
                    RaiseEvent TitleClicked(Me, New System.EventArgs())
                End If
            End If
        End If
        MyBase.OnMouseUp(e)
    End Sub
#End Region

#Region "P/Invoke"
    ' DrawThemeBackground()
    Protected Const WP_CLOSEBUTTON As Int32 = 18

    Private Sub NotifyWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Protected Const CBS_NORMAL As Int32 = 1
    Protected Const CBS_HOT As Int32 = 2
    Protected Const CBS_PUSHED As Int32 = 3
    <StructLayout(LayoutKind.Explicit)> _
    Protected Structure RECT
        <FieldOffset(0)> _
        Public Left As Int32
        <FieldOffset(4)> _
        Public Top As Int32
        <FieldOffset(8)> _
        Public Right As Int32
        <FieldOffset(12)> _
        Public Bottom As Int32

        Public Sub New(ByVal bounds As System.Drawing.Rectangle)
            Left = bounds.Left
            Top = bounds.Top
            Right = bounds.Right
            Bottom = bounds.Bottom
        End Sub
    End Structure

    ' SetWindowPos()
    Protected Const HWND_TOPMOST As Int32 = -1
    Protected Const SWP_NOACTIVATE As Int32 = &H10

    ' ShowWindow()
    Protected Const SW_SHOWNOACTIVATE As Int32 = 4

    ' UxTheme.dll
    <DllImport("UxTheme.dll")> _
    Protected Shared Function IsThemeActive() As Int32
    End Function
    <DllImport("UxTheme.dll")> _
    Protected Shared Function OpenThemeData(ByVal hWnd As IntPtr, <MarshalAs(UnmanagedType.LPTStr)> ByVal classList As String) As IntPtr
    End Function
    <DllImport("UxTheme.dll")> _
    Protected Shared Sub CloseThemeData(ByVal hTheme As IntPtr)
    End Sub
    <DllImport("UxTheme.dll")> _
    Protected Shared Sub DrawThemeBackground(ByVal hTheme As IntPtr, ByVal hDC As IntPtr, ByVal partId As Int32, ByVal stateId As Int32, ByRef rect As RECT, ByRef clipRect As RECT)
    End Sub

    ' user32.dll
    <DllImport("user32.dll")> _
    Protected Shared Function ShowWindow(ByVal hWnd As IntPtr, ByVal flags As Int32) As Boolean
    End Function
    <DllImport("user32.dll")> _
    Protected Shared Function SetWindowPos(ByVal hWnd As IntPtr, ByVal hWndInsertAfter As Int32, ByVal X As Int32, ByVal Y As Int32, ByVal cx As Int32, ByVal cy As Int32, _
     ByVal uFlags As UInteger) As Boolean
    End Function
#End Region

    'Private Sub InitializeComponent()
    '    Me.Button1 = New System.Windows.Forms.Button
    '    Me.SuspendLayout()
    '    '
    '    'Button1
    '    '
    '    Me.Button1.Location = New System.Drawing.Point(12, 12)
    '    Me.Button1.Name = "Button1"
    '    Me.Button1.Size = New System.Drawing.Size(75, 23)
    '    Me.Button1.TabIndex = 0
    '    Me.Button1.Text = "MTU"
    '    Me.Button1.UseVisualStyleBackColor = True
    '    '
    '    'NotifyWindow
    '    '
    '    Me.ClientSize = New System.Drawing.Size(284, 262)
    '    Me.Controls.Add(Me.Button1)
    '    Me.Name = "NotifyWindow"
    '    Me.ResumeLayout(False)

    'End Sub


End Class