using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject LevelBaseOBJ;
    public List<GameObject> Levels;
    public GameObject HandsUI;

    public UIManager UIManager;
    public Player Player;
    public GameObject ResetBtnOBJ;

    public static int currentLevel;
    public static int InThisLevelCurrentCoins = 0;

    public static int Coins = 0;
    public List<GameObject> TempCoins = new List<GameObject>();

    public static bool GamePaused = true;

    // Start is called before the first frame update
    private void Awake()
    {
        FindLevels();
    }
    void Start()
    {
        currentLevel = 0; // You must change this to Create Save and Load System
        if (GamePaused)
        {
            Time.timeScale = 0.0f;
            HandsUI.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        SendCoinNumbers();
        if (GamePaused)
        {
            if (InputManager.currentMode == InputMode.Nothing)
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
        NextLevel();
        //TODO WIN UI and Next Level 
    }
    public void PlayerLose()
    {
        Debug.Log("Lose");
        PauseGame();
        Player.DeSpawnPlayer();
        ResetBtnOBJ.SetActive(true);

    }
    public void LevelStart()
    {
        UnpauseGame();
        Levels[currentLevel].SetActive(true); // Start From Level 0
        HandsUI.SetActive(false);
    }
    public void RestartLevel()
    {
        ResetBtnOBJ.SetActive(false);
        InThisLevelCurrentCoins = 0;
        ResetCoins();
        Player.SpawnPlayerInStartPos();
        UnpauseGame();
    }
    public void NextLevel()
    {

        Levels[currentLevel].SetActive(false);
        currentLevel += 1;
        if ((Levels.Count - 1 >= currentLevel))
        {
            Levels[currentLevel].SetActive(true);
            Player.SpawnPlayerInStartPos();
        }

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

    public void FindLevels()
    {
        foreach (Transform levelOBJ in LevelBaseOBJ.transform)
        {
            if (levelOBJ.name.Contains("level"))
            {
                Levels.Add(levelOBJ.gameObject);

            }

        }
    }
    public void AddNewCoins()
    {
        Coins += InThisLevelCurrentCoins;
        InThisLevelCurrentCoins = 0;
    }

    public List<GameObject> FindCoinsInCurrentLevel()
    {
        var level = Levels[currentLevel];
        List<GameObject> CoinSearchResault = new List<GameObject>();
        var CoinParentObj = level.transform.Find("Coins");
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
}
