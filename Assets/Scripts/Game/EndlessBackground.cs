using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessBackground : MonoBehaviour
{
    private float length;
    Vector3 speed; 

    private void Start()
    {
        speed = new Vector3(13f, 0f, 0f);
        length = 76.52f;
    }

    void FixedUpdate()
    {
        transform.localPosition -= speed * Time.fixedDeltaTime;

        if(transform.localPosition.x <= -length)
        {
            //print(transform.localPosition.x);
            Reposition();
        }
    }

    private void Reposition()
    {
        transform.localPosition = new Vector3(76.52f, 0f, 0f);
    }
}
