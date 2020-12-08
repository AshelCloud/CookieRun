using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> prefabs;

    [SerializeField]
    private float spawnDelay;

    private void Start()
    {
        spawnDelay = Mathf.Clamp(spawnDelay, 0.1f, spawnDelay);

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while(true)
        {
            if (GameManager.Instance.IsGameOver) { break; }

            Instantiate(prefabs[Random.Range(0, prefabs.Count)], transform.position, Quaternion.identity);

            yield return new WaitForSeconds(spawnDelay);
        }

        yield return null;
    }
}
