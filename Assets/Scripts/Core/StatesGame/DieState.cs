using DG.Tweening;
using UnityEngine.SceneManagement;

namespace Core.StatesGame
{
    public class DieState : IStateGame
    {
        public void Enter()
        {
            DOTween.KillAll();
            ReloadCurrentScene();
        }
        
        private void ReloadCurrentScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}