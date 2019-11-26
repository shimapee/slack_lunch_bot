Imports System.Net.Http

''' <summary>
''' メインクラス
''' </summary>
Public Class clsMain

    ''' <summary>
    ''' メイン処理
    ''' </summary>
    ''' <returns></returns>
    Public Function mainProc() As Boolean

        Dim rtn As Boolean = False

        Dim cls As New CommunicationHttp
        Try
            Dim HotPepperParams As Dictionary(Of String, String) = CommonLunchBot.getHotPepperParams()
            Dim tskHotPepper As Task(Of String) = cls.GetRequest(ConstLunchBot.HOTPEPPER_URL, HotPepperParams)
            tskHotPepper.Wait()

            Dim shopName As String = String.Empty
            Dim shopUrl As String = String.Empty

            CommonLunchBot.convertJson(tskHotPepper.Result, shopName, shopUrl)

            Dim slackParams As Dictionary(Of String, String) = CommonLunchBot.getSlackParams(shopName, shopUrl)
            Dim tskSlack As Task(Of HttpResponseMessage) = cls.PostRequest(ConstLunchBot.SLACK_URL, slackParams)
            tskSlack.Wait()

            rtn = True
        Catch ex As Exception
            Console.WriteLine(ex.Message & vbCrLf & ex.StackTrace)
            rtn = False
        End Try

        Return rtn

    End Function

End Class
