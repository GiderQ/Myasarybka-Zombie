using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform player;
    public float minRadius = 0.5f; 
    public float maxRadius = 2.0f;
    public float spriteRotationOffset = -90f;

    void Update()
    {
        RotateAroundPlayer();
    }

    void RotateAroundPlayer()
    {
        if (player == null) return;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        Vector3 dir = (mousePos - player.position).normalized;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.position = player.position + dir * Mathf.Clamp((mousePos - player.position).magnitude, minRadius, maxRadius);

       
        transform.rotation = Quaternion.Euler(0, 0, angle + spriteRotationOffset);
    }
}
