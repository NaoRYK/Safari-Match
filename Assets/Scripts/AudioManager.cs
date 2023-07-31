using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioManager Instance;

    public AudioClip move;
    public AudioClip miss;
    public AudioClip match;
    public AudioClip gameOver;
    public AudioSource SFXsoruce;

    void Awake()
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
    private void Start()
    {
        GameManager.Instance.OnPointsUpdate.AddListener(PointsUpdated);
        GameManager.Instance.OnGameStateUpdate.AddListener(GameStateUpdated);

    }

    private void GameStateUpdated(GameManager.GameState newState)
    {
        if (newState == GameManager.GameState.GameOver)
        {
            SFXsoruce.PlayOneShot(gameOver);
        }
        if (newState == GameManager.GameState.InGame)
        {
            SFXsoruce.PlayOneShot(match);
        }
    }


private void PointsUpdated()
    {
        SFXsoruce.PlayOneShot(match);
    }

    public void Move()
    {
        SFXsoruce.PlayOneShot(move);
    }
    public void Miss()
    {
        SFXsoruce.PlayOneShot(move);
    }
    private void OnDestroy()
    {
        GameManager.Instance.OnPointsUpdate.RemoveListener(PointsUpdated);
        GameManager.Instance.OnGameStateUpdate.RemoveListener(GameStateUpdated);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
