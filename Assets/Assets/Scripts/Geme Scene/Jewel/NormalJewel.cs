using UnityEngine;
using System.Collections;

public class NormalJewel : Jewel {

    private int jewelIndex;

    public NormalJewel(int index)
    {
        jewelIndex = index;
    }

    public int GetJewelIndex()
    {
        return jewelIndex;
    }
}
