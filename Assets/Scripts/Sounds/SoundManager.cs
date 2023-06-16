using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource SongSource;
    public AudioClip PlayingSong;
    public AudioClip MenuSong;

    public AudioSource pispisSource;
    public AudioSource SoundEffects;
    public AudioClip Bounce;
    public AudioClip Win;
    public AudioClip GameOver;
    public AudioClip CoinSound;
    public static SoundManager instance { get; private set; }

    private void Awake()
    {
        instance = this;
        OnClickBackGroundMusic(SettingMenu.canPlayMusic);
    }

    void Update()
    {
        ChangeSong();
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
        if (pispisSource.isPlaying) return;
        pispisSource.Play();
    }
    public void StopPispis()
    {
        if (!pispisSource.isPlaying) return;
        pispisSource.Pause();
    }

    public void PlayLoseSound()
    {
        if (SettingMenu.canPlaySound)
        {
            SoundEffects.PlayOneShot(GameOver);

        }
    }
    public void PlayWinSound()
    {
        if (SettingMenu.canPlaySound)
        {
            SoundEffects.PlayOneShot(Win);

        }
    }
    public void PlayBonceSound()
    {
        if (SettingMenu.canPlaySound)
        {
            SoundEffects.PlayOneShot(Bounce);

        }
    }
    public void PlayCoinSound()
    {
        if (SettingMenu.canPlaySound)
        {
            SoundEffects.PlayOneShot(CoinSound);

        }
    }

    public void OnClickBackGroundMusic(bool canPlaySound)
    {
        if (!(MenuManager.GameState == GameState.Playing) && !(MenuManager.GameState == GameState.GameLogo))
        {
            SongSource.clip = MenuSong;
            if (canPlaySound)
            {
                SongSource.Play();
            }
            else
            {
                SongSource.Stop();
            }

        }
        else if (MenuManager.GameState == GameState.Playing)
        {
            SongSource.clip = PlayingSong;
            if (canPlaySound)
            {
                SongSource.Play();
            }
            else
            {
                SongSource.Stop();
            }

        }
    }
    public void ChangeSong()
    {
        if (!(MenuManager.GameState == GameState.Playing) &&
             !(MenuManager.GameState == GameState.GameLogo) &&
             !(MenuManager.GameState == GameState.WaitForPlayerFingers))
        {
            if (SongSource.isPlaying)
            {
                var currentSong = SongSource.clip;
                if (currentSong == MenuSong) { }
                else
                {
                    SongSource.clip = MenuSong;
                    SongSource.Play();
                }

            }
        }
        else if (MenuManager.GameState == GameState.Playing || MenuManager.GameState == GameState.WaitForPlayerFingers)
        {
            if (SongSource.isPlaying)
            {
                var currentSong = SongSource.clip;
                if (currentSong == PlayingSong) { }
                else
                {
                    SongSource.clip = PlayingSong;
                    SongSource.Play();
                }

            }
        }
    }
}
