using UnityEngine;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour {
    
    public static BoardManager Instance { get; private set; }

    private Board board;
    private Board oldBoard;
    private string[,] oldIndexBoard;
    private string[,] indexBoard; 
    public int boardWidth;
    public int boardHeight;
    public int jewelAmount;

    void Awake()
    {
        Instance = this;

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
        randomHolder.AddChance("2", 2);
        randomHolder.AddChance("3", 13);
        randomHolder.AddChance("4", 50);
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
                Jewel newJewel = JewelConverter.GetJewelFromIndex(indexBoard[i, j]);
                newJewel.InitiateLogic(i, j);
                tempBoard.SetJewel(i, j, newJewel);
            }
        }
        if (oldBoard != null)
            oldBoard.Leave();
        oldBoard = board;
        board = tempBoard;
        board.Enter();
    }

    public bool HasPairLeft()
    {
        for(int i = 0; i < board.board.GetLength(0); i++)
        {
            for(int j = 0; j < board.board.GetLength(1); j++)
            {
                if (!board.HasJewel(i, j))
                    continue;
                Jewel jewel = board.GetJewel(i, j);
                if(jewel is NormalJewel)
                {
                    NormalJewel normalJewel = jewel as NormalJewel;
                    if (normalJewel.GetLogic<NormalJewelLogic>().IsBlock) continue;
                    int jewelType = normalJewel.GetJewelIndex();
                    int countSameColor = CountAroundEqual(i, j, jewelType);
                    if (countSameColor >= 2)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public int CountAroundEqual(int x, int y, int jewelType)
    {
        int co = 0;
        int[,] direction = { { -1, -1 }, { -1, 0 }, { -1, 1 }, { 0, -1 }, { 0, 1 }, { 1, -1 }, { 1, 0 }, { 1, 1 } };
        for(int i = 0; i < direction.GetLength(0); i++)
        {
            int dx = direction[i, 0];
            int dy = direction[i, 1];
            if(IsTypeEqual(x + dx, y + dy, jewelType))
            {
                co++;
            }
        }
        return co;
    }

    private bool IsTypeEqual(int x, int y, int jewelType)
    {
        if (!board.HasJewel(x, y))
            return false;
        Jewel jewel = board.GetJewel(x, y);
        if (!(jewel is NormalJewel))
            return false;
        NormalJewel normalJewel = jewel as NormalJewel;
        if (normalJewel.GetLogic<JewelLogic>().IsBlock)
            return false;
        return jewelType == normalJewel.GetJewelIndex();
    }

    public int CheckCountAroundOfAround(int x, int y, int jewelType)
    {
        int maxCount = 0;
        int co = 0;
        for(int i = -1; i <= 1; i++)
        {
            for(int j = -1; j <= 1; j++)
            {
                int x1 = x + i;
                int y1 = y + j;
                if (!board.HasJewel(x1, y1))
                    continue;
                Jewel jewel = board.GetJewel(x1, y1);
                if(jewel is NormalJewel)
                {
                    NormalJewel normalJewel = jewel as NormalJewel;
                    if(normalJewel.GetJewelIndex() == jewelType)
                    {
                        co = CountAroundEqual(x1, y1, jewelType);
                        if (co > maxCount)
                            maxCount = co;
                    }
                }
            }
        }
        return maxCount;
    }
}
