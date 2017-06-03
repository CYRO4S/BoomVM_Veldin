Public Class BoomPackage

    'Public Vars
    Private pkgSource As String = ""
    Private pkgName As String = ""
    Private pkgAuthor As String = ""
    Private pkgIcon As String = ""
    Private pkgIntro As String = ""
    Private pkgInstall As String = ""
    Private pkgUpdate As String = ""
    Private pkgRemove As String = ""
    Private pkgNeedParam As Boolean = False
    Private pkgParams() As String

    Public Sub New(ByVal SourceDomain As String)
        pkgSource = SourceDomain
    End Sub

    Public Property Name As String
        Get
            Return pkgName
        End Get
        Set(value As String)
            pkgName = value
        End Set
    End Property

    Public Property Author As String
        Get
            Return pkgAuthor
        End Get
        Set(value As String)
            value = pkgAuthor
        End Set
    End Property

    Public Property Icon As String
        Get
            Return pkgIcon
        End Get
        Set(value As String)
            pkgIcon = "http://" & pkgSource & "/" & value
        End Set
    End Property

    Public Property Intro As String
        Get
            Return pkgIntro
        End Get
        Set(value As String)
            pkgIntro = "http://" & pkgSource & "/" & value
        End Set
    End Property

    Public Property InstallScript As String
        Get
            Return pkgInstall
        End Get
        Set(value As String)
            pkgInstall = "http://" & pkgSource & "/" & value
        End Set
    End Property

    Public Property UpdateScript As String
        Get
            Return pkgUpdate
        End Get
        Set(value As String)
            pkgUpdate = "http://" & pkgSource & "/" & value
        End Set
    End Property

    Public Property RemoveScript As String
        Get
            Return pkgRemove
        End Get
        Set(value As String)
            pkgRemove = "http://" & pkgSource & "/" & value
        End Set
    End Property

    Public Property NeedParam As Boolean
        Get
            Return pkgNeedParam
        End Get
        Set(value As Boolean)
            pkgNeedParam = value
        End Set
    End Property

    Public Property Params As String()
        Get
            Return pkgParams
        End Get
        Set(value As String())
            pkgParams = value
        End Set
    End Property

End Class
