using UnityEngine;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour {

    private BoardManager _instance;
    public BoardManager Instance { get { return _instance; } }

    private Board board;
    private Board oldBoard;
    private string[,] oldIndexBoard;
    private string[,] indexBoard; 
    public int boardWidth;
    public int boardHeight;
    public int jewelAmount;

    void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }

        Initiate();
    }

    public void Initiate()
    {
        if(board == null)
        {
            board = new Board(boardWidth, boardHeight);
            indexBoard = new string[boardWidth, boardHeight];
            oldBoard = null;
        }
    }

    public void GenerateIndexBoard()
    {
        string[,] boardTemp;

        RandomHolder randomHolder = new RandomHolder();
        randomHolder.AddChance("2", 5);
        randomHolder.AddChance("3", 20);
        randomHolder.AddChance("4", 30);
        randomHolder.AddChance("5", 30);
        string randomName = randomHolder.GetRandom();
        switch(randomName)
        {
            case "2":
                boardTemp = GenerateNormalPattern(2);
                break;
            case "3":
                boardTemp = GenerateNormalPattern(3);
                break;
            case "4":
                boardTemp = GenerateNormalPattern(4);
                break;
            case "5":
                boardTemp = GenerateNormalPattern(5);
                break;
            default:
                boardTemp = GenerateNormalPattern(4);
                break;
        }
        oldIndexBoard = indexBoard;
        indexBoard = boardTemp;
    }

    public string[,] GenerateNormalPattern(int numJewel)
    {
        List<int> jewelIndex = RandomManager.GetShufflingIntList(jewelAmount);
        RandomHolder randomHolder = new RandomHolder();
        //randomHolder.AddChance("Touch", 0.01f);

        string[,] boardTemp = new string[boardWidth, boardHeight];
        for(int i = 0; i < boardWidth; i++)
        {
            for(int j = 0; j < boardHeight; j++)
            {
                boardTemp[i, j] = GetGeneratedJewel(jewelIndex, numJewel, randomHolder);
            }
        }
        return boardTemp;
    }

    public string GetGeneratedJewel(List<int> jewelIndex, int numJewel, RandomHolder randomHolder)
    {
        string randomName = randomHolder.GetRandom();
        if(randomName == "ETC")
        {
            return GetGenerateNormalJewel(jewelIndex, numJewel);
        }
        return randomName;
    }

    public string GetGenerateNormalJewel(List<int> jewelIndex, int numJewel)
    {
        int randomIndex = Random.Range(0, numJewel);
        return jewelIndex[randomIndex] + "";
    }

    public void ConvertIndexBoardToBoard()
    {
        if(indexBoard == null)
        {
            Debug.Log("Index Board is empty");
        }

        Board tempBoard = new Board(boardWidth, boardHeight);
        for (int i = 0; i < indexBoard.GetLength(0); i++)
        {
            for (int j = 0; j < indexBoard.GetLength(1); j++)
            {
                tempBoard.SetJewel(i, j, JewelConverter.GetJewelFromIndex(indexBoard[i, j]));
            }
        }
        if (oldBoard != null)
            oldBoard.Leave();
        oldBoard = board;
        board = tempBoard;
        board.Enter();
    }
}
