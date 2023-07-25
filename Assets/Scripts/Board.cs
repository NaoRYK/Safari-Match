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

    public GameObject[] availablePieces;

    Tile startTile,endTile;
    


    Tile[,] Tiles;

    Piece[,] Pieces;
    
    void Start()
    {

        Tiles = new Tile[width,height];
        Pieces = new Piece[width,height];
        setupBoard();
        PositiconCamera();
        SetupPieces();
    }

    private void SetupPieces()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {

                var selectedPiece = availablePieces[UnityEngine.Random.Range(0, availablePieces.Length)];
                var o = Instantiate(selectedPiece, new Vector3(x, y, -5), Quaternion.identity);
                o.transform.parent = transform;

                Pieces[x, y] = o.GetComponent<Piece>();
                Pieces[x,y]?.Setup(x, y, this);

            }
        }
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

                Tiles[x, y] = o.GetComponent<Tile>();

                Tiles[x,y]?.Setup(x, y, this);
            }
        }
    }
    

    public void TileDown(Tile tile_)
    {
        startTile = tile_;
    }
    public void TileOver(Tile tile_)
    {
        endTile = tile_;
    }
    public void TileUp(Tile tile_)
    {
        if (startTile != null && endTile!= null)
        {
            swapTiles();
        }
        startTile = null; 
        endTile = null;
    }

    private void swapTiles()
    {
        var StartPiece = Pieces[startTile.x,startTile.y];
        var EndPiece = Pieces[endTile.x,endTile.y];

        StartPiece.Move(endTile.x, endTile.y);
        EndPiece.Move(startTile.x, startTile.y);

        Pieces[startTile.x, startTile.y] = EndPiece;
        Pieces[endTile.x,endTile.y] = StartPiece;
    }
}
