using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Piece : MonoBehaviour
{

    public int x;
    public int y;
    public Board board;

    public enum type
    {
        elephant,
        giraffe,
        hippo,
        monkey,
        panda,
        parrot,
        penguin,
        pig,
        rabbit,
        snake
    };

    public type pieceType;
    // Start is called before the first frame update
    public void Setup( int x_, int y_ , Board board_)
    {
        y = y_;
        x = x_; 
        board = board_; 
    }


    public void Move(int desX, int desY)
    {
        transform.DOMove(new Vector3(desX, desY, -5), 0.5f).SetEase(Ease.InOutCubic).onComplete = () =>
        {
            x = desX;
            y = desY;
        };


    }


    [ContextMenu("Mover")]
    public void MoveTest()
    {
        Move(0, 0);
    }
}
