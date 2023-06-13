
using UnityEngine;

public class CameraAttachToChar : MonoBehaviour
{
    public GameObject PlayerObj;

    public GameObject DeadZoneUp;
    public GameObject DeadZoneDown;
    float X, Y;
    // Update is called once per frame
    void Update()
    {
        if (MenuManager.GameState == GameState.Playing ||
         MenuManager.GameState == GameState.WaitForPlayerFingers)
        {
            if (transform.position.y < DeadZoneUp.transform.position.y - 0.8f || transform.position.y < DeadZoneDown.transform.position.y + 0.8f)
            {
                Y = PlayerObj.transform.position.y;
                Vector3 Pos = new Vector3(transform.position.x, Y + 3.0f, transform.position.z);
                transform.position = Pos;

            }
        }
    }
}
