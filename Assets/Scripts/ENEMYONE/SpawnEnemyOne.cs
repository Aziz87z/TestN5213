using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class SpawnEnemyOne : MonoBehaviour
{
    public GameObject[] cars;
    private float[] positions = {-7.88f,-4.25f,-0.47f,3.12f,6.59f};
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
            yield return new WaitForSeconds(5f);
        }
    }
}
