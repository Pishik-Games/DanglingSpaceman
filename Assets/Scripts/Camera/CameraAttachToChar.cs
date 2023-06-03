
using UnityEngine;

public class CameraAttachToChar : MonoBehaviour
{
    public GameObject PlayerObj;
    float X, Y;
    // Update is called once per frame
    void Update()
    {
        if (MenuManager.GameState == GameState.Playing ||
         MenuManager.GameState == GameState.WaitForPlayerFingers)
        {
            Y = PlayerObj.transform.position.y;
            Vector3 Pos = new Vector3(transform.position.x, Y + 3.0f, transform.position.z);
            transform.position = Pos;
        }
    }
}
