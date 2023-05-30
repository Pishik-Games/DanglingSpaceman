using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStation : MonoBehaviour{
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player")
            LevelManager.instance.playerWin();
    }
}
