using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShardBeh : MonoBehaviour
{

    public float movementSpeed = 5.0f;
    public Vector3 DirectionVector;

    public Sprite sprite1;
    public Sprite sprite2;

    private SpriteRenderer spriteRenderer;


    private void DirectionRandomizer()
    {
        float RandomVarX = Random.Range(-1.0f, 1.0f);
        float RandomVarY = Random.Range(-1.0f, 1.0f);

        DirectionVector = new Vector3(RandomVarX, RandomVarY, 0);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

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

        DirectionRandomizer();
    }

    void Update()
    {
        Destroy(gameObject, 8);

        transform.position += DirectionVector * Time.deltaTime * movementSpeed;
    }
}
