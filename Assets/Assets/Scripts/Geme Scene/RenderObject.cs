using UnityEngine;
using System.Collections;

public abstract class RenderObject : MonoBehaviour {

    protected LogicRenderObject head;

    public LogicRenderObject GetHead()
    {
        return head;
    }
}
