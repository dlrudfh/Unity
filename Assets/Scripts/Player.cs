using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private StageData stage;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private GameObject chargedBullet;
    [SerializeField]
    private KeyCode attack;
    [SerializeField]
    private KeyCode jump;
    [SerializeField]
    private KeyCode dash;
    private AudioSource audioSource;
    private bool dir;
    private float startTime;
    private bool chargeComplete = true;

    private void Awake()
    {
        dir = true;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        if(x != 0)
        {
            if (x > 0) dir = true;
            else dir = false;
        }
        transform.position += new Vector3(x, 0, 0) * speed * Time.deltaTime;
        if (Input.GetKeyDown(attack))
        {
            startTime = Time.time;
            chargeComplete = false;
            GameObject bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            bullet.GetComponent<Movement2D>().Setup(10.0f, new Vector3((dir ? 1 : -1), 0, 0));
            Destroy(bullet, 2.0f);
        }
        if (PlayerPrefs.GetInt("CHARGESHOT") > 0)
        {
            if(chargeComplete == false && Time.time - startTime >= 0.7f)
            {
                audioSource.Play();
                chargeComplete = true;
            }
            if (Input.GetKeyUp(attack))
            {
                if (chargeComplete == true)
                {
                    GameObject charge = Instantiate(chargedBullet, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                    charge.GetComponent<Movement2D>().Setup(20.0f, new Vector3((dir ? 1 : -1), 0, 0));
                    Destroy(charge, 1.0f);
                }
                else chargeComplete = true;
            }
        }
        if (PlayerPrefs.GetInt("DASH") > 0)
        {
            if (Input.GetKeyDown(dash)) GetComponent<Movement2D>().Dash(dir);
        }
        if(Input.GetKeyDown(jump))
        {
            gameObject.GetComponent<Movement2D>().Jump();
        }
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stage.LimitMin.x, stage.LimitMax.x),
                                         Mathf.Clamp(transform.position.y, stage.LimitMin.y, stage.LimitMax.y));
    }
}
