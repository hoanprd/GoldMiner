using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    public GameObject[] prefabToSpawn;  // Tham chiếu đến prefab cần sinh ra
    public Transform parentObject;    // Tham chiếu đến đối tượng cha

    // Start is called before the first frame update
    void Start()
    {
        int[] uniqueNumbers = new int[3]; // Mảng chứa 3 số ngẫu nhiên
        int count = 0;

        while (count < 3)
        {
            int randomNumber = Random.Range(0, 6); // Random từ 0 đến 5

            // Kiểm tra xem số đã tồn tại trong mảng chưa
            bool isUnique = true;
            for (int i = 0; i < count; i++)
            {
                if (uniqueNumbers[i] == randomNumber)
                {
                    isUnique = false;
                    break;
                }
            }

            // Nếu số là duy nhất, thêm vào mảng
            if (isUnique)
            {
                uniqueNumbers[count] = randomNumber;
                Instantiate(prefabToSpawn[randomNumber], parentObject);
                count++;
            }
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("LevelScene");
    }
}
