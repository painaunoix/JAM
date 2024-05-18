using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Chrono : MonoBehaviour
{
    public float timerInterval = 5f;
    
    private float elapsedTime = 0f;
    private float minutes = 0f;
    private float nextUpdateTime = 0f;
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI text2;

    void Start()
    {
    StartCoroutine(timer());
    }

    void Update()
    {
        textComponent.text = Mathf.FloorToInt(elapsedTime).ToString();
        text2.text = Mathf.FloorToInt(minutes).ToString();
    }


    public IEnumerator timer()
    {
        yield return new WaitForSeconds(1);
        if (elapsedTime == 60) {
            elapsedTime = 0;
            minutes++;
        }
        elapsedTime++;
        StartCoroutine(timer());
    }
}
