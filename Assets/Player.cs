using UnityEngine;

public class Player : MonoBehaviour {
    public static Player localPlayer;

    public Health health;
    public CharacterController2D characterController;
    public Shooting shooting;

    void Awake() {
        localPlayer = this;
    }

    void Update() {
        if (transform.position.y < -5f)
            health.health = 0;

    }

    public void Kill() {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Trap")) {
            health.health -= 10;
            characterController.animator.SetBool("Hurt", true);
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        if (collider.CompareTag("Trap"))
            characterController.animator.SetBool("Hurt", false);
    }
}
