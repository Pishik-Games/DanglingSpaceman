using UnityEngine;

public class InputManager : MonoBehaviour
{
    private string inputType;
    public static InputMode currentMode;

    private bool rightInput = false;
    private bool leftInput = false;
    private void Awake()
    {
        if (Application.isMobilePlatform)
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
            default:
                CheckTouchInputs();
                break;
        }
        if (rightInput && !leftInput) currentMode = InputMode.SpinRight;
        else if (!rightInput && leftInput) currentMode = InputMode.SpinLeft;
        else if (rightInput && leftInput) currentMode = InputMode.Nothing;
        else if (!rightInput && !leftInput) currentMode = InputMode.Forward;

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
                if (pos.x > 0) rightInput = true;
                else leftInput = true;
                // Debug.Log("w2:" + w2 + " pos.x:" + pos.x);
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
        Debug.Log(inputType + " " + rightInput + leftInput);
    }
}

public enum InputMode
{
    SpinRight = 0,
    SpinLeft = 1,
    Forward = 2,
    Nothing = 3,
}

