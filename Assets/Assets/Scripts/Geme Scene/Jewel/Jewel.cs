using UnityEngine;
using System.Collections;
using System;

public abstract class Jewel : LogicRenderObject {
    public virtual void InitiateLogic(int x, int y)
    {
        Debug.Assert(logicObject == null);
        JewelLogic logic = new JewelLogic(x, y);
        logic.SetHead(this);
        logicObject = logic;
    }

    public virtual void InitiateRender(float x, float y)
    {
        Debug.Assert(renderObject == null);
        renderObject = PrefabsHolder.Instance.CreateJewelPrefabByName(GetName(), x, y).GetComponent<RenderObject>();
        renderObject.SetHead(this);
    }

    public void Appear()
    {
        GetRender<JewelRender>().Appear();
    }

    public void Disappear()
    {
        GetRender<JewelRender>().Disappear();
    }

    public abstract string GetName();

    public override void OnTouchDown()
    {
        Debug.Log("On Touch " + GetName());
    }

    public override void OnDragOver()
    {
        //Debug.Log("Over " + GetName());
    }

    public override void OnTouchUp()
    {
        Selected();
    }

    private void Selected()
    {

    }
}
