using System;
using Application.Scripts.Infrastructure;
using UniRx;
using UnityEngine;

namespace Application.Scripts.UnityDelivery
{
    public class Application : MonoBehaviour
    {
        [SerializeField] private TournamentBoardView boardView;
        [SerializeField] private ErrorPopup errorPopup;
        [SerializeField] private GameObject loadingText;

        private IDisposable _fetchTournamentsDisposable;
        public void Start()
        {
            SetupErrorPopup();
            FetchTournaments();
        }

        private void SetupErrorPopup()
        {
            errorPopup.OnPopupClosed()
                .Do(_ => CloseErrorPopup())
                .Do(_ => FetchTournaments())
                .Subscribe();
        }

        private void FetchTournaments()
        {
            ShowLoadingText();
            
            _fetchTournamentsDisposable?.Dispose();
            _fetchTournamentsDisposable = ServiceProvider.GetTournamentList()
                .Execute()
                .Do(boardView.Setup)
                .DoOnError(ShowErrorPopup)
                .CatchIgnore()
                .DoOnTerminate(HideLoadingText)
                .Subscribe();
        }

        private void ShowLoadingText()
        {
            loadingText.gameObject.SetActive(true);
        }

        private void HideLoadingText()
        {
            loadingText.gameObject.SetActive(false);
        }

        private void ShowErrorPopup(Exception exception)
        {
            errorPopup.gameObject.SetActive(true);
            errorPopup.Setup(exception.Message);
        }

        private void CloseErrorPopup()
        {
            errorPopup.gameObject.SetActive(false);
        }
    }
}