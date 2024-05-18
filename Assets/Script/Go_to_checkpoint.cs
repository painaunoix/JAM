using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Go_to_checkpoint : MonoBehaviour
{
    public Transform target;
    public GameObject player;
    public Rigidbody rb;

    public int Time = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.R))
        {
            MoveToTarget();
        }
    }

    void MoveToTarget()
    {
        rb.isKinematic = true;
        player.transform.position = target.position;
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.05f);
        rb.isKinematic = false;
        Time = 0;
    }
}
