using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;

public class AnalyticsManager : MonoBehaviour
{
    public static AnalyticsManager Instance;
    private bool _isInitialized = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    private async void Start()
    {
        await UnityServices.InitializeAsync();
        AnalyticsService.Instance.StartDataCollection();
        _isInitialized = true;
    }

    public void LevelDone(int currentLevel)
    {
        if (!_isInitialized)
        {
            return;
        }
        CustomEvent myEvent = new CustomEvent("next_level")
        {
            {"level_index", currentLevel }
        };
        AnalyticsService.Instance.RecordEvent(myEvent);
        AnalyticsService.Instance.Flush();
        Debug.Log("level_done");
    }

    public void GoToMenu()
    {
        AnalyticsService.Instance.RecordEvent("in_menu_scene");
        AnalyticsService.Instance.Flush();
        Debug.Log("in_menu_scene");
    }
}
