using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public bool isAlive = true;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Vector3 gunOffset = new Vector3(0.5f, 0, 0);

    public float fireRate = 0.2f;
    private float nextFireTime = 0f;

    void Update()
    {
        Move();
        HandleShooting();

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

    void HandleShooting()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
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
