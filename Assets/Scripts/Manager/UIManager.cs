using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;  // Hiển thị điểm số
    public Text timeText;   // Hiển thị thời gian còn lại
    public GameManager gameManager; // Tham chiếu đến GameManager

    public float timeLimit = 60f;  // Thời gian tối đa (giây)
    private float remainingTime;   // Thời gian còn lại

    private void Start()
    {
        remainingTime = timeLimit;  // Đặt thời gian ban đầu
        UpdateScoreText(gameManager.GetScore()); // Cập nhật điểm khi bắt đầu
    }

    private void Update()
    {
        // Kiểm tra nếu thời gian còn lại > 0
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime; // Giảm thời gian còn lại mỗi frame
            UpdateTimeText(); // Cập nhật hiển thị thời gian
        }
        else
        {
            // Khi hết thời gian, gọi GameOver trong GameManager
            if (!gameManager.IsGameOver)
            {
                gameManager.GameOver(); // Kết thúc trò chơi
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
            scoreText.text = "$ " + newScore.ToString();
        }
        else
        {
            Debug.LogWarning("ScoreText chưa được gán trong UIManager.");
        }
    }
}
