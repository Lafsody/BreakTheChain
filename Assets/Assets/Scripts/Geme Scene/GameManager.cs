using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private GameManager _instance;
    public GameManager Instance { get{ return _instance; } }

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
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }

        gameState = GameState.COUNTDOWN;
    }
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
