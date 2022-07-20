using UnityEngine;

public class Uproot : Interactable
{
    public override string GetInteractDescription()
    {
        return "Press [F] to uproot plant.";
    }

    public override void Interact() {
        Destroy(this.gameObject);
    }
}
