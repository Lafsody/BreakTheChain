using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour {

    private Jewel[,] board;

    public Board(int width, int height)
    {
        board = new Jewel[width, height];
    }

    public void SetJewel(int x, int y, Jewel jewel)
    {
        board[x, y] = jewel;
    }

    public Jewel GetJewel(int x, int y)
    {
        return board[x, y];
    }

    public void Enter()
    {
        // TODO loop jewel.GetController().showEnterAnimation
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[i, j] != null)
                {
                    board[i, j].Appear();
                }
            }
        }
    }

    public void Leave()
    {
        // TODO loop jewel.GetController().LeaveAnimation
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if(board[i, j] != null)
                {
                    board[i, j].Disappear();
                }
            }
        }
    }

    public void Clear()
    {
        // TODO loop jewel.clear();
    }
}
