using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public enum MapBackgroundType
{
    Island,
    Sea
}

public class MapConfig : MonoBehaviour
{
    public GameObject[] prefabBackgroundTop;
    public GameObject[] prefabBackgroundBottom;
    public Transform parent;
    public MapBackgroundType mapType;

    private int backgroundIndex;

#if UNITY_EDITOR
    [Button(Name = "Build bottom map background")]
    private void BuildMapBackground()
    {
        switch (mapType)
        {
            case MapBackgroundType.Island:
                backgroundIndex = 0;
                break;
            case MapBackgroundType.Sea:
                backgroundIndex = 1;
                break;
        }

        Instantiate(prefabBackgroundTop[backgroundIndex], parent);
        Instantiate(prefabBackgroundBottom[backgroundIndex], parent);
    }
#endif
}
