using UnityEngine;
using System.Collections;

public abstract class Jewel : LogicRenderObject {
    public void Appear()
    {
        GetRender<JewelRender>().Appear();
    }

    public void Disappear()
    {
        GetRender<JewelRender>().Disappear();
    }
}
