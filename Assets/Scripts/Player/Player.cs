using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject PlayerOBJ;
    public Vector2 PlayerStartPos;

    // Start is called before the first frame update
    void Start()
    {
        PlayerOBJ = GameObject.Find("Player");
        PlayerStartPos = PlayerOBJ.transform.position;
    }
    public void SpawnPlayerInStartPos()
    {
        PlayerOBJ.transform.position = PlayerStartPos;
        PlayerOBJ.transform.rotation = Quaternion.Euler(Vector3.forward);
        PlayerOBJ.SetActive(true);
    }
    public void DeSpawnPlayer()
    {

        PlayerOBJ.SetActive(false);
    }
}
