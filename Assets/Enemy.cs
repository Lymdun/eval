using UnityEngine;

public class Enemy : MonoBehaviour {
    public Health health;

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.GetComponent<Bullet>())
            health.health -= 20;
    }

    public void Kill() {
        Destroy(gameObject);
    }
}
