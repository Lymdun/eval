using UnityEngine;

public class EnemyAttack : MonoBehaviour {
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 1.5f;
    public float attackTimer = 1.4f;
    public int attackDamage = 20;

    GameObject target;
    float timer;

    void Update() {
        timer += Time.deltaTime;

        if (timer >= attackTimer && target)
            Attack();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
            target = other.gameObject;
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
            target = null;
    }

    void Attack() {
        timer = 0f;
        
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            
        rb.AddForce((target.transform.position - transform.position) * bulletForce, ForceMode2D.Impulse);
    }
}
