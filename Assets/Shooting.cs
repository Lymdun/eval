using UnityEngine;

public class Shooting : MonoBehaviour {
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 6f;

    void Update() {
        Player player = Player.localPlayer;

        if (player && Input.GetButtonDown("Fire1")) {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            float offset = 1f;
            if ((mousePosition.x - transform.position.x) < 0f)
                offset = -offset;

            firePoint.transform.localPosition = new Vector3(offset, 0f, 0f);

            GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            
            rb.AddForce((mousePosition - transform.position).normalized * bulletForce, ForceMode2D.Impulse);
        }
    }
}