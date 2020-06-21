using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkBox : MonoBehaviour {
    public bool active, contact;
    public int dmg;
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
                    colliding = coll.gameObject;
                    contact = true;

                    if (!Player.p.iframe && !Player.p.iframe2 && !Player.p.iframe3)
                    {
                        Controller.Instance.currHP -= dmg;
                        Player.p.iframe2 = true;
                        Player.p.iframe2cd = 30;
                    }
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
                    if (!colliding.GetComponent<Enemy>().iframe)
                    {
                        colliding.GetComponent<Enemy>().iframe = true;
                        colliding.GetComponent<Enemy>().invTimer = 15;
                        colliding.GetComponent<Enemy>().hp -= Controller.Instance.dmg;
                    }
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
