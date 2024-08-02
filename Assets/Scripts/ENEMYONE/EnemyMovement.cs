using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class EnemyMovement: MonoBehaviour
{
    public float speed = 2f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if(transform.position.y > 6 || transform.position.y < -6 ){
            Destroy(gameObject);
        }
    }
}
