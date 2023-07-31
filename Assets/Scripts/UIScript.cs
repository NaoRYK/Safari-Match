using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIScript : MonoBehaviour
{

    public RectTransform containerRect;
    public CanvasGroup contianerCanvas;
    public Image background;
    public GameManager.GameState visibleState;
    public float transitionTime;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnGameStateUpdate.AddListener(GameStateUpdated);
        bool initialState = GameManager.Instance.gameState == visibleState;
        background.enabled = initialState;
        containerRect.gameObject.SetActive(initialState);
    }

    private void GameStateUpdated(GameManager.GameState newState)
    {
        if(newState == visibleState)
        {
            ShowScreen();
        }
        else
        {
            HideScreen();
        }
    }

    private void HideScreen()
    {
        //bg anim

        var bgcolor = background.color;
        bgcolor.a = 0;
        background.DOColor(bgcolor, transitionTime * 0.5f);

        //container anim

        contianerCanvas.alpha = 1;
        containerRect.anchoredPosition = Vector2.zero;
        contianerCanvas.DOFade(0f, transitionTime *0.5f);
        containerRect.DOAnchorPos(new Vector2(0, -100),transitionTime * 0.5f).onComplete = () =>
        {
            background.enabled = false;
            containerRect.gameObject.SetActive(false);
        };

    }

    private void ShowScreen()
    {
        //Enable elements
        background.enabled = true;
        containerRect.gameObject.SetActive(true);
        //bg anim

        var bgColor = background.color;
        bgColor.a = 0;
        background.color = bgColor;
        bgColor.a = 1;
        background.DOColor(bgColor, transitionTime);

        //container animation

        contianerCanvas.alpha = 0;
        containerRect.anchoredPosition = new Vector2(0, 100);
        contianerCanvas.DOFade(1f, transitionTime);
        containerRect.DOAnchorPos(Vector2.zero, transitionTime);

    }

    

    // Update is called once per frame
   
}
