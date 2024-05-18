using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_position : MonoBehaviour
{
    public Transform playerTransform;
    private bool isGrounded;

    void Start()
    {
        LoadPosition();
    }

    void Update()
    {
        isGrounded = Physics.Raycast(playerTransform.position, Vector3.down, 1.1f);

        if (isGrounded)
        {
            SavePosition();
        }
    }

    public void SavePosition()
    {
        Vector3 position = playerTransform.position;
        PlayerPrefs.SetFloat("PlayerX", position.x);
        PlayerPrefs.SetFloat("PlayerY", position.y);
        PlayerPrefs.SetFloat("PlayerZ", position.z);
        PlayerPrefs.Save();
        Debug.Log("Position sauvegardée : " + position);
    }

    public void LoadPosition()
    {
        if (PlayerPrefs.HasKey("PlayerX") && PlayerPrefs.HasKey("PlayerY") && PlayerPrefs.HasKey("PlayerZ"))
        {
            float x = PlayerPrefs.GetFloat("PlayerX");
            float y = PlayerPrefs.GetFloat("PlayerY");
            float z = PlayerPrefs.GetFloat("PlayerZ");
            playerTransform.position = new Vector3(x, y, z);
            Debug.Log("Position chargée : " + playerTransform.position);
        }
        else
        {
            Debug.LogWarning("Aucune position sauvegardée trouvée.");
        }
    }
}
