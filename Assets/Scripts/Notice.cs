using TMPro;
using UnityEngine;

public class Notice : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private int pastLevel = 1;
    private void Update()
    {
        if(player.GetComponent<PlayerLevel>().level > pastLevel)
        {
            pastLevel = player.GetComponent<PlayerLevel>().level;
            if(pastLevel == 3)
            {
                gameObject.GetComponent<TextMeshProUGUI>().text = "Now you can use charge shot!!";
            }
            else gameObject.GetComponent<TextMeshProUGUI>().text = "LEVEL UP!!";
            Invoke("text", 2f);
        }

    }

    public void text()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = " ";
    }
}
