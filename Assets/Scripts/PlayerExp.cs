using UnityEngine.UI;
using UnityEngine;

public class PlayerExp : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private void Update()
    {
        GetComponent<Slider>().value = (float)player.GetComponent<PlayerLevel>().exp
                                     / (float)player.GetComponent<PlayerLevel>().level;
    }
}
