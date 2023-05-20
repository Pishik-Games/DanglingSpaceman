using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI CoinCounter;
    public Button RestartBtn;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowCoins(int CoinsNumber)
    {
        var txt = ("Coins:" + CoinsNumber.ToString());
        CoinCounter.text = txt;
    }


}
