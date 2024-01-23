using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource aud;
    [SerializeField] AudioClip beginFight;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        if (aud == null)
        {
            aud = gameObject.AddComponent<AudioSource>();
        }

        aud.playOnAwake = false;
        aud.loop = false;
        aud.clip = beginFight;
    }
   
    public void PlayBeginFightSound()
    {
        aud.clip = beginFight;
        aud.Play();
    }
}
