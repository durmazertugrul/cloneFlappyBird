using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] private float pipeSpeed = 3f;
    private void Update()
    {
        transform.position += Vector3.left * pipeSpeed * Time.deltaTime;

        if (transform.position.x < -8.28f) //When the object pass the position destroy
        {
            Destroy(gameObject);
        }
    }
}
