using System;

namespace Domain
{
    [Serializable]
    public struct TournamentDto
    {
        public string type;
        public string id;
        public TournamentAttributesDto attributes;
    }
}