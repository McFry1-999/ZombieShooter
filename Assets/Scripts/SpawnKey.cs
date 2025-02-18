using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKey : MonoBehaviour
{
   public GameObject prefab; // Prefab a instanciar
    public List<Transform> spawnPoints; // Lista de puntos de spawn
    public float spawnInterval = 3f; // Tiempo entre apariciones
    public float objectLifetime = 2f; // Tiempo antes de desaparecer
 
    private GameObject currentObject; // Referencia al objeto actual
 
    void Start()
    {
        StartCoroutine(SpawnLoop());
    }
 
    IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnObject();
            yield return new WaitForSeconds(spawnInterval);
        }
    }
 
    void SpawnObject()
    {
        if (currentObject != null)
        {
            Destroy(currentObject); // Destruye el objeto anterior si existe
        }
 
        if (spawnPoints.Count > 0)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)]; // Punto aleatorio
            currentObject = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
            StartCoroutine(DestroyAfterTime(currentObject, objectLifetime));
        }
    }
 
    IEnumerator DestroyAfterTime(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (obj != null)
        {
            Destroy(obj);
        }
    }
}
