using System.Collections;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Префаб снаряда
    public Transform firePoint; // Точка, откуда будут вылетать снаряды
    public float shootInterval = 3f; // Интервал между выстрелами
    public float bulletSpeed = 3f;// Скорость снаряда
    public AudioSource soundSource; 
    void Start()
    {
        StartCoroutine(ShootRoutine()); // Запуск корутины для стрельбы
    }

    IEnumerator ShootRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootInterval); // Ждем заданное время

            Shoot(); // Вызываем функцию выстрела
        }
    }

    void Shoot()
    {
        // Создаем экземпляр снаряда на позиции firePoint
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
         if (soundSource != null && soundSource.clip != null)
        {
            soundSource.Play(); // Воспроизвести звук
        }

        // Настройка скорости снаряда
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = -firePoint.up * bulletSpeed; // Используем firePoint.up для направления вниз
    }
}
