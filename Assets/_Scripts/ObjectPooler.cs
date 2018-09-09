using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    public static ObjectPooler instance;
    [SerializeField] List<ObjectPoolItem> itemsToPool;
    List<GameObject> pooledObjects;

    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {
        pooledObjects = new List<GameObject>();
        foreach (ObjectPoolItem poolObject in itemsToPool) {
            for (int i = 0; i < poolObject.pooledAmount; i++)
            {
                GameObject obj = (GameObject)Instantiate(poolObject.objectToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
	}

    public GameObject GetPooledObject(string tag)
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag)
            {
                return pooledObjects[i];
            }
        }

        foreach (ObjectPoolItem poolObject in itemsToPool)
        {
            if (poolObject.tag == tag && poolObject.canGrow)
            {
                GameObject obj = (GameObject)Instantiate(poolObject.objectToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
                return obj;
            }
        }

        return null;
    }
}
