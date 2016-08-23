using UnityEngine;
using System.Collections.Generic;

public class RandomManager {
    public static List<T> GetShuffling<T>(List<T> inputList)
    {
        if (inputList == null)
        {
            Debug.Log("Warning: Input List is null");
            return null;
        }
        List<T> outputList = new List<T>();

        foreach (T obj in inputList)
        {
            outputList.Add(obj);
        }

        for (int i = outputList.Count - 1; i > 0; i--)
        {
            int ran = Random.Range(0, i + 1);
            T temp = outputList[i];
            outputList[i] = outputList[ran];
            outputList[ran] = temp;
        }

        return outputList;
    }

    public static List<int> GetShufflingIntList(int amount)
    {
        List<int> list = new List<int>();
        for(int i = 0; i < amount; i++)
        {
            list.Add(i);
        }
        return GetShuffling<int>(list);
    }
}
