using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleBeh : MonoBehaviour
{
    public float impulseSpeed = 3f;
    public float movementSpeed = 8f;
   

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    void Update()
    {
        Destroy(gameObject, 2);
        transform.position += transform.up * Time.deltaTime * movementSpeed;
    }
}
