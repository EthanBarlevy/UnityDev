using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : Singleton<UiManager>
{
	[SerializeField] private TMP_Text scoreUI;
	[SerializeField] private GameObject gameOverUI;
	[SerializeField] private GameObject titleUI;
	[SerializeField] private GameObject gameWinUI;
	[SerializeField] private Slider healthMeter;

	public void ShowTitle(bool show)
	{ 
		titleUI.SetActive(show);
	}

	public void ShowGameOver(bool show)
	{
		gameOverUI.SetActive(show);
	}

	public void setHealth(int health)
	{
		healthMeter.value = Mathf.Clamp(health, 0, 100);
	}

	public void setScore(int score)
	{
		scoreUI.text = score.ToString();
	}
}
