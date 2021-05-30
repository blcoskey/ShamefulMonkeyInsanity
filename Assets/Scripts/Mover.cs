using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 0.0f;
    public LevelManager levelManager;
    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        speed = levelManager.GetSpeed(gameObject.tag);
    }

    // Update is called once per frame
    void Update()
    {
        speed = levelManager.GetSpeed(gameObject.tag);
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }

    void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
