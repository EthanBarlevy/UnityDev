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

    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform playerStart;

    public void Start()
    {
        Instantiate(playerPrefab, playerStart.position, playerStart.rotation);
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
        gameOverUI.SetActive(true);
    }
}
