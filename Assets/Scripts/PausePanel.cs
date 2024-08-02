using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class PausePanelSettings : MonoBehaviour
{

   public GameObject PausePanel;
   private int clickCount = 0;
   public InterstitialAds interstitialAdScript;
   public RewardedAds rewardedAds;

   public void PauseButtonPressed(){
       clickCount++;
    PausePanel.SetActive(true);
    if (clickCount % 2 == 0)
        {
            if (interstitialAdScript != null)
            {
            interstitialAdScript.ShowInterstitialAd(); // Показываем межстраничную рекламу
            }
            else
            {
            Debug.LogError("InterstitialAdScript reference is not set.");
            }
           
        }
        Time.timeScale = 0f;
    
   }
   public void ContinueButtonPressed(){
    PausePanel.SetActive(false);
    Time.timeScale = 1f;
   }
  public void RestartButtonPressed()
    {
        // Show the reward ad asynchronously
        StartCoroutine(ShowAdAndWaitThenRestart());
    }

   public void ChangeScene(int scene){
      SceneManager.LoadScene(scene);
      Time.timeScale = 1f;
   }
   private IEnumerator ShowAdAndWaitThenRestart()
    {
        if (rewardedAds != null)
            {
            rewardedAds.ShowRewardedAd(); // Показываем межстраничную рекламу
            }
            else
            {
            Debug.LogError("rewardedAds reference is not set.");
            }
        // Wait for 5 seconds (adjust this time as needed)
        yield return new WaitForSeconds(0.2f);

        // After waiting, load the active scene again
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // Ensure time scale is set back to 1
        Time.timeScale = 1f;
    }
}
