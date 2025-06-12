using UnityEngine;

public class WolfController : MonoBehaviour
{
    public Transform target;
    public float speed = 3f;

    void Start()
    {
        // Eðer hedef atanmadýysa, "HumanAgent" tag'ine sahip objeyi otomatik bul
        if (target == null)
        {
            GameObject targetObj = GameObject.FindGameObjectWithTag("Player");
            if (targetObj != null)
            {
                target = targetObj.transform;
            }
        }
    }

    void Update()
    {
        if (target != null)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            transform.position += (Vector3)direction * speed * Time.deltaTime;
        }
    }
}
