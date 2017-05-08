using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroRad : MonoBehaviour {
    public Enemy e;
    public bool sd;
    public int timer;

	// Use this for initialization
	void Start () {
        e.active = false;
        timer = 0;
        sd = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (sd)
        {
            timer--;
            if (timer < 0)
            {
                Destroy(this.gameObject);
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
     if (collision.gameObject.tag == "PlayerTag")
        {
            e.active = true;
            if (timer == 0)
            {
                timer = 60;
            }
            sd = true;
        }
    }


}
