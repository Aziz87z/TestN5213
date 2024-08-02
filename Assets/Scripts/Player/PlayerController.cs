using UnityEngine;
using UnityEngine.UI; // Добавляем пространство имен для работы с UI элементами

public class PlayerController : MonoBehaviour
{
    public Sprite[] playerSprites;
    private SpriteRenderer spriteRenderer;
    private ExperienceManager experienceManager;
    public Text experienceText; // Поле для текстового компонента
    public Slider experienceSlider; // Поле для слайдера

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        experienceManager = FindObjectOfType<ExperienceManager>();

        // Найдем текстовый компонент и слайдер по имени в иерархии объектов   
        experienceText = GameObject.Find("ExperienceText").GetComponent<Text>();
        experienceSlider = GameObject.Find("ExperienceSlider").GetComponent<Slider>();

        UpdatePlayerSprite();
        UpdateExperienceText(); // Вызываем метод для обновления текста и слайдера
    }

    private void UpdateExperienceText()
    {
        int currentExp = experienceManager.playerStats.experience;
        int expToNextLevel = experienceManager.playerStats.experienceToNextLevel;

        experienceText.text = $"Exp: {currentExp} / {expToNextLevel}";

        // Обновляем слайдер
        experienceSlider.maxValue = expToNextLevel;
        experienceSlider.value = currentExp;
    }

    public void UpdatePlayerSprite()
    {
        int level = experienceManager.playerStats.level; // Получаем текущий уровень игрока
        if (level <= playerSprites.Length)
        {
            spriteRenderer.sprite = playerSprites[level - 1]; // -1 потому что индексы массива начинаются с 0
        }
        // Если у вас есть анимации вместо спрайтов, используйте соответствующие методы для изменения анимации
    }
}
