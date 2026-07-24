' -----------------------------------------------------------------------------
' AtlasHelper © 2026 Unai Villar López
' Este módulo forma parte del proyecto AtlasLMS y está creado con la intención
' de mantener el código limpio, reutilizable y libre de ruido. Su uso está 
' permitido dentro del ecosistema AtlasLMS y proyectos derivados del autor.
' Todas las funciones aquí son puras, simples y pensadas para mantener la lógica 
' de negocio limpia y profesional.
' -----------------------------------------------------------------------------
Public Module AtlasHelper

#Region "   IsStringEmpty----------------------------------------------------------------"
    Public Function IsStringEmpty(asVal As String) As Boolean
        Return String.IsNullOrEmpty(asVal)
    End Function
#End Region

#Region "   IsNotStringEmpty----------------------------------------------------------------"
    Public Function IsNotStringEmpty(asVal As String) As Boolean
        Return Not String.IsNullOrEmpty(asVal)
    End Function
#End Region

#Region "   AreStringsEmpty----------------------------------------------------------------------"
    Public Function AreStringsEmpty(asValF As String, asValS As String) As Boolean
        Return String.IsNullOrEmpty(asValF) AndAlso String.IsNullOrEmpty(asValS)
    End Function
    Public Function AreStringsEmpty(asValF As String, asValS As String, asValT As String) As Boolean
        Return String.IsNullOrEmpty(asValF) AndAlso String.IsNullOrEmpty(asValS) AndAlso String.IsNullOrEmpty(asValT)
    End Function
#End Region

#Region "   AreNotStringsEmpty------------------------------------------------------------------------"
    Public Function AreNotStringsEmpty(asValF As String, asValS As String) As Boolean
        Return Not String.IsNullOrEmpty(asValF) AndAlso String.IsNullOrEmpty(asValS)
    End Function
    Public Function AreNotStringsEmpty(asValF As String, asValS As String, asValT As String) As Boolean
        Return Not String.IsNullOrEmpty(asValF) AndAlso String.IsNullOrEmpty(asValS) AndAlso String.IsNullOrEmpty(asValT)
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

#Region "   GetOrFallbackAndNormalizeStr-----------------------------------------------------------------------"
    Public Function GetOrFallbackAndNormalizeStr(asPrimary As String, asFallback As String) As String
        If String.IsNullOrEmpty(asPrimary) Then
            Return asFallback.ToUpper().Trim()
        Else
            Return asPrimary.ToUpper().Trim()
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

#Region "   IsDateGreater-----------------------------------------------------"
    Public Function IsDateGreater(adDate As DateTime) As Boolean
        Return adDate > DateTime.UtcNow
    End Function
#End Region

#Region "   IsDateGreaterOrEqual-------------------------------------------------------------"
    Public Function IsDateGreaterOrEqual(adDateF As DateTime, adDateS As DateTime) As Boolean
        Return adDateF >= adDateS
    End Function
#End Region

#Region "   IsNotDateGreaterOrEqual-------------------------------------------------------------"
    Public Function IsNotDateGreaterOrEqual(adDateF As DateTime, adDateS As DateTime) As Boolean
        Return Not adDateF >= adDateS
    End Function
#End Region

#Region "   IsAnyDatePast--------------------------------------------------------------------"
    Public Function IsAnyDatePast(adDateF As DateTime) As Boolean
        Return adDateF <= DateTime.UtcNow
    End Function
    Public Function IsAnyDatePast(adDateF As DateTime, adDateS As DateTime) As Boolean
        Return adDateF <= DateTime.UtcNow OrElse adDateS <= DateTime.UtcNow
    End Function
#End Region

#Region "   IsNotAnyDatePast--------------------------------------------------------------------"
    Public Function IsNotAnyDatePast(adDateF As DateTime) As Boolean
        Return Not adDateF <= DateTime.UtcNow
    End Function
    Public Function IsNotAnyDatePast(adDateF As DateTime, adDateS As DateTime) As Boolean
        Return Not adDateF <= DateTime.UtcNow OrElse adDateS <= DateTime.UtcNow
    End Function
#End Region

#Region "   NormalizeUpper--------------------------------------------------------------------"
    Public Function NormalizeUpper(asVal As String) As String
        If asVal IsNot Nothing Then
            Return asVal.ToUpper().Trim()
        Else
            Return ""
        End If
    End Function
#End Region

#Region "  GetOrExistingIntNullable------------------------------------------------------------------"
    Public Function GetOrExistingIntNullable(aiValNullable As Integer?, aiValExisting As Integer) As Integer
        If aiValNullable.HasValue Then
            Return aiValNullable.Value
        Else
            Return aiValExisting
        End If
    End Function
#End Region

#Region "  ResolveNullableInt------------------------------------------------------------------"
    Public Function ResolveNullableInt(aiValNullable As Integer?, aiValExisting As Integer?) As Integer?
        If aiValNullable.HasValue Then
            Return aiValNullable.Value
        Else
            If aiValExisting.HasValue Then
                Return aiValExisting.Value
            Else
                Return Nothing
            End If
        End If
    End Function
#End Region

#Region "   GetOrExistingDate------------------------------------------------------------------------"
    Public Function GetOrExistingDate(adDateNullable As DateTime?, adDateExisting As DateTime) As DateTime
        If Not adDateNullable.HasValue Then
            Return adDateExisting
        Else
            Return adDateNullable.Value
        End If
    End Function
#End Region

#Region "   IsNullableInteger--------------------------------------------------------------"
    Public Function IsNullableInteger(aiVal As Integer?) As Boolean
        Return Not aiVal.HasValue
    End Function
#End Region

#Region "   IsNotNullableInteger--------------------------------------------------------------"
    Public Function IsNotNullableInteger(aiVal As Integer?) As Boolean
        Return aiVal.HasValue
    End Function
#End Region

#Region "   IsNotNullAndFutureDate------------------------------------------------------------"
    Public Function IsNotNullAndFutureDate(adDate As DateTime?) As Boolean
        Return adDate.HasValue AndAlso adDate > DateTime.UtcNow
    End Function
#End Region

#Region "   IsNotNullAndPassDate------------------------------------------------------------"
    Public Function IsNotNullAndPassDate(adDate As DateTime?) As Boolean
        Return adDate.HasValue AndAlso adDate < DateTime.UtcNow
    End Function
#End Region

#Region "   GetEmailUserPart--------------------------------------------------------"
    Public Function GetEmailUserPart(asEmail As String) As String
        Return asEmail.Split("@")(0)
    End Function
#End Region

End Module
