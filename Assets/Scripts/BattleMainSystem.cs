using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleMainSystem : MonoBehaviour
{
    public Unit player;
    public Unit enemy;
    public GameObject Label;
    public GameObject battleLabel;
    public Text battleResultText;
    public Text battleLogText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Battle()
    {
        Unit firstAttackUnit;
        Unit secoundAttackUnit;

        bool firstPlayerAttackFlag = false;

        if(player.speed >= enemy.speed)
        {
            firstAttackUnit = player;
            secoundAttackUnit = enemy;
            firstPlayerAttackFlag = true;
        }
        else
        {
            firstAttackUnit = enemy;
            secoundAttackUnit = player;
        }

        int damage;
        if (firstAttackUnit.hp > 0)
        {
            damage = firstAttackUnit.Attack(secoundAttackUnit);
            if (firstPlayerAttackFlag == true)
            {
                battleLogText.text += $"自分の攻撃:{damage}ダメージ!!\n";
            }
            else
            {
                battleLogText.text += "敵の攻撃:-{damage}ダメージ\n";
            }
        }
        if (secoundAttackUnit.hp > 0)
        {
            damage = secoundAttackUnit.Attack(firstAttackUnit);
            if (firstPlayerAttackFlag == false)
            {
                battleLogText.text += $"自分の攻撃:{damage}ダメージ!!\n";
            }
            else
            {
                battleLogText.text += $"敵の攻撃:-{damage}ダメージ\n";

            }
        }

        player.hpSlider.value = player.hp;
        enemy.hpSlider.value = enemy.hp;

        if(player.hp == 0 && enemy.hp == 0)
        {
            Label.SetActive(true);
            battleResultText.text = "引き分け";
        }else if(enemy.hp == 0)
        {
            battleLabel.SetActive(false);
            Label.SetActive(true);
            battleResultText.text = "敵を倒した！！";
        }
        else if (player.hp == 0)
        {
            battleLabel.SetActive(false);
            Label.SetActive(true);
            battleResultText.text = "ばったんきゅ～";
        }
    }
}
