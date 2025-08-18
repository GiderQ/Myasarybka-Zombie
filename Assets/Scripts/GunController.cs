using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        RotateAroundPlayer();
    }

    void RotateAroundPlayer()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

     
        Vector3 dir = (mousePos - player.position).normalized;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

    
        transform.position = player.position;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
