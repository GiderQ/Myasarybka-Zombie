using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public bool isAlive = true;
    public float hpValue = 3;
    public float fireRate = 0.2f;
    private float nextFireTime = 0f;
    public bool cooldown = true;
    public GameObject bulletPrefab, game, deathScene;
    public TextMeshProUGUI hp;
    public Transform firePoint;
    public Vector3 gunOffset = new Vector3(0.5f, 0, 0);

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }
    void Update()
    {
        Move();
        HandleShooting();

        if (firePoint != null)
            firePoint.parent.localPosition = gunOffset;

        if (hpValue <= 0)
        {
            game.SetActive(false);
            deathScene.SetActive(true);
        }

        hp.text = ($"HP: {hpValue}");
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
      
        Quaternion rotation = firePoint.rotation;

       
        Instantiate(bulletPrefab, firePoint.position, rotation);
    }





    private void OnCollisionStay2D(Collision2D other)
    {   
        if (other.gameObject.CompareTag("Zombie") && cooldown)
        {
            cooldown = false;
            StartCoroutine(GetDamage());
        }
    }

    IEnumerator GetDamage()
    {
        hpValue--;
        yield return new WaitForSeconds(1);
        cooldown = true;

    }
}
