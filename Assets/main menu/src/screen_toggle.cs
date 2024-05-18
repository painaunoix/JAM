using UnityEngine;
using UnityEngine.UI;

public class ScreenToggle : MonoBehaviour
{
    public Button toggleButton;

    void Start()
    {
        // Assigner la méthode ToggleFullScreen à l'événement onClick du bouton
        toggleButton.onClick.AddListener(ToggleFullScreen);
    }

    void ToggleFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
