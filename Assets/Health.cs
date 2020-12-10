using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour {
    public int health = 100;
    public UnityEvent deathEvent;

    void Update() {
        if (health <= 0)
            deathEvent?.Invoke();
    }
}
