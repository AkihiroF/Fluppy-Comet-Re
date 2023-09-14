using UI;
using Zenject;

namespace _Source.Player
{
    public class ScoreDataBase
    {
        private int _countCoin;
        private UIPreviewer _uiPreviewer;

        [Inject]
        public ScoreDataBase(UIPreviewer previewer)
        {
            _uiPreviewer = previewer;
            UpdateUI();
        }

        public void AddCoin()
        {
            _countCoin++;
            UpdateUI();
        }

        private void UpdateUI() => _uiPreviewer.UpdateCoinText(_countCoin);
    }
}