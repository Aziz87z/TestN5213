using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public GameObject gameObject;
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверяем, столкнулся ли данный объект с другим объектом
        if (collision.gameObject.CompareTag("Player")) 
        {
            Destroy(gameObject);
        }
         if (collision.gameObject.CompareTag("EnemyBullet1")) 
        {
            Destroy(gameObject);
        }
         if (collision.gameObject.CompareTag("Enemy")) 
        {
            Destroy(gameObject);
        }
    }
}
