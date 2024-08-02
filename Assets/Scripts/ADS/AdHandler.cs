// using UnityEngine;
// using GoogleMobileAds.Api;

// public class AdHandler : MonoBehaviour
// {
//     // Объявление переменных для рекламы.
//     private BannerView bannerView;
//     private InterstitialAd interstitial;
//     private RewardedAd rewardedAd;

//     // Идентификаторы рекламных блоков.
//     private string bannerAdUnitId = "your-banner-ad-unit-id";
//     private string interstitialAdUnitId = "your-interstitial-ad-unit-id";
//     private string rewardedAdUnitId = "your-rewarded-ad-unit-id";

//     void Start()
//     {
//         // Инициализация Google Mobile Ads SDK.
//         MobileAds.Initialize(initStatus => { });

//         // Запуск запросов на рекламу.
//         RequestBanner();
//         RequestInterstitial();
//         RequestRewardedAd();
//     }

//     // Запрос баннерной рекламы.
//     private void RequestBanner()
//     {
//         bannerView = new BannerView(bannerAdUnitId, AdSize.Banner, AdPosition.Bottom);

//         AdRequest request = new AdRequest.Builder().Build();
//         bannerView.LoadAd(request);
//     }

//     // Запрос интерстициальной рекламы.
//     private void RequestInterstitial()
//     {
//         interstitial = new InterstitialAd(interstitialAdUnitId);

//         AdRequest request = new AdRequest.Builder().Build();
//         interstitial.LoadAd(request);
//     }

//     // Запрос рекламы с вознаграждением.
//     private void RequestRewardedAd()
//     {
//         rewardedAd = new RewardedAd(rewardedAdUnitId);

//         // Обработчики событий.
//         rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
//         rewardedAd.OnAdFailedToLoad += HandleAdFailedToLoad;
//         rewardedAd.OnAdClosed += HandleAdClosed;

//         AdRequest request = new AdRequest.Builder().Build();
//         rewardedAd.LoadAd(request);
//     }

//     // Показывает баннерную рекламу.
//     public void ShowBanner()
//     {
//         if (bannerView != null)
//         {
//             bannerView.Show();
//         }
//     }

//     // Показывает интерстициальную рекламу.
//     public void ShowInterstitial()
//     {
//         if (interstitial != null && interstitial.IsLoaded())
//         {
//             interstitial.Show();
//         }
//         else
//         {
//             // Перезагрузите интерстициальную рекламу, если она не загружена.
//             RequestInterstitial();
//         }
//     }

//     // Показывает рекламу с вознаграждением.
//     public void ShowRewardedAd()
//     {
//         if (rewardedAd != null && rewardedAd.IsLoaded())
//         {
//             rewardedAd.Show();
//         }
//         else
//         {
//             // Перезагрузите рекламу с вознаграждением, если она не загружена.
//             RequestRewardedAd();
//         }
//     }

//     // Обработчик получения вознаграждения.
//     private void HandleUserEarnedReward(object sender, Reward e)
//     {
//         Debug.Log("User earned reward: " + e.Amount.ToString() + " " + e.Type);
//         // Здесь можно добавить код для предоставления вознаграждения пользователю.
//     }

//     // Обработчик ошибки загрузки рекламы.
//     private void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs e)
//     {
//         Debug.Log("Ad failed to load: " + e.LoadAdError.GetMessage());
//     }

//     // Обработчик закрытия рекламы.
//     private void HandleAdClosed(object sender, System.EventArgs e)
//     {
//         // Перезагрузите рекламу с вознаграждением после её закрытия.
//         RequestRewardedAd();
//     }

//     void OnDestroy()
//     {
//         // Очистка ресурсов при уничтожении объекта.
//         if (bannerView != null)
//         {
//             bannerView.Destroy();
//         }

//         if (interstitial != null)
//         {
//             interstitial.Destroy();
//         }

//         if (rewardedAd != null)
//         {
//             rewardedAd.Destroy();
//         }
//     }
// }
