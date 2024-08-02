using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    [System.Serializable]
    public class SoundCategory
    {
        public AudioSource audioSource; // Источник аудио
        public Button toggleButton; // Кнопка для включения/выключения
        public Sprite onSprite; // Спрайт для включенного состояния
        public Sprite offSprite; // Спрайт для выключенного состояния
        public bool isOn = true; // Флаг для состояния
    }

    public SoundCategory[] soundCategories; // Массив для различных категорий звука

    private Dictionary<Button, SoundCategory> buttonToSoundCategoryMap;

    void Start()
    {
        buttonToSoundCategoryMap = new Dictionary<Button, SoundCategory>();

        // Настройка кнопок и начальных спрайтов
        foreach (var category in soundCategories)
        {
            if (category.toggleButton != null)
            {
                category.toggleButton.onClick.AddListener(() => ToggleSound(category));
                buttonToSoundCategoryMap[category.toggleButton] = category;
            }
            UpdateButtonSprite(category);
        }
    }

    private void ToggleSound(SoundCategory category)
    {
        category.isOn = !category.isOn;
        category.audioSource.mute = !category.isOn;
        UpdateButtonSprite(category);
    }

    private void UpdateButtonSprite(SoundCategory category)
    {
        if (category.toggleButton != null)
        {
            category.toggleButton.image.sprite = category.isOn ? category.onSprite : category.offSprite;
        }
    }
}
