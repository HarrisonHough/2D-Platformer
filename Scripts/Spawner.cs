using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField]
    private GameObject objectToSpawn;

    [SerializeField][Tooltip("How long in seconds before each spawn")]
    private float spawnInterval = 3f;

    [SerializeField]
    private float startTimeOffset;
    

	// Use this for initialization
	void Start () {

        StartCoroutine(SpawnCoroutine()); 
	}

    void SpawnObject()
    {
        //GameObject obj = Instantiate(objectToSpawn, transform.position,transform.rotation);
        GameObject obj = GameManager.Instance.SceneVariables.ProjectilePool.GetObject();
        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
    }

    IEnumerator SpawnCoroutine()
    {
        //float timer = 0;
        float nextSpawnTime = Time.time + spawnInterval + startTimeOffset;
        //TODO make bool for when active
        while (true) {
            //timer += Time.deltaTime;
            if (Time.time > nextSpawnTime)
            {
                SpawnObject();
                nextSpawnTime = Time.time + spawnInterval;
            }
            yield return null;
        }
    }
}
