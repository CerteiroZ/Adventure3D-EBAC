using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

namespace Ebac.StateMachine
{
    public enum PlayerState
    {
        RUN,
        IDLE,
        JUMP
    }

    public class StateMachine<T> where T : System.Enum
    {
        public Dictionary<T, StateBase> dictionaryState;

        public float timeToStartGame = 1f;

        private StateBase _currentState;

        public StateBase CurrentState
        {
            get { return _currentState; }
        }

        public void Init()
        {
            dictionaryState = new Dictionary<T, StateBase>();
        }

        public void RegisterStates(T typeEnum, StateBase state)
        {
            dictionaryState.Add(typeEnum, state);
        }

        public void SwitchState(T state, params object[] objs)
        {
            if (_currentState != null) _currentState.OnStateExit();

            _currentState = dictionaryState[state];

            _currentState.OnStateEnter(objs);
        }

        public void Update()

        {
            if (_currentState != null) _currentState.OnStateStay();
        }
    }
}
