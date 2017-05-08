using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public static Player p;
    public SpriteRenderer s;
    public Sprite[] playerOrientation= new Sprite[8];
    public int playerDir, timer, dashCD;
    public bool dead, swinging, countering, dashing, iframe;

	public Animator anim;
	bool facingFront, facingRight, facingBack, facingLeft;


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
            Dash();
        }
		if (Input.GetKeyDown (KeyCode.J)) {
			StartCoroutine (Attack ());
		} else if (Input.GetKeyDown (KeyCode.K)) {
			StartCoroutine (Counter ());
		}
        //Debug.Log(swinging);


		//ANIMATION STUFF
		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D)) {
			anim.SetBool ("moving", true);
		} else {
			anim.SetBool ("moving", false);
		}

		if (facingFront) { anim.SetBool ("FacingFront", true); }
		 else { anim.SetBool ("FacingFront", false); }
		if (facingBack) { anim.SetBool ("FacingBack", true); }
		 else { anim.SetBool ("FacingBack", false); }
		if (facingLeft) {
			anim.SetBool ("FacingLeft", true);
		} else {
			anim.SetBool ("FacingLeft", false);
		}
		if (facingRight) {
			anim.SetBool ("FacingRight", true);
		} else {
			anim.SetBool ("FacingRight", false);
		}
	}

    void Move()
    {
        if (!dead && !dashing)
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
				facingRight = true;
				facingBack = false;
				facingFront = false;
				facingLeft = false;
            }
            if (playerDir / 45 == 1)
            {
                playerDir = 1;
            }
            if (playerDir / 45 == 2)
            {
                playerDir = 0;
				facingBack = true;
				facingRight = false;
				facingLeft = false;
				facingFront = false;
            }
            if (playerDir / 45 == 3)
            {
                playerDir = 7;
            }
			if (playerDir / 45 == 4) {
				playerDir = 6;
				facingLeft = true;
				facingFront = false;
				facingBack = false;
				facingRight = false;
			}
            if (playerDir / 45 == -1)
            {
                playerDir = 3;
            }
            if (playerDir / 45 == -2)
            {
                playerDir = 4;
				facingFront = true;
				facingBack = false;
				facingLeft = false;
				facingRight = false;
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
			anim.SetBool ("attacking", true);
            yield return new WaitForSeconds(.5f);
            swinging = false;
			anim.SetBool ("attacking", false);
            yield return new WaitForSeconds(.5f);
        }
    }

    IEnumerator Counter()
    {
        if (!countering)
        {
            countering = true;
			anim.SetBool ("counter", true);
            yield return new WaitForSeconds(1);
			anim.SetBool ("counter", false);
            countering = false;
            yield return new WaitForSeconds(1);
        }
    }

    void Dash()
    {
        if ((Input.GetKeyDown(KeyCode.Space)) && dashCD < 1)
        {
			anim.SetBool ("dash", true);
            dashing = true;
            iframe = true;
            timer = 30;
            dashCD = 180;
        }
        else if (timer > 0)
        {
            if (playerDir == 0)
            {
                //play dash UP
                transform.position += GlobalFxns.ToVect(90).normalized * .875f;
            }
            if (playerDir == 1)
            {
                //play dash UPRT
                transform.position += GlobalFxns.ToVect(45).normalized * .875f;
            }
            if (playerDir == 2)
            {
                //play dash RT
                transform.position += GlobalFxns.ToVect(0).normalized * .875f;
            }
            if (playerDir == 3)
            {
                //play dash DNRT
                transform.position += GlobalFxns.ToVect(-45).normalized * .875f;
            }
            if (playerDir == 4)
            {
                //play dash DN
                transform.position += GlobalFxns.ToVect(-90).normalized * .875f;
            }
            if (playerDir == 5)
            {
                //play dash DNLT
                transform.position += GlobalFxns.ToVect(-135).normalized * .875f;
            }
            if (playerDir == 6)
            {
                //play dash LT
                transform.position += GlobalFxns.ToVect(180).normalized * .875f;
            }
            if (playerDir == 7)
            {
                //play dash UPLT
                transform.position += GlobalFxns.ToVect(135).normalized * .875f;
            }
            timer--;
        }
        else {
            iframe = false;
            dashing = false;
			anim.SetBool ("dash", false);
        }
        dashCD--;
    }
}
