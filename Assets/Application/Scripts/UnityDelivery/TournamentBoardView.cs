using Application.Scripts.Model;
using UnityEngine;

namespace Application.Scripts.UnityDelivery
{
    public class TournamentBoardView : MonoBehaviour
    {
        [SerializeField] private GameObject tournamentItemPrefab;
        [SerializeField] private GameObject tournamentList;
        
        public void Setup(Tournament[] tournaments)
        {
            foreach (var tournament in tournaments)
            {
                CreateTournamentItem(tournament);
            }
        }

        private void CreateTournamentItem(Tournament tournament)
        {
            var instance = Instantiate(tournamentItemPrefab, tournamentList.transform);
            var view = instance.GetComponent<TournamentItemView>();
            view.Setup(tournament);
        }
    }
}
