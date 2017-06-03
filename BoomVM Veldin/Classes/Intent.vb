Public Class Intent

    'Global vars
    Private varParam(0) As Param
    Private intParam As Integer = 0

    'Param Structure
    Private Structure Param
        Dim Key As String
        Dim Value As Object
    End Structure

    'Property Parameter Length
    Public ReadOnly Property ParamLength As Integer
        Get
            Return intParam
        End Get
    End Property

    'Init
    Public Sub New()
        intParam = 0
        ReDim varParam(0)
    End Sub

    'Add String to intent
    Public Sub AddExtra(ByVal Key As String, ByVal Value As String)
        ReDim Preserve varParam(intParam + 1)
        varParam(intParam).Key = Key
        varParam(intParam).Value = Value
        intParam += 1
    End Sub

    'Add Object to intent
    Public Sub AddExtra(ByVal Key As String, ByVal Value As Object)
        ReDim Preserve varParam(intParam + 1)
        varParam(intParam).Key = Key
        varParam(intParam).Value = Value
        intParam += 1
    End Sub

    'Get Parameter from Intent
    Public Function GetExtra(ByVal Key As String) As Object
        For i As Integer = 0 To intParam - 1
            If Key = varParam(i).Key Then
                Return varParam(i).Value
            End If
        Next
        Return Nothing
    End Function

End Class
