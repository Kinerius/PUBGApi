using System;

namespace Domain
{
    public struct Tournament
    {
        public TournamentType type;
        public string id;
        public DateTime createdTime;
    }

    public enum TournamentType
    {
        tournament
    }
}