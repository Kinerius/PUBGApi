using System;
using System.Collections.Generic;
using System.Net;
using UniRx;
using UnityEngine.Networking;

namespace Application.Scripts.Domain
{
    public class WebClient : IWebClient
    {
        public IObservable<string> Get(string url)
        {
            var request = UnityWebRequest.Get(url);
            request.SetRequestHeader("accept","application/vnd.api+json");
            request.SetRequestHeader("Authorization", GetAuth());

            return request.SendWebRequest().AsAsyncOperationObservable()
                .Where(r => r.isDone)
                .Do(r => CheckResponse(r.webRequest))
                .Select(_ => request.downloadHandler.text);
        }
        private void CheckResponse(UnityWebRequest webRequest)
        {
            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                throw new WebException(webRequest.error);
            }
        }
        
        private string GetAuth()
        {
            return "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJqdGkiOiI3OTdmNGRlMC01OTIzLTAxMzktNzRmMS03ZGE4YmZmYTllYzAiLCJpc3MiOiJnYW1lbG9ja2VyIiwiaWF0IjoxNjE0MjA4MjU2LCJwdWIiOiJibHVlaG9sZSIsInRpdGxlIjoicHViZyIsImFwcCI6InB1Ymd0ZXN0YXBpa2V5In0.DdHIf94SHqfcBVt615jO2HraUzJnRacylddnW0fCKUc";
        }
    }
}