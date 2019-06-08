using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacursRoom : Racurs
{
    protected RacursRoom()
    { }

    public static new RacursRoom CreateRacurs(GameObject obj)
    {
        RacursRoom racurs = new RacursRoom { gameObject = obj };
        return racurs;
    }

    public override void ActivateRacurs()
    {
        base.ActivateRacurs();
        UIController.instance.itemCounter.SetActive(true);
    }

    protected override void Backward()
    {
        base.Backward();
        UIController.instance.itemCounter.SetActive(false);
    }
}
