using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {

	public float movementSpeed;

	private Rigidbody2D rb;

	//float movement;
    float screenEdge = 3.8f;

	private bool moveLeft, moveRight;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		movementSpeed = 10f;
		moveLeft = false;
		moveRight = false;
	}
	
	// Update is called once per frame
	void Update () {
		//movement = CrossPlatformInputManager.GetAxis("Horizontal") * movementSpeed;

        if (transform.position.x < -screenEdge)
        {
            transform.position = new Vector3(screenEdge, transform.position.y, transform.position.z);
        }

        else if (transform.position.x > screenEdge)
        {
            transform.position = new Vector3(-screenEdge, transform.position.y, transform.position.z);
        }
	}

	public void MoveLeftDown()
	{
		moveLeft = true;
	}

	public void MoveLeftUp()
	{
		moveLeft = false;
	}

	public void MoveRightDown()
	{
		moveRight = true;
	}

	public void MoveRightUp()
	{
		moveRight = false;
	}

	void FixedUpdate()
	{
		if (moveLeft)
		{
			rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
		}

		else if (moveRight)
		{
			rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
		}

		else
		{
			rb.velocity = new Vector2(0f, rb.velocity.y);
		}
	}

	// void FixedUpdate()
	// {
	// 	Vector2 velocity = rb.velocity;
	// 	velocity.x = movement;
	// 	rb.velocity = velocity;

	// 	// if (rb.position.y < -1 && outofscreen == false)
	// 	// {
	// 	// 	outofscreen = true;
	// 	// 	Debug.Log("Out of Screen");
	// 	// }
	// }

	void OnBecameInvisible()
	{
		FindObjectOfType<GameManager>().EndGame();
		// Destroy(this.gameObject);
	}
}