using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource pispis;
    public AudioSource BackGroundMusic;

    private void Awake()
    {
        if (SettingMenu.canPlaySound)
        {
            BackGroundMusic.Play();
        }
    }

    void Update()
    {
        if (SettingMenu.canPlaySound)
        {
            if (MenuManager.GameState != GameState.Playing)
            {
                StopPispis();
                return;
            }

            if (InputManager.currentMode == InputMode.Nothing)
                StopPispis();
            else
                PlayPisPis();

        }

    }

    public void PlayPisPis()
    {
        if (pispis.isPlaying) return;
        pispis.Play();
    }
    public void StopPispis()
    {
        if (!pispis.isPlaying) return;
        pispis.Pause();
    }

    public void OnClickBackGroundMusic(bool canPlaySound)
    {
        if (canPlaySound)
        {
            BackGroundMusic.Play();
        }
        else
        {
            BackGroundMusic.Stop();
        }
    }
}
