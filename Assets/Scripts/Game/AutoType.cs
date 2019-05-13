using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoType : MonoBehaviour
{
    Text textComponent;
    Coroutine typeTextRoutine;

    string message;

    void OnEnable()
    {
        textComponent = gameObject.GetComponent<Text>();
        message = textComponent.text;
        textComponent.text = "";
        if(typeTextRoutine == null)
            typeTextRoutine = StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        foreach(char letter in message.ToCharArray())
        {
            textComponent.text += letter;
            yield return new WaitForSeconds(0.03f);
        }
        typeTextRoutine = null;
    }

    private void OnDisable()
    {
        textComponent.text = message;
        if(typeTextRoutine != null)
            StopCoroutine(typeTextRoutine);
        typeTextRoutine = null;
    }
}
