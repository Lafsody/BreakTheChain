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
        BoardManager.Instance.GenerateIndexBoard();
        BoardManager.Instance.ConvertIndexBoardToBoard();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
