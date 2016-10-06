﻿using UnityEngine;
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

            }
        }
        return false;
    }

    public void CountAroundEqual(int x, int y, int jewelIndex)
    {

    }
}
