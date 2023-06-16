using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackWhole : MonoBehaviour
{
    public bool enable = true;
    public void WhenBorderTriggerEnter(Collider2D other, GameObject gameObject)
    {
        if (gameObject.tag == "Player")
        {
            gameObject.transform.position = Vector2.MoveTowards
                (gameObject.transform.position,
                    this.transform.position,
                    0.1f * Time.deltaTime);
            //gameObject.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.position);
        }
    }
    public void WhenCenterTriggerEnter(Collider2D other, GameObject gameObject)
    {
        if (gameObject.tag == "Player" && enable)
        {
            enable = false;
            var Animator = gameObject.GetComponent<Animator>();
            Animator.Play("LostInBlackWhole");
            StartCoroutine(WaitForSecondToSendLose());
        }
    }

    IEnumerator WaitForSecondToSendLose()
    {

        Debug.Log("timer");
        yield return new WaitForSeconds(0.9f); // Ali change this from 1 to 0.9f to fix visual glich
        Debug.Log("Lose");
        LevelManager.instance.playerLose();
        enable = true;
    }
}
