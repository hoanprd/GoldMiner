using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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