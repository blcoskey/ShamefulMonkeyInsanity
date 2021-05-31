using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using enums;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    [Header("Difficulty")]
    public float speedMultiplier = 1.0f;
    public float speedIncrement = 0.1f;
    public float incrementDelayInSeconds = 0.1f;
    public float maxSpeed = 10.0f;
    [Header("Prefabs")]
    public GameObject background1;
    public GameObject background2;
    public GameObject background3;
    public GameObject randomTree;
    public GameObject bridgeSlat;
    public GameObject randomForegroundBush;
    public GameObject randomForegroundTree;
    public GameObject dart;
    public GameObject monkeyPickup;
    public GameObject bananaPickup;
    public GameObject drone;
    [Header("Spawn")]
    public GameObject slatSpawnPosition;
    public GameObject spawnPosition;
    public GameObject background1SpawnTrigger;
    public GameObject background2SpawnTrigger;
    public GameObject background3SpawnTrigger;
    public float randomTreeSpawnChance = 0.5f;
    public float treeSpawnTime = 5.0f;
    public float slatSpawnTime = 1.0f;
    public float foregroundTreeSpawnTime = 1.0f;
    public float foregroundTreeSpawnChance = 0.5f;
    public float foregroundBushSpawnTime = 1.0f;
    public float foregroundBushSpawnChance = 0.5f;
    public float dartSpawnTime = 1.0f;
    public float dartSpawnChance = 0.5f;
    public float dartSpawnOffset = -2.0f;
    public float bananaSpawnChance = 1.0f;
    public float bananaSpawnTime = 1.0f;
    public float bananaSpawnOffset = -2.0f;
    public float monkeySpawnChance = 1.0f;
    public float monkeySpawnTime = 1.0f;
    public float monkeySpawnOffset = 5.0f;
    public float droneSpawnChance = 1.0f;
    public float droneSpawnTime = 1.0f;

    [Header("Speed")]
    public float bridgeSlatSpeed = 10.0f;
    public float backgroundSpeed1 = 10.0f;
    public float backgroundSpeed2 = 10.0f;
    public float backgroundSpeed3 = 10.0f;
    public float backgroundTreeSpeed = 10.0f;
    public float foregroundSpeed = 12.0f;
    public float hazardSpeed = 12.0f;
    public float pickupSpeed = 12.0f;
    [Header("UI")]
    public int monkeys = 0;
    public int banannas = 0;
    public Text monkeyScore;
    public Text bananaScore;
    public GameObject bananaIcon;
    public GameObject monkeyIcon;
    public bool gameOver = false;
    public GameObject gameOverUI;

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
        if (tag == "ForegroundElement")
        {
            speed = foregroundSpeed;
        }
        if (tag == "Hazard")
        {
            speed = hazardSpeed;
        }
        if (tag == "Pickup")
        {
            speed = pickupSpeed;
        }

        return speed * speedMultiplier;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Retry()
    {
        SceneManager.LoadScene("Jungle2");
        gameOver = false;
        monkeys = 0;
        banannas = 0;
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnTreeProp", 0.0f, treeSpawnTime);
        InvokeRepeating("SpawnForegroundTree", 0.0f, foregroundTreeSpawnTime);
        InvokeRepeating("SpawnForegroundBush", 0.0f, foregroundBushSpawnTime);
        InvokeRepeating("SpawnDart", dartSpawnTime, dartSpawnTime);
        InvokeRepeating("SpawnBanana", bananaSpawnTime, bananaSpawnTime);
        InvokeRepeating("SpawnMonkey", monkeySpawnTime, monkeySpawnTime);
        InvokeRepeating("SpawnDrone", droneSpawnTime, droneSpawnTime);
    }

    public float Timer = 0.0f;
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverUI.gameObject.SetActive(true);
        }
        Timer += Time.deltaTime;
        if (Timer >= incrementDelayInSeconds)
        {
            Timer = 0.0f;
            if (speedMultiplier < maxSpeed)
                speedMultiplier += speedIncrement;
        }

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

    void SpawnDart()
    {
        if (Random.value <= dartSpawnChance)
            Instantiate(dart, new Vector2(spawnPosition.transform.position.x, dartSpawnOffset), Quaternion.identity);
    }

    void SpawnTreeProp()
    {
        if (Random.value <= randomTreeSpawnChance)
            Instantiate(randomTree, spawnPosition.transform.position, Quaternion.identity);
    }

    void SpawnForegroundTree()
    {
        if (Random.value <= foregroundTreeSpawnChance)
            Instantiate(randomForegroundTree, spawnPosition.transform.position, Quaternion.identity);
    }

    void SpawnForegroundBush()
    {
        if (Random.value <= foregroundBushSpawnChance)
            Instantiate(randomForegroundBush, new Vector2(spawnPosition.transform.position.x, -9.0f), Quaternion.identity);
    }

    void SpawnBridgeSlat()
    {
        Instantiate(bridgeSlat, slatSpawnPosition.transform.position, Quaternion.identity);
    }
    void SpawnBanana()
    {
        if (Random.value <= bananaSpawnChance)
            Instantiate(bananaPickup, new Vector2(spawnPosition.transform.position.x, bananaSpawnOffset), Quaternion.identity);
    }
    void SpawnMonkey()
    {
        if (Random.value <= monkeySpawnChance)
            Instantiate(monkeyPickup, new Vector2(spawnPosition.transform.position.x, monkeySpawnOffset), Quaternion.identity);
    }
    void SpawnDrone()
    {
        if (Random.value <= droneSpawnChance)
            Instantiate(drone, new Vector2(spawnPosition.transform.position.x, monkeySpawnOffset), Quaternion.identity);
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

    public void Pickup(PickupType pickupType)
    {
        if (pickupType == PickupType.Bananna)
        {
            banannas += 1;
            bananaScore.text = $"x {banannas}";
            bananaIcon.GetComponent<Animator>().Play("Banana");
        }
        if (pickupType == PickupType.Monkey)
        {
            monkeys += 1;
            monkeyScore.text = $"x {monkeys}";
            monkeyIcon.GetComponent<Animator>().Play("MonkeyIconBounce");
        }
    }
}
