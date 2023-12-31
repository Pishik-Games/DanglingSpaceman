using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            this.GetComponent<Animator>().Play("PlayerCollide");
            SoundManager.instance.PlayBonceSound();
        }
    }
}
