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
}