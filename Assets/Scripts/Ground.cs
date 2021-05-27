using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public float despawnX = -31;
    public float speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= despawnX) Destroy(this.gameObject);
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
