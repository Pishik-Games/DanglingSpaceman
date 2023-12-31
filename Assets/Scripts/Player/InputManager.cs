using UnityEngine;
using System.Runtime.InteropServices;

public class InputManager : MonoBehaviour
{
    private string inputType;
    public static InputMode currentMode;

    private bool rightInput = false;
    private bool leftInput = false;

    #region WebGL is on moblie check 
    [DllImport("__Internal")]
    private static extern bool IsMobile();

    public bool isMoblie()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        return IsMobile();
#endif
        return false;
    }
    #endregion
    private void Awake()
    {
        Debug.Log(isMoblie());
        if (Application.isMobilePlatform || isMoblie())
        {
            inputType = "touch";
        }
        else
        {
            inputType = "keyboard";
        }


    }
    private void Update()
    {
        switch (inputType)
        {
            case "touch":
                CheckTouchInputs();
                break;
            case "keyboard":
                CheckKeyBoardInput();

                break;
        }
        if (rightInput && !leftInput) currentMode = InputMode.SpinRight;
        else if (!rightInput && leftInput) currentMode = InputMode.SpinLeft;
        else if (!rightInput && !leftInput) currentMode = InputMode.Nothing;
        else if (rightInput && leftInput) currentMode = InputMode.Forward;

        rightInput = false;
        leftInput = false;
    }
    public void CheckTouchInputs()
    {

        for (var i = 0; i < Input.touchCount; i++)
        {
            inputType = "touch";
            Touch touch = Input.GetTouch(i);

            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                //touch is moving or not moving(but pressed)
                Vector2 pos = Camera.main.ScreenToWorldPoint(touch.position);
                if (pos.x > 1)
                {
                    rightInput = true;
                }
                else if (pos.x < -1)
                {
                    leftInput = true;
                }
                else
                {
                    rightInput = true;
                    leftInput = true;
                }
                // Debug.Log("w2:" + w2 + " pos.x:" + pos.x);
            }
            else
            {
                rightInput = false;
                leftInput = false;

            }
        }

    }

    public void CheckKeyBoardInput()
    {
        var AD = Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D);
        var LR = Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow);
        if (AD || LR)
        {
            rightInput = true;
            leftInput = true;
        }
        else if ((Input.GetKey(KeyCode.A)) || Input.GetKey(KeyCode.LeftArrow))
        {
            leftInput = true;
        }
        else if ((Input.GetKey(KeyCode.D)) || Input.GetKey(KeyCode.RightArrow))
        {
            rightInput = true;
        }
        else
        {
            leftInput = false;
            rightInput = false;
        }
        //Debug.Log(inputType + " " + rightInput + leftInput);
    }
}

public enum InputMode
{
    SpinRight = 0,
    SpinLeft = 1,
    Forward = 2,
    Nothing = 3,
}

