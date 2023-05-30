using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour{
    public GameObject levelParent;
    public GameObject handsUI;

    private GameObject levelGameObject = null;

    private int levelId;
    private int earnedCoins = 0;

    public static LevelManager instance { get; private set; }
    void Start(){ instance = this; }

    void Update(){ 
        handsUI.SetActive(MenuManager.GameState == GameState.WaitForPlayerFingers);
    }

    public void loadLevel(int level){
        if(levelGameObject) Destroy(levelGameObject);
        levelGameObject = null;
        levelId = level;
        SpawnLevel();
        MenuManager.GameState = GameState.WaitForPlayerFingers;
    }

    public void loadNextLevel(){ loadLevel(levelId + 1); }
    public void reload(){ loadLevel(levelId); }

    public void increaseCoin(){ earnedCoins++; }

    public void playerWin(){
        MenuManager.instance.onWin(levelId, earnedCoins);
        earnedCoins = 0;
    }

    public void playerLose(){
        MenuManager.instance.onLost(levelId, earnedCoins);
        earnedCoins = 0;
        reload();
    }

    public void SpawnLevel(){
        var level = Resources.Load("Prefabs/Levels/level" + levelId) as GameObject;
        if (level == null) return;// Player Finished All Levels or Cant Find Level
        levelGameObject = Instantiate(level);
        levelGameObject.transform.SetParent(levelParent.transform);
        levelGameObject.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        levelGameObject.name = level.name;
    }

}
