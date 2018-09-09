using UnityEngine;

[System.Serializable]
public class ObjectPoolItem {
    public GameObject objectToPool;
    public int pooledAmount;
    public string tag;
    public bool canGrow = true; // Pool can grow (does not shrink)
}
