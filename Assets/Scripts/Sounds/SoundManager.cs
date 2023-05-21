using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour{
    public AudioSource pispis;

    void Update(){
        if (LevelManager.GamePaused){
            StopPispis();
            return;
        }

        if (InputManager.currentMode == InputMode.Nothing)
            StopPispis();
        else 
            PlayPisPis();

    }

    public void PlayPisPis(){
        if (pispis.isPlaying) return;
        pispis.Play();
    }
    public void StopPispis(){
        if (!pispis.isPlaying) return;
        pispis.Pause();
    }
}
