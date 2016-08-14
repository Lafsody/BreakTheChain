using UnityEngine;
using System.Collections;

public abstract class LogicObject {
    protected LogicRenderObject head;

    public LogicRenderObject GetHead()
    {
        return head;
    }
}
