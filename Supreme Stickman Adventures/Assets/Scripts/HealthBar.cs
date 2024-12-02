using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public PlayerController player;
    Image healthBar;
    public float maxHealth = 100f;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        player.HP = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = player.HP / maxHealth;
    }
}
