using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public GameObject PlayerOBJ;
    public AudioSource pispis;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!LevelManager.GamePaused && PlayerOBJ.activeSelf)
        {

            if (!(InputManager.currentMode == InputMode.Nothing))
            {
                if (!pispis.isPlaying)
                {
                    PlayPisPis();
                }
            }
            else
            {
                StopPispis();
            }

        }
    }

    public void PlayPisPis()
    {
        pispis.Play();
        Debug.Log("LOWLOW" + InputManager.currentMode);
    }
    public void StopPispis()
    {
        pispis.Pause();
    }
}
