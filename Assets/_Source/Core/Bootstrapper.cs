using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Source.Core
{
    public class Bootstrapper : MonoBehaviour, IStartable
    {
        private StateMachine _stateMachine;

        [Inject]
        private void Construct(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Start()
        {
            _stateMachine.StartGame();
        }
    }
}
