using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{

    public Image healthBar;
    public float health;
    public float maxHealth;



    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health / maxHealth;
    }
}

