using UnityEngine;

public class Bullet : MonoBehaviour {
    public GameObject hitEffect;

    void OnCollisionEnter2D(Collision2D collision) {
        if (hitEffect && collision.gameObject.CompareTag("Enemy")) {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.3f);
        }

        Destroy(gameObject);
    }
}
