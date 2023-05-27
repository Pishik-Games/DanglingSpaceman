using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject LevelBaseOBJ;

    private GameObject CurrentLevelObj;
    public GameObject HandsUI;

    public UIManager UIManager;
    public Player Player;
    public GameObject ResetBtnOBJ;

    public static int currentLevel;
    public static int InThisLevelCurrentCoins = 0;

    public static int Coins = 0;
    private List<GameObject> TempCoins = new List<GameObject>();

    public static bool GamePaused = true;
    public static bool CanStartGame = true;

    // Start is called before the first frame update
    private void Awake()
    {
    }
    void Start()
    {
        CurrentLevelObj = null;
        currentLevel = 0; // You must change this to Create Save and Load System
        PauseGame();

    }

    // Update is called once per frame
    void Update()
    {
        SendCoinNumbers();
        if (GamePaused)
        {
            if (CanStartGame)
            {
                LevelStart();
            }
        }

    }

    public void PlayerWin()
    {
        Debug.Log("Win");
        AddNewCoins();
        Player.DeSpawnPlayer();
        PauseGame();
        NextLevel();
        //TODO WIN UI and Next Level 
    }
    public void PlayerLose()
    {
        Debug.Log("Lose");
        Player.DeSpawnPlayer();
        ResetBtnOBJ.SetActive(true);
        CanStartGame = false;
        PauseGame();
    }
    public void LevelStart()
    {
        if (CurrentLevelObj == null)
        {
            SpawnLevel();
        }
        
        HandsUI.SetActive(true);
        Player.SpawnPlayerInStartPos();
        if (InputManager.currentMode == InputMode.Nothing)
        {
            HandsUI.SetActive(false);
            UnpauseGame();
        }
    }
    public void RestartLevel()
    {
        CanStartGame = true;

        ResetBtnOBJ.SetActive(false);
        InThisLevelCurrentCoins = 0;
        ResetCoins();
        Player.SpawnPlayerInStartPos();
    }
    public void NextLevel()
    {
        Destroy(CurrentLevelObj);
        currentLevel += 1;
    }



    public void SendCoinNumbers()
    {
        UIManager.ShowCoins(Coins);
    }

    public void PauseGame()
    {
        GamePaused = true;
        Time.timeScale = 0.0f;

    }

    public void UnpauseGame()
    {
        GamePaused = false;
        Time.timeScale = 1.0f;

    }

    public void AddNewCoins()
    {
        Coins += InThisLevelCurrentCoins;
        InThisLevelCurrentCoins = 0;
    }

    public List<GameObject> FindCoinsInCurrentLevel()
    {
        List<GameObject> CoinSearchResault = new List<GameObject>();
        var CoinParentObj = CurrentLevelObj.transform.Find("Coins");
        if (CoinParentObj != null)
        {
            foreach (Transform Coin in CoinParentObj.transform)
            {
                if (Coin.gameObject.name.Contains("Coin"))
                {
                    CoinSearchResault.Add(Coin.gameObject);
                }
            }


        }
        return CoinSearchResault;
    }
    public void ResetCoinsInCurrentLevel(List<GameObject> Coins)
    {
        foreach (GameObject coin in Coins)
        {
            coin.SetActive(true);
        }

    }

    public void ResetCoins()
    {

        TempCoins.Clear();
        TempCoins = FindCoinsInCurrentLevel();
        ResetCoinsInCurrentLevel(TempCoins);
    }
    public void SpawnLevel()
    {
        var level = Resources.Load("Prefabs/Levels/level" + currentLevel) as GameObject;
        if (level == null) return;// Player Finished All Levels or Cant Find Level
        CurrentLevelObj = Instantiate(level);
        CurrentLevelObj.transform.SetParent(LevelBaseOBJ.transform);
        CurrentLevelObj.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        CurrentLevelObj.name = level.name;
    }
}
