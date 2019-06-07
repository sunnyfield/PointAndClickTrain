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

    void Update()
    {
        transform.localPosition -= speed * Time.deltaTime;

        if(transform.localPosition.x <= -length + 0.5f) Reposition();
    }

    private void Reposition() { transform.localPosition = new Vector3(76.52f, 0f, 0f); }
}
