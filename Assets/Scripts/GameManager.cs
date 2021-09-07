using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    int score;
    private int lives = 3;
    private bool pause;
    
    public static GameManager instance;
    [SerializeField]
    private GameObject resumePanel;

    [SerializeField]
    Text scoreText;

    [SerializeField]
    PlayerMovement playerMovement;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public int Score { 
        get { return score; }
        set { 
            score = value;
            playerMovement.IncreaseSpeed();
            scoreText.text = "SCORE: " + score;
           
        }
    }

    public void AddScore()
    {
        score++;
        playerMovement.IncreaseSpeed();
        scoreText.text = "SCORE: " + score;
    }
    public int Lives
    {
        get { return lives; }
        set
        {
            lives = value;
            //scoreText.text = "SCORE: " + score;

            if (lives < 1) 
            {
                playerMovement.Die();
            }
            
        }
    }

    public void PauseGame()
    {
        
        Time.timeScale = 0;
        resumePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        resumePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
