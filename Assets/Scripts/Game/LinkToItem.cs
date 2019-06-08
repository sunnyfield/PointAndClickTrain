using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkToItem : MonoBehaviour
{
    public GameObject linkedObject;

    private void OnEnable() { linkedObject.SetActive(true); }

    private void OnDestroy() { linkedObject.SetActive(false); }
}
