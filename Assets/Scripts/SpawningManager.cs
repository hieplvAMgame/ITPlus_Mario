using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningManager : MonoBehaviour
{
    public List<Transform> listSpawnEnemy = new List<Transform>();

    private void Awake()
    {
        ObjectPooling.Instance.OnCompleteCreatePool = GenerateEnemy;
    }

    private void GenerateEnemy()
    {
        Debug.LogError("GEn Enemy");
        for (int i = 0; i < listSpawnEnemy.Count; i++)
        {
            Debug.LogError($"GEn Enemy {i}");
            GameObject obj = ObjectPooling.Instance.GetObjectFromPool("Enemy");
            Debug.LogError(obj);
            obj.transform.position = listSpawnEnemy[i].position;
            obj.SetActive(true);
            Debug.LogError($"Done Enemy {i}");
        }
    }
    
}
