using UnityEngine;
using System.Collections;

public class player_controller : MonoBehaviour {
	
	private const float PLAYER_SPEED = 1f;
	private const float PLAYER_JUMP = 15f;
	private const float PLAYER_SPEEDLIMIT = 10f;
	private bool isGrounded = false;

	void Start () {
	
	}

	void Update () {
		bool _l = (this.rigidbody2D.velocity.x - PLAYER_SPEED > PLAYER_SPEEDLIMIT * -1);
		bool _r = (this.rigidbody2D.velocity.x - PLAYER_SPEED < PLAYER_SPEEDLIMIT);
		if (Input.GetKey (KeyCode.A)
		 || Input.GetKey (KeyCode.LeftArrow)) {
			this.rigidbody2D.velocity = new Vector3(
				    (_l ? this.rigidbody2D.velocity.x - PLAYER_SPEED : this.rigidbody2D.velocity.x),
				    this.rigidbody2D.velocity.y
				);
		}
		if ((Input.GetKeyDown (KeyCode.W)
		 || Input.GetKeyDown (KeyCode.UpArrow))
		 && isGrounded) {
			this.rigidbody2D.velocity = new Vector3(
					this.rigidbody2D.velocity.x,
					this.rigidbody2D.velocity.y + PLAYER_JUMP
				);
		}

		if (Input.GetKey (KeyCode.D)
		 || Input.GetKey (KeyCode.RightArrow)) {
			this.rigidbody2D.velocity = new Vector3(
				    (_r ? this.rigidbody2D.velocity.x + PLAYER_SPEED : this.rigidbody2D.velocity.x),
					this.rigidbody2D.velocity.y
				);
		}

		if (this.rigidbody2D.velocity.x > 0 && this.rigidbody2D.velocity.x <= 0.7f
		 || this.rigidbody2D.velocity.x < 0 && this.rigidbody2D.velocity.x >= -0.7f) {
			this.rigidbody2D.velocity =  new Vector3(0f, this.rigidbody2D.velocity.y);
		}
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.name == "floor") {
			isGrounded = true;
		}
	}

	void OnCollisionExit2D (Collision2D col) {
		if (col.gameObject.name == "floor") {
			isGrounded = false;
		}
	}
}
