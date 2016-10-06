using UnityEngine;
using System.Collections;

public abstract class RenderObject : MonoBehaviour {
    protected LogicRenderObject head;

    public T GetHead<T>() where T : LogicRenderObject
    {
        return (T)head;
    }

    public void SetHead(LogicRenderObject _head)
    {
        head = _head;
    }
}
