using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class RewardedAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string _rewardedAdID = "Rewarded_Android";
    [SerializeField] StaminaSystem staminaSys;

    public void LoadRewardedAd()
    {
        Advertisement.Load(_rewardedAdID, this);
    }

    public void ShowRewardedAd()
    {
        Advertisement.Show(_rewardedAdID, this);
        LoadRewardedAd();
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Reward Loaded");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log("Reward loading failure");
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("Reward ad clicked");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log("Time for reward");
        if (showCompletionState.Equals(UnityAdsCompletionState.COMPLETED)) staminaSys.currentStamina += 6;
        else if (showCompletionState.Equals(UnityAdsCompletionState.SKIPPED)) staminaSys.currentStamina += 3;
        else if (showCompletionState.Equals(UnityAdsCompletionState.UNKNOWN)) Debug.Log("Error");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log("Reward ad failure");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("Starting reward ad");
    }
}
