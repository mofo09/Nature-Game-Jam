using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pond : Interactable
{
    public override string GetInteractDescription()
    {
        return "Press [F] to refill container.";
    }

    public override void Interact()
    {
        FindObjectOfType<WateringCan>().HandleRefill();
    }
}
