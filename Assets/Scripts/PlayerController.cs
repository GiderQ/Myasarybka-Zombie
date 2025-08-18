using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Vector3 gunOffset = new Vector3(0.5f, 0, 0);

    void Update()
    {
        Move();

        if (Input.GetButtonDown("Fire1"))
            Shoot();


        if (firePoint != null)
            firePoint.parent.localPosition = gunOffset;
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveX, moveY);
        transform.Translate(movement * speed * Time.deltaTime);
    }

    void Shoot()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        Vector2 direction = (mousePos - firePoint.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle);

        Instantiate(bulletPrefab, firePoint.position, rotation);
    }
}
