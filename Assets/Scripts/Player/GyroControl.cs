using UnityEngine;

public class GyroControl : MonoBehaviour
{
    // Скорость перемещения игрока
    public float speed = 5.0f;

    void Start()
    {
        // Включаем гироскоп
        Input.gyro.enabled = true;
    }

    void Update()
    {
        // Получаем данные гироскопа
        Gyroscope gyro = Input.gyro;
        
        // Получаем смещение по осям
        float tiltX = gyro.gravity.x;
        float tiltY = gyro.gravity.y;

        // Перемещение игрока в зависимости от наклона устройства
        Vector3 movement = new Vector3(tiltX, 0, 0) * speed * Time.deltaTime;

        // Перемещаем игрока
        transform.Translate(movement);
    }
}