using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RollerGameManager : Singleton<RollerGameManager>
{
    [SerializeField] private Slider healthMeter;
    [SerializeField] private TMP_Text scoreUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject titleUI;

    [SerializeField] private AudioSource gameMusic;
    [SerializeField] public Transform playerStartGame;

    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private int maxLives;
    private int lives;

    public enum State
    { 
        TITLE,
        START_GAME,
        PLAY_GAME,
        RESET_PLAYER,
        GAME_OVER
    }

    State state = State.TITLE;
    float stateTimer = 0;

    public void Start()
    {
    }

	private void Update()
	{
		switch (state)
        {
            case State.TITLE:
                titleUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            case State.START_GAME:
                titleUI.SetActive(false);
				Cursor.lockState = CursorLockMode.Locked;
                GetComponent<Checkpoint>().StartLocation = playerStartGame;
                Instantiate(playerPrefab, GetComponent<Checkpoint>().StartLocation.position, GetComponent<Checkpoint>().StartLocation.rotation);
                lives = maxLives;
                state = State.PLAY_GAME;
				break;
            case State.PLAY_GAME:
                //
                break;
            case State.RESET_PLAYER:
                Cursor.lockState = CursorLockMode.Locked;
                Instantiate(playerPrefab, GetComponent<Checkpoint>().StartLocation.position, GetComponent<Checkpoint>().StartLocation.rotation);
                state = State.PLAY_GAME;
                break;
            case State.GAME_OVER:
				gameOverUI.SetActive(true);
                stateTimer -= Time.deltaTime;
                if (stateTimer < 0)
                { 
                    gameOverUI.SetActive(false);
                    state = State.TITLE;
                }
				break;
            default:
                break;

        }
	}

	public void setHealth(int health)
    { 
        healthMeter.value = Mathf.Clamp(health, 0, 100);
    }

    public void setScore(int score)
    {
        scoreUI.text = score.ToString();
    }

    public void SetGameOver()
    {
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
            FindObjectOfType<Lives>().OnLifeLost(lives);
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
}
