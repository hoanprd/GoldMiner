using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItemController : MonoBehaviour
{
    public void BuySandClock()
    {
        PlayerPrefs.SetInt("BuySandClock", 1);
    }

    public void BuyBomb()
    {
        PlayerPrefs.SetInt("BuyBomb", 1);
    }
}
