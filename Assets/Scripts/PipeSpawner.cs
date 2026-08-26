using System.Collections;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Pipes;

    [SerializeField] private float spawnTime = 1.5f;
    [SerializeField] private float height = 1.2f;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn() 
    {
        while (true) 
        {
            Instantiate(Pipes, new Vector3(3f, Random.Range(-height, height),0), Quaternion.identity);

            yield return new WaitForSeconds(spawnTime);
        }
    }
}
