using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

    [System.Serializable]
    public class MissilePool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<MissilePool> poolsList;

    public Dictionary<string, Queue<GameObject>> MissileDictionary;

	// Use this for initialization
	void Start () {
        MissileDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (MissilePool pool in poolsList)
        {
            Queue<GameObject> missilePool = new Queue<GameObject>();
            for(int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                missilePool.Enqueue(obj);
            }
            //adds everything made in the missilepool to the missiledictionary
            MissileDictionary.Add(pool.tag, missilePool);
        }
	}

    public GameObject SpawnFromPool(string tag, Vector2 position, Quaternion rotation)
    {

        if (!MissileDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " does not exist");
            return null;
        }
        GameObject ObjectToSpawn = MissileDictionary[tag].Dequeue();
        ObjectToSpawn.SetActive(true);
        ObjectToSpawn.transform.position = position;
        ObjectToSpawn.transform.rotation = rotation;

        MissileDictionary[tag].Enqueue(ObjectToSpawn);

        return ObjectToSpawn;

    }
	

}
