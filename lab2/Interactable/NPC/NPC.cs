using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    protected string Name { get; set; } // ім'я
    protected string Role { get; set; } // Роль
    protected int Health { get; set; } // Здоров'я
    protected List<string> Messages { get; set; } // Повідомлення

    protected virtual void Move() { } // Скрипт руху (для override)

    protected virtual void Talk(List<string> Messages) { } // Реалізований скрипт розмови
}