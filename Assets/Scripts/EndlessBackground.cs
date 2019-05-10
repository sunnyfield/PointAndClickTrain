using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessBackground : MonoBehaviour
{
    private float length = 75f;
    Vector3 speed = new Vector3(13f, 0f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= speed * Time.deltaTime;

        if(transform.position.x < - length)
        {
            Reposition();
        }
    }

    private void Reposition()
    {
        Vector2 offset = new Vector2(length * 2f, 0f);
        transform.position = (Vector2)transform.position + offset;
    }
}
