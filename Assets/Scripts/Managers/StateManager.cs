using System;
using UnityEngine;

namespace Managers
{
    public class StateManager : MonoBehaviour
    {
        #region Singleton
        public static StateManager Instance;

        private void Awake()
        {
            Instance = this;
        }
        #endregion

        public static Action<GameState> onGameStateChanged;
        
        public GameState gameState;

        private void Start()
        {
            UpdateGameState(GameState.WaitForCustomer);
        }

        public void UpdateGameState(GameState newState)
        {
            gameState = newState;

            switch (newState)
            {
                case GameState.WaitForCustomer:
                    //input blocker
                    break;
                case GameState.ServeCustomer:
                    break;
                case GameState.EndOfTheDay:
                    break;
                case GameState.Lose:
                    HandleLose();
                    break;
                case GameState.Victory:
                    HandleVictory();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
            }

            onGameStateChanged?.Invoke(newState);
        }

        private void HandleVictory()
        {
            throw new NotImplementedException();
        }

        private void HandleLose()
        {
            throw new NotImplementedException();
        }
    }

    public enum GameState
    {
        WaitForCustomer,
        ServeCustomer,
        EndOfTheDay,
        Lose,
        Victory
    }
}