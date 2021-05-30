using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHelper : MonoBehaviour
{
    public string selectedTag;
    public bool hasColission = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == selectedTag)
            hasColission = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == selectedTag)
            hasColission = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == selectedTag)
            hasColission = false;
    }
}
