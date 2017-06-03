Module Mod_INI

    'Get Value by Section & Key
    Public Function INIGet(ByVal Section As String, ByVal AppName As String, ByVal DefaultValue As String, ByVal FileName As String) As String
        Dim Str As String = LSet(Str, 256)
        GetPrivateProfileString(Section, AppName, DefaultValue, Str, Len(Str), FileName)
        Return Microsoft.VisualBasic.Left(Str, InStr(Str, Chr(0)) - 1)
    End Function

    'Set Value by Section & Key
    Public Function INISet(ByVal Section As String, ByVal AppName As String, ByVal Value As String, ByVal FileName As String) As Long
        INISet = WritePrivateProfileString(Section, AppName, Value, FileName)
    End Function

    'Get All Sections
    Public Function INIGetAllSection(ByVal Path As String)
        Const ProStringLen = 8096
        Dim Res As Long, S As String, i As Long
        S = Space(ProStringLen)
        Res = GetPrivateProfileString(vbNullString, vbNullString, vbNullString, S, ProStringLen, Path)
        S = Trim(Left(S, Res))
        If S <> "" Then
            i = Len(S)
            Do While Mid(S, i, 1) = vbNullChar
                i = i - 1
            Loop
            S = Left(S, i)
        End If
        INIGetAllSection = Split(Trim(S), vbNullChar)
    End Function

    'Remove Section
    Public Function INIRemoveSection(Section As String, IniFile As String) As String
        WritePrivateProfileString(Section, vbNullString, vbNullString, IniFile)
    End Function

    'Remove Key by Section
    Public Function INIRemoveKey(Section As String, Key As String, IniFile As String) As String
        WritePrivateProfileString(Section, Key, 0&, IniFile)
    End Function

    'Clear Section
    Public Function INIClearSection(Section As String, IniFile As String) As String
        WritePrivateProfileSection(Section, "", IniFile)
    End Function

    'The APIs
    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Int32, ByVal lpFileName As String) As Int32
    Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Int32
    Private Declare Function GetPrivateProfileSection Lib "kernel32" Alias "GetPrivateProfileSectionA" (ByVal lpAppName As String, ByVal lpReturnedString As String, ByVal nSize As Long, ByVal lIniFileName As String) As Long
    Private Declare Function WritePrivateProfileSection Lib "kernel32" Alias "WritePrivateProfileSectionA" (ByVal lpAppName As String, ByVal lpString As String, ByVal lIniFileName As String) As Long
End Module
