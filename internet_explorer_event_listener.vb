# VB .NET class that implements an Internet Explorer event listener using a separate thread for the listener.
# The class uses OLE interfaces to listen for events, outputing an interaction map. A configuration class is used
# to switch on/off events listened (once start listening, a lot of events will popup!)

Imports SHDocVw
Imports System.Runtime.InteropServices
Imports System.Xml
Imports System.Threading
Imports AutomationCore.EnvironmentResources


Public Class _Listener
    Private WithEvents _ref As InternetExplorer
    Private _loop As Boolean = True
    Private _configuration As ListenerModeConfiguration

    Public Event OnEvent(ByVal eventObj As _Event)

    Public Sub New()
        _ref = New InternetExplorer
        _ref.Visible = True
    End Sub

    Public Sub SetConfiguration(ByRef listenerModeConfig As ListenerModeConfiguration)
        _configuration = listenerModeConfig
    End Sub

    Public Function GetListenerMode() As String
        Return _configuration.GetName
    End Function

    Public Sub StartListening()
        While _loop
        End While
    End Sub

    Private Function CreateEventObject(ByVal eventName As String, Optional ByVal eventAttrs As Hashtable = Nothing)
        If _configuration.IsEventSupported(eventName) Then
            Dim eventObj = New _Event
            eventObj.EventName = eventName
            eventObj.EventSource = "Internet Explorer"
            eventObj.EventTarget = ""
            eventObj.EventTime = Now.ToString

            If eventAttrs Is Nothing Then
            Else
                eventObj.AddAttributes(eventAttrs)
            End If

            Return eventObj
        End If

        Return Nothing
    End Function

    # Event handlers for default IE events

    Private Sub _OnQuit() Handles _ref.OnQuit
        Dim eventObj = CreateEventObject("OnQuit")
        RaiseEvent OnEvent(eventObj)
        _loop = False
        _ref = Nothing
    End Sub

    Private Sub _DocumentComplete(ByVal pDisp As Object, ByRef URL As Object) Handles _ref.DocumentComplete
        Dim attrs = New Hashtable
        attrs.Add("url", URL.ToString)
        Dim eventObj = CreateEventObject("DocumentComplete", attrs)
        RaiseEvent OnEvent(eventObj)
    End Sub
    Private Sub _OnVisible(ByVal Visible As Boolean) Handles _ref.OnVisible
        Dim attrs = New Hashtable
        attrs.Add("visible", Visible.ToString)
        Dim eventObj = CreateEventObject("OnVisible", attrs)
        RaiseEvent OnEvent(eventObj)
    End Sub

    Private Sub _BeforeNavigate2(ByVal pDisp As Object, ByRef URL As Object, ByRef Flags As Object, ByRef TargetFrame As Object, ByRef PostData As Object, ByRef Headers As Object, ByRef Cancel As Object) Handles _ref.BeforeNavigate2

        Dim attrs = New Hashtable
        attrs.Add("url", URL.ToString)
        Dim eventObj = CreateEventObject("BeforeNavigate2", attrs)
        RaiseEvent OnEvent(eventObj)
    End Sub

    Private Sub _NavigateComplete2(ByVal pDisp As Object, ByRef URL As Object) Handles _ref.NavigateComplete2
        Dim attrs = New Hashtable
        attrs.Add("url", URL.ToString)
        Dim eventObj = CreateEventObject("NavigateComplete2", attrs)
        RaiseEvent OnEvent(eventObj)
    End Sub

    Private Sub _TitleChange(ByVal Title As String) Handles _ref.TitleChange
        Dim attrs = New Hashtable
        attrs.Add("title", Title.ToString)
        Dim eventObj = CreateEventObject("TitleChange", attrs)
        RaiseEvent OnEvent(eventObj)
    End Sub

    Private Sub _ClientToHostWindow() Handles _ref.ClientToHostWindow
        Dim eventObj = CreateEventObject("ClientToHostWindow")
        RaiseEvent OnEvent(eventObj)
    End Sub

    Private Sub _CommandStateChange() Handles _ref.CommandStateChange
        Dim eventObj = CreateEventObject("CommandStateChange")
        RaiseEvent OnEvent(eventObj)
    End Sub

    Private Sub _DownloadBegin() Handles _ref.DownloadBegin
        Dim eventObj = CreateEventObject("DownloadBegin")
        RaiseEvent OnEvent(eventObj)
    End Sub

    Private Sub _DownloadComplete() Handles _ref.DownloadComplete
        Dim eventObj = CreateEventObject("DownloadComplete")
        RaiseEvent OnEvent(eventObj)
    End Sub

    Private Sub _NewProcess() Handles _ref.NewProcess
        Dim eventObj = CreateEventObject("NewProcess")
        RaiseEvent OnEvent(eventObj)
    End Sub

    Private Sub _NewWindow2() Handles _ref.NewWindow2
        Dim eventObj = CreateEventObject("NewWindow2")
        RaiseEvent OnEvent(eventObj)
    End Sub

    Private Sub _NewWindow3() Handles _ref.NewWindow3
        Dim eventObj = CreateEventObject("NewWindow3")
        RaiseEvent OnEvent(eventObj)
    End Sub

    Private Sub _OnFullScreen() Handles _ref.OnFullScreen
        Dim eventObj = CreateEventObject("OnFullScreen")
        RaiseEvent OnEvent(eventObj)
    End Sub

    Private Sub _OnMenuBar() Handles _ref.OnMenuBar
        Dim eventObj = CreateEventObject("OnMenuBar")
        RaiseEvent OnEvent(eventObj)
    End Sub

    Private Sub _OnStatusBar() Handles _ref.OnStatusBar
        Dim eventObj = CreateEventObject("OnStatusBar")
        RaiseEvent OnEvent(eventObj)
    End Sub

    Private Sub _OnTheaterMode() Handles _ref.OnTheaterMode
        Dim eventObj = CreateEventObject("OnTheaterMode")
        RaiseEvent OnEvent(eventObj)
    End Sub

    Private Sub _OnToolBar() Handles _ref.OnToolBar
        Dim eventObj = CreateEventObject("OnToolBar")
        RaiseEvent OnEvent(eventObj)
    End Sub

    Private Sub _PrintTemplateInstantiation() Handles _ref.PrintTemplateInstantiation
        Dim eventObj = CreateEventObject("PrintTemplateInstantiation")
        RaiseEvent OnEvent(eventObj)
    End Sub

    Private Sub _PrintTemplateTeardown() Handles _ref.PrintTemplateTeardown
        Dim eventObj = CreateEventObject("PrintTemplateTeardown")
        RaiseEvent OnEvent(eventObj)
    End Sub

    Private Sub _ProgressChange() Handles _ref.ProgressChange
        Dim eventObj = CreateEventObject("ProgressChange")
        RaiseEvent OnEvent(eventObj)
    End Sub

    Private Sub _PropertyChange() Handles _ref.PropertyChange
        Dim eventObj = CreateEventObject("PropertyChange")
        RaiseEvent OnEvent(eventObj)
    End Sub

    Private Sub _StatusTextChange() Handles _ref.StatusTextChange
        Dim eventObj = CreateEventObject("StatusTextChange")
        RaiseEvent OnEvent(eventObj)
    End Sub

    Private Sub _UpdatePageStatus() Handles _ref.UpdatePageStatus
        Dim eventObj = CreateEventObject("UpdatePageStatus")
        RaiseEvent OnEvent(eventObj)
    End Sub

    Private Sub _WindowClosing() Handles _ref.WindowClosing
        Dim eventObj = CreateEventObject("WindowClosing")
        RaiseEvent OnEvent(eventObj)
    End Sub

    Private Sub _WindowSetHeight() Handles _ref.WindowSetHeight
        Dim eventObj = CreateEventObject("WindowSetHeight")
        RaiseEvent OnEvent(eventObj)
    End Sub

    Private Sub _WindowSetLeft() Handles _ref.WindowSetLeft
        Dim eventObj = CreateEventObject("WindowSetLeft")
        RaiseEvent OnEvent(eventObj)
    End Sub

    Private Sub _WindowSetResizable() Handles _ref.WindowSetResizable
        Dim eventObj = CreateEventObject("WindowSetResizable")
        RaiseEvent OnEvent(eventObj)
    End Sub

    Private Sub _WindowSetTop() Handles _ref.WindowSetTop
        Dim eventObj = CreateEventObject("WindowSetTop")
        RaiseEvent OnEvent(eventObj)
    End Sub

    Private Sub _WindowSetWidth() Handles _ref.WindowSetWidth
        Dim eventObj = CreateEventObject("WindowSetWidth")
        RaiseEvent OnEvent(eventObj)
    End Sub

    Private Sub _WindowStateChanged() Handles _ref.WindowStateChanged
        Dim eventObj = CreateEventObject("WindowStateChanged")
        RaiseEvent OnEvent(eventObj)
    End Sub

End Class