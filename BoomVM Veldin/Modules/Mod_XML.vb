Imports System.Xml

Module Mod_XML

    Public Function XmlGetPackages(ByVal FileName As String, ByVal Category As String) As String
        Dim strReturn As String = ""
        Dim xmlFile As New XmlDocument
        Try
            xmlFile.Load(FileName)
        Catch ex As Exception
            strReturn = Nothing
            Return strReturn
            Exit Function
        End Try

        Dim xn As XmlNode = xmlFile.SelectSingleNode("//cat[@name='" & Category & "']")
        Dim xnr As New XmlNodeReader(xn)
        While xnr.Read
            Select Case xnr.NodeType
                Case XmlNodeType.Element
                    If xnr.Name = "pkg" Then
                        strReturn &= xnr.GetAttribute("name")
                        strReturn &= ","
                    End If
            End Select
        End While
        Return strReturn
    End Function

    Public Function XmlGetCategories(ByVal FileName As String) As String
        Dim strReturn As String = ""
        Dim xmlFile As New XmlDocument
        Try
            xmlFile.Load(FileName)
        Catch ex As XmlException
            strReturn = Nothing
            Return strReturn
            Exit Function
        End Try

        Dim xnr As New XmlNodeReader(xmlFile)
        While xnr.Read
            Select Case xnr.NodeType
                Case XmlNodeType.Element
                    If xnr.Name = "cat" Then
                        strReturn &= xnr.GetAttribute("name")
                        strReturn &= ","
                    End If
            End Select
        End While
        Return strReturn
    End Function

    Public Function XmlGetDetail(ByVal Domain As String, ByVal PackageName As String) As BoomPackage
        'Package class to return
        Dim pkgReturn As New BoomPackage(Domain)
        'Package name
        pkgReturn.Name = PackageName
        'Load XML File
        Dim xmlFile As New XmlDocument
        xmlFile.Load(Application.StartupPath & "\Temp\bom.xml")
        'Get the package node
        Dim xn As XmlNode = xmlFile.SelectSingleNode("//pkg[@name='" & PackageName & "']")
        Dim xnr As New XmlNodeReader(xn)
        'XMl Element Name
        Dim strName As String = ""
        'XML Install param index
        Dim intParam As Integer = 1
        'Install Params
        Dim strParams(0) As String
        While xnr.Read
            Select Case xnr.NodeType
                Case XmlNodeType.Element
                    strName = xnr.Name
                    If xnr.AttributeCount <> 0 Then
                        intParam = CInt(xnr.GetAttribute("index"))
                    End If
                Case XmlNodeType.Text
                    Select Case strName
                        Case "icon"
                            pkgReturn.Icon = xnr.Value
                        Case "author"
                            pkgReturn.Author = xnr.Value
                        Case "intro"
                            pkgReturn.Intro = xnr.Value
                        Case "install"
                            pkgReturn.InstallScript = xnr.Value
                        Case "update"
                            pkgReturn.UpdateScript = xnr.Value
                        Case "remove"
                            pkgReturn.RemoveScript = xnr.Value
                        Case "param"
                            pkgReturn.NeedParam = True
                            ReDim Preserve strParams(intParam)
                            strParams(intParam - 1) = xnr.Value
                            intParam += 1
                    End Select
            End Select
        End While
        'Package Params
        pkgReturn.Params = strParams
        Return pkgReturn
    End Function

End Module
