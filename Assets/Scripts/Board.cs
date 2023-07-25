using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{

    [SerializeField] private int height;
    [SerializeField] private int width;
    [SerializeField] private GameObject tileObject;


    public float cameraSizeOffset;
    public float cameraVerticalOffset;


    // Start is called before the first 
    
    void Start()
    {
        setupBoard();
        PositiconCamera();
    }

    private void PositiconCamera()
    {
        float newPosX = (float)width / 2f;
        float newPosY = (float)height / 2f;

        Camera.main.transform.position = new Vector3 (newPosX -0.5f, newPosY -0.5f + cameraVerticalOffset , -10f);

        float horizontal = width +1;
        float vertical = (height/2) +1 ;


        Camera.main.orthographicSize = horizontal > vertical ? horizontal + cameraSizeOffset : vertical + cameraSizeOffset;

    }

    private void setupBoard()
    {
        for(int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var o = Instantiate(tileObject,new Vector3(x,y,-5),Quaternion.identity);
                o.transform.parent = transform;

                o.GetComponent<Tile>()?.Setup(x, y, this);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
