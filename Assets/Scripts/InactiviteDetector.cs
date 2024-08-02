using UnityEngine;
using GoogleMobileAds.Api;

public class InactivityDetector : MonoBehaviour
{
    public float inactivityTime = 60f; // 1 minute of inactivity
    private float timer;
    private bool isTouchOrClickDetected = false;
    public InterstitialAds interstitialAdScript;


    void Update()
    {
        // Сбрасываем таймер, когда пользователь взаимодействует с экраном (нажатие или клик мыши)
        if (Input.touchCount > 0 )
        {
            timer = 0f; // Сбросить таймер
            isTouchOrClickDetected = true;
        }
        else
        {
            // Увеличиваем таймер только если не было нажатий или кликов
            if (!isTouchOrClickDetected)
            {
                timer += Time.deltaTime;
            }

            // Если таймер достигает заданного времени бездействия, вызываем методA
            if (timer >= inactivityTime)
            {
                if (interstitialAdScript != null)
            {
            interstitialAdScript.ShowInterstitialAd(); // Показываем межстраничную рекламу
            }
            else
            {
            Debug.LogError("InterstitialAdScript reference is not set.");
            }
                timer = 0f; // Сбросить таймер после вызова метода, если это необходимо
            }
        }
    }

   
}
