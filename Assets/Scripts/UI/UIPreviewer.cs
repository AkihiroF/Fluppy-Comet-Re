using deVoid.Utils;
using Events;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UIPreviewer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private CanvasGroup startText;

        private void Awake()
        {
            Signals.Get<OnDie>().AddListener(Unsubscribe);
            Signals.Get<OnStartGame>().AddListener(HideStartingText);
        }

        private void Unsubscribe()
        {
            Signals.Get<OnDie>().RemoveListener(Unsubscribe);
            Signals.Get<OnStartGame>().RemoveListener(HideStartingText);
        }

        public void UpdateCoinText(int countCoin)
        {
            scoreText.text = $"{countCoin}";
        }

        private void HideStartingText()
        {
            startText.alpha = 0;
        }
    }
}