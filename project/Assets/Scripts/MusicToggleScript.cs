using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicToggleScript : MonoBehaviour
{
    [SerializeField] AudioBehaviour musicBehaviour;

    [SerializeField] Toggle toggle;

    public void ToggleChanged()
    {
        if (toggle.isOn)
        {
            musicBehaviour.GetComponentInParent<AudioSource>().Play();
        }
        else
        {
            musicBehaviour.GetComponentInParent<AudioSource>().Pause();
        }
    }

}
