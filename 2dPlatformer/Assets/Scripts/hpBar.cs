using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;
    [SerializeField] private Image handle;
    [SerializeField] private playerHP player;



    void Start()
    {
        
    }

    void FixedUpdate()
    {
        slider.value = player.getHP();
        fill.color = gradient.Evaluate(player.getHP() / 100f);
        handle.color = gradient.Evaluate(player.getHP() / 100f);
    }
}
