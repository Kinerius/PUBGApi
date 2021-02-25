using Application.Scripts.Model;
using TMPro;
using UnityEngine;

namespace Application.Scripts.UnityDelivery
{
    public class TournamentItemView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI idLabel;
        [SerializeField] private TextMeshProUGUI dateLabel;

        public void Setup(Tournament tournament)
        {
            idLabel.text = tournament.id;
            dateLabel.text = tournament.createdTime.ToString();
        }
    }
}