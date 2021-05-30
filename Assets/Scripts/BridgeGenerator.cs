using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeGenerator : MonoBehaviour
{
    public GameObject bridgeSlat;
    public GameObject ropes;
    public int totalSlats = 20;
    public float slatYOffsetMax = 0.5f;
    public float slatYOffsetMin = -1.5f;
    // Start is called before the first frame update
    void Start()
    {
        GenerateSlats();
    }

    void GenerateSlats()
    {
        for (var a = 0; a < totalSlats; a++)
        {
            Instantiate(bridgeSlat, new Vector2((a * 3 )- (ropes.transform.right.x * -1), Random.Range(slatYOffsetMin, slatYOffsetMax)), Quaternion.identity).transform.parent = transform;
        }
    }
}
