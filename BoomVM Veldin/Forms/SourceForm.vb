Imports System.ComponentModel
Imports System.Windows.Forms.ListView
Imports System.Xml

Public Class SourceForm

    'Public Vars
    'Private strList(0) As String
    Private strLogo As String = ""
    Private strSource As String = Application.StartupPath & "\Source.ini"

    'Validate & Add Source
    Private Sub btnAddSource_Click(sender As Object, e As EventArgs) Handles btnAddSource.Click
        If txtDomain.Text = "" Then Exit Sub
        'Show Validating
        btnAddSource.Text = My.Resources.UI_Source_Validating
        'Start Thread
        bgwValidate.RunWorkerAsync()
    End Sub

#Region "Validate"

    'Validate Thread
    Private Sub bgwValidate_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwValidate.DoWork
        'Check if bom.xml exists
        Dim wcFile As New Net.WebClient
        If Not IO.Directory.Exists(Application.StartupPath & "\Temp\") Then
            IO.Directory.CreateDirectory(Application.StartupPath & "\Temp")
        End If
        Try
            wcFile.DownloadFile("http://" & txtDomain.Text & "/bom.xml", Application.StartupPath & "\Temp\bom.xml")
        Catch ex As Exception
            bgwValidate.ReportProgress(0)
            Exit Sub
        End Try
        wcFile.Dispose()
        'If exists, load icon & name
        Dim srcName As String = ""
        Dim srcLogo As String = ""
        Dim xmlFile As New XmlDocument
        xmlFile.Load(Application.StartupPath & "/Temp/bom.xml")
        Dim xnr As New XmlNodeReader(xmlFile)
        While xnr.Read
            Select Case xnr.NodeType
                Case XmlNodeType.Element
                    If xnr.Name = "name" Then
                        srcName = xnr.Value
                    ElseIf xnr.Name = "logo" Then
                        srcLogo = xnr.Value
                    End If
            End Select
        End While
        xnr.Close()
        'Display name
        bgwValidate.ReportProgress(1, srcName)
        'Get Logo
        strLogo = "http://" & txtDomain.Text & "/" & srcLogo
        Dim wcLogo As New Net.WebClient
        Try
            wcLogo.DownloadFile("http://" & txtDomain.Text & "/" & srcLogo, Application.StartupPath & "\Temp\" & srcLogo)
        Catch ex As Exception
            bgwLoadIcon.ReportProgress(0)
            Exit Sub
        End Try
        'Display Logo
        bgwValidate.ReportProgress(2, Application.StartupPath & "\Temp\" & srcLogo)
    End Sub

    'Apply UI Changes
    Private Sub bgwValidate_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwValidate.ProgressChanged
        Dim strSourceName As String = ""
        Dim itmNew As New ListViewItem
        Dim itmSub As New ListViewItem.ListViewSubItem
        Select Case e.ProgressPercentage
            Case 0
                btnAddSource.Text = My.Resources.UI_Source_Add
                MessageBox.Show(My.Resources.UI_Source_Validate_Failed, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Case 1
                itmNew.Text = e.UserState
                itmSub.Text = txtDomain.Text
                itmNew.SubItems.Add(itmSub)
                strSourceName = e.UserState
            Case 2
                imgMain.Images.Add(txtDomain.Text, Image.FromFile(e.UserState))
                itmNew.ImageKey = txtDomain.Text
                lstMain.Items.Add(itmNew)
                'Write changes to config
                INISet(strSourceName, "Domain", txtDomain.Text, strSource)
                INISet(strSourceName, "Logo", e.UserState, strSource)
        End Select
    End Sub

#End Region

    'Load Boom Sources From File
    Private Sub SourceForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        'Remove From List
        If lstMain.SelectedItems.Count = 0 Then Exit Sub
        Dim strRemove = lstMain.SelectedItems.Item(0).Text
        lstMain.Items.Remove(lstMain.SelectedItems.Item(0))
        'Remove From Config
        INIRemoveSection(strRemove, strSource)
    End Sub

    'Form Closing
    'Private Sub SourceForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

    'End Sub

End Class