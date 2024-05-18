using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Rendering;

public class Chrono : MonoBehaviour
{
    public float timerInterval = 5f;
    
    private float elapsedTime = 0f;
    private float minutes = 0f;
    private float secondt = 0f;
    private float minutes10 = 0f;
    private float nextUpdateTime = 0f;
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI text2;

    public TextMeshProUGUI seconds10;

    public TextMeshProUGUI minuteplus;
    void Start()
    {
    StartCoroutine(timer());
    }

    void Update()
    {
        textComponent.text = Mathf.FloorToInt(elapsedTime).ToString();
        text2.text = Mathf.FloorToInt(minutes).ToString();
        seconds10.text = Mathf.FloorToInt(secondt).ToString();
        minuteplus.text = Mathf.FloorToInt(minutes10).ToString();
    }


    public IEnumerator timer()
    {
        yield return new WaitForSeconds(1);
        if (secondt == 5 && elapsedTime == 9) {
            minutes++;
            secondt = 0;
            elapsedTime = -1;
        }
        if (elapsedTime == 9) {
            elapsedTime = -1;
            secondt++;
        }
        if (minutes == 9) {
            minutes = -1;
            minutes10++;
        }
        elapsedTime++;
        StartCoroutine(timer());
    }
}
