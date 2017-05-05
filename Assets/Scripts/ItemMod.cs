using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMod : MonoBehaviour {
    public SpriteRenderer s;
    public Sprite i1, i2, i3, i4, i5;
    public int currItem;
    public int[] itemQuantity= new int[5];

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 5; i++)
        {
            itemQuantity[i] = 1;
        }

	}
	
	// Update is called once per frame
	void Update () {
        itemCycle();
	}

    void itemCycle()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (currItem == 0)
            {
                currItem = 4;
            }
            else
            {
                currItem--;
            }
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            if (currItem == 4)
            {
                currItem = 0;
            }
            else
            {
                currItem++;
            }
        }
    }
}
