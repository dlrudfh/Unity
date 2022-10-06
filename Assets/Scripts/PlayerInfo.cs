using TMPro;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    int level;
    int exp;
    int maxHp;
    int curHp;
    int damage;
    int point;
    int gold;

    private void Update()
    {
        level = PlayerPrefs.GetInt("LV");
        damage = PlayerPrefs.GetInt("DMG");
        exp = PlayerPrefs.GetInt("XP");
        maxHp = PlayerPrefs.GetInt("HP");
        curHp = PlayerPrefs.GetInt("HP");
        point = PlayerPrefs.GetInt("PTS");
        gold = PlayerPrefs.GetInt("GOLD");
        gameObject.GetComponent<TextMeshProUGUI>().text = "<color=#f000ff>Level : " + level + //ºÐÈ«
                                                          "\n<color=#ff0000>Damage : " + damage + //»¡°­
                                                          "\n<color=#000000>Hp : " + curHp + "/" + maxHp + //°ËÁ¤
                                                          "\n<color=#000000>Exp : " + (float)exp / level * 100 + "%" + 
                                                          "\n<color=#ffffff>" + point + "pts" + //Èò»ö
                                                          "\n<color=#ffff00>" + gold + "G"; // ³ë¶û


    }
}
