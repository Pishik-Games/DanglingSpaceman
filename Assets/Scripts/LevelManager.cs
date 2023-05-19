using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject PlayerOBJ;
    public GameObject HandsUI;

    public UIManager UIManager;

    public static int currentLevel;
    public static int InThisLevelCurrentCoins = 0;

    public static bool GamePaused = true;

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = 1; // You must change this to Create Save and Load System
        if(GamePaused){
            Time.timeScale = 0.0f;
            HandsUI.SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        SendCoinNumbers();
        if (GamePaused){
            if(InputManager.currentMode == InputMode.Nothing){
                LevelStart();
                Debug.Log("called");
            }    
        }
        
    }

    public void PlayerWin(){
        Debug.Log("Win");
        PlayerOBJ.SetActive(false);
        NextLevel();
        //TODO WIN UI and Next Level 
    }
    public void PlayerLose(){
        Debug.Log("Lose");
        Destroy(PlayerOBJ);
        RestartLevel();

    }
     public void LevelStart(){
        GamePaused = false;
        Time.timeScale = 1.0f;
        HandsUI.SetActive(false);
     }
     public void RestartLevel(){
        Time.timeScale = 0.0f;
     }
     public void NextLevel(){
        
     }



     public void SendCoinNumbers(){
            UIManager.ShowCoins(InThisLevelCurrentCoins);
     }
}
