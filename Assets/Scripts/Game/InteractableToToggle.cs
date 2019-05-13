using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableToToggle : MonoBehaviour
{
    public GameObject toggle;

    private void OnMouseDown()
    {
        if(!UIController.instance.menuIsOpen)
            toggle.SetActive(!toggle.activeInHierarchy);
    }
}
