using UnityEngine;
using System.Collections;

public class Board {

    private GameObject boardGameObject;
    public Jewel[,] board { get; private set; }

    public Board(int width, int height)
    {
        board = new Jewel[width, height];
    }

    public void CreateGameObject()
    {
        boardGameObject = PrefabsHolder.Instance.CreateBoard();
    }

    public bool HasJewel(int x, int y)
    {
        return x >= 0 && x < board.GetLength(0) && y >= 0 && y < board.GetLength(1) && board[x, y] != null;
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
        CreateGameObject();
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[i, j] != null)
                {
                    float x;
                    float y;
                    GetPositionFromIndex(i, j, out x, out y);
                    board[i, j].InitiateRender(x, y);
                    board[i, j].Appear();
                    board[i, j].GetRender<JewelRender>().gameObject.transform.parent = boardGameObject.transform;
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
        Leave();
    }

    private void GetPositionFromIndex(int i, int j, out float x, out float y)
    {
        x = i - board.GetLength(0) / 2 + boardGameObject.transform.position.x;
        y = j - board.GetLength(1) / 2 + boardGameObject.transform.position.y;
    }
}
