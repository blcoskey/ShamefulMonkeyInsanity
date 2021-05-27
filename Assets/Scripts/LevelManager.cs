using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject movingObject;
    public GameObject ground;
    public float spawnTime = 5.0f;
    public float spawnX = 5.0f;
    public float groundSpawnX = 18.4f;
    public float groundSpawnDelay = 10.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating ("SpawnMovingObject", 1.0f, spawnTime);
        InvokeRepeating ("SpawnGround", 0, groundSpawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnMovingObject(){
        Instantiate(movingObject, new Vector2(spawnX,0), Quaternion.identity);
    }

    void SpawnGround(){
        Instantiate(ground, new Vector2(groundSpawnX,-0.09f), Quaternion.identity);
    }
}
