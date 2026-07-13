using UnityEngine;

public class ObjectPoolerTester : MonoBehaviour
{
    public string poolTag;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject spawnedObject = ObjectPooler.Instance.SpawnFromPool(poolTag, transform.position, transform.rotation);

            if (spawnedObject != null)
            {
                Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.linearVelocity = transform.forward * 10f;
                }
            }
        }
    }
}