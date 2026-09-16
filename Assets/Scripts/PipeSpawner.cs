using System.Collections;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Pipes;
    [SerializeField] private GameManager gameManager;

    [SerializeField] private float spawnTime = 2f; // initial spawn time
    [SerializeField] private float height = 3f;
    [SerializeField] private float minSpawnTime = 0.6f; // bottom limit for spawn time to prevent pipes from spawning too quickly

    private float pipeGap; // constant gap between pipes based on current speed

    private void Start()
    {
        pipeGap = gameManager.currentPipeSpeed * spawnTime;
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            GameObject newPipe = Instantiate(Pipes, new Vector3(3f, Random.Range(-height, height), 0), Quaternion.identity);
            newPipe.GetComponent<PipeMovement>().pipeSpeed = gameManager.currentPipeSpeed;

            float currentSpawnTime = pipeGap / gameManager.currentPipeSpeed;
            currentSpawnTime = Mathf.Max(currentSpawnTime, minSpawnTime);

            yield return new WaitForSeconds(currentSpawnTime);
        }
    }
}