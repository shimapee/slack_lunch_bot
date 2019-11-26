Imports Newtonsoft.Json

''' <summary>
''' ボット用共通クラス
''' </summary>
Public Class CommonLunchBot

    ''' <summary>
    ''' Hot Pepper API パラメータ設定
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function getHotPepperParams() As Dictionary(Of String, String)

        Dim apikey As String = Utility.getValue("hotpepperkey")
        Dim smallarea As String = Utility.getValue("hotpeppersmallarea")

        Dim rdm As Integer = Utility.getRandomValue(DateTime.Now.Day)

        Dim params As New Dictionary(Of String, String)
        params.Add("key", apikey)
        params.Add("small_area", smallarea)
        params.Add("keyword", ConstLunchBot.HOTPEPPER_KEYWORD)
        params.Add("start", rdm.ToString)
        params.Add("count", ConstLunchBot.HOTPEPPER_COUNT.ToString)
        params.Add("format", ConstLunchBot.HOTPEPPER_FORMAT)

        Return params
    End Function

    ''' <summary>
    ''' Slack API パラメータ設定
    ''' </summary>
    ''' <param name="name"></param>
    ''' <param name="url"></param>
    ''' <returns></returns>
    Public Shared Function getSlackParams(ByVal name As String, ByVal url As String) As Dictionary(Of String, String)
        Dim token As String = Utility.getValue("slacktoken")
        Dim channel As String = Utility.getValue("slackchannel")

        Dim params As New Dictionary(Of String, String)
        params.Add("token", token)
        params.Add("channel", channel)
        params.Add("text", name & vbCrLf & url)
        params.Add("icon_emoji", ConstLunchBot.SLACK_ICON)

        Return params
    End Function

    ''' <summary>
    ''' Hot Pepper API レスポンスJSON加工
    ''' </summary>
    ''' <param name="rst"></param>
    ''' <param name="name"></param>
    ''' <param name="url"></param>
    Public Shared Sub convertJson(ByVal rst As String, ByRef name As String, ByRef url As String)

        Dim objJson As Object = JsonConvert.DeserializeObject(rst)

        For Each shopdata In objJson("results")("shop")

            name = shopdata("name")
            url = shopdata("urls")("pc")

        Next

    End Sub
End Class
