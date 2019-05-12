using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IRacurs
{
    void OpenRacurs();
    void ActivateRacurs();
    void DeactivateRacurs();
    void SetForw(IRacurs forw);
    void SetPrev(IRacurs prev);
    void SetRight(IRacurs right);
    void SetLeft(IRacurs left);
    void SetButtons();
}


public class Racurs : IRacurs
{
    protected GameObject gameObject;
    protected IRacurs forwardRacurs = null;
    protected IRacurs prevRacurs = null;
    protected IRacurs leftRacurs = null;
    protected IRacurs rightRacurs = null;

    protected Racurs()
    { }

    public static Racurs CreateRacurs(GameObject obj)
    {
        Racurs racurs = new Racurs { gameObject = obj };
        return racurs;
    }

    protected void Forward()
    {
        if (forwardRacurs == null)
            return;

        forwardRacurs.SetPrev(this);
        forwardRacurs.ActivateRacurs();    
        gameObject.SetActive(false);
    }

    protected virtual void Left()
    {
        if (leftRacurs == null)
            return;

        leftRacurs.SetPrev(this);
        leftRacurs.ActivateRacurs();      
        gameObject.SetActive(false);
    }

    protected virtual void Right()
    {
        if (rightRacurs == null)
            return;

        rightRacurs.SetPrev(this);
        rightRacurs.ActivateRacurs();
        gameObject.SetActive(false);
    }

    protected void Backward()
    {
        if (prevRacurs == null)
            return;

        prevRacurs.ActivateRacurs();
        gameObject.SetActive(false);
    }

    public void OpenRacurs()
    {  
        prevRacurs.DeactivateRacurs();
        ActivateRacurs();
    }

    public void ActivateRacurs()
    {
        GameController.instance.currentRacurs = this;
        UIController.instance.SetCursorMain();
        gameObject.SetActive(true);
        SetButtons();
    }

    public void DeactivateRacurs()
    {
        gameObject.SetActive(false);
        ClearButtons();
    }

    public void SetForw(IRacurs forw)
    {
        forwardRacurs = forw;
    }

    public void SetPrev(IRacurs prev)
    {
        prevRacurs = prev;
    }

    public void SetRight(IRacurs right)
    {
        rightRacurs = right;
    }

    public void SetLeft(IRacurs left)
    {
        leftRacurs = left;
    }

    public void SetButtons()
    {
        if (forwardRacurs == null)
            UIController.instance.forward.gameObject.SetActive(false);
        else
        {
            UIController.instance.forward.gameObject.SetActive(true);
            UIController.instance.forward.onClick.RemoveAllListeners();
            UIController.instance.forward.onClick.AddListener(Forward);
        }

        if (prevRacurs == null)
            UIController.instance.backward.gameObject.SetActive(false);
        else
        {
            UIController.instance.backward.gameObject.SetActive(true);
            UIController.instance.backward.onClick.RemoveAllListeners();
            UIController.instance.backward.onClick.AddListener(Backward);
        }

        if (rightRacurs == null)
            UIController.instance.right.gameObject.SetActive(false);
        else
        {
            UIController.instance.right.gameObject.SetActive(true);
            UIController.instance.right.onClick.RemoveAllListeners();
            UIController.instance.right.onClick.AddListener(Right);
        }

        if (leftRacurs == null)
            UIController.instance.left.gameObject.SetActive(false);
        else
        {
            UIController.instance.left.gameObject.SetActive(true);
            UIController.instance.left.onClick.RemoveAllListeners();
            UIController.instance.left.onClick.AddListener(Left);
        }
    }

    protected void ClearButtons()
    {
        UIController.instance.forward.onClick.RemoveAllListeners();
        UIController.instance.backward.onClick.RemoveAllListeners();
        UIController.instance.right.onClick.RemoveAllListeners();
        UIController.instance.left.onClick.RemoveAllListeners();
    }  
}
