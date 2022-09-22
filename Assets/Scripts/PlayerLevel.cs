using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerLevel : MonoBehaviour
{
    public int level;
    public int damage;
    public int exp;
    public int maxHp = 3;
    public int curHp;
    public int point = 0;
    public int gold = 0;

    public void GetExp(int enemyExp)
    {
        exp += enemyExp;
        if (exp >= level)
        {
            exp -= level;
            level++;
            point++;
            curHp = maxHp;
            if(level == 3)
            {
                PlayerPrefs.SetInt("ChargeShot", 1);
            }
            if (level == 5)
            {
                PlayerPrefs.SetInt("Dash", 1);
            }
        }
    }

    public void GetGold(int enemyGold)
    {
        gold += enemyGold;
    }

    public void DamageUp()
    {
        if (point > 0)
        {
            damage++;
            point--;
        }
        
    }

    public void HpUp()
    {
        if(point > 0)
        {
            maxHp++;
            curHp++;
            point--;
        }

    }

    public void TakeDamage(int enemyDmg)
    {
        curHp -= enemyDmg;
        if (curHp <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

}
