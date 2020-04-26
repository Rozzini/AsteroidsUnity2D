using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBeh : MonoBehaviour
{

    private Vector3 dir = new Vector3(100, 0, 0);
    public float movementSpeed = 5.0f;
    public Vector3 DirectionVector;
    public GameObject AsteroidShard;
    private bool isDestroyed = false;
    public Sprite sprite1; 
    public Sprite sprite2; 

    private SpriteRenderer spriteRenderer;


    public void SetDirection()
    {
        Vector3 currentPposition = transform.position;

        if(currentPposition.x == 0)
        {
            if(currentPposition.y < 0)
            {
                DirectionVector = new Vector3(0, 0.4f, 0);
                DirectionRandomizer(-0.5f, 0.5f, 1);
            }
            else
            {
                DirectionVector = new Vector3(0, -0.4f, 0);
                DirectionRandomizer(-0.5f, 0.5f, 2);
            }
        }
        else
        {
            if(currentPposition.x < 0)
            {
                DirectionVector = new Vector3(0.4f, 0, 0);
                DirectionRandomizer(-0.5f, 0.5f, 3);
            }
            else
            {
                DirectionVector = new Vector3(-0.4f, 0, 0);
                DirectionRandomizer(-0.5f, 0.5f, 4);
            }
        }

    }

    private void DirectionRandomizer(float from, float to, int Emiter)
    {
        float RandomVarX = Random.Range(from, to);
        float RandomVarY = Random.Range(from, to);

        switch(Emiter)
        {
            case 1:
                DirectionVector.x += RandomVarX;
                break;
            case 2:
                DirectionVector.x += RandomVarX;
                break;
            case 3:
                DirectionVector.y += RandomVarY;
                break;
            case 4:
                DirectionVector.y += RandomVarY;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isDestroyed = true;
       
    }
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        int SpriteChoice = Random.Range(-10, 10);
        if (SpriteChoice >= 0)
        {
            spriteRenderer.sprite = sprite1;
        }
        else
        {
            spriteRenderer.sprite = sprite2;
        }
        SetDirection();
    }

    void Update()
    {
        if(isDestroyed == true)
        {
            Destroy(gameObject);
            int quantity = Random.Range(0, 4);
            for(int i = 0; i < quantity; i ++)
            {
                Instantiate(AsteroidShard, transform.position, Quaternion.identity);
            }
        }
        Destroy(gameObject, 10);
        transform.position += DirectionVector * Time.deltaTime * movementSpeed;
    }
    
}
