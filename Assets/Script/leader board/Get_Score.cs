using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Get_Score : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI textComponent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameManager = FindObjectOfType<GameManager>();
        Get_score();
    }
    void Get_score() {
        textComponent.text = Mathf.FloorToInt(gameManager.nb_coin).ToString();  
    }
}
