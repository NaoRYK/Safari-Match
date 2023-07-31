using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void StartBtnClicked()
    {
        GameManager.Instance.StartGame();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
