using System.Collections;
using UnityEngine;
public class trap : MonoBehaviour
{
    [SerializeField] private GameObject poles;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private float minY = 0f;
    [SerializeField] private float maxY = 5f;

    void Start()
    {
        StartCoroutine(spawn());
    }
    private IEnumerator spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            Vector3 basePosition = spawnPosition.position;
            float randomY = Random.Range(minY, maxY);
            Vector3 newPosition = new Vector3(basePosition.x, randomY, basePosition.z);
            Instantiate(poles, newPosition, Quaternion.identity);
        }
    }
}
