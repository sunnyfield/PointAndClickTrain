using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public IRacurs room;

    private void OnMouseDown()
    {
        if(gameObject.CompareTag("Door"))
            room.OpenRacurs();
    }
}
