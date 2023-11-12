using UnityEngine;


class MenuManager : MonoBehaviour
{

    public static GameState GameState = GameState.PishikGamesLogo;
    public UIManager UIManager;

    public GameObject PlayerCamera;
    public GameObject MenuCamera;

    public GameObject starsBackground;
    public GameObject pishikLogo;
    public GameObject gameLogo;
    public GameObject tutorial;
    public GameObject tutorial_part1;
    public GameObject tutorial_part2;
    public GameObject tutorial_part3;
    public GameObject menuLayout;
    public GameObject settingsLayout;
    public GameObject AboutUsLayout;

    public GameObject levelSelectionLayout;
    public GameObject playgroundLayout;
    public GameObject reportLayout;

    public Badge reportBadge;
    public static MenuManager instance
    { get; private set; }

    private void Start()
    {
        instance = this;
        deactiveAll();
        showGameLogo(); // skipping Pishik Games logo becouse it shows with unity logo
    }

    void Update()
    {
        if (
            MenuManager.GameState == GameState.WaitForPlayerFingers &&
            !(InputManager.currentMode == InputMode.Nothing)
        ) startGame();
    }


    private void showPishikGamesLogo() { } // TODO
    private void showGameLogo()
    {
        GameState = GameState.GameLogo;
        deactiveAll();
        gameLogo.SetActive(true);
        Utilities.setTimeout(this, () =>
        {
            // skipping Pishik Games logo becouse it shows with unity logo
            showMainMenu();
        }, 2);
    }
    int tutorialPart = 0;
    public void showTutorial()
    {
        GameState = GameState.Tutorial;
        deactiveAll();
        tutorial.SetActive(true);

        tutorial_part1.SetActive(false);
        tutorial_part2.SetActive(false);
        tutorial_part3.SetActive(false);

        tutorialPart++;

        switch (tutorialPart)
        {
            case 1: tutorial_part1.SetActive(true); break;
            case 2: tutorial_part2.SetActive(true); break;
            case 3: tutorial_part3.SetActive(true); break;
            case 4: selectLevel(0); tutorialPart = 0; break;
        }
    }
    public void showMainMenu()
    {
        GameState = GameState.Menu;
        deactiveAll();
        menuLayout.SetActive(true);
        UIManager.ShowAllCoins(DB.LoadNumberOfEarnedCoins().ToString());
    }
    public void showSettings()
    {
        GameState = GameState.Settings;
        deactiveAll();
        settingsLayout.SetActive(true);
    }
    public void showAboutUs()
    {
        GameState = GameState.Settings;
        deactiveAll();
        AboutUsLayout.SetActive(true);
    }
    public void backFromSettings()
    {
        GameState = GameState.Menu;
        deactiveAll();
        menuLayout.SetActive(true);
        UIManager.ShowAllCoins(DB.LoadNumberOfEarnedCoins().ToString());
    }
    public void showLevelSelection()
    {
        GameState = GameState.LevelSelecction;
        deactiveAll();
        levelSelectionLayout.SetActive(true);
        LevelSelection.instance.Refresh();

        // TODO level selection callback and call selectLevel(level)
    }
    public void loadLastUnlockedLevel(){
        if (DB.loadLastUnlockedLevel() == 0){
            showTutorial();
        }
        else{
            if (DB.loadLastUnlockedLevel() <= LevelManager.TotalLevel){
                selectLevel(DB.loadLastUnlockedLevel());
            }else{
                selectLevel(LevelManager.TotalLevel );
            }
        }
    }
    public void selectLevel(int level)
    {
        if (level <= DB.loadLastUnlockedLevel())
        {
            GameState = GameState.WaitForPlayerFingers;
            deactiveAll();
            playgroundLayout.SetActive(true);
            MenuCamera.SetActive(false);
            PlayerCamera.SetActive(true);
            LevelManager.instance.loadLevel(level);
        }
    }
    private void startGame()
    {
        // automatically starts physics and everything
        MenuManager.GameState = GameState.Playing;
    }
    public void onLost(int level, int score) { } // ignore
    public void onWin(int level, int score, int allCoins)
    {
        GameState = GameState.ReportScreen;
        deactiveAll();
        reportLayout.SetActive(true);
        DB.SetLevelData(level, score, allCoins);

        UIManager.ShowReportCoins(score.ToString() + "/" + allCoins.ToString());

        if (score < 2)
        {
            reportBadge.onBronze();
        }
        else if (score < 3)
        {
            reportBadge.onSilver();
        }
        else
        {
            reportBadge.onGold();
        }
    }
    public void onReplayClicked()
    {
        GameState = GameState.WaitForPlayerFingers;
        deactiveAll();
        playgroundLayout.SetActive(true);
        MenuCamera.SetActive(false);
        PlayerCamera.SetActive(true);
        LevelManager.instance.reload();
    }
    public void onNextLevelClicked()
    {
            GameState = GameState.WaitForPlayerFingers;
            deactiveAll();
            playgroundLayout.SetActive(true);
            MenuCamera.SetActive(false);
            PlayerCamera.SetActive(true);
            Debug.Log(LevelManager.TotalLevel +" + "+ DB.loadLastUnlockedLevel());
        if (LevelManager.TotalLevel >= DB.loadLastUnlockedLevel()){
            LevelManager.instance.loadNextLevel();
        }else{
            LevelManager.instance.loadLevel(DB.loadLastUnlockedLevel() - 1);
        }
    }
    public void onMenuSelectionClicked()
    {
        GameState = GameState.Menu;
        deactiveAll();
        menuLayout.SetActive(true);
        UIManager.ShowAllCoins(DB.LoadNumberOfEarnedCoins().ToString());
    }

    private void deactiveAll()
    {
        // starsBackground.SetActive(false); // not this
        pishikLogo.SetActive(false);
        gameLogo.SetActive(false);
        tutorial.SetActive(false);
        menuLayout.SetActive(false);
        settingsLayout.SetActive(false);
        AboutUsLayout.SetActive(false);
        levelSelectionLayout.SetActive(false);
        playgroundLayout.SetActive(false);
        reportLayout.SetActive(false);
        MenuCamera.SetActive(true);
        PlayerCamera.SetActive(false);
    }
}

enum GameState
{
    PishikGamesLogo,
    GameLogo,
    Tutorial,
    Menu,
    Settings,
    LevelSelecction,
    WaitForPlayerFingers,
    Playing,
    ReportScreen,
}