using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Score;

public class AsteroidBeh : MonoBehaviour
{
    private Vector3 dir = new Vector3(100, 0, 0);
    public float movementSpeed = 5.0f;
    public Vector3 DirectionVector;
    public GameObject AsteroidShard;
    private bool isDestroyed = false;
    public Sprite sprite1; 
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;
    private float SpeenSpeed = 0.5f;


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
        int SpriteChoice = Random.Range(1, 6);
        Debug.Log(SpriteChoice);
        if (SpriteChoice == 1)
        {
            spriteRenderer.sprite = sprite1;
        }
        else if (SpriteChoice == 2)
        {
            spriteRenderer.sprite = sprite2;
            SpeenSpeed *= -1;
        }
        else if (SpriteChoice == 3)
        {
            spriteRenderer.sprite = sprite3;
        }
        else if (SpriteChoice == 4)
        {
            spriteRenderer.sprite = sprite4;
            SpeenSpeed *= -1;
        }
        else if (SpriteChoice == 5)
        {
            spriteRenderer.sprite = sprite5;
            SpeenSpeed = 0.0f;
        }
        SetDirection();
    }

    void Update()
    {
        if(isDestroyed == true)
        {
            ScoreScript.ScoreValue += 50;
            Destroy(gameObject);
            int quantity = Random.Range(0, 4);
            for(int i = 0; i < quantity; i ++)
            {
                Instantiate(AsteroidShard, transform.position, Quaternion.identity);
            }
        }
        Destroy(gameObject, 10);
        transform.position += DirectionVector * Time.deltaTime * movementSpeed;
        transform.Rotate(new Vector3(0, 0, SpeenSpeed));
    }
    
}
