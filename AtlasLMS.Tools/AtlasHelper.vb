Public Module AtlasHelper

#Region "   AreNotStringsEmpty------------------------------------------------------------------------"
    Public Function AreNotStringsEmpty(asValF As String, asValS As String) As Boolean
        Return Not String.IsNullOrEmpty(asValF) AndAlso String.IsNullOrEmpty(asValS)
    End Function
#End Region

#Region "   GetOrFallbackStr-----------------------------------------------------------------------"
    Public Function GetOrFallbackStr(asPrimary As String, asFallback As String) As String
        If String.IsNullOrEmpty(asPrimary) Then
            Return asFallback
        Else
            Return asPrimary
        End If
    End Function
#End Region

#Region "   IsEqualsStr------------------------------------------------------------------"
    Public Function IsEqualsStr(asValF As String, asValS As String) As Boolean
        Return asValF.Equals(asValS)
    End Function
#End Region

#Region "   IsNotEqualsStr------------------------------------------------------------------"
    Public Function IsNotEqualsStr(asValF As String, asValS As String) As Boolean
        Return Not asValF.Equals(asValS)
    End Function
#End Region

End Module
