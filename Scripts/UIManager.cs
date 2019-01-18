using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    private int score = 0; 

    public Sprite[] lives;
    public Image livesImageDisplay;
    public Text scoreText;
    public GameObject mainMenu;


    private void Update()
    {
       
    }

    public void UpdateLives(int currentLives)
    {
        livesImageDisplay.sprite = lives[currentLives];
    }

    public void UpdateScore()
    {
        score += 10;
        scoreText.text = "Score: " + score;
    }

   public void StartGame()
    {
        score = 00;
        mainMenu.SetActive(false);
    }

    public void EndGame()
    {
        mainMenu.SetActive(true);


    }

}
