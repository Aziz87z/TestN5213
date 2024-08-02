using UnityEngine;

public class AutoShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // Префаб пули
    public float fireRate = 1.5f; // Частота стрельбы в выстрелах в секунду
    public float bulletSpeed = 10f; // Скорость полета пули
    public Transform firePoint; // Точка, откуда будет выпускаться пуля
    public AudioSource soundSource; // Источник звука для воспроизведения звука выстрела

    private float nextFireTime; // Время следующего возможного выстрела

    void Update()
    {
        // Проверяем, можно ли стрелять
        if (Time.time >= nextFireTime)
        {
            // Стреляем прямо вперед (в направлении взгляда объекта)
            Vector2 direction = firePoint.up; // firePoint.right даст направление вправо от точки firePoint

            Shoot(direction);
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot(Vector2 direction)
    {
        // Создаем экземпляр пули из префаба
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        
        // Воспроизводим звук выстрела, если источник звука и звук заданы
        if (soundSource != null && soundSource.clip != null)
        {
            soundSource.Play();
        }

        // Настроим скорость движения пули
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = direction * bulletSpeed;
    }
}
