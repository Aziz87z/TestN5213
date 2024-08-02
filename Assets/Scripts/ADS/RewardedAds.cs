using GoogleMobileAds.Api;
using UnityEngine;

public class RewardedAds : MonoBehaviour
{
    // Ad unit IDs for testing.
#if UNITY_ANDROID
    private string _adUnitId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
    private string _adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
    private string _adUnitId = "unused";
#endif

    private RewardedAd _rewardedAd;

    public void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => {
            // Initialization complete. Load the first ad.
            LoadRewardedAd();
        });
    }

    /// <summary>
    /// Loads the rewarded ad.
    /// </summary>
    public void LoadRewardedAd()
    {
        // Clean up the old ad before loading a new one.
        if (_rewardedAd != null)
        {
            _rewardedAd.Destroy();
            _rewardedAd = null;
        }

        Debug.Log("Loading the rewarded ad.");

        var adRequest = new AdRequest();

        RewardedAd.Load(_adUnitId, adRequest, (RewardedAd ad, LoadAdError error) => {
            if (error != null || ad == null)
            {
                Debug.LogError("Rewarded ad failed to load with error: " + error);
                return;
            }

            Debug.Log("Rewarded ad loaded with response: " + ad.GetResponseInfo());
            _rewardedAd = ad;

            // Register event handlers.
            RegisterEventHandlers(_rewardedAd);
        });
    }

    /// <summary>
    /// Shows the rewarded ad.
    /// </summary>
    public void ShowRewardedAd()
    {
        if (_rewardedAd != null && _rewardedAd.CanShowAd())
        {
            _rewardedAd.Show(reward =>
            {
                // Reward the user.
                Debug.Log($"Rewarded ad rewarded the user. Type: {reward.Type}, amount: {reward.Amount}");
            });
        }
        else
        {
            Debug.LogError("Rewarded ad is not ready yet.");
        }
    }

    /// <summary>
    /// Register event handlers for rewarded ad events.
    /// </summary>
    private void RegisterEventHandlers(RewardedAd ad)
    {
        ad.OnAdPaid += adValue =>
        {
            Debug.Log($"Rewarded ad paid {adValue.Value} {adValue.CurrencyCode}.");
        };

        ad.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Rewarded ad recorded an impression.");
        };

        ad.OnAdClicked += () =>
        {
            Debug.Log("Rewarded ad was clicked.");
        };

        ad.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Rewarded ad full screen content opened.");
        };

        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Rewarded ad full screen content closed.");
            // Preload the next rewarded ad.
            LoadRewardedAd();
        };

        ad.OnAdFullScreenContentFailed += error =>
        {
            Debug.LogError("Rewarded ad failed to open full screen content with error: " + error);
            // Preload the next rewarded ad.
            LoadRewardedAd();
        };
    }

    // Clean up the rewarded ad when it is no longer needed.
    private void OnDestroy()
    {
        if (_rewardedAd != null)
        {
            _rewardedAd.Destroy();
        }
    }
}
