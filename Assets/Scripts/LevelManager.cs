using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [Header("Prefabs")]
    public GameObject background1;
    public GameObject background2;
    public GameObject background3;
    public GameObject randomTree;
    public GameObject bridgeSlat;
    [Header("Spawn")]
    public GameObject slatSpawnPosition;
    public GameObject spawnPosition;
    public GameObject background1SpawnTrigger;
    public GameObject background2SpawnTrigger;
    public GameObject background3SpawnTrigger;
    public float randomTreeSpawnChance = 0.5f;
    public float treeSpawnTime = 5.0f;
    public float slatSpawnTime = 1.0f;

    [Header("Speed")]
    public float bridgeSlatSpeed = 10.0f;
    public float backgroundSpeed1 = 10.0f;
    public float backgroundSpeed2 = 10.0f;
    public float backgroundSpeed3 = 10.0f;
    public float backgroundTreeSpeed = 10.0f;
    public float speedMultiplier = 1.0f;

    public float GetSpeed(string tag)
    {
        var speed = 0.0f;
        if (tag == "Bridge")
        {
            speed = bridgeSlatSpeed;
        }
        if (tag == "BackgroundElement1")
        {
            speed = backgroundSpeed1;
        }
        if (tag == "BackgroundElement2")
        {
            speed = backgroundSpeed2;
        }
        if (tag == "BackgroundElement3")
        {
            speed = backgroundSpeed3;
        }
        if (tag == "BackgroundTree")
        {
            speed = backgroundTreeSpeed;
        }

        return speed * speedMultiplier;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnTreeProp", 0.0f, treeSpawnTime);
    }

    void Update()
    {
        if (!slatSpawnPosition.GetComponent<CollisionHelper>().hasColission)
        {
            SpawnBridgeSlat();
        }
        if (!background1SpawnTrigger.GetComponent<CollisionHelper>().hasColission)
        {
            SpawnBackground("BackgroundElement1");
        }
        if (!background2SpawnTrigger.GetComponent<CollisionHelper>().hasColission)
        {
            SpawnBackground("BackgroundElement2");
        }
        if (!background3SpawnTrigger.GetComponent<CollisionHelper>().hasColission)
        {
            SpawnBackground("BackgroundElement3");
        }
    }

    void SpawnTreeProp()
    {
        if (Random.value <= randomTreeSpawnChance)
            Instantiate(randomTree, spawnPosition.transform.position, Quaternion.identity);
    }

    void SpawnBridgeSlat()
    {
        Instantiate(bridgeSlat, slatSpawnPosition.transform.position, Quaternion.identity);
    }

    public void SpawnBackground(string tag)
    {
        if (tag == "BackgroundElement1" && GameObject.FindGameObjectsWithTag("BackgroundElement1")?.Length < 2)
        {
            Instantiate(background1, spawnPosition.transform.position, Quaternion.identity);
        }
        if (tag == "BackgroundElement2" && GameObject.FindGameObjectsWithTag("BackgroundElement2")?.Length < 2)
        {
            Instantiate(background2, spawnPosition.transform.position, Quaternion.identity);
        }
        if (tag == "BackgroundElement3" && GameObject.FindGameObjectsWithTag("BackgroundElement3")?.Length < 2)
        {
            Instantiate(background3, spawnPosition.transform.position, Quaternion.identity);
        }
    }
}
