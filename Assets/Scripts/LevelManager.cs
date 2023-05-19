using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject PlayerOBJ;
    public static bool GamePaused = true;
    public GameObject HandsUI;
    // Start is called before the first frame update
    void Start()
    {
        if(GamePaused){
            Time.timeScale = 0.0f;
            HandsUI.SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
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
        LevelStart();

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
}
