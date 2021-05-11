using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Interactable
{
    protected string Name { get; set; } // Ім'я
    protected int Health { get; set; }  // Зроров'я
    protected int Damage { get; set; }  // Сила атаки

    public Enemy (string _name)
    {
        Name = _name;
    }

    protected virtual void Move() { } // Тут буде override функції руху ворога

    public virtual void Attack() 
    {
        // Реалізована функція атаки 
    }
}