﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickCrackBehaviour : MonoBehaviour
{
    //Vamos utilizar o conceito de lista/Array para armazenar as cores
    public Sprite[] spriteList;
    public int maxHits;
    protected int hitCounter;

    // Use this for initialization
    void Start()
    {
        hitCounter = 0;
        GetComponent<SpriteRenderer>().sprite = spriteList[hitCounter];
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        hitCounter++;
        if (hitCounter >= maxHits)
            Destroy(gameObject);
        else
            GetComponent<SpriteRenderer>().sprite = spriteList[hitCounter];
    }

    public int getLife()
    {
        return maxHits - hitCounter;
    }
}
