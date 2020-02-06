using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPllatform : MonoBehaviour
{

    public PlatformEffector2D effector;
    public float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            waitTime = 0.5f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (waitTime <= 0)
            {
                effector.rotationalOffset = 180f;
                waitTime = 0.25f;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                effector.rotationalOffset = 0f;
            }
        }
    }
}
