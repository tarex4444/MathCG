using UnityEngine;

public class OptionsManager : MonoBehaviour
{
    public bool AudioMute;
    private AudioManager audioManager;
    void Start(){
        audioManager = FindAnyObjectByType<AudioManager>();
    }
}

