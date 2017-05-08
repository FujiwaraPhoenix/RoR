using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int itemtype;
    public SpriteRenderer s;
    public Sprite s1, s2, s3, s4;
    // Use this for initialization
    void Start()
    {
        int rand = Random.Range(0, 4);
        itemtype = rand;
        if (itemtype == 0)
        {
            s.sprite = s1;
        }
        if (itemtype == 1)
        {
            s.sprite = s2;
        }
        if (itemtype == 2)
        {
            s.sprite = s3;
        }
        if (itemtype == 3)
        {
            s.sprite = s4;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "PlayerTag")
        {
            ItemMod.imod.itemQuantity[itemtype]++;
            Destroy(this.gameObject);
        }
    }
}
