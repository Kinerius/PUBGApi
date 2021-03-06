﻿using System;
using System.Linq;
using Application.Scripts.Domain;
using Application.Scripts.Domain.Dto;
using Application.Scripts.Model;
using UniRx;

namespace Application.Scripts.Actions
{
    public class GetTournamentList
    {
        private readonly IPubgService _service;

        public GetTournamentList(IPubgService service)
        {
            _service = service;
        }

        public IObservable<Tournament[]> Execute()
        {
            return _service.GetTournamentList()
                .Select(ToTournament);
        }

        private Tournament[] ToTournament(TournamentDto[] tournaments)
        {
            return tournaments.Select(t => new Tournament
            {
                id = t.id,
                createdTime = DateTime.Parse(t.attributes.createdAt),
                type = (TournamentType) Enum.Parse(typeof(TournamentType), t.type)
            }).ToArray();
        }
    }
}