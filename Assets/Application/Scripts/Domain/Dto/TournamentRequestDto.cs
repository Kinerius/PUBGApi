using System;

namespace Application.Scripts.Domain.Dto
{
    [Serializable]
    public struct TournamentRequestDto
    {
        public TournamentDto[] data;
        public LinksDto links;
        public object meta;
    }
}