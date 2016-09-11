using UnityEngine;
using System.Collections;
using System;

public class NormalJewel : Jewel {

    private int jewelIndex;

    public NormalJewel(int index)
    {
        jewelIndex = index;
    }

    public override void InitiateLogic(int x, int y)
    {
        base.InitiateLogic(x, y);
    }

    public int GetJewelIndex()
    {
        return jewelIndex;
    }

    public override string GetName()
    {
        return "" + jewelIndex;
    }
}
