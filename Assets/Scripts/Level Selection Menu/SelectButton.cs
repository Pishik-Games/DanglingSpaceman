using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectButton : MonoBehaviour
{
    public Sprite lockImageSprite;
    public Sprite unlockImageSprite;
    public TextMeshProUGUI levelText;
    private int level = 0;

    private bool isUnlocked;
    private Button button;
    private Image image;
    public Animator LevelMenuAnimator;

    private void Awake()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
    }

    public void Setup(int level, bool isUnlocked)
    {
        this.isUnlocked = isUnlocked;
        this.level = level;
        if (isUnlocked)
        {
            levelText.text = level.ToString();
            image.sprite = unlockImageSprite;
            levelText.gameObject.SetActive(true);

        }
        else
        {
            image.sprite = lockImageSprite;
            levelText.gameObject.SetActive(false);
        }
    }

    public void OnClick()
    {
        if (isUnlocked)
        {

            MenuManager.instance.selectLevel(level);
        }
        else
        {
            LevelMenuAnimator.Play("Shake Lock Level");
        }
    }
}
