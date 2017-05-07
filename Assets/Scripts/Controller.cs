using System.Collections;
using UnityEngine;

public class Controller : MonoBehaviour {
    public static Controller Instance;
    public int currHP, maxHP, dmg;
    public bool counterActive, attacking, dodging;

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
		
	}
}
