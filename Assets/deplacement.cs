using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class deplacement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int temp = 0;
        int var = 0;

        if (transform.position.x > -40 && transform.position.x < -42 && var == 0)
        {
            temp = 1;
            var = 1;
        }
        if (transform.position.x > -22 && transform.position.x < -21 && var == 1)
        {
            temp = 0;
            var = 0;
        }
        if (temp == 1)
            transform.Translate(Vector3.forward * Time.deltaTime * 2);
        if (temp == 0)
            transform.Translate(Vector3.back * Time.deltaTime * 2);
    }
}
