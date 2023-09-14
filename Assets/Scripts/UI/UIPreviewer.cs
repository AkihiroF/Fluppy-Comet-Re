using TMPro;
using UnityEngine;

namespace UI
{
    public class UIPreviewer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private CanvasGroup startText;

        public void UpdateCoinText(int countCoin)
        {
            scoreText.text = $"{countCoin}";
        }

        public void HideStartingText()
        {
            startText.alpha = 0;
        }
    }
}