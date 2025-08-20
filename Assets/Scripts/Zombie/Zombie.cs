    using System.Collections;
    using static UnityEngine.Color;
    using UnityEngine;
public class Zombie : MonoBehaviour
{
    public bool alive = true;
    public float speed = 3;
    public float hp = 3;
        
    private Transform player;
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        Vector2 direction = (player.position - transform.position).normalized;
        transform.position += (Vector3)direction * speed * Time.deltaTime;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            SpriteRenderer color = GetComponent<SpriteRenderer>();
            StartCoroutine(ChangeColor(color));
        }
    }

    IEnumerator ChangeColor(SpriteRenderer color)
    {
        color.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        color.color = Color.white;

    }

}
