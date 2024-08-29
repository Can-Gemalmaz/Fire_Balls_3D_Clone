using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] Transform parentObject;
    [SerializeField] GameObject poolableObjectPrefab;
    [SerializeField] int maxAmountPool;

    Stack<GameObject> _pooledObjects;

    private void Awake()
    {
        _pooledObjects = new Stack<GameObject>();

    }

    private void Start()
    {
        for (int i = 0; i < maxAmountPool; i++)
        {
            AddNewObject();
        }
    }



    private void AddNewObject()
    {
        GameObject newObject = Instantiate(poolableObjectPrefab, parentObject);
        newObject.SetActive(false);
        _pooledObjects.Push(newObject);
    }


    public GameObject GetPooledObject()
    {

        for (int i = 0; i < maxAmountPool; i++)
        {
            GameObject popedPoolObject = _pooledObjects.Pop();
            if (!popedPoolObject.activeInHierarchy)
            {
                return popedPoolObject;
            }
        }
        AddNewObject();
        return GetPooledObject();
    }

    public void AddToStack(GameObject go)
    {
        _pooledObjects.Push(go);
    }

}
