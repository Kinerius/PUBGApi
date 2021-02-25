using Application.Scripts.Actions;
using Application.Scripts.Domain;

namespace Application.Scripts.Infrastructure
{
    public static class ServiceProvider
    {
        private static IPubgService _pubgService;
        private static GetTournamentList _getTournamentListAction;
        private static IWebClient _webClient;

        public static GetTournamentList GetTournamentList()
        {
            return _getTournamentListAction ??= CreateGetTournamentListAction();
        }

        private static GetTournamentList CreateGetTournamentListAction()
        {
            return new GetTournamentList( _pubgService ??= CreatePubgService() );
        }

        private static IPubgService CreatePubgService()
        {
            return new PubgService( _webClient ??= CreateWebClient() );
        }

        private static IWebClient CreateWebClient()
        {
            return new WebClient();
        }
    }
}