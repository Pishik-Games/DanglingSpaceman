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
    public GameObject happyFace;
    public GameObject normalFace;
    public GameObject worriedFace;
    public GameObject worried1Face;
    public GameObject worried2Face;
    public GameObject worried3Face;
    public GameObject worried4Face;
    public GameObject sadFace;

    public GameObject DeadZoneUp;
    public GameObject DeadZoneDown;
    public GameObject DeadZoneRight;
    public GameObject DeadZoneLeft;

    public static Player instance { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        // PlayerOBJ = GameObject.Find("PlayGround/Player");
        PlayerStartPos = PlayerOBJ.transform.position;
        UIManager.ShowPisPisBar(Mathf.Clamp01(CurrentPisPisGas));

    }
    public void SpawnPlayerInStartPos()
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
            var distUp = Vector2.Distance(PlayerOBJ.transform.position, DeadZoneUp.transform.position);
            var distDown = Vector2.Distance(PlayerOBJ.transform.position, DeadZoneDown.transform.position);
            var distR = Vector2.Distance(PlayerOBJ.transform.position, DeadZoneRight.transform.position);
            var distL = Vector2.Distance(PlayerOBJ.transform.position, DeadZoneLeft.transform.position);
            var LerpDownAndUp = Mathf.Lerp(distUp, distDown, 0.0f);
            var LerpRightAndLeft = Mathf.Lerp(distR, distL, 0.0f);
            var dist = Mathf.Lerp(LerpDownAndUp, LerpRightAndLeft, 0.0f);
            //TODO check Other 2 DeadZone For Better accurate
            if (dist < 0.5f)
            {
                SetHeadStatus(FaceStatus.happy);
            }
            else if (dist < 1f)
            {
                SetHeadStatus(FaceStatus.normal);

            }
            else if (dist < 1.5f)
            {
                SetHeadStatus(FaceStatus.worried);

            }
            else if (dist < 2f)
            {
                SetHeadStatus(FaceStatus.worried1);

            }
            else if (dist < 2.5f)
            {
                SetHeadStatus(FaceStatus.worried2);

            }
            else if (dist < 3f)
            {
                SetHeadStatus(FaceStatus.worried2);

            }
            else if (dist < 3.5f)
            {
                SetHeadStatus(FaceStatus.worried3);

            }
            else if (dist < 4.0f)
            {
                SetHeadStatus(FaceStatus.worried3);

            }
            else if (dist < 4.0f)
            {
                SetHeadStatus(FaceStatus.worried4);

            }
            else if (dist >= 4.0f)
            {
                SetHeadStatus(FaceStatus.sad);

            }
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

    public void SetHeadStatus(FaceStatus status)
    {
        DisableOtherFaces();
        switch (status)
        {
            case FaceStatus.happy:
                happyFace.SetActive(true);
                break;

            case FaceStatus.normal:
                normalFace.SetActive(true);

                break;
            case FaceStatus.worried:
                worriedFace.SetActive(true);

                break;
            case FaceStatus.worried1:
                worried1Face.SetActive(true);

                break;
            case FaceStatus.worried2:
                worried2Face.SetActive(true);

                break;
            case FaceStatus.worried3:
                worried3Face.SetActive(true);

                break;
            case FaceStatus.worried4:
                worried4Face.SetActive(true);

                break;
            case FaceStatus.sad:
                sadFace.SetActive(true);

                break;
        }
        void DisableOtherFaces()
        {
            happyFace.SetActive(false);
            normalFace.SetActive(false);
            worriedFace.SetActive(false);
            worried1Face.SetActive(false);
            worried2Face.SetActive(false);
            worried3Face.SetActive(false);
            worried4Face.SetActive(false);
            sadFace.SetActive(false);

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