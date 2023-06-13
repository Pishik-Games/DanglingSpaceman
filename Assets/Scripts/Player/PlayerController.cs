using UnityEngine;


class PlayerController : MonoBehaviour
{

    public const float FORWARD_ACCELERATION = 0.3f;
    public const float TOP_SPEED = 1f;
    public const float DRAG = 0.05f;//

    // increasing drag on gas goes out help turnning somehow (message ali for more info)
    public const float BREAKING = 0.3f;//

    public const float ANG_ACCELERATION = 0.1f;
    public const float TOP_ANG_SPEED = 200f;
    public const float ANG_DRAG = 0.05f;//


    private Rigidbody2D rigidbody;
    //TODO: 

    public GameObject playerCloseMode;
    public GameObject playerOpenMode;
    public GameObject playerOpenRightMode;
    public GameObject playerOpenLeftMode;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.drag = DRAG;
        rigidbody.angularDrag = ANG_DRAG;
    }

    private void FixedUpdate()
    {
        if (MenuManager.GameState == GameState.Playing)
        {
            visual();
            physical();
        }
    }

    private void physical()
    {

        rigidbody.drag = InputManager.currentMode == InputMode.Forward ? BREAKING : DRAG; // for better turning

        var speed = Vector2.Distance(Vector2.zero, rigidbody.velocity);
        var angSpeed = rigidbody.angularVelocity;
        angSpeed = angSpeed > 0 ? angSpeed : -1 * angSpeed; // abs
        switch (InputManager.currentMode)
        {
            case InputMode.Forward:
                if (speed + FORWARD_ACCELERATION > TOP_SPEED) return; // throttle cut off
                rigidbody.AddForce(transform.up * FORWARD_ACCELERATION);
                break;
            case InputMode.SpinRight:
                if (angSpeed + ANG_ACCELERATION > TOP_ANG_SPEED) return; // throttle cut off
                rigidbody.AddTorque(-1 * ANG_ACCELERATION);
                rigidbody.AddForce(transform.up * 0.02f);
                break;
            case InputMode.SpinLeft:
                if (angSpeed + ANG_ACCELERATION > TOP_ANG_SPEED) return; // throttle cut off
                rigidbody.AddTorque(ANG_ACCELERATION);
                rigidbody.AddForce(transform.up * 0.02f);
                break;
        }
    }

    private void visual()
    {

        switch (InputManager.currentMode)
        {
            case InputMode.Forward:
                playerCloseMode.SetActive(false);
                playerOpenMode.SetActive(true);
                playerOpenRightMode.SetActive(false);
                playerOpenLeftMode.SetActive(false);
                break;
            case InputMode.SpinRight:
                playerCloseMode.SetActive(false);
                playerOpenMode.SetActive(false);
                playerOpenRightMode.SetActive(false);
                playerOpenLeftMode.SetActive(true);
                break;
            case InputMode.SpinLeft:
                playerCloseMode.SetActive(false);
                playerOpenMode.SetActive(false);
                playerOpenRightMode.SetActive(true);
                playerOpenLeftMode.SetActive(false);
                break;
            case InputMode.Nothing:
                playerCloseMode.SetActive(true);
                playerOpenMode.SetActive(false);
                playerOpenRightMode.SetActive(false);
                playerOpenLeftMode.SetActive(false);
                break;
        }

    }
}