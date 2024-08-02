using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public float timeLimit = 180.0f; // Лимит времени в секундах
    private float currentTime;
    private FinishLevel finishLevelInstance;
     public GameObject WinPanel; 

    // Reference to FinishLevel instance

    void Start()
    {
        currentTime = timeLimit;
        // Assuming FinishLevel needs to be instantiated
        finishLevelInstance = new FinishLevel();
    }

    void Update()
    {
        currentTime -= Time.deltaTime; // Уменьшаем текущее время на прошедшее время с последнего кадра

        // Отображаем время в формате минут:секунды
        timerText.text = string.Format("{0}:{1:00}", Mathf.FloorToInt(currentTime / 60), Mathf.FloorToInt(currentTime % 60));

        // Если время истекло
        if (currentTime <= 0)
        {
            currentTime = 0; // Чтобы избежать отрицательного времени
            WinPanelButtonPressed();
            finishLevelInstance.FinishLvl();
            Debug.Log("Time's up!");
            // Здесь можно добавить логику для завершения игры или других действий
        }
    }
     public void WinPanelButtonPressed(){
     WinPanel.SetActive(true);
    Time.timeScale = 0f;
   }
}
 
 
// using UnityEngine;
// using UnityEngine.UI;

// public class TimerManager : MonoBehaviour
// {
//     public float timeLimit = 10f; // Ограничение по времени в секундах
//     public Text timerText; // UI элемент для отображения таймера
//     private FinishLevel finishLevelInstance;
//     private float timeRemaining;
//     private bool timerIsRunning = false;

//     private void Start()
//     {
//         // Инициализируем таймер
//         timeRemaining = timeLimit;
//         timerIsRunning = true;
//     }

//     private void Update()
//     {
//         if (timerIsRunning)
//         {
//             if (timeRemaining > 0)
//             {
//                 timeRemaining -= Time.deltaTime;
//                 UpdateTimerDisplay();
//             }
//             else
//             {
//                 // Время истекло
//                 timeRemaining = 0;
//                 timerIsRunning = false;
//                 finishLevelInstance.FinishLvl();
//                 OnTimeExpired();
//             }
//         }
//     }

//     private void UpdateTimerDisplay()
//     {
//         if (timerText != null)
//         {
//             // Обновляем отображение времени
//             timerText.text = $"{Mathf.Round(timeRemaining)}";
//         }
//     }

//     private void OnTimeExpired()
//     {
//         // Обработка истечения времени
//         GameLogic gameLogic = FindObjectOfType<GameLogic>();
//         if (gameLogic != null)
//         {
//             gameLogic.CheckBattleOutcome(true); // Время истекло, игрок считается победителем
//         }
//     }
// }
