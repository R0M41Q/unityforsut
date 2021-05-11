using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBottle : Item
{
    public HealBottle(string _name)
    {
        this.Description = "Healing player";
        this.Name = _name;
        this.Type = "Healer";
        this.Reusable = true;
        this.Usages = 3;
    }

    protected override void Recreate()
    {
        // перезаповнює баночку після використання
    }

    public override void Interact()
    {
        // Якщо не пуста, регенерує здоров'я
    }
}