using UnityEngine;

public class Movement2D : MonoBehaviour
{
	private float moveSpeed;        // �̵� �ӵ�
	private Vector3 moveDirection;
	private int jumpCount;
	private bool doNotJump;
	private bool doNotDash;

	public void Setup(float speed, Vector3 direction)
	{
		moveDirection = direction;
		moveSpeed = speed;
	}

	public void Jump()
    {
		if (doNotJump == false)
        {
			if (gameObject.GetComponent<Rigidbody2D>().velocity.y == 0)
			{
				if (jumpCount > 1) jumpCount = 0;
				jumpCount++;
				gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * 10.0f;
			}
			else if (jumpCount == 1)
			{
				jumpCount++;
				gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * 10.0f;
			}
		}
	}

	public void Dash(bool dir)
    {
		if(doNotDash == false)
        {
			doNotDash = true;
			doNotJump = true;
			gameObject.GetComponent<Rigidbody2D>().velocity = ((dir ? Vector2.right : Vector2.left)) * 20.0f;
			gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
			Invoke("DashEnd", 0.15f);
		}
    }

	private void DashEnd()
    {
		doNotJump = false;
		gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		gameObject.GetComponent<Rigidbody2D>().gravityScale = 3;
		Invoke("DoNotDash", 3.3f-(0.3f*PlayerPrefs.GetInt("DASH")));
	}

	private void DoNotDash()
    {
		doNotDash = false;
    }


	private void Update()
	{
		// ���ο� ��ġ = ���� ��ġ + (���� * �ӵ�)
		transform.position += moveDirection * moveSpeed * Time.deltaTime;
	}
}

