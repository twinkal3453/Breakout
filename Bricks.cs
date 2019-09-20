using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{
    public GameObject BrickParticle = null;


    private void OnCollisionEnter(Collision collision)
    {
        if (BrickParticle != null)
        {
            Instantiate(BrickParticle, transform.position, Quaternion.identity);

        }
        GameManager.Instance.DestroyBrick();
        Destroy(gameObject);
    }
}
