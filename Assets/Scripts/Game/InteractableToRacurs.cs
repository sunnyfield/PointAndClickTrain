using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableToRacurs : MonoBehaviour
{
    public IRacurs racurs;

    private void OnMouseDown()
    {
        if (!UIController.instance.menuIsOpen)
            racurs.OpenRacurs();
    }
}
