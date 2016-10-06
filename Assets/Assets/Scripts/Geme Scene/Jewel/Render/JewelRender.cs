using UnityEngine;
using System.Collections;
using System;

public class JewelRender : RenderObject {

    public void Appear()
    {
        gameObject.SetActive(true);
    }

    public void Disappear()
    {
        gameObject.SetActive(false);
    }

    public void Selected()
    {

    }

    public void Deselected()
    {

    }

    public void Block()
    {
        gameObject.SetActive(false);
    }
}