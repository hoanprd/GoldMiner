using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public enum TreasureType
{
    Gold1,
    Gold2,
    Gold3,
    RatGold,
    Diamond,
    LuckyPack,
    TNT,
    Rock1,
    Rock2,
    Rock3
}

public class TreasureConfig : MonoBehaviour
{
    public GameObject[] prefabTreasure;
    public Transform parent;
    public TreasureType treasureType;

    private int treasureIndex;

#if UNITY_EDITOR
    [Button(Name = "Build treasure")]
    private void BuildMapTreasure()
    {
        switch (treasureType)
        {
            case TreasureType.Gold1:
                treasureIndex = 0;
                break;
            case TreasureType.Gold2:
                treasureIndex = 1;
                break;
            case TreasureType.Gold3:
                treasureIndex = 2;
                break;
            case TreasureType.RatGold:
                treasureIndex = 3;
                break;
            case TreasureType.Diamond:
                treasureIndex = 4;
                break;
            case TreasureType.LuckyPack:
                treasureIndex = 5;
                break;
            case TreasureType.TNT:
                treasureIndex = 6;
                break;
            case TreasureType.Rock1:
                treasureIndex = 7;
                break;
            case TreasureType.Rock2:
                treasureIndex = 8;
                break;
            case TreasureType.Rock3:
                treasureIndex = 9;
                break;
        }

        Instantiate(prefabTreasure[treasureIndex], parent);
    }
#endif
}
