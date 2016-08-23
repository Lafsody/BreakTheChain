using UnityEngine;
using System.Collections;

public class JewelConverter {
    public static Jewel GetJewelFromIndex(string jewelIndex)
    {
        switch(jewelIndex)
        {
            case "0":
                return new NormalJewel(0);
            case "1":
                return new NormalJewel(1);
            case "2":
                return new NormalJewel(2);
            case "3":
                return new NormalJewel(3);
            case "4":
                return new NormalJewel(4);
            case "5":
                return new NormalJewel(5);
            default:
                int randomIndex = Random.RandomRange(0, 6);
                return new NormalJewel(randomIndex);
        }
    }
}
