using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactable
{
    protected string Name { get; set; } // Ім'я
    protected string Type { get; set; } // Тип
    protected string Description { get; set; } // Опис
    protected bool Reusable { get; set; } = false; // Можливість повторного використання (по замовчуванню неможливо)
    protected int Usages { get; set; } = 1; // Кількість можливого використання (по замовчуванню 1)

    protected virtual void Recreate() { } // Функція "респавну" речі (для override)
}