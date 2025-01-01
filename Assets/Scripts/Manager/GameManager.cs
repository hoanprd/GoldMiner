using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int score;
    public bool IsGameOver { get; private set; } // Kiểm tra trạng thái game over

    public UIManager uiManager; // Tham chiếu đến UIManager
    public LevelManager lvManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Đảm bảo GameManager không bị hủy khi cảnh thay đổi
        }
        else
        {
            Destroy(gameObject); // Nếu có một instance khác, hủy object này
        }
    }

    public void AddScore(int points)
    {
        if (!IsGameOver) // Chỉ cộng điểm nếu chưa game over
        {
            score += points;
            uiManager.UpdateScoreText(score); // Cập nhật UI sau khi cộng điểm
            if (GetScore() >= lvManager.levelTarget[lvManager.levelIndex])
            {
                LevelPass(lvManager.levelIndex);
            }
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void GameOver()
    {
        IsGameOver = true; // Đánh dấu trò chơi kết thúc
        Debug.Log("Game Over!");

        // Thực hiện các hành động khác khi game over, ví dụ: chuyển đến màn hình game over
        // UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene");
    }

    public void LevelPass(int levelIndex)
    {
        PlayerPrefs.SetInt("Level", levelIndex + 1);
        SceneManager.LoadScene("ShopScene");
    }
}
