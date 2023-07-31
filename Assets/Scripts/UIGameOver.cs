using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    public int displayedPoints = 0;
    public TextMeshProUGUI pointsUi;


    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnGameStateUpdate.AddListener(GameStateUpdated);
    }
    private void OnDestroy()
    {
        GameManager.Instance.OnGameStateUpdate.RemoveListener(GameStateUpdated);
    }

    private void GameStateUpdated(GameManager.GameState newState)
    {
        if (newState == GameManager.GameState.GameOver)
        {
            displayedPoints = 0;
            StartCoroutine(DisplayPointsCorutine());
        }
    }

    IEnumerator DisplayPointsCorutine()
    {
        while (displayedPoints < GameManager.Instance.points)
        {
            displayedPoints++;
            pointsUi.text = displayedPoints.ToString();
            yield return new WaitForFixedUpdate();
        }
        displayedPoints = GameManager.Instance.points;
        pointsUi.text = displayedPoints.ToString();
        yield return null;
    }

    public void PlayAgainButtonClicked()
    {
        GameManager.Instance.RestartGame();
    }
    public void ExitButtonClicked()
    {
        GameManager.Instance.ExitGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
