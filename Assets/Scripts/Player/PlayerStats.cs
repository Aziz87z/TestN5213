using UnityEngine;
[System.Serializable]
public class PlayerStats
{
    public int level = 1;                     // Текущий уровень игрока
    public int experience = 0;                // Текущий опыт игрока
    public int experienceToNextLevel = 100;   // Опыт, необходимый для достижения следующего уровня

    // Метод для сохранения данных
    public void SavePlayerData()
    {
        PlayerPrefs.SetInt("PlayerLevel", level);
        PlayerPrefs.SetInt("PlayerExperience", experience);
        PlayerPrefs.SetInt("ExperienceToNextLevel", experienceToNextLevel);
    }

    // Метод для загрузки данных
    public void LoadPlayerData()
    {
        if (PlayerPrefs.HasKey("PlayerLevel"))
        {
            level = PlayerPrefs.GetInt("PlayerLevel");
            experience = PlayerPrefs.GetInt("PlayerExperience");
            experienceToNextLevel = PlayerPrefs.GetInt("ExperienceToNextLevel");
        }
    }
}
