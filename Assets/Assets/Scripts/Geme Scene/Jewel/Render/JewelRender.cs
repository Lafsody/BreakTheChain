using UnityEngine;
using System.Collections;
using System;

public class JewelRender : RenderObject {

    private float x;
    private float y;

    public JewelRender(float _x, float _y) : base()
    {
        x = _x;
        y = _y;
    }

    public void Appear()
    {
        renderGameObject.SetActive(true);
    }

    public void Disappear()
    {
        renderGameObject.SetActive(false);
    }

    public override void CreateObject()
    {
        string jewelName = GetHead<Jewel>().GetName();
        GameObject prefab = PrefabsHolder.Instance.GetJewelPrefabByName(jewelName);
        renderGameObject = Instantiate(prefab, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
    }
}