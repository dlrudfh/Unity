using UnityEngine;
using System.Collections;


public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private  int maxHp;
    [SerializeField]
    private  int curHp;
    [SerializeField]
    private GameObject coin;
    [SerializeField]
    private GameObject money;
    [SerializeField]
    private float time;
    private int direction = 1;

    public int MaxHp => maxHp;
    public int CurHp => curHp;

    private void Awake()
    {
        curHp = maxHp;
    }

    private void Update()
    {
        time += Time.deltaTime;
        transform.position += new Vector3(direction, 0, 0) * 1.0f * Time.deltaTime;
        if (time > 2 )
        {
            direction = direction * (-1);
            time = time - 2;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet") || collision.CompareTag("chargedBullet"))
        {
            if (collision.CompareTag("bullet")) Destroy(collision.gameObject);
            if(collision.CompareTag("bullet")) curHp -= player.GetComponent<PlayerLevel>().damage;
            else curHp -= player.GetComponent<PlayerLevel>().damage * 3;
            StopCoroutine("HitColorAnimation");
            StartCoroutine("HitColorAnimation");
            if (curHp <= 0)
            {
                player.GetComponent<PlayerLevel>().GetExp(1);
                Destroy(gameObject);
                int spawnCount = PlayerPrefs.GetInt("spawnCount") - 1;
                PlayerPrefs.SetInt("spawnCount", spawnCount);
                DropItem();
            }
        }
        
    }

    private void DropItem()
    {
        GameObject gold;
        int rand = Random.Range(1, 11);
        if (rand <= 5) gold = Instantiate(money, transform.position, Quaternion.identity);
        else gold = Instantiate(coin, transform.position, Quaternion.identity);
        gold.GetComponent<Gold>().Drop();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerLevel>().TakeDamage(1);
        }
    }

    private IEnumerator HitColorAnimation()
    { 
        GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.05f);
        GetComponent<SpriteRenderer>().color = Color.blue;
    }
}
