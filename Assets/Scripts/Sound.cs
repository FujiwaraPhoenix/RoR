using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {
    public static Sound me;
    public GameObject audSource;
    public AudioSource[] audSources;
    public AudioClip music;

    // Use this for initialization
    void Start() {
        audSources = new AudioSource[64];
        for (int i = 0; i < audSources.Length; i++)
        {
            audSources[i] = (Instantiate(audSource, new Vector3(20,20,0), Quaternion.identity) as GameObject).GetComponent<AudioSource>();
        }
    }

    void Awake()
    {
        if (me == null)
        {
            DontDestroyOnLoad(gameObject);
            me = this;
        }
        else if (me != this)
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip snd, float vol, int min, int max)
    {
        int sNum = GetSourceNum(min, max);
        if (sNum == -1)
        {
            return;
        }
        else
        {
            audSources[sNum].clip = snd;
            audSources[sNum].volume = vol;
            audSources[sNum].Play();
        }
    }

    public int GetSourceNum(int a, int b)
    {
        if (b < audSources.Length)
        {
            for (int i = a; i < b; i++)
            {
				if (audSources[i] != null) {
					if (!audSources [i].isPlaying) {

						return i;
					}
				}
            }
        }
        return -1;
    }

	// Update is called once per frame
	void Update () {
        Awake();
        for (int i = 0; i < audSources.Length; i++)
        {
            if (audSources[i] == null)
            {
                audSources[i] = (Instantiate(audSource, new Vector3(20, 20, 0), Quaternion.identity) as GameObject).GetComponent<AudioSource>();
            }
        }
	}
}
