using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private AudioSource gameMusic;
    [SerializeField] public Transform playerStartGame;

    [Header("Events")]
    [SerializeField] EventRouter GameWinEvent;
    [SerializeField] EventRouter GameStartEvent;
    [SerializeField] EventRouter GameEndEvent;

    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private int maxLives;
    private int lives;

    public enum State
    { 
        TITLE,
        START_GAME,
        PLAY_GAME,
        RESET_PLAYER,
        GAME_WIN,
        GAME_OVER
    }

    State state = State.TITLE;
    float stateTimer = 0;

    public void Start()
    {
        GameWinEvent.onEvent += SetGameWin;
    }

	private void Update()
	{
		switch (state)
        {
            case State.TITLE:
				UiManager.Instance.ShowTitle(true);
				Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            case State.START_GAME:
				UiManager.Instance.ShowGameOver(false);
				Cursor.lockState = CursorLockMode.Locked;
                //GetComponent<Checkpoint>().StartLocation = playerStartGame;
                //Instantiate(playerPrefab, GetComponent<Checkpoint>().StartLocation.position, GetComponent<Checkpoint>().StartLocation.rotation);
                Instantiate(playerPrefab, playerStartGame);
                lives = maxLives;
                //FindObjectOfType<Lives>().OnLifeLost(lives);
                state = State.PLAY_GAME;
				break;
            case State.PLAY_GAME:
                //
                break;
            case State.RESET_PLAYER:
                Cursor.lockState = CursorLockMode.Locked;
                Instantiate(playerPrefab, GetComponent<Checkpoint>().StartLocation.position, GetComponent<Checkpoint>().StartLocation.rotation);
                //FindObjectOfType<Lives>().OnLifeLost(lives);
                state = State.PLAY_GAME;
                break;
            case State.GAME_OVER:
				UiManager.Instance.ShowGameOver(true);
				stateTimer -= Time.deltaTime;
                if (stateTimer < 0)
                {
					UiManager.Instance.ShowGameOver(false);
					state = State.TITLE;
                }
				break;
            case State.GAME_WIN:
                //gameWinUI.SetActive(true);
                stateTimer -= Time.deltaTime;
                if (stateTimer < 0)
                {
                    //gameWinUI.SetActive(false);
                    state = State.TITLE;
                }
                break;
            default:
                break;

        }
	}

    public void SetGameOver()
    {
        UiManager.Instance.ShowGameOver(true);
        gameMusic.Stop();
        state = State.GAME_OVER;
        stateTimer = 3;
    }

    public void SetResetPlayer()
    {
        if (lives > 0)
        {
            state = State.RESET_PLAYER;
            lives--;
        }
        else
        {
            SetGameOver();
        }
    }

    public void onStartGame()
    {
		gameMusic.Play();
		state = State.START_GAME;
    }

    public void SetGameWin()
    {
        stateTimer = 3;
        gameMusic.Stop();
        state = State.GAME_WIN;
    }
}
