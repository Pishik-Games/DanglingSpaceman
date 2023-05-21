using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public LevelManager LevelManager;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            LevelManager.InThisLevelCurrentCoins += 1;
            //Todo Some Sound And Effects
            gameObject.SetActive(false);
        }
    }
}
