using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkBox : MonoBehaviour {
    public bool active, contact;
    public GameObject colliding;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D coll)
    {
        if (tag == "enemyAtkBox")
        {
            if (active)
            {
                if (coll.gameObject.tag == "PlayerTag")
                {
                    contact = true;
                }
            }
        }

        if (tag == "pAtkBox")
        {
            if (active)
            {
                if (coll.gameObject.tag == "eHitbox")
                {
                    colliding = coll.gameObject;
                    contact = true;
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if ((coll.gameObject.tag == "PlayerTag") || (coll.gameObject.tag == "eHitbox"))
        {
            contact = false;
        }
    }
}
