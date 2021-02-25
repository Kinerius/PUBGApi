using System;
using System.Collections.Generic;
using System.Net;
using Application.Scripts.Domain.Dto;
using Newtonsoft.Json;
using UniRx;
using UnityEngine.Networking;

namespace Application.Scripts.Domain
{
    public class PubgService : IPubgService
    {
        private readonly IWebClient _webClient;
        private const string API_URL = "https://api.pubg.com/tournaments";

        public PubgService(IWebClient webClient)
        {
            _webClient = webClient;
        }

        public IObservable<TournamentDto[]> GetTournamentList()
        {
            return _webClient.Get(API_URL).Select(ParseResponse);
        }

        private TournamentDto[] ParseResponse(string response)
        {
            var requestDto = JsonConvert.DeserializeObject<TournamentRequestDto>(response);
            return requestDto.data;
        }
        
    }
}
