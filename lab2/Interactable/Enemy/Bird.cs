using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Enemy
{
    public Bird(string _name) : base(_name)
    {
        this.Name = _name;
        this.Damage = 10;
        this.Health = 200;
    }

    protected override void Move()
    {
         // Реалізована функція польоту
    }

    public override void Interact()
    {
        base.Attack();
    }
}