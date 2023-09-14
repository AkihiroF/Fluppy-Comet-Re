using UI;
using UnityEngine;
using VContainer;

namespace Core.StatesGame
{
    public class RunningState : IStateGame
    {
        private UIPreviewer _previewer;
        
        [Inject]
        public RunningState(UIPreviewer previewer)
        {
            _previewer = previewer;
        }

        public void Enter()
        {
            Time.timeScale = 1;
            _previewer.HideStartingText();
        }
    }
}