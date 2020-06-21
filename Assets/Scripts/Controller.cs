using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        ResetScene();
    }

    private void ResetScene()
    {
        if (Player.p.dead && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
            currHP = maxHP;
            Player.p.transform.position = new Vector3(-29.24f, -1.62f, 0);
            Player.p.s.color = new Color(1, 1, 1);
            Player.p.dead = false;
            Player.p.anim.SetBool("dead", false);
            Player.p.anim.SetBool("stilldead", false);
        }
    }

    
}
