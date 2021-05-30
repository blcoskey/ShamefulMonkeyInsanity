using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomProp : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    public float scaleRandomnessMax = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Randoms.GetRandomSprite(sprites);
        transform.localScale = transform.localScale *= Random.Range(1, scaleRandomnessMax);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
