using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleBeh : MonoBehaviour
{
    public float impulseSpeed = 3f;
    public float movementSpeed = 8f;
    //private Rigidbody _rb;

    float tempTime;
    private void Impulse()
    {
        //_rb.velocity += transform.up * impulseSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 2);
        transform.position += transform.up * Time.deltaTime * movementSpeed;
    }
}
