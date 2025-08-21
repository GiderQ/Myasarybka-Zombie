using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int defaultSpeed = 4,
        defaultHp = 9,
        defaultAtack = 3;
    float defaultSpeedAtack = 0.3f;

    public GameObject bulletPrefab, game, deathScene;
    public TextMeshProUGUI hpText,scoreText;
    public Transform firePoint;
    public Vector3 gunOffset = new Vector3(0.5f, 0, 0);

    public static int money, score;

    bool cooldown = true;

    private float nextFireTime = 0f;
    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }
    void Update()
    {
        HandleShooting();    

        if (firePoint != null)
            firePoint.parent.localPosition = gunOffset;
        
        if (defaultHp <= 0)
        {
            game.SetActive(false);
            deathScene.SetActive(true);
        }

        hpText.text = ($"HP: {defaultHp}");
        scoreText.text = ($"Score: {score}");
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveX, moveY);

        rb.MovePosition(rb.position + movement * defaultSpeed * Time.fixedDeltaTime);
    }

    void HandleShooting()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Quaternion rotation = firePoint.rotation;
            Instantiate(bulletPrefab, firePoint.position, rotation);
            nextFireTime = Time.time + defaultSpeedAtack;
        }
    }


    private void OnCollisionStay2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Zombie") && cooldown)
        {
            SpriteRenderer color = GetComponent<SpriteRenderer>();
             cooldown = false;
            StartCoroutine(GetDamage(color));
        }
    }

    IEnumerator GetDamage(SpriteRenderer color)
    {
        defaultHp -= 3;
        color.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        color.color = Color.white;

        yield return new WaitForSeconds(1);
        cooldown = true;

    }
}
