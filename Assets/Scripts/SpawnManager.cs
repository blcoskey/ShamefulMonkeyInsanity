using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] backgroundSprites;
    public Sprite[] background2Sprites;
    public Sprite[] foregroundSprites;
    private float speed = 0.0f;
    public float backgroundSpeed = 2.0f;
    public float background2Speed = 3.5f;
    public float foregroundSpeed = 5.0f;

    public float foregroundSpawnRate = 0.1f;
    public float backgroundSpawnRate = 0.8f;
    public float background2SpawnRate = 0.6f;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if(Random.value > backgroundSpawnRate){
            spriteRenderer.sprite = GetRandomSprite(backgroundSprites);
            speed = backgroundSpeed;
        }
        else if(Random.value > background2SpawnRate){
            spriteRenderer.sprite = GetRandomSprite(background2Sprites);
            speed = background2Speed;
        }
        else if(Random.value > foregroundSpawnRate){
            spriteRenderer.sprite = GetRandomSprite(foregroundSprites);
            speed = foregroundSpeed;
        }
        
        spriteRenderer.sprite = GetRandomSprite(backgroundSprites);
        speed = foregroundSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }

    public Sprite GetRandomSprite(Sprite[] spriteArray){
        return spriteArray[Random.Range(0, spriteArray.Length -1)];
    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        Destroy(this);
    }
}
