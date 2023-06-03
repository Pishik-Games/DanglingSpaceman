using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI CoinCounterObj;
    public TextMeshProUGUI reportMenuCoinCounterObj;

    public Image PisPisBar;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void ShowAllCoins(string CoinsNumber)
    {
        var txt = ("Coins:" + CoinsNumber);
        CoinCounterObj.text = CoinsNumber;
    }

    public void ShowReportCoins(string earnedCoins)
    {
        reportMenuCoinCounterObj.text = earnedCoins;
    }

    public void ShowPisPisBar(float PisPisGas)
    {
        PisPisBar.fillAmount = PisPisGas;
    }


}
