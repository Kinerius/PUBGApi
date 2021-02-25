using System;

namespace Application.Scripts.Domain.Dto
{
    [Serializable]
    public struct TournamentDto
    {
        public string type;
        public string id;
        public TournamentAttributesDto attributes;
    }
}