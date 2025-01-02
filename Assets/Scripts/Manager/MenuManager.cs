using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject continueButton;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Level") > 0)
        {
            continueButton.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("Level", 0);
        PlayerPrefs.SetInt("BuySandClock", 0);
        PlayerPrefs.SetInt("BuyPower", 0);
        PlayerPrefs.SetInt("BuyBomb", 0);
        PlayerPrefs.SetInt("BuyLuckyUpValue", 0);
        PlayerPrefs.SetInt("BuyDiamondValue", 0);
        PlayerPrefs.SetInt("BuyRockValue", 0);
        SceneManager.LoadScene("LevelScene");
    }

    public void Continue()
    {
        SceneManager.LoadScene("LevelScene");
    }

    public void Setting()
    {

    }
}
