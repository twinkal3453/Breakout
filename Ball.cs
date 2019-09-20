using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float BallInitialVelocity = 600f;
    private Rigidbody ballRigidBody = null;
    private bool isBallInPlay = false;

    void Awake()
    {
        ballRigidBody = GetComponent<Rigidbody>();     
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isBallInPlay)
        {
            transform.parent = null;
            isBallInPlay = true;
            ballRigidBody.isKinematic = false;
            ballRigidBody.AddForce(new Vector3(BallInitialVelocity, BallInitialVelocity, 0f));
        }
    }
}
