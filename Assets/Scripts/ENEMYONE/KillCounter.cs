using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour
{
    public static int enemiesKilled = 0; // Статическая переменная для подсчета убитых врагов
    public Text enemiesKilledText; // UI текст для отображения количества убитых врагов

    void Start()
    {
        // Обнуляем счетчик убитых врагов при старте
        enemiesKilled = 0;
        UpdateUI();
    }

    void OnEnable()
    {
        // Обнуляем счетчик убитых врагов при включении объекта
        enemiesKilled = 0;
        UpdateUI();
    }

    void OnDisable()
    {
        // Обнуляем текстовый элемент при отключении объекта
        if (enemiesKilledText != null)
        {
            enemiesKilledText.text = "";
        }
    }

    void Update()
    {
        // Обновляем текст UI
        UpdateUI();
    }

    // Метод для обновления UI текста
    private void UpdateUI()
    {
        if (enemiesKilledText != null)
        {
            enemiesKilledText.text = "" + enemiesKilled;
        }
    }

    // Метод для увеличения счетчика убитых врагов
    public static void AddEnemyKill()
    {
        enemiesKilled++;
    }
}
