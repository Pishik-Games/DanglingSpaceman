using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndRelease : MonoBehaviour
{
    public LineRenderer LineRenderer;
    public Rigidbody2D Rigidbody2D;

    public Material material;
    public float startWidth;
    public float endWidth;
    public Color startColor = Color.green;
    public Color endColor = Color.red;

    // Start is called before the first frame update
    void Start()
    {

        LineRenderer.enabled = false;
        LineRenderer.positionCount = 2;
        LineRenderer.material = material;
        LineRenderer.startWidth = startWidth;
        LineRenderer.endWidth = endWidth;
        LineRenderer.startColor = startColor;
        LineRenderer.endColor = endColor;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            { //A finger touched the screen.
                Vector2 StartPos = Camera.main.ScreenToWorldPoint(touch.position);
                LineRenderer.SetPosition(0, StartPos);
                LineRenderer.SetPosition(1, StartPos);
                LineRenderer.enabled = true;

            }
            else if (touch.phase == TouchPhase.Moved)
            {//A finger moved on the screen. 
                Vector2 endPos = Camera.main.ScreenToWorldPoint(touch.position);
                LineRenderer.SetPosition(1, endPos);

            }
            else if (touch.phase == TouchPhase.Ended)
            {//A finger was lifted from the screen. 
                LineRenderer.enabled = false;
                Vector3 ForcePower = LineRenderer.GetPosition(0) - LineRenderer.GetPosition(1);
                Rigidbody2D.AddForce(ForcePower, ForceMode2D.Impulse);
            }

        }
    }
}
