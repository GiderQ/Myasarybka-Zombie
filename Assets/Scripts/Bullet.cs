using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 25f;
    public float lifeTime = 2f;
    public int damage = 1;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Zombie"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
