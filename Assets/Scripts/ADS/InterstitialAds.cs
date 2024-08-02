using GoogleMobileAds.Api;
using UnityEngine;

public class InterstitialAds : MonoBehaviour
{
    private InterstitialAd _interstitialAd;

    // Ad unit IDs for testing.
#if UNITY_ANDROID
    private string _adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
    private string _adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
    private string _adUnitId = "unused";
#endif

    public void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => {
            // Initialization complete. Load the first ad.
            LoadInterstitialAd();
        });
    }

    /// <summary>
    /// Loads the interstitial ad.
    /// </summary>
    public void LoadInterstitialAd()
    {
        // Clean up the old ad before loading a new one.
        if (_interstitialAd != null)
        {
            _interstitialAd.Destroy();
            _interstitialAd = null;
        }

        Debug.Log("Loading the interstitial ad.");

        var adRequest = new AdRequest();

        InterstitialAd.Load(_adUnitId, adRequest, (InterstitialAd ad, LoadAdError error) => {
            if (error != null || ad == null)
            {
                Debug.LogError("Interstitial ad failed to load with error: " + error);
                return;
            }

            Debug.Log("Interstitial ad loaded with response: " + ad.GetResponseInfo());
            _interstitialAd = ad;

            // Register event handlers.
            RegisterEventHandlers(_interstitialAd);
        });
    }

    /// <summary>
    /// Shows the interstitial ad.
    /// </summary>
    public void ShowInterstitialAd()
    {
        if (_interstitialAd != null && _interstitialAd.CanShowAd())
        {
            Debug.Log("Showing interstitial ad.");
            _interstitialAd.Show();
        }
        else
        {
            Debug.LogError("Interstitial ad is not ready yet.");
        }
    }

    /// <summary>
    /// Register event handlers for interstitial ad events.
    /// </summary>
    private void RegisterEventHandlers(InterstitialAd interstitialAd)
    {
        interstitialAd.OnAdPaid += adValue =>
        {
            Debug.Log($"Interstitial ad paid {adValue.Value} {adValue.CurrencyCode}.");
        };

        interstitialAd.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Interstitial ad recorded an impression.");
        };

        interstitialAd.OnAdClicked += () =>
        {
            Debug.Log("Interstitial ad was clicked.");
        };

        interstitialAd.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Interstitial ad full screen content opened.");
        };

        interstitialAd.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Interstitial ad full screen content closed.");
            // Preload the next interstitial ad.
            LoadInterstitialAd();
        };

        interstitialAd.OnAdFullScreenContentFailed += error =>
        {
            Debug.LogError("Interstitial ad failed to open full screen content with error: " + error);
            // Preload the next interstitial ad.
            LoadInterstitialAd();
        };
    }

    // Clean up the interstitial ad when it is no longer needed.
    private void OnDestroy()
    {
        if (_interstitialAd != null)
        {
            _interstitialAd.Destroy();
        }
    }
}
