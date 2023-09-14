using System;
using System.Collections.Generic;
using Core.StatesGame;
using deVoid.Utils;
using Events;
using VContainer;

namespace Core
{
    public class Game
    {
        private Dictionary<Type, IStateGame> _states;

        [Inject]
        public Game(IEnumerable<IStateGame> stateGames)
        {
            _states = new Dictionary<Type, IStateGame>();
            foreach (var state in stateGames)
            {
                _states.Add(state.GetType(), state);
            }
        }

        private void SwitchStateGame(Type state)
        {
            if (_states.ContainsKey(state))
            {
                if(state == typeof(DieState))
                    UnsubscribeFromEvents();
                _states[state].Enter();
            }
        }

        private void SubscribeToEvents()
        {
            Signals.Get<OnSwitchStateGame>().AddListener(SwitchStateGame);
        }

        private void UnsubscribeFromEvents()
        {
            Signals.Get<OnSwitchStateGame>().RemoveListener(SwitchStateGame);
        }

        public void StartGame()
        {
            SubscribeToEvents();
            SwitchStateGame(typeof(InitialiseState));
        }
    }
}
