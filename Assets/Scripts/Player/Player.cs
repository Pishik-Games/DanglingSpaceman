using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float TotalPisPisGas = 100.0f;
    private float CurrentPisPisGas = 1.0f;
    public GameObject PlayerOBJ;
    public Vector3 PlayerStartPos;
    public UIManager UIManager;

    public static Player instance { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        // PlayerOBJ = GameObject.Find("PlayGround/Player");
        PlayerStartPos = PlayerOBJ.transform.position;
        UIManager.ShowPisPisBar(Mathf.Clamp01(CurrentPisPisGas));

    }
    public void SpawnPlayerInStartPos(int level)
    {
        try
        {
            PlayerOBJ.transform.position = PlayerStartPos;
            PlayerOBJ.transform.rotation = Quaternion.Euler(Vector3.forward);
            PlayerOBJ.SetActive(true);
            var rg = PlayerOBJ.GetComponent<Rigidbody2D>();
            rg.velocity = Vector2.zero;
            rg.angularVelocity = 0;

        }
        catch { }
        TotalPisPisGas = DB.getLevelPisPis(level);
        CurrentPisPisGas = TotalPisPisGas;
        UIManager.ShowPisPisBar(Mathf.Clamp01(CurrentPisPisGas));
    }
    public void DeSpawnPlayer()
    {

        PlayerOBJ.SetActive(false);
    }

    void FixedUpdate()
    {
        if (MenuManager.GameState == GameState.Playing)
        {
            CheckPisPis();
        }
    }

    public void CheckPisPis()
    {
        if (CurrentPisPisGas <= 0)
        {
            LevelManager.instance.playerLose();
        }
        if (MenuManager.GameState == GameState.Playing)
        {
            if (!(InputManager.currentMode == InputMode.Nothing))
            {
                if (InputManager.currentMode == InputMode.Forward)
                {
                    CurrentPisPisGas = CurrentPisPisGas - 0.1f * Time.deltaTime;

                }
                else
                {
                    CurrentPisPisGas = CurrentPisPisGas - 0.05f * Time.deltaTime;
                }
                UIManager.ShowPisPisBar(Mathf.Clamp01(CurrentPisPisGas / TotalPisPisGas));
            }
        }

    }
}


public enum FaceStatus
{
    happy,
    normal,
    worried,
    worried1,
    worried2,
    worried3,
    worried4,
    sad,

}