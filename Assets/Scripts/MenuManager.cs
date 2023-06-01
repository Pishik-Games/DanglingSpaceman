using UnityEngine;


class MenuManager : MonoBehaviour
{

    public static GameState GameState = GameState.PishikGamesLogo;
    public UIManager UIManager;

    public GameObject starsBackground;
    public GameObject pishikLogo;
    public GameObject gameLogo;
    public GameObject menuLayout;
    public GameObject settingsLayout;
    public GameObject levelSelectionLayout;
    public GameObject playgroundLayout;
    public GameObject reportLayout;

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
            InputManager.currentMode == InputMode.Nothing
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
    private void showMainMenu()
    {
        GameState = GameState.Menu;
        deactiveAll();
        menuLayout.SetActive(true);
    }
    public void showSettings()
    {
        GameState = GameState.Settings;
        deactiveAll();
        settingsLayout.SetActive(true);
    }
    public void backFromSettings()
    {
        GameState = GameState.Menu;
        deactiveAll();
        menuLayout.SetActive(true);
    }
    public void showLevelSelection()
    {
        GameState = GameState.LevelSelecction;
        deactiveAll();
        levelSelectionLayout.SetActive(true);

        // TODO level selection callback and call selectLevel(level)
    }
    public void loadLastUnlockedLevel()
    {
        Debug.Log("Loading next level");
        selectLevel(DB.loadLastUnlockedLevel());
    }
    public void selectLevel(int level)
    {
        if (level <= DB.loadLastUnlockedLevel())
        {
            GameState = GameState.WaitForPlayerFingers;
            deactiveAll();
            playgroundLayout.SetActive(true);
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
        UIManager.ShowAllCoins(DB.LoadNumberOfEarnedCoins().ToString());
        Debug.Log("onWin Called");
    }
    public void onReplayClicked()
    {
        GameState = GameState.WaitForPlayerFingers;
        deactiveAll();
        playgroundLayout.SetActive(true);
        LevelManager.instance.reload();
    }
    public void onNextLevelClicked()
    {
        GameState = GameState.WaitForPlayerFingers;
        deactiveAll();
        playgroundLayout.SetActive(true);
        LevelManager.instance.loadNextLevel();
    }
    public void onMenuSelectionClicked()
    {
        GameState = GameState.Menu;
        deactiveAll();
        menuLayout.SetActive(true);
    }

    private void deactiveAll()
    {
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

enum GameState
{
    PishikGamesLogo,
    GameLogo,
    Menu,
    Settings,
    LevelSelecction,
    WaitForPlayerFingers,
    Playing,
    ReportScreen,
}