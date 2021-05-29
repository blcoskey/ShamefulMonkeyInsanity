using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnzone : MonoBehaviour
{
    public GameObject LevelManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        LevelManager.GetComponent<LevelManager>().SpawnBackground(other.gameObject.tag);
    }
}
