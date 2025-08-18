using UnityEngine;

public class AimAtMouse : MonoBehaviour
{
    public Transform weaponPivot;

    void Update()
    {
        if (weaponPivot == null) return;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 dir = (mousePos - weaponPivot.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        weaponPivot.rotation = Quaternion.Euler(0, 0, angle);
    }
}
