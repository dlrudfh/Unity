using TMPro;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private void Update()
    {
        int level = player.GetComponent<PlayerLevel>().level;
        int exp = player.GetComponent<PlayerLevel>().exp;
        int maxHp = player.GetComponent<PlayerLevel>().maxHp;
        int curHp = player.GetComponent<PlayerLevel>().curHp;
        int damage = player.GetComponent<PlayerLevel>().damage;
        int point = player.GetComponent<PlayerLevel>().point;
        int gold = player.GetComponent<PlayerLevel>().gold;
        gameObject.GetComponent<TextMeshProUGUI>().text = "<color=#f000ff>Level : " + level + //ºÐÈ«
                                                          "\n<color=#ff0000>Damage : " + damage + //»¡°­
                                                          "\n<color=#000000>Hp : " + curHp + "/" + maxHp + //°ËÁ¤
                                                          "\n<color=#000000>Exp : " + (float)exp / level * 100 + "%" + 
                                                          "\n<color=#ffffff>" + point + "pts" + //Èò»ö
                                                          "\n<color=#ffff00>" + gold + "G"; // ³ë¶û


    }
}
