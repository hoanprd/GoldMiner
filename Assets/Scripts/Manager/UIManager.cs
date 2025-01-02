﻿using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    LevelManager lvManager;

    public Text scoreText;  // Hiển thị điểm số
    public Text timeText;   // Hiển thị thời gian còn lại
    public Text levelText;
    public Text targetText;
    public GameObject bombUI;
    public Text bombAmongText;

    public float timeLimit;  // Thời gian tối đa (giây)
    private float remainingTime;   // Thời gian còn lại

    private void Start()
    {
        lvManager = FindObjectOfType<LevelManager>();

        if (PlayerPrefs.GetInt("BuySandClock") == 1)
        {
            timeLimit += GameManager.Instance.clockSandTime;
        }
        remainingTime = timeLimit;  // Đặt thời gian ban đầu
        levelText.text = "Level " + (PlayerPrefs.GetInt("Level") + 1).ToString();
        targetText.text = "$" + lvManager.levelTarget[PlayerPrefs.GetInt("Level")];
        UpdateScoreText(GameManager.Instance.GetScore()); // Cập nhật điểm khi bắt đầu
    }

    private void Update()
    {
        // Kiểm tra nếu thời gian còn lại > 0
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime; // Giảm thời gian còn lại mỗi frame
            UpdateTimeText(); // Cập nhật hiển thị thời gian
            if (PlayerPrefs.GetInt("BuyBomb") > 0)
            {
                bombUI.SetActive(true);
                bombAmongText.text = PlayerPrefs.GetInt("BuyBomb").ToString();
            }
            else
            {
                bombUI.SetActive(false);
            }
        }
        else
        {
            // Khi hết thời gian, gọi GameOver trong GameManager
            if (!GameManager.Instance.IsGameOver)
            {
                GameManager.Instance.GameOver(); // Kết thúc trò chơi
            }
        }
    }

    // Cập nhật thời gian hiển thị trên UI
    private void UpdateTimeText()
    {
        timeText.text = Mathf.Max(0, Mathf.FloorToInt(remainingTime)).ToString();
    }

    // Cập nhật điểm số hiển thị trên UI
    public void UpdateScoreText(int newScore)
    {
        if (scoreText != null)
        {
            Debug.Log("Check");
            scoreText.text = "$ " + newScore.ToString();
        }
        else
        {
            Debug.LogWarning("ScoreText chưa được gán trong UIManager.");
        }
    }
}
