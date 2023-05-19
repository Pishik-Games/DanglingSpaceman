using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject PlayerOBJ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerWin(){
        Debug.Log("Win");
        PlayerOBJ.SetActive(false);
        //TODO WIN UI and Next Level 
    }
    public void PlayerLose(){
        Debug.Log("Lose");
        Destroy(PlayerOBJ);

    }
}
