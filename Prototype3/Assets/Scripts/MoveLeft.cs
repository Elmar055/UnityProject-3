using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // speed for background and obstacles
    private float speed = 20f;
    // for use PlayerController class'es variables and methods
    private PlayerController playerControllerScript;
    // left limit for objects
    private float leftBound = -15f;

    // Start is called before the first frame update
    void Start()
    {
        // to give Player object's PlayerController component to playerControllerScript
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // if game doesn't over execute code
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        // for destrroy gameobjects(obstacle)
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
