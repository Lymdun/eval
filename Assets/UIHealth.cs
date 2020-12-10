using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour {
    public Slider slider;

    void Update() {
        if (Player.localPlayer)
            slider.value = Player.localPlayer.health.health;
    }
}
