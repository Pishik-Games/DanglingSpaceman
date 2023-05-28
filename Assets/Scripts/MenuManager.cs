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

    private void Start(){
        deactiveAll();
        showGameLogo(); // skipping Pishik Games logo becouse it shows with unity logo
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
    private void showSettings(){} // TODO
    private void backFromSettings(){} // TODO
    private void showLevelSelection(){} // TODO
    private void selectLevel(int level){} // TODO
    private void startGame(){} // TODO
    private void onLost(){} // TODO
    private void onWin(){} // TODO
    private void onReplayClicked(){} // TODO
    private void onNextLevelClicked(){} // TODO
    private void onMenuSelectionClicked(){} // TODO

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