using UnityEngine;
using System.Collections;

public class PrefabsHolder : MonoBehaviour {

    public static PrefabsHolder Instance { get; private set; }

    public GameObject boardPrefab;
    public GameObject[] jewelPrefabs;

    public GameObject GetBoardPrefab()
    {
        Debug.Assert(boardPrefab != null);
        return boardPrefab;
    }

    void Awake()
    {
        Instance = this;
    }

    public GameObject GetJewelPrefab(int index)
    {
        Debug.Assert(jewelPrefabs != null);
        Debug.Assert(index < jewelPrefabs.Length);
        return jewelPrefabs[index];
    }

    public GameObject GetJewelPrefabByName(string jewelName)
    {
        Debug.Assert(jewelPrefabs != null);
        int index = JewelConverter.GetJewelIndexFromName(jewelName);
        Debug.Assert(index < jewelPrefabs.Length);
        return jewelPrefabs[index];
    }

    public GameObject CreateBoard()
    {
        return Instantiate(boardPrefab) as GameObject;
    }

    public GameObject CreateJewelPrefabByName(string jewelName, float x, float y)
    {
        GameObject jewelPrefab = GetJewelPrefabByName(jewelName);
        Debug.Assert(jewelPrefab != null);
        return Instantiate(jewelPrefab, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
    }
}
