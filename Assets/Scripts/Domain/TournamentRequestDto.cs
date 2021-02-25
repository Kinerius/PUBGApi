using System;

namespace Domain
{
    [Serializable]
    public struct TournamentRequestDto
    {
        public TournamentDto[] data;
        public LinksDto links;
        public object meta;
    }
}