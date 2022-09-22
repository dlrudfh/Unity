using UnityEngine.UI;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private void Update()
    {
        GetComponent<Slider>().value = (float)player.GetComponent<PlayerLevel>().curHp
                                     / (float)player.GetComponent<PlayerLevel>().maxHp;
    }
}
