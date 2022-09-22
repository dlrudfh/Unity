using System.Collections;
using UnityEngine;

public class Gold : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private bool alreadyPick;
    private AudioSource pick;

    private void Awake()
    {
        pick = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && alreadyPick == false)
        {
            alreadyPick = true;
            if(CompareTag("coin")) player.GetComponent<PlayerLevel>().GetGold(1);
            else player.GetComponent<PlayerLevel>().GetGold(5);
            Pick();
        }
    }

	public void Drop()
	{
		GetComponent<Rigidbody2D>().velocity = Vector2.up * 7.0f;
        GetComponent<Rigidbody2D>().gravityScale = 3;
        Invoke("DropStop", 0.5f);
	}

    private void DropStop()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    public void Pick()
    {
        pick.Play();
        GetComponent<Rigidbody2D>().velocity = Vector2.up * 7.0f;
        GetComponent<Rigidbody2D>().gravityScale = 3;
        StartCoroutine("FadeOut");
        Destroy(gameObject, 0.5f);
    }

    private IEnumerator FadeOut()
    {
        float a = 1;
        while (a != 0 && CompareTag("coin")) 
        {
            a = GetComponent<SpriteRenderer>().color.a;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 0, a - 0.02f);
            yield return new WaitForSeconds(0.01f);
        }
        while (a != 0 && CompareTag("money"))
        {
            a = GetComponent<SpriteRenderer>().color.a;
            GetComponent<SpriteRenderer>().color = new Color(0.05f, 0.65f, 0.05f, a - 0.02f);
            yield return new WaitForSeconds(0.01f);
        }
    }

}
