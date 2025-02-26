using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Extensions;
using System;
using Firebase.Analytics;

public class FirsebaseInit : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                //app = Firebase.FirebaseApp.DefaultInstance;
                Firebase.FirebaseApp app = Firebase.FirebaseApp.DefaultInstance;

                // Set a flag here to indicate whether Firebase is ready to use by your app.
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });
    }

    #region Button functions

    public void LogInGame()
    {
        FirebaseAnalytics.LogEvent("Log_Menu_Scene");
    }

    public void PressNumberButton(int number)
    {
        FirebaseAnalytics.LogEvent("Press_Test_Button", new Parameter[] { 
            new Parameter("ButtonNumber", number),
            new Parameter("ButtonNumber", number),
        });
    }

    #endregion
}
