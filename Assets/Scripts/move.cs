using UnityEngine;

public class move : MonoBehaviour
{
    [SerializeField] private float speed;   
    void Update()
    {
         transform.Translate(-speed * Time.deltaTime, 0, 0);
        if(transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}
