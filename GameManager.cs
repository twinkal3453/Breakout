using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Lives = 3;
    public int Bricks = 36;
    public float ResetDelay;
    public Text txtLives = null;
    public GameObject GameOver = null;
    public GameObject YouWon = null;
    public GameObject BricksPrefab = null;
    public GameObject Paddle = null;
    public GameObject pfDeathParticle = null;
    public static GameManager Instance = null;

    private GameObject clonePaddle = null;

    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(gameObject);
        }
        SetUp();
    }

    public void SetUp()
    {
        if(Paddle != null)
        {
            clonePaddle = Instantiate(Paddle, Paddle.transform.position, Quaternion.identity) as GameObject;
        }
        
        if (BricksPrefab != null)
        {
            Instantiate(BricksPrefab, BricksPrefab.transform.position, Quaternion.identity);
        }
    }
    void CheckGameOver()
    {
        if(Bricks <= 1)
        {
            if(YouWon != null)
            {
                YouWon.SetActive(true);
                Time.timeScale = 0.25f;
                Invoke("Reset", ResetDelay);
            }
        }
        if(Lives < 1)
        {
            if (GameOver != null)
            {
                GameOver.SetActive(true);
                Time.timeScale = 0.25f;
                Invoke("Reset", ResetDelay);
            }
        }
    }

    void Reset()
    {
        Time.timeScale = 1f;
        //Application.LoadLevel(Application.loadedLevel);
        SceneManager.LoadScene(0);
    }
    public void LoseLife()
    {
        Lives--;
        
        if(txtLives != null)
        {
            txtLives.text = "Lives : " + Lives;
        }
        
        if(pfDeathParticle != null)
        {
            Instantiate(pfDeathParticle, clonePaddle.transform.position, Quaternion.identity);
        }
        Destroy(clonePaddle.gameObject);
        Invoke("SetupPaddle", ResetDelay);
        CheckGameOver();
    }

    private void SetupPaddle()
    {
        clonePaddle = Instantiate(Paddle, transform.position, Quaternion.identity) as GameObject;
    }

    public void DestroyBrick()
    {
        Bricks--;
        CheckGameOver();
    }
}
