using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float PaddleSpeed = 1f;
    private Vector3 playerPos = new Vector3(0f, -11.33f, 0f);

    //Use update for once per frame
    void Update()
    {
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * PaddleSpeed);
        playerPos = new Vector3(Mathf.Clamp(xPos, -9.9f, 9.9f), -11.33f, 0f);
        transform.position = playerPos;
    }
}
