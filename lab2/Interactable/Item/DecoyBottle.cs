using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoyBottle : Item // виглядає як HealBottle, але наносить поранення
{
    public DecoyBottle(string _name)
    {
        this.Description = "Deal damage to player or NPC";
        this.Name = _name;
        this.Type = "Harmful";
        this.Reusable = false;
    }

    protected override void Recreate()
    {
        // перезаповнює баночку після використання
    }

    public override void Interact()
    {
        // Завдає шкоди, якщо не пуста
    }
}