using Actions;
using Domain;

namespace Infrastructure
{
    public static class ServiceProvider
    {
        private static IPubgService _pubgService;
        private static GetTournamentList _getTournamentListAction;

        public static GetTournamentList GetTournamentList()
        {
            return _getTournamentListAction ?? CreateGetTournamentListAction();
        }

        private static GetTournamentList CreateGetTournamentListAction()
        {
            return new GetTournamentList( _pubgService ?? CreatePubgService() );
        }

        private static IPubgService CreatePubgService()
        {
            return new PubgService();
        }
    }
}