using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public static Player p;
    public SpriteRenderer s;
    public Sprite[] playerOrientation= new Sprite[8];
    public int playerDir;
    public bool dead, swinging, countering, iframe;

    void Awake()
    {
        if (p == null)
        {
            DontDestroyOnLoad(gameObject);
            p = this;
        }
        else if (p != this)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!swinging && !countering)
        {
            Move();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            StartCoroutine(Attack());
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(Counter());
        }
        Debug.Log(swinging);
	}

    void Move()
    {
        if (!dead)
        {
            Vector2 moveVect = Vector2.zero;
            if (Input.GetKey(KeyCode.W)) { moveVect.y += 1; }
            if (Input.GetKey(KeyCode.S)) { moveVect.y -= 1; }
            if (Input.GetKey(KeyCode.A)) { moveVect.x -= 1; }
            if (Input.GetKey(KeyCode.D)) { moveVect.x += 1; }
            if (moveVect.magnitude == 0)
            {
                return;
            }

            moveVect.Normalize();
            transform.position += (Vector3)(moveVect * .0625f * 60f * Time.deltaTime);

            float pDir = GlobalFxns.ToAng(moveVect.normalized);
            playerDir = (int)pDir;
            if (playerDir / 45 == 0)
            {
                playerDir = 2;
            }
            if (playerDir / 45 == 1)
            {
                playerDir = 1;
            }
            if (playerDir / 45 == 2)
            {
                playerDir = 0;
            }
            if (playerDir / 45 == 3)
            {
                playerDir = 7;
            }
            if (playerDir / 45 == 4)
            {
                playerDir = 6;
            }
            if (playerDir / 45 == -1)
            {
                playerDir = 3;
            }
            if (playerDir / 45 == -2)
            {
                playerDir = 4;
            }
            if (playerDir / 45 == -3)
            {
                playerDir = 5;
            }
        }
    }

    IEnumerator Attack()
    {
        if (!swinging)
        {
            swinging = true;
            //Play the swing animation
            yield return new WaitForSeconds(.5f);
            swinging = false;
            yield return new WaitForSeconds(.5f);
        }
    }

    IEnumerator Counter()
    {
        if (!countering)
        {
            countering = true;
            yield return new WaitForSeconds(1);
            countering = false;
            yield return new WaitForSeconds(1);
        }
    }
}
