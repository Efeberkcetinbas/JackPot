using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;

    }

    public static CubePooler Instance;

    private void Awake()
    {
        Instance=this;
    }

    public List<Pool> pools;
    public Dictionary<string,Queue<GameObject>> poolDictionary;

    void Start()
    {
        poolDictionary=new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool=new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj=Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag,objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag,Vector3 position,Quaternion rotation)
    {
        if(!poolDictionary.ContainsKey(tag))
        {
            return null;
        }

        GameObject objectToSpawn=poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position=position;
        objectToSpawn.transform.rotation=rotation;
        GameManager.Instance.knives.Add(objectToSpawn);

        IPooledCube pooledCube=objectToSpawn.GetComponent<IPooledCube>();

        if(pooledCube!=null)
        {
            pooledCube.OnCubeSpawn();
        }

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

}
