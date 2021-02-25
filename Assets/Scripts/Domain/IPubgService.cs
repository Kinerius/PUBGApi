using System;
using System.Collections.Generic;

namespace Domain
{
    public interface IPubgService
    {
        IObservable<TournamentDto[]> GetTournamentList();
    }
}