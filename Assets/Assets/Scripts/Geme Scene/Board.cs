using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour {

    private GameObject boardGameObject;
    private Jewel[,] board;

    public Board(int width, int height)
    {
        board = new Jewel[width, height];
    }

    public void CreateGameObject()
    {
        GameObject boardPrefab = PrefabsHolder.Instance.GetBoardPrefab();
        boardGameObject = Instantiate(boardPrefab);
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

    private void GetPositionFromIndex(int i, int j, out float x, out float y)
    {
        x = i - board.GetLength(0) / 2 + boardGameObject.transform.position.x;
        y = j - board.GetLength(1) / 2 + boardGameObject.transform.position.y;
    }
}
