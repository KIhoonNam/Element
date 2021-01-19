using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundScript : MonoBehaviour
{

    AudioSource Audio;
    AudioListener AudioLn;
    // Start is called before the first frame update
    void Start()
    {
        Audio = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAudio()
    {
        Audio.Play();
    }

    public void ChangeAudio(string name)
    {
        Audio.clip = Resources.Load<AudioClip>("Sound/"+name);
        Audio.Play();
    }
    public void Mute()
    {
       
    }
}

