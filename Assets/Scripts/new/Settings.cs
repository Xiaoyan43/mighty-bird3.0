using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject soundGO;
    public GameObject muteGO;

    public void Init(bool mute)
    {
        SetSoundState(mute);
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }

    /// <summary> µã»÷ÒôÁ¿°´Å¥ </summary>
    public void OnSoundBtn()
    {
        bool mute = !GameContainer.Instance.muteState;
        GameContainer.Instance.muteState = mute;
        SetSoundState(mute);
    }

    private void SetSoundState(bool mute)
    {
        audioSource.mute = mute;
        if (!mute && !audioSource.isPlaying)
        {
            audioSource.Play();
        }

        soundGO.SetActive(!mute);
        muteGO.SetActive(mute);
    }

    /// <summary> µã»÷ÇÐ»»±³¾°°´Å¥ </summary>
    public void OnSwitchBgBtn()
    {
        GameContainer.Instance.SwitchBg();
    }

}
