using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sportsman : NPC
{
    public Sportsman(string _name)
    {
        this.Health = 100;
        this.Messages = new List<string> { "What's going on?", "Ready to run?" };
        this.Name = _name;
        this.Role = "Sportsman";
    }

    protected override void Move()
    {
        // Бігати по визначеній площі 
    }

    public override void Interact()
    {
        // Відкрити Діалог з гравцем
        Talk();
    }
}