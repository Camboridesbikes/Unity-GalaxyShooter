using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public bool gameOn = false;
    
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private GameObject SpawnManager;

    private UIManager _uiManager;

    private void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    void Update () {
        if (!gameOn)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameOn = true;
                StartGame(); 
            }
        }
    }

    public void StartGame()
    {
  
        Instantiate(Player);
        Instantiate(SpawnManager);
        _uiManager.StartGame();
    }

    public void EndGame()
    {
        gameOn = false;
        GameObject player = GameObject.Find("Player(Clone)");
        if (player != null)
        {
            Destroy(player);
        }
        GameObject spawnManager = GameObject.Find("SpawnManager(Clone)");
        if (spawnManager != null)
        {
            Destroy(spawnManager);
        }
        _uiManager.EndGame();


    }
}
