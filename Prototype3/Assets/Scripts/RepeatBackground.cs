using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// for background
public class RepeatBackground : MonoBehaviour
{
    // background start pos
    private Vector3 startPos;
    private float repeatWidht;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        // take half of background in x-axis
        repeatWidht = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {   // repeat background
        if (transform.position.x < startPos.x - repeatWidht)
        {
            transform.position = startPos;
        }
    }
}
