using System.Collections;
using UnityEngine;

public class Controller : MonoBehaviour {
    public static Controller Instance;
    public int currHP, maxHP, dmg;
    public bool counterActive, attacking, dodging;
    public Item items;

    // Use this for initialization
    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
        Sound.me.PlaySound(Sound.me.music, .25f, 1, 2);
    }
}
