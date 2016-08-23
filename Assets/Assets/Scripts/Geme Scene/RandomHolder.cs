using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomHolder {

    public struct Holder
    {
        public string name;
        public float chance;
    }

    public List<Holder> chanceList;
    public float sumAll;
    public RandomHolder()
    {
        chanceList = new List<Holder>();
        sumAll = 0;
    }
    public void AddChance(string name, float chance)
    {
        Holder holder = new Holder();
        holder.name = name;
        holder.chance = chance;

        chanceList.Add(holder);
        sumAll += chance;
        if(sumAll > 100)
        {
            Debug.Log("Chance is exceed 100 it's " + sumAll);
        }
    }

    public string GetRandom()
    {
        float ran = Random.Range(0, sumAll > 100? sumAll:100);
        float sum = 0;
        for(int i = 0; i < chanceList.Count; i++)
        {
            sum += chanceList[i].chance;
            if(sum >= ran)
            {
                return chanceList[i].name;
            }
        }

        return "ETC";
    }
}
