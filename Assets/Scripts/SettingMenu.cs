using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SettingMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public Image SoundOff;
    public static bool canPlaySound = true;
    public Image MusicOff;
    public static bool canPlayMusic = true;

    public SoundManager soundManager;


    public void OnClickSound()
    {
        canPlaySound = !canPlaySound;
        SoundOff.gameObject.SetActive(!canPlaySound);
    }

    public void OnClickMusic()
    {
        canPlayMusic = !canPlayMusic;
        MusicOff.gameObject.SetActive(!canPlayMusic);
        soundManager.OnClickBackGroundMusic(canPlayMusic);
    }
}
