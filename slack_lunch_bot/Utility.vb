''' <summary>
''' ユーティリティクラス
''' </summary>
Public Class Utility
    ''' <summary>
    ''' App.configの値返却
    ''' </summary>
    ''' <param name="key"></param>
    ''' <returns>value</returns>
    Public Shared Function getValue(ByVal key As String) As String
        Return System.Configuration.ConfigurationManager.AppSettings(key)
    End Function

    ''' <summary>
    ''' ランダムな数値を取得
    ''' </summary>
    ''' <param name="range">取得する範囲</param>
    ''' <returns>ランダムな数値</returns>
    Public Shared Function getRandomValue(ByVal range As Integer) As Integer

        Dim rtn As Integer = 0

        Dim rdm As New Random(1000 * range)

        rtn = rdm.Next(range)

        Return rtn

    End Function
End Class
