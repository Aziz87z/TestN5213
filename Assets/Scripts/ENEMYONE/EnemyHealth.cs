using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int experienceOnDeath = 50;
    private ExperienceManager experienceManager;

    public int maxHealth = 50; // максимальное количество здоровья врага
    public int currentHealth; // текущее количество здоровья врага

    void Start()
    {
        // Найти объект ExperienceManager в сцене
        experienceManager = FindObjectOfType<ExperienceManager>();
        if (experienceManager == null)
        {
            Debug.LogError("ExperienceManager не найден в сцене. Убедитесь, что он добавлен на сцену.");
        }

        currentHealth = maxHealth;
        // UpdateHealthBar(); // Обновляем полоску здоровья при старте
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        // UpdateHealthBar();
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверяем, столкнулся ли данный объект с другим объектом
        if (collision.gameObject.CompareTag("Player"))
        {
            int damage = 10;  // Урон, который получает персонаж
            TakeDamage(damage);
        }
    }

    public void Die()
    {
        EnemyCounter.AddEnemyKill();

        // Проверяем, что experienceManager был найден
        if (experienceManager != null)
        {
            experienceManager.GainExperience(experienceOnDeath);
        }
        else
        {
            Debug.LogWarning("Не удалось получить доступ к ExperienceManager при смерти врага.");
        }

        Destroy(gameObject); // Уничтожаем объект врага при его смерти
    }
}
