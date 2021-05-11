using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seller : NPC
{
    private List<Item> Items { get; set; }

    public Seller(string _name) : base(_name)
    {
        this.Health = 100;
        this.Messages = new List<string> { "Hello", "Need something?" };
        this.Name = _name;
        this.Role = "Seller";
    }

    private void SellMenu(List<Item> Items)
    {
        // Діалог з покупкою і продажем
    }


    public override void Interact()
    {
        // Відкрити Діалог з гравцем
        Talk();
    }
}