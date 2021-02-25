using System;
using Application.Scripts.Domain.Dto;

namespace Application.Scripts.Domain
{
    public interface IPubgService
    {
        IObservable<TournamentDto[]> GetTournamentList();
    }
}