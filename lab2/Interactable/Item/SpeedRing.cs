using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedRing : Item // кільце, що прискорює гравця
{
    public SpeedRing(string _name)
    {
        this.Description = "Speeding up player";
        this.Name = _name;
        this.Type = "Buff";
        this.Reusable = true;
        this.Usages = 3;
    }

    public override void Interact()
    {
        // Реалізація пришвидшення на N секунд
    }
}