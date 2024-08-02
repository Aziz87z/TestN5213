using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;
public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;  // Максимальное здоровье персонажа
    public float currentHealth; 
    private int deathCount = 0;
    public AudioSource soundSource;
     public GameObject DeathPanel;   // Текущее здоровье персонажа
       public InterstitialAds interstitialAdScript;

    public Text healthText;      // Ссылка на текстовое поле для отображения здоровья

    void Start()
    {
        currentHealth = maxHealth;
         if (soundSource != null && soundSource.clip != null)
        {
            soundSource.Play();
        }

        UpdateHealthUI();
    }

    // Функция для отнимания здоровья при столкновении с врагом
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверяем, столкнулся ли данный объект с другим объектом
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            float damage = 10;  // Урон, который получает персонаж
            TakeDamage(damage);
            UpdateHealthUI();
        }
        if (collision.gameObject.CompareTag("EnemyBullet1")) 
        {
            float damage = 5;  // Урон, который получает персонаж
            TakeDamage(damage);
            UpdateHealthUI();
        }
        if (collision.gameObject.CompareTag("EnemyBullet2")) 
        {
            float damage = 10;  // Урон, который получает персонаж
            TakeDamage(damage);
            UpdateHealthUI();
        }
         if (collision.gameObject.CompareTag("Meteor"))
        {
            float damage = currentHealth * 0.2f;
            currentHealth -= damage;
             UpdateHealthUI();
        }
         if (collision.gameObject.CompareTag("MeteorSmall"))
        {
            float damage = currentHealth * 0.05f;
            currentHealth -= damage;
             UpdateHealthUI();
        }
        
    }
    
    

    // Функция для отнимания здоровья
    public void TakeDamage(float damage)
    {
         deathCount++;
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            DeathPanelButtonPressed();
            Debug.Log("Персонаж умер!");
        }
        if (deathCount % 5 == 0)
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
        UpdateHealthUI();
    }

    // Функция для обновления отображения здоровья в текстовом поле
    void UpdateHealthUI()
    {
        healthText.text = "" + currentHealth.ToString();
    }
    public void DeathPanelButtonPressed(){
     DeathPanel.SetActive(true);
    Time.timeScale = 0f;
   }
   
}
