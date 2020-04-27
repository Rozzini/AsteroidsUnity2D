using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ship
{
	public class RocketControll : MonoBehaviour
	{
		public float impulseSpeed = 1.5f;

		public float rotateAngle = 100f;

		public bool isDead;

		public static int ShipArmor;

		public GameObject Missle;

		private Rigidbody _rb;

		float tempTime;

		public GameObject MenuButton;

		public GameObject RestartButton;

		public GameObject NameInputField;

		private void OnTriggerEnter(Collider other)
		{
			ShipArmor--;
		}

		void Start()
		{
			MenuButton.SetActive(false);
			RestartButton.SetActive(false);
			NameInputField.SetActive(false);
			ShipArmor = 1000000;
			_rb = GetComponent<Rigidbody>();
		}

		void Update()
		{
			if (ShipArmor < 0)
			{
				Destroy(gameObject);
				isDead = true;
			}

			if (isDead == true)
			{
				MenuButton.SetActive(true);
				RestartButton.SetActive(true);
				NameInputField.SetActive(true);
			}


			Vector3 CurPos = transform.position;
			if (CurPos.x < -9)
			{
				transform.position = new Vector3(9, CurPos.y, 0);
			}

			if (CurPos.x > 9)
			{
				transform.position = new Vector3(-9, CurPos.y, 0);
			}

			if (CurPos.y < -6)
			{
				transform.position = new Vector3(CurPos.x, 6, 0);
			}

			if (CurPos.y > 6)
			{
				transform.position = new Vector3(CurPos.x, -6, 0);
			}
			if (Input.GetAxisRaw("Vertical") == 1)
				Impulse();

			Rotate(Input.GetAxisRaw("Horizontal"));

			if (Input.GetKey(KeyCode.Space))
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
			if (_rb.velocity.x < 3 || _rb.velocity.y < 3)
			{
				_rb.velocity += transform.up * impulseSpeed * Time.deltaTime;
			}
		}

		private void Rotate(float rotateDirection)
		{
			var rotation = Quaternion.AngleAxis(rotateDirection * rotateAngle * Time.deltaTime, Vector3.forward);
			transform.up = rotation * transform.up;
		}
	}
}
