//using Catel.Pooling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketControll : MonoBehaviour
{
	public float impulseSpeed = 3f;
	public float rotateAngle = 100f;

	public GameObject Missle;

	private Rigidbody _rb;

	float tempTime;


	private void OnTriggerEnter(Collider other)
	{
		Destroy(gameObject);
	}

	void Start()
	{
		_rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		Vector3 CurPos = transform.position;
		if(CurPos.x < -9)
		{
			transform.position = new Vector3(9, CurPos.y, 0);
		}

		if(CurPos.x > 9)
		{
			transform.position = new Vector3(-9, CurPos.y, 0);
		}

		if(CurPos.y < -6)
		{
			transform.position = new Vector3(CurPos.x, 6, 0);
		}

		if(CurPos.y > 6)
		{
			transform.position = new Vector3(CurPos.x, -6, 0);
		}
		if (Input.GetAxisRaw("Vertical") == 1)
			Impulse();

		Rotate(Input.GetAxisRaw("Horizontal"));

		if(Input.GetKey(KeyCode.Space))
		{
			tempTime += Time.deltaTime;
			if (tempTime > 0.18f)
			{
				tempTime = 0;
				Instantiate(Missle, transform.position, transform.rotation);
			}
		}
	}

	private void Impulse()
	{
		_rb.velocity += transform.up * impulseSpeed * Time.deltaTime;
	}

	private void Rotate(float rotateDirection)
	{
		var rotation = Quaternion.AngleAxis(rotateDirection * rotateAngle * Time.deltaTime, Vector3.forward);
		transform.up = rotation * transform.up;
	}
}
