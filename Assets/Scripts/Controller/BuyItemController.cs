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

    public void BuyPower()
    {
        PlayerPrefs.SetInt("BuyPower", 1);
    }

    public void BuyDiamondValue()
    {
        PlayerPrefs.SetInt("BuyDiamondValue", 1);
    }

    public void BuyLuckyUp()
    {
        PlayerPrefs.SetInt("BuyDiamondValue", 1);
    }

    public void BuyRockValue()
    {
        PlayerPrefs.SetInt("BuyRockValue", 1);
    }
}
