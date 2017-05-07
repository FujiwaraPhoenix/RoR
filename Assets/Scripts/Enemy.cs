using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public bool attacking;
    public int hp, maxhp, dmg, def, enemyDir;
    public float mvspd, atkdelay, atkRad;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        Move();
        if ((transform.position - Player.p.transform.position).magnitude < atkRad) {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        if (!attacking)
        {
            attacking = true;
            //Play the atk animation
            yield return new WaitForSeconds(atkdelay/2);
            //hitscan
            yield return new WaitForSeconds(atkdelay / 2);
            attacking = false;
            yield return new WaitForSeconds(atkdelay);
        }
    }

    void Move()
    {
        if((transform.position - Player.p.transform.position).magnitude > atkRad)
        {
            if (!attacking)
            {
                Vector3 dir = (transform.position - Player.p.transform.position).normalized;
                float ang = GlobalFxns.ToAng(dir);
                Orientation(ang);
                transform.position += dir * mvspd;
            }
        }
    }

    //tl;dr Orientation sets up the way the enemy is looking and therefore where it can attack.
    void Orientation(float angle)
    {
        if (angle < 22.5f && angle > -22.5f)
        {
            enemyDir = 2;
        }
        if (angle < 67.5f && angle >= 22.5f)
        {
            enemyDir = 1;
        }
        if (angle < 112.5f && angle >= 67.5f)
        {
            enemyDir = 0;
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
        }
        if (angle > -157.5f && angle <= -112.5f)
        {
            enemyDir = 5;
        }
        if (angle > 157.5f && angle < -157.5f)
        {
            enemyDir = 6;
        }
    }
}
