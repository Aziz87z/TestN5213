using UnityEngine;
using UnityEngine.UI;

public class ExperienceManager : MonoBehaviour
{
    public PlayerStats playerStats;
    public Text experienceText; // Поле для текстового компонента

    private void Start()
    {
        // Находим компонент текста при старте
        GameObject textObject = GameObject.Find("ExperienceText");
        if (textObject != null)
        {
            experienceText = textObject.GetComponent<Text>();
        }
        else
        {
            Debug.LogError("Не удалось найти текстовый объект 'ExperienceText'");
        }
    }

    public void GainExperience(int amount)
    {
        playerStats.experience += amount;

        if (playerStats.experience >= playerStats.experienceToNextLevel)
        {
            LevelUp();
            FindObjectOfType<PlayerController>().UpdatePlayerSprite();
        }

        UpdateExperienceText(); // Вызываем метод для обновления текста опыта
    }

  private void UpdateExperienceText()
{
    // Проверяем, что текстовый компонент существует
    if (experienceText != null)
    {
        int currentExp = playerStats.experience;
        int expToNextLevel = playerStats.experienceToNextLevel;
        
        // Форматируем текст в формат "текущий опыт / опыт до следующего уровня"
        experienceText.text = $"Exp: {currentExp} / {expToNextLevel}";
    }
    else
    {
        Debug.LogWarning("Текстовый компонент 'experienceText' не установлен");
    }
}

    // Метод для повышения уровня
    private void LevelUp()
    {
        playerStats.level++;
        playerStats.experience -= playerStats.experienceToNextLevel;
        playerStats.experienceToNextLevel = CalculateExperienceForLevel(playerStats.level);

        playerStats.SavePlayerData(); // Сохранение данных после повышения уровня

        // Обновляем спрайт игрока
        FindObjectOfType<PlayerController>().UpdatePlayerSprite();
    }

    // Функция, определяющая количество опыта для достижения каждого уровня
    private int CalculateExperienceForLevel(int level)
    {
        // Опыт для каждого уровня, согласно вашей формуле
        switch (level)
        {
            case 1:
                return 100;
            case 2:
                return 150;
            case 3:
                return 200;
            case 4:
                return 250;
            default:
                return 0; // Если вам нужны опытные значения для больших уровней, добавьте их сюда
        }
    }
}