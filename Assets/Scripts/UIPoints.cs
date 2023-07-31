using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIPoints : MonoBehaviour
{

    int displayedPoints;

    public TextMeshProUGUI pointsLabel;
    // Start is called before the first frame update
    void Start()
    {
        displayedPoints = 0;
        GameManager.Instance.OnPointsUpdate.AddListener(UpdatePoints);
        GameManager.Instance.OnGameStateUpdate.AddListener(GameStateUpdated);
    }
    private void OnDestroy()
    {
        GameManager.Instance.OnPointsUpdate.RemoveListener(UpdatePoints);
        GameManager.Instance.OnGameStateUpdate.RemoveListener(GameStateUpdated);
    }

    private void GameStateUpdated(GameManager.GameState newState)
    {
       if(newState == GameManager.GameState.GameOver)
        {
            displayedPoints = 0;
            pointsLabel.text = displayedPoints.ToString();
        }
    }

    private void UpdatePoints()
    {
        StartCoroutine(UpdatePointsCoroutine());
    }

     IEnumerator UpdatePointsCoroutine()
    {
        while(displayedPoints < GameManager.Instance.points)
        {
            displayedPoints++; 
            pointsLabel.text = displayedPoints.ToString();
            yield return new WaitForSeconds(0.1f);
        }

        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
