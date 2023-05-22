using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public List<GameObject> listObjectToPool = new List<GameObject>();
    public int size;
    Dictionary<string, List<GameObject>> poolDict = new Dictionary<string, List<GameObject>>();
    // Bullet
    //"Bullet", List<GameObject>

    private void Awake()
    {
        for (int j = 0; j < listObjectToPool.Count; j++)
            for (int i = 0; i < size; i++)
            {
                GameObject obj = Instantiate(listObjectToPool[j], transform);
                obj.SetActive(false);
                string key = listObjectToPool[j].name;

                if (!poolDict.ContainsKey(key))
                {
                    poolDict.Add(key, new List<GameObject>());
                }
                poolDict[key].Add(obj);
            }
    }
    public GameObject GetObjectFromPool(string key) // "Bullet"
    {
        if (poolDict.ContainsKey(key))
        {
            for(int i=0;i< poolDict[key].Count;i++)
            {
                int temp = i;
                if (!poolDict[key][temp].activeInHierarchy)
                {
                    poolDict[key][temp].SetActive(true);
                    Debug.LogError("1");
                    return poolDict[key][temp]; 
                }
            }
            int _index = -1;
            //Spawn new object for adding to pool
            for (int i = 0; i < listObjectToPool.Count; i++)
            {
                if (listObjectToPool[i].name.Equals(key))
                {
                    _index = i;
                    break;
                }
            }
            GameObject newObj = Instantiate(listObjectToPool[_index], transform);
            newObj.SetActive(true);
            poolDict[key].Add(newObj);
            Debug.LogError("2");
            return newObj;
        }
        return null;
        //GameObject newObj = Instantiate(objectToPool, transform);
        //newObj.SetActive(true);

        //if (!poolDict.ContainsKey(key))
        //{
        //    poolDict.Add(key, new List<GameObject>());
        //}
        //poolDict[key].Add(newObj);
        //return newObj;
    }

}

