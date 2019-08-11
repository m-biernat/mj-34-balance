using UnityEngine;
using System.Collections.Generic;

public class AudioHandler : MonoBehaviour
{
    [SerializeField]
    private List<AudioSource> audioSources = null;

    public static AudioHandler instance = null;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (instance == null)
            instance = this;
    }

    public void PlayAudioClip(int index)
    {
        audioSources[index].Play();
    }
}
