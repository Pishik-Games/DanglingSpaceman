using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour{
    public GameObject levelParent;
    public GameObject handsUI;
    public GameObject playerEntry;
    public GameObject player;

    private GameObject levelGameObject = null;

    private int levelId;
    private int earnedCoins = 0;

    public static LevelManager instance { get; private set; }
    void Awake(){ instance = this; }

    void Update(){ 
        handsUI.SetActive(MenuManager.GameState == GameState.WaitForPlayerFingers);
    }

    public void loadLevel(int level){
        if(levelGameObject) Destroy(levelGameObject);
        levelGameObject = null;
        levelId = level;
        SpawnLevel();
        resetPlayerPosition();
        MenuManager.GameState = GameState.WaitForPlayerFingers;
    }

    private void resetPlayerPosition(){
        try{
            player.transform.position = playerEntry.transform.position;
            player.transform.rotation = playerEntry.transform.rotation;
            var rg = player.GetComponent<Rigidbody2D>();
            rg.velocity = Vector2.zero;
            rg.angularVelocity = 0;
        }catch{}
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
