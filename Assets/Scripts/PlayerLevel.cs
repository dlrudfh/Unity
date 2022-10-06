using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerLevel : MonoBehaviour
{
    public int level;
    public int damage;
    public int exp;
    public int maxHp;
    public int curHp;
    public int point;
    public int gold;

    public void Awake()
    {
        level = PlayerPrefs.GetInt("LV");
        damage = PlayerPrefs.GetInt("DMG");
        exp = PlayerPrefs.GetInt("XP");
        maxHp = PlayerPrefs.GetInt("HP");
        curHp = PlayerPrefs.GetInt("HP");
        point = PlayerPrefs.GetInt("PTS");
        gold = PlayerPrefs.GetInt("GOLD");
    }

    public void GetExp(int enemyExp)
    {
        level = PlayerPrefs.GetInt("LV");
        exp += enemyExp;
        if (exp >= level)
        {
            exp -= level;
            PlayerPrefs.SetInt("LV", ++level);
            PlayerPrefs.SetInt("PTS", ++point);
            curHp = maxHp;
        }
        PlayerPrefs.SetInt("XP", exp);
        
    }

    public void GetGold(int enemyGold)
    {
        gold += enemyGold;
        PlayerPrefs.SetInt("GOLD", gold);
    }

    public void DamageUp()
    {
        if (point > 0)
        {
            PlayerPrefs.SetInt("DMG", ++damage);
            PlayerPrefs.SetInt("PTS", --point);
        }
        
    }

    public void HpUp()
    {
        if(point > 0)
        {
            PlayerPrefs.SetInt("HP", ++maxHp);
            curHp++;
            PlayerPrefs.SetInt("PTS", --point);
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
