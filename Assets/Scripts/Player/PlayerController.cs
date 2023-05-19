using UnityEngine;


class PlayerController : MonoBehaviour{
    
    public LevelManager LevelManager;
    public GameObject rightPiss;
    public GameObject leftPiss;
    private Rigidbody2D rigidbody;


    private void Start(){
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update(){
        if (!LevelManager.GamePaused){
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
                rightPiss.SetActive(true);
                leftPiss.SetActive(true);
                break;
            case InputMode.SpinRight:
                rightPiss.SetActive(false);
                leftPiss.SetActive(true);
                break;
            case InputMode.SpinLeft:
                rightPiss.SetActive(true);
                leftPiss.SetActive(false);
                break;
            case InputMode.Nothing:
                rightPiss.SetActive(false);
                leftPiss.SetActive(false);
                break;
        }

    }
}