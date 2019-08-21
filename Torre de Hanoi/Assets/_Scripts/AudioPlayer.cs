using UnityEngine;
using UnityEngine.UI;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource SFX;
    [SerializeField] private AudioSource BGM;

    public static AudioPlayer instance;

    private bool isMute;
    [SerializeField] private Sprite mute;
    [SerializeField] private Sprite unmute;
    [SerializeField] private Image audioIcon;

    private void Awake()
    {
        instance = this;
    }

    public void PlaySFX(AudioClip _clip)
    {
        SFX.PlayOneShot(_clip);
    }

    public void PlayBGM(AudioClip _music)
    {
        BGM.clip = _music;
        BGM.Play();
    }

    public void MuteAndUnmute()
    {
        if(isMute)
        {
            isMute = false;
            SFX.mute = false;
            BGM.mute = false;
            audioIcon.sprite = unmute;
        }
        else
        {
            isMute = true;
            SFX.mute = true;
            BGM.mute = true;
            audioIcon.sprite = mute;
        }
    }
}
