using Core;
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

        private int countCoin = -1;

        private void Awake()
        {
            Signals.Get<OnGetCoin>().AddListener(AddCoin);
            Signals.Get<OnDie>().AddListener(Unsubscribe);
            Signals.Get<OnStartGame>().AddListener(HideStartingText);
        }

        private void Unsubscribe()
        {
            Signals.Get<OnGetCoin>().RemoveListener(AddCoin);
            Signals.Get<OnDie>().RemoveListener(Unsubscribe);
            Signals.Get<OnStartGame>().RemoveListener(HideStartingText);
        }

        private void Start()
        {
            AddCoin();
        }

        private void AddCoin()
        {
            countCoin++;
            scoreText.text = $"{countCoin}";
        }

        private void HideStartingText()
        {
            startText.alpha = 0;
        }
    }
}