using Application.Scripts.Domain;
using Application.Scripts.Infrastructure;
using Application.Scripts.Model;
using UniRx;
using UnityEngine;

namespace Application.Scripts.UnityDelivery
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
