using UnityEngine;
using System.Collections;

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
        JewelRender render = new JewelRender(x, y);
        render.SetHead(this);
        render.CreateObject();
        renderObject = render;
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
}
