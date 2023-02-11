using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager :  MonoBehaviour
{
    
    public GameObject obstaclePrefab;
    // repeat clone interval
    private float repeatRate;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        // give PlayerController component to playerControllerScript
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        //call method
        SpawnObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObstacle()
    {

        Vector3 spawnPos = new Vector3(25, 0, 0);
        //clone obstaclePrefab in spawnPos 
        if (playerControllerScript.gameOver == false)
        {
            // clone an obstaclePrefab
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
        // execute this method in range
        repeatRate = Random.Range(0.8f, 2.5f);
        Invoke("SpawnObstacle", repeatRate);
    }
}
