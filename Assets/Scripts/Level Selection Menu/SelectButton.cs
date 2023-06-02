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
    private Button button;
    private Image image;

    private void Awake()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
    }

    public void Setup(int level, bool isUnlocked)
    {
        this.level = level;
        if (isUnlocked)
        {
            levelText.text = level.ToString();
            image.sprite = unlockImageSprite;
            button.enabled = true;
            levelText.gameObject.SetActive(true);

        }
        else
        {
            image.sprite = lockImageSprite;
            button.enabled = false;
            levelText.gameObject.SetActive(false);
        }
    }

    public void OnClick()
    {
        MenuManager.instance.selectLevel(level);
    }
}
