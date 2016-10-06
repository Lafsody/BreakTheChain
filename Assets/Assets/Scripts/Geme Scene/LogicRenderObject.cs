using UnityEngine;
using System.Collections;

public abstract class LogicRenderObject {
    protected LogicObject logicObject;
    protected RenderObject renderObject;

    public T GetLogic<T>() where T : LogicObject
    {
        return (T)logicObject;
    }

    public T GetRender<T>() where T : RenderObject
    {
        return (T)renderObject;
    }

    public abstract void OnTouchDown();
    public abstract void OnDragOver();
    public abstract void OnTouchUp();
}
