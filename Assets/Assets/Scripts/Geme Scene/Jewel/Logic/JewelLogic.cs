using UnityEngine;
using System.Collections;

public class JewelLogic : LogicObject {
    public int x { get; private set; }
    public int y { get; private set; }
    public bool IsBlock { get; private set; }
    public JewelLogic(int _x, int _y)
    {
        x = _x;
        y = _y;
        IsBlock = false;
    }

    public void SetBlock(bool _isBlock)
    {
        IsBlock = _isBlock;
    }
}
