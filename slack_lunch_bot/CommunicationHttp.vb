Imports System.Net.Http
''' <summary>
''' HTTP通信クラス
''' </summary>
Public Class CommunicationHttp

    ''' <summary>
    ''' Getメソッドリクエスト
    ''' </summary>
    ''' <param name="uri"></param>
    ''' <param name="params"></param>
    ''' <returns></returns>
    Async Function GetRequest(ByVal uri As String, ByVal params As Dictionary(Of String, String)) As Task(Of String)

        Using client = New HttpClient()

            Try

                Dim builder As UriBuilder = New UriBuilder(uri)
                builder.Query = CreateGetMethodParameter(params).Result

                Return Await client.GetStringAsync(builder.Uri)

            Catch ex As Exception
                Throw
            End Try

        End Using
        Return Nothing
    End Function

    ''' <summary>
    ''' Postメソッドリクエスト
    ''' </summary>
    ''' <param name="uri"></param>
    ''' <param name="params"></param>
    ''' <returns></returns>
    Async Function PostRequest(ByVal uri As String, ByVal params As Dictionary(Of String, String)) As Task(Of HttpResponseMessage)
        Using client = New HttpClient

            Try

                Dim content As FormUrlEncodedContent = New FormUrlEncodedContent(params)

                Dim builder As UriBuilder = New UriBuilder(uri)

                Return Await client.PostAsync(builder.Uri, content)

            Catch ex As Exception
                Throw
            End Try

        End Using
        Return Nothing
    End Function

    ''' <summary>
    ''' Getメソッド用パラメータ作成
    ''' </summary>
    ''' <param name="dic"></param>
    ''' <returns></returns>
    Private Async Function CreateGetMethodParameter(ByVal dic As Dictionary(Of String, String)) As Task(Of String)

        Dim content As FormUrlEncodedContent = New FormUrlEncodedContent(dic)
        Await content.ReadAsStringAsync()

        Return Await content.ReadAsStringAsync()

    End Function
End Class
