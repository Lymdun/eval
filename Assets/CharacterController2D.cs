using UnityEngine;

public class CharacterController2D : MonoBehaviour {
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public float movementSpeed = 5f;
    public BoxCollider2D playerCollider;
    public Rigidbody2D playerRigidbody;

    public bool jumpEnabled = true;
    public float jumpForce = 1f;

    Vector2 jump = new Vector2(0f, 2f);

    void Update() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        if (!Player.localPlayer)
            return;

        if (moveHorizontal != 0f)
            spriteRenderer.flipX = moveHorizontal < 0f;

        animator.SetFloat("Speed", Mathf.Abs(moveHorizontal));

        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f);
        transform.Translate(movement * Time.deltaTime * movementSpeed);
    }

    void LateUpdate() {
        if (Player.localPlayer && Input.GetKeyDown(KeyCode.Space) && jumpEnabled) {
            playerRigidbody.AddForce(jump * jumpForce, ForceMode2D.Impulse);
            animator.SetBool("Jump", true);
        }
           
    }

    void OnCollisionStay2D(Collision2D collision) {
        jumpEnabled = true;
    }

    void OnCollisionExit2D(Collision2D collision) {
        jumpEnabled = false;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        animator.SetBool("Jump", false);
    }
}
