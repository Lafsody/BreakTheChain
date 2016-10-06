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
        Debug.Assert(logicObject == null);
        NormalJewelLogic logic = new NormalJewelLogic(x, y);
        logic.SetHead(this);
        logicObject = logic;
    }

    public int GetJewelIndex()
    {
        return jewelIndex;
    }

    public override string GetName()
    {
        return "" + jewelIndex;
    }

    public override void OnTouchUp()
    {
        base.OnTouchUp();
        Selected();
    }

    private void Selected()
    {
        if (CheckCanSelect())
        {
            GetLogic<NormalJewelLogic>().SetBlock(true);
            GetRender<NormalJewelRender>().Block();
            GameManager.Instance.OnBoardChange();
        }
        else
        {
            Debug.LogFormat("<color=red>Not a possible move!</color>");
        }
    }

    private bool CheckCanSelect()
    {
        NormalJewelLogic jewelLogic = GetLogic<NormalJewelLogic>();
        int sameColorCount = BoardManager.Instance.CheckCountAroundOfAround(jewelLogic.x, jewelLogic.y, GetJewelIndex());
        return sameColorCount >= 2;
    }
}
