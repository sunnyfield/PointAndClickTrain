using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableToRacurs : MonoBehaviour
{
    public IRacurs racurs;

    //private void Start()
    //{
    //    backButton = UIController.instance.backFromCloseUpButton;
    //    UIController.instance.backFromCloseUpButton.onClick.AddListener(Back);
    //    backButton.gameObject.SetActive(false);
    //}

    private void OnMouseDown()
    {
        racurs.OpenRacurs();
        //if(gameObject.CompareTag("PickUp"))
        //{
        //    print("panel activated");
        //    gameObject.GetComponent<SpriteRenderer>().enabled = false;
        //    close.SetActive(true);
        //    print(close);
        //    backButton.gameObject.SetActive(true);
        //    GameController.instance.DeactivateButtons();           
        //}
    }

    //private void Back()
    //{
    //    print("back button pressed");
    //    close.SetActive(false);

    //    if (close == null)
    //        print("close lost");

    //    print(close);
    //    backButton.gameObject.SetActive(false);
    //    GameController.instance.AtivateButtons();
    //    gameObject.SetActive(false);
    //}
}
