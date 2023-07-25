using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
