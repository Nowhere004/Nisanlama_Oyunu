using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour {
    private int health;
    private int numberOfHealth=3;

    public Image[] healths;
    public Sprite empHealth;
    public Sprite fulHealth;
    private Oyuncu player;
    // Update is called once per frame
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Oyuncu>();
    }
    void Update () {
        health = player.health;
        if (health > numberOfHealth)
        {
            health = numberOfHealth;
        }
        for (int i = 0; i < healths.Length; i++)
        {
            if (i < health)
            {
                healths[i].sprite = fulHealth;
            }
            else
            {
                healths[i].sprite = empHealth;
            }

            if (i < numberOfHealth)
            {
                healths[i].enabled = true;
            }
            else
            {
                healths[i].enabled = false;
            }
        }

    }
}
