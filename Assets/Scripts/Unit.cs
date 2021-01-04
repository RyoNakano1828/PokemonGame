using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public int hp;
    public int power;
    public int speed;
    public Slider hpSlider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Attack(Unit target)
    {
        System.Random r = new System.Random();
        int randomValue = r.Next(10);
        int damage;
        if (randomValue < 3)
        {
            damage = this.power * 2;
        }
        else
        {
            damage = this.power;
        }

        target.hp = target.hp - damage;


        if (target.hp < 0)
        {
            target.hp = 0;
        }
        Debug.Log(target.hp);
        return damage;
    }
}
