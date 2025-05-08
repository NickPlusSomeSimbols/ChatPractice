using Ardalis.Result;
using ChatPractice.DTO.Dtos.Message;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net.Http.Json;

namespace ChatPractice.BLL.Helpers;
public static class ResponceProcessingHelper
{
    public async static Task<dynamic> GetResultValue<T>(this Result<T> result, HttpResponseMessage response)
    {
        var responseBody = await response.Content.ReadFromJsonAsync<Result<T>>();

        // Move To generic check
        if (responseBody == null)
        {
            return default;
        }
        //
        if (typeof(T) is System.Collections.IEnumerable)
        {
            var objectList = responseBody.Value as ;

            if (objectList is null)
            {
                var type = typeof(int);
                Type at = typeof(IEnumerable<>).MakeGenericType(type);
                var x = at.GetMethod("Empty").Invoke(null, new object[] { });
                return x;
            }

            dynamic sss = DateOnly.MinValue;
            DateTime dt = sss.AsDateOnly();
            sss.Year = 2023;

            sss.GetMonth();

            return default;
        }
        List<ChatMessageDto> messages;



        if (responseBody == null || responseBody.Value == null)
        {
            messages = new List<ChatMessageDto>();
        }
        else
        {
            messages = responseBody.Value;
        }

        if (messages == null)
        {
            messages = new List<ChatMessageDto>();
        }

        return messages;
    }

}
