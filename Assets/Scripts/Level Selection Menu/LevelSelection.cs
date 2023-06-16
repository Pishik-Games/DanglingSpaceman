using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelection : MonoBehaviour
{
    public int totalLevel = 0;

    public int totalSession = 2;
    public int lastSessionunlocked = 1;

    public int lastLevelUnlocked = 0;

    public SelectButton[] selectButtons;

    public int totalPage = 0;

    public int page = 1;
    public int itemsInPage = 30;


    public GameObject NextButton;
    public GameObject BackButton;


    public static LevelSelection instance
    { get; private set; }
    void Start()
    {
        Refresh();
    }

    void Awake()
    {
        instance = this;
        selectButtons = GetComponentsInChildren<SelectButton>();
    }

    public void ClickNextPage()
    {
        page += 1;
        Refresh();
    }
    public void ClickBackPage()
    {
        page -= 1;
        Refresh();

    }

    public void Refresh()
    {
        //lastSessionunlocked = DB.loadLastSessionUnlocked();
        lastLevelUnlocked = DB.loadLastUnlockedLevel();

        totalPage = totalLevel / itemsInPage;

        int index = page * itemsInPage;
        for (int i = 0; i < selectButtons.Length; i++)
        {
            int level = index + i + 1;
            if (level <= totalLevel)
            {
                selectButtons[i].gameObject.SetActive(true);
                selectButtons[i].Setup(level, level <= lastLevelUnlocked);

                // badge
                var badge = selectButtons[i].gameObject.GetComponent<Badge>();
                if(level>lastLevelUnlocked-1){
                    badge.clear();
                }else{
                    var score = DB.LoadLevelEarnedCoins(level);
                    if (score < 2) badge.onBronze();
                    else if (score < 3) badge.onSilver();
                    else badge.onGold();
                }
                
            }
            else
            {
                selectButtons[i].gameObject.SetActive(false);
            }

        }
        CheckPageButton();
    }
    private void CheckPageButton()
    {
        BackButton.SetActive(page > 0);
        NextButton.SetActive(page < totalPage - 1);
    }
}

