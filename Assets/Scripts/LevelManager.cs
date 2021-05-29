using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public float timeScale = 1.0f;
    public GameObject spawnPosition;
    public GameObject background1;
    public GameObject background2;
    public GameObject background3;
    public GameObject randomTree;
    public float randomTreeSpawnChance = 0.5f;
    public float spawnTime = 5.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating ("SpawnTreeProp", 0.0f, spawnTime);
    }

    void Update(){
        Time.timeScale = timeScale;
    }

    void SpawnTreeProp(){
        if(Random.value < randomTreeSpawnChance)
            Instantiate(randomTree, spawnPosition.transform.position, Quaternion.identity);
    }

    public void SpawnBackground(string tag){
        if(tag == "BackgroundElement1" && GameObject.FindGameObjectsWithTag("BackgroundElement1")?.Length < 2){
            Instantiate(background1, spawnPosition.transform.position, Quaternion.identity);
        }
        if(tag == "BackgroundElement2" && GameObject.FindGameObjectsWithTag("BackgroundElement2")?.Length < 2){
            Instantiate(background2, spawnPosition.transform.position, Quaternion.identity);
        }
        if(tag == "BackgroundElement3" && GameObject.FindGameObjectsWithTag("BackgroundElement3")?.Length < 2){
            Instantiate(background3, spawnPosition.transform.position, Quaternion.identity);
        }
    }
}
