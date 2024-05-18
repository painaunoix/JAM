using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;

    void Start()
    {
        // Charger le volume enregistr� ou d�finir une valeur par d�faut
        float savedVolume = PlayerPrefs.GetFloat("volume", 0.5f);
        audioSource.volume = savedVolume;
        volumeSlider.value = savedVolume;

        // Assigner la m�thode OnVolumeChange � l'�v�nement onValueChanged du curseur
        volumeSlider.onValueChanged.AddListener(OnVolumeChange);
    }

    void OnVolumeChange(float value)
    {
        // Changer le volume de l'audio source
        audioSource.volume = value;

        // Enregistrer le volume choisi par l'utilisateur
        PlayerPrefs.SetFloat("volume", value);
    }
}
