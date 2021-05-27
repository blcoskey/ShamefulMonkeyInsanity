using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] backgroundSprites;
    public Sprite[] background2Sprites;
    public Sprite[] foregroundSprites;
    private float speed = 0.0f;
    public float backgroundSpeed = 2.0f;
    public float background2Speed = 3.5f;
    public float foregroundSpeed = 5.0f;
    
    public float backgroundY = -0.5f;
    public float background2Y = -0.5f;
    public float foregroundY = -5f;

    public float foregroundSpawnRate = 0.1f;
    public float backgroundSpawnRate = 0.8f;
    public float background2SpawnRate = 0.6f;
    public float despawnX = -11;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if(Random.value < backgroundSpawnRate){
            spriteRenderer.sprite = GetRandomSprite(backgroundSprites);
            speed = backgroundSpeed;
            transform.position = new Vector3(transform.position.x, backgroundY, 9);
            transform.localScale *= Random.Range(2,4);
        }
        else if(Random.value < background2SpawnRate){
            spriteRenderer.sprite = GetRandomSprite(background2Sprites);
            speed = background2Speed;
            transform.position = new Vector3(transform.position.x, background2Y, 8);
            transform.localScale *= Random.Range(2,4);
        }
        else if(Random.value < foregroundSpawnRate){
            spriteRenderer.sprite = GetRandomSprite(foregroundSprites);
            speed = foregroundSpeed;
            transform.position = new Vector3(transform.position.x, foregroundY, -5);
            transform.localScale *= Random.Range(1,3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= despawnX) Destroy(this.gameObject);
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
