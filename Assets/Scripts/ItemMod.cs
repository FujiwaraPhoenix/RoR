using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMod : MonoBehaviour {
    public static ItemMod imod;
    public Sprite i1, i2, i3, i4;
    public int currItem;
    public int[] itemQuantity= new int[4];
    public Text quant;
    public Image img;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 4; i++)
        {
            itemQuantity[i] = 5;
        }

	}

    void Awake()
    {
        if (imod == null)
        {
            DontDestroyOnLoad(gameObject);
            imod = this;
        }
        else if (imod != this)
        {
            Destroy(gameObject);
        }
    }


    // Update is called once per frame
    void Update () {
        itemCycle();
        Display();
        consumeItem();
	}

    void itemCycle()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (currItem == 0)
            {
                currItem = 3;
            }
            else
            {
                currItem--;
            }
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            if (currItem == 3)
            {
                currItem = 0;
            }
            else
            {
                currItem++;
            }
        }
    }

    void Display()
    {
        if (currItem == 0)
        {
            img.sprite = i1;
        }
        if (currItem == 1)
        {
            img.sprite = i2;
        }
        if (currItem == 2)
        {
            img.sprite = i3;
        }
        if (currItem == 3)
        {
            img.sprite = i4;
        }
        quant.text = "x" + itemQuantity[currItem].ToString();
    }

    void consumeItem()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (itemQuantity[currItem] > 0)
            {
                if (currItem == 0)
                {
                    if (Player.p.itemcd < 0) {
                        if (Controller.Instance.currHP < Controller.Instance.maxHP)
                        {
                            Controller.Instance.currHP += 5;
                            if (Controller.Instance.currHP > Controller.Instance.maxHP)
                            {
                                Controller.Instance.currHP = Controller.Instance.maxHP;
                            }
                            Player.p.itemcd = 60;
                            itemQuantity[currItem]--;
                        }
                    }
                }
                if (currItem == 1)
                {
                    if (Player.p.item2cd <= 0)
                    {
                            Player.p.item2used = true;
                            Player.p.item2cd = 180;
                            itemQuantity[currItem]--;
                    }
                }
                if (currItem == 2)
                {
                    if (Player.p.item3cd <= 0)
                    {
                            Player.p.item3used = true;
                            Player.p.item3cd = 300;
                            itemQuantity[currItem]--;
                    }
                }
                if (currItem == 3)
                {
                    if (Player.p.item4cd <= 0)
                    {
                            Player.p.item4used = true;
                            Player.p.item4cd = 300;
                            itemQuantity[currItem]--;
                    }
                }
            }
        }
    }
}
