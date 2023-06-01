using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI CoinCounterObj;
    public TextMeshProUGUI reportMenuCoinCounterObj;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowCoins(string CoinsNumber)
    {
        //var txt = ("Coins:" + CoinsNumber.ToString());
        //CoinCounter.text = CoinsNumber;
    }

    public void ShowReportCoins(string earnedCoins)
    {
        reportMenuCoinCounterObj.text = earnedCoins;
    }


}
