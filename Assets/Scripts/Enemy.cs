using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public bool attacking, active;
    public int hp, maxhp, dmg, enemyDir;
    public float mvspd, atkdelay, atkRad;
    public AggroRad ar;
    public AtkBox a, b, c, d;

	//ANIMATION STUFF
	public Animator anim;
	bool facingFront, facingRight, facingBack, facingLeft;
	float deathTimer;

    // Use this for initialization
    void Start () {
		deathTimer = 1f;
	}

    // Update is called once per frame
    void Update() {
		if (active) {
			Move ();
			if ((transform.position - Player.p.transform.position).magnitude < atkRad) {
				StartCoroutine (Attack ());
			}
			//more animation stuff
			if (facingFront) {
				anim.SetBool ("FacingFront", true);
			} else {
				anim.SetBool ("FacingFront", false);
			}
			if (facingBack) {
				anim.SetBool ("FacingBack", true);
			} else {
				anim.SetBool ("FacingBack", false);
			}
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

		if (hp <= 0) {
			anim.SetBool ("dead", true);
			deathTimer -= Time.deltaTime;
		} else {
			anim.SetBool ("dead", false);
		}

		if (deathTimer <= 0) {
			Destroy (gameObject);
		}
    }

    IEnumerator Attack()
    {
        if (!attacking)
        {
            attacking = true;
            //Play the atk animation
			anim.SetBool ("attacking", true);
            HitScan();
            yield return new WaitForSeconds(atkdelay);
            attacking = false;
			anim.SetBool ("attacking", false);
        }
    }

    void Move()
    {
        if ((transform.position - Player.p.transform.position).magnitude > atkRad)
        {
			if (!attacking) {
				anim.SetBool ("moving", true);
				Vector3 dir = (Player.p.transform.position - transform.position).normalized;
				float ang = GlobalFxns.ToAng (dir);
				Orientation (ang);
				transform.position += dir * mvspd;
                //Debug.Log(dir);
            }
            else {
				anim.SetBool ("moving", false);
			}
        }
        
    }

    //tl;dr Orientation sets up the way the enemy is looking and therefore where it can attack.
    void Orientation(float angle)
    {
        if (angle < 22.5f && angle > -22.5f)
        {
            enemyDir = 2;
			facingRight = true;
			facingBack = false;
			facingFront = false;
			facingLeft = false;
        }
        if (angle < 67.5f && angle >= 22.5f)
        {
            enemyDir = 1;
        }
        if (angle < 112.5f && angle >= 67.5f)
        {
            enemyDir = 0;
			facingBack = true;
			facingFront = false;
			facingRight = false;
			facingLeft = false;
        }
        if (angle < 157.5f && angle > 112.5f)
        {
            enemyDir = 7;
			facingLeft = true;
			facingFront = false;
			facingBack = false;
			facingRight = false;
        }
        if (angle > -67.5f && angle <= -22.5f)
        {
            enemyDir = 3;
        }
        if (angle > -112.5f && angle <= -67.5f)
        {
            enemyDir = 4;
			facingFront = true;
			facingBack = false;
			facingLeft = false;
			facingRight = false;
        }
        if (angle > -157.5f && angle <= -112.5f)
        {
            enemyDir = 5;
			facingLeft = true;
			facingFront = false;
			facingBack = false;
			facingRight = false;
        }
        if (angle > 157.5f || angle < -157.5f)
        {
            facingLeft = true;
            facingFront = false;
            facingBack = false;
            facingRight = false;
            enemyDir = 6;
        }
    }

    void HitScan()
    {
        if (!Player.p.iframe && !Player.p.iframe2 && !Player.p.iframe3)
        {
            if (facingBack)
            {
                a.active = true;
                a.dmg = 1;
            }
            else if (facingRight)
            {
                b.active = true;
                b.dmg = 1;
            }
            else if (facingFront)
            {
                c.active = true;
                c.dmg = 1;
            }
            else if (facingLeft)
            {
                d.active = true;
                d.dmg = 1;
            }
        }
    }
}
