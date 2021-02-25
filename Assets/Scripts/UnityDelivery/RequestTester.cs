using Domain;
using Infrastructure;
using UniRx;
using UnityEngine;

namespace UnityDelivery
{
    public class RequestTester : MonoBehaviour
    {
        public void Start()
        {
            var getTournamentList = ServiceProvider.GetTournamentList();
            
            getTournamentList.Execute()
                .Do(LogTournaments)
                .Subscribe();
        }

        private void LogTournaments(Tournament[] tournaments)
        {
            foreach (var tournament in tournaments)
            {
                Debug.Log($"ID: {tournament.id} type: {tournament.type} time: {tournament.createdTime}");
            }
        }
    }
}
