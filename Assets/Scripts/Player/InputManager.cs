using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputMode currentMode;
    private void Update()
    {

        var rightInput = false;
        var leftInput = false;
        for (var i = 0; i < Input.touchCount; i++)
        {
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
        if (rightInput && !leftInput) currentMode = InputMode.SpinRight;
        else if (!rightInput && leftInput) currentMode = InputMode.SpinLeft;
        else if (rightInput && leftInput) currentMode = InputMode.Nothing;
        else if (!rightInput && !leftInput) currentMode = InputMode.Forward;



    }
}

public enum InputMode
{
    SpinRight = 0,
    SpinLeft = 1,
    Forward = 2,
    Nothing = 3,
}