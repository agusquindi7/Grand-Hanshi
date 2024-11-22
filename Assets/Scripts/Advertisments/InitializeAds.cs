using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class InitializeAds : MonoBehaviour , IUnityAdsInitializationListener
{
    [SerializeField] string _androidID = "5735065";
    [SerializeField] bool _testingMode;

    private void Awake()
    {
        if(!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(_androidID, _testingMode, this);
        }
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Initialization success");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("Initialization Failure");
    }

}
