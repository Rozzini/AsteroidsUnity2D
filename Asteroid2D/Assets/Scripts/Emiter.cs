using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emiter : MonoBehaviour
{
    public GameObject BigAsteroid;

    public Vector3 InitialCoords;

    float tempTime;

    // Start is called before the first frame update
    void Start()
    {
       // Instantiate(BigAsteroid, InitialCoords, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        tempTime += Time.deltaTime;
        if (tempTime > 2)
        {
            tempTime = 0;
            Instantiate(BigAsteroid, InitialCoords, Quaternion.identity);
        }
    }
}
