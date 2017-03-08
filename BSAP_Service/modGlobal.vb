Imports System.Windows.Forms
Imports BurnSoft.Universal
Module modGlobal
    Public DO_DEBUG As Boolean
    Public DO_HEALTH_CHECK As Boolean
    Dim sConn As String
    Public Function ShortPath() As String
        Dim strSplit() As String
        Dim IntBound As Integer
        Dim sAns As String = ""
        Dim i As Integer
        Dim sPath As String = Application.StartupPath
        Dim strPath As String = Replace(sPath, " ", "")

        strSplit = Split(strPath, "\")
        IntBound = UBound(strSplit)
        If IntBound > 0 Then
            For i = 0 To IntBound
                If Len(strSplit(i)) > 8 Then
                    sAns &= Left(Trim(strSplit(i)), 6) & System.Configuration.ConfigurationManager.AppSettings("SHORTPATH") & "\"
                Else
                    sAns &= strSplit(i) & "\"
                End If
            Next
        End If
        Return sAns
        Exit Function
    End Function
End Module
