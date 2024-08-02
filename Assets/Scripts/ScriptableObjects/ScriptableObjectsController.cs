using UnityEngine;
using UnityEngine.UI; // Для работы с UI элементами

public class ScriptableObjectsController : MonoBehaviour
{
    [SerializeField] private ScriptableObject[] scriptableObjects;
    [SerializeField] private MapDisplay mapDisplay;
    [SerializeField] private Button previousButton; // Ссылка на кнопку "Назад"
    [SerializeField] private Button nextButton; // Ссылка на кнопку "Вперед"
     public InterstitialAds interstitialAdScript;

    private int currentIndex;

    private void Awake()
    {
        if (scriptableObjects.Length > 0)
        {
            currentIndex = 0;
            DisplayCurrentScriptableObject();
            UpdateButtonStates();
        }
    }

    public void ChangrScriptableObject(int change)
    {
        // Сохраняем предыдущий индекс для проверки, нужно ли обновлять отображение
        int previousIndex = currentIndex;

        // Обновляем индекс в зависимости от изменения
        currentIndex += change;

        // Проверяем границы и корректируем индекс
        if (currentIndex < 0)
        {
            currentIndex = 0; // Не позволяем уйти ниже 0
        }
        else if (currentIndex >= scriptableObjects.Length)
        {
            currentIndex = scriptableObjects.Length - 1; // Не позволяем выйти за границы массива
        }
        if (currentIndex % 3 == 0)
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

        // Обновляем отображение и состояние кнопок, только если индекс изменился
        if (mapDisplay != null && currentIndex != previousIndex)
        {
            DisplayCurrentScriptableObject();
            UpdateButtonStates();
        }
    }

    private void DisplayCurrentScriptableObject()
    {
        if (mapDisplay != null && scriptableObjects.Length > 0)
        {
            mapDisplay.DisplayMap((Map)scriptableObjects[currentIndex]);
        }
    }

    private void UpdateButtonStates()
    {
        if (previousButton != null && nextButton != null)
        {
            // Если текущий индекс - первый элемент, делаем кнопку "Назад" неактивной и серой
            previousButton.interactable = currentIndex > 0;
            SetButtonColor(previousButton, currentIndex > 0 ? Color.white : Color.grey);

            // Если текущий индекс - последний элемент, делаем кнопку "Вперед" неактивной и серой
            nextButton.interactable = currentIndex < scriptableObjects.Length - 1;
            SetButtonColor(nextButton, currentIndex < scriptableObjects.Length - 1 ? Color.white : Color.grey);
        }
    }

    private void SetButtonColor(Button button, Color color)
    {
        ColorBlock colors = button.colors;
        colors.normalColor = color;
        colors.highlightedColor = color;
        colors.pressedColor = color;
        colors.selectedColor = color;
        button.colors = colors;
    }
}
