using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    
    public static GameManager Instance { get; private set; }

    public enum GameState
    {
        COUNTDOWN,
        PLAYING,
        GAMEEND,
        SCORE,
        PAUSE
    }

    private GameState gameState;

    void Awake()
    {
        Instance = this;

        gameState = GameState.COUNTDOWN;
    }
    
	// Use this for initialization
	void Start () {
        StartPlaying();
	}

    public void StartPlaying()
    {
        gameState = GameState.PLAYING;
        BoardManager.Instance.GenerateIndexBoard();
        BoardManager.Instance.ConvertIndexBoardToBoard();
    }
	
    public void ChangeBoard()
    {
        BoardManager.Instance.GenerateIndexBoard();
        BoardManager.Instance.ConvertIndexBoardToBoard();
    }
}
