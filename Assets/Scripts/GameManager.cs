using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float timeToMatch = 10f;
    public float currentTimeToMatch = 0;

    public enum GameState
    {
        Idle,
        InGame,
        GameOver
    }

    public GameState gameState;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    public int points = 0;


    public UnityEvent OnPointsUpdate;
    public UnityEvent<GameState> OnGameStateUpdate;


    public void AddPoints(int newPoints)
    {
        points += newPoints;
        OnPointsUpdate?.Invoke();
        currentTimeToMatch = 0;
    }



    private void Update()
    {
        if(gameState == GameState.InGame)
        {
            currentTimeToMatch += Time.deltaTime;
            if(currentTimeToMatch > timeToMatch)
            {
                gameState = GameState.GameOver;
                OnGameStateUpdate?.Invoke(gameState);

            }
        }
    }

    public void RestartGame()
    {
        points = 0;

        gameState = GameState.InGame;

        OnGameStateUpdate?.Invoke(gameState);
        currentTimeToMatch = 0F;
    }

    public void ExitGame()
    {
        gameState = GameState.Idle;
        points = 0;
        OnGameStateUpdate?.Invoke(gameState);
    }
    public void StartGame()
    {
        points = 0;
        gameState = GameState.InGame;
        OnGameStateUpdate?.Invoke(gameState);
        currentTimeToMatch = 0;
    }
}
