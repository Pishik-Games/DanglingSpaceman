using UnityEngine;


class MenuManager : MonoBehaviour{

    public static GameState GameState = GameState.PishikGamesLogo;

    public GameObject starsBackground;
    public GameObject pishikLogo;
    public GameObject gameLogo;
    public GameObject menuLayout;
    public GameObject settingsLayout;
    public GameObject levelSelectionLayout;
    public GameObject playgroundLayout;
    public GameObject reportLayout;

    public static MenuManager instance { get; private set; }

    private void Start(){
        instance = this;
        deactiveAll();
        showGameLogo(); // skipping Pishik Games logo becouse it shows with unity logo
    }

    void Update(){
        if(
            MenuManager.GameState == GameState.WaitForPlayerFingers && 
            InputManager.currentMode == InputMode.Nothing
        ) startGame();
    }


    private void showPishikGamesLogo(){} // TODO
    private void showGameLogo(){
        GameState = GameState.GameLogo;
        deactiveAll();
        gameLogo.SetActive(true);
        Utilities.setTimeout(this, () => {
            // skipping Pishik Games logo becouse it shows with unity logo
            showMainMenu();
        }, 2);
    } 
    private void showMainMenu(){
        GameState = GameState.Menu;
        deactiveAll();
        menuLayout.SetActive(true);
    } 
    public void showSettings(){
        GameState = GameState.Settings;
        deactiveAll();
        settingsLayout.SetActive(true);
    }
    public void backFromSettings(){
        GameState = GameState.Menu;
        deactiveAll();
        menuLayout.SetActive(true);
    }
    public void showLevelSelection(){
        GameState = GameState.LevelSelecction;
        deactiveAll();
        levelSelectionLayout.SetActive(true);

        // TODO level selection callback and call selectLevel(level)
    }
    public void loadNextLevel(){
        Debug.Log("Loading next level");
        selectLevel(0);// TODO load last played level from database
    }
    private void selectLevel(int level){
        GameState = GameState.WaitForPlayerFingers;
        deactiveAll();
        playgroundLayout.SetActive(true);
        LevelManager.instance.loadLevel(level);
    } 
    private void startGame(){
        // automatically starts physic and everything
        MenuManager.GameState = GameState.Playing; 
    }
    public void onLost(int level, int score){} // ignore
    public void onWin(int level, int score){
        GameState = GameState.ReportScreen;
        deactiveAll();
        reportLayout.SetActive(true);
        // TODO pass report data to report layout to show 
        // TODO set report click listeners
    }
    private void onReplayClicked(){
        GameState = GameState.WaitForPlayerFingers;
        LevelManager.instance.reload();
    } 
    private void onNextLevelClicked(){
        GameState = GameState.WaitForPlayerFingers;
        LevelManager.instance.loadNextLevel();
    } 
    private void onMenuSelectionClicked(){
        GameState = GameState.Menu;
        deactiveAll();
        menuLayout.SetActive(true);
    }

    private void deactiveAll(){
        // starsBackground.SetActive(false); // not this
        pishikLogo.SetActive(false);
        gameLogo.SetActive(false);
        menuLayout.SetActive(false);
        settingsLayout.SetActive(false);
        levelSelectionLayout.SetActive(false);
        playgroundLayout.SetActive(false);
        reportLayout.SetActive(false);
    }
}

enum GameState{
    PishikGamesLogo,
    GameLogo,
    Menu,
    Settings,
    LevelSelecction,
    WaitForPlayerFingers,
    Playing,
    ReportScreen,
}