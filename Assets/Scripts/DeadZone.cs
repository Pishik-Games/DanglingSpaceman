using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public LevelManager LevelManager;
    private void OnTriggerEnter2D(Collider2D other) {
            if(other.gameObject.tag == "Player"){
                LevelManager.PlayerLose();
            }       
    }
}
