using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] cars;
    private float[] positions = {-6.27f,-2.36f,1.34f,5.01f,8.08f};
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawn());
    }

    IEnumerator spawn(){
        while(true){
            Instantiate(cars[Random.Range(0, cars.Length)],
            new Vector3(positions[Random.Range(0,5)],6f,0),
            Quaternion.Euler(new Vector3(0,0,0))
            );
            yield return new WaitForSeconds(3f);
        }
    }
}
