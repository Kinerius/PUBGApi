using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Application.Scripts.UnityDelivery
{
    public class ErrorPopup : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI errorText;
        [SerializeField] private Button closeButton;

        private readonly Subject<Unit> _onCloseButtonPressed = new Subject<Unit>();
        private IDisposable _disposable;
        
        public void Setup(string message)
        {
            errorText.text = message;
        }

        public IObservable<Unit> OnPopupClosed()
        {
            return _onCloseButtonPressed;
        }

        private void OnEnable()
        {
            _disposable = closeButton.OnClickAsObservable()
                .Do(_ => OnCloseButtonPressed())
                .Subscribe();
        }

        private void OnDisable()
        {
            _disposable?.Dispose();
        }

        private void OnCloseButtonPressed()
        {
            _onCloseButtonPressed.OnNext(Unit.Default);
        }
    }
}