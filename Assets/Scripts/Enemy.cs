using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public bool attacking;
    public int hp, maxhp, dmg, def, enemyDir;
    public float mvspd, atkdelay, atkRad;

	//ANIMATION STUFF
	public Animator anim;
	bool facingFront, facingRight, facingBack, facingLeft;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        Move();
        if ((transform.position - Player.p.transform.position).magnitude < atkRad) {
            StartCoroutine(Attack());
        }

		//more animation stuff
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

    IEnumerator Attack()
    {
        if (!attacking)
        {
            attacking = true;
            //Play the atk animation
			anim.SetBool ("attacking", true);
            yield return new WaitForSeconds(atkdelay/2);
            //hitscan
            yield return new WaitForSeconds(atkdelay / 2);
            attacking = false;
			anim.SetBool ("attacking", false);
            yield return new WaitForSeconds(atkdelay);
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
                Debug.Log(dir);
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
        }
        if (angle > 157.5f && angle < -157.5f)
        {
            enemyDir = 6;
			facingLeft = true;
			facingFront = false;
			facingBack = false;
			facingRight = false;
        }
    }
}
