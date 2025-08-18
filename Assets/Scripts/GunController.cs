using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform player;   // Assign player here
    public float radius = 1f;  // Distance from player

    void Update()
    {
        FollowMouse();
    }

    void FollowMouse()
    {
        // Mouse world position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        // Direction from player to mouse
        Vector3 dir = (mousePos - player.position).normalized;

        // Position gun at a fixed radius from player in that direction
        transform.position = player.position + dir * radius;

        // Optional: rotate gun to point at mouse
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}

