using UnityEngine;


class PlayerController : MonoBehaviour{
    
    private Rigidbody2D rigidbody;

    public GameObject playerCloseMode;
    public GameObject playerOpenMode;
    public GameObject playerOpenRightMode;
    public GameObject playerOpenLeftMode;

    private void Start(){
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update(){
        if (MenuManager.GameState == GameState.Playing){
            visual();
            physical();
        }
    }

    private void physical(){
        switch(InputManager.currentMode){
            case InputMode.Forward:
                rigidbody.AddForce(transform.up * 0.2f);
                break;
            case InputMode.SpinRight:
                rigidbody.AddTorque(-0.05f);
                rigidbody.AddForce(transform.up * 0.02f);
                break;
            case InputMode.SpinLeft:
                rigidbody.AddTorque(0.05f);
                rigidbody.AddForce(transform.up * 0.02f);
                break;
        }
    }

    private void visual(){

        switch(InputManager.currentMode){
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