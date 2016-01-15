using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float collisionForce = 100f;
	public float collisionRadius = 0.8f;
	public float LBoundary = -4.5f;
	public float RBoundary = 4.5f;
	public float YBoundary = 2.5f;

	private Vector3 playerPosition = Vector3.zero;

	void Update(){
		TrackPlayerMovements();
		CheckBoundaries();
	}
	
	void OnMouseDrag () {
		transform.position = Vector3.MoveTowards (transform.position, playerPosition, 100f * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Pluck") {
			float XForce = Input.GetAxis ("Mouse X");
			XForce = XForce > 1 ? 1 : XForce;
			XForce = XForce < -1 ? -1 : XForce;
			XForce = XForce * collisionForce;
			float YForce = Input.GetAxis ("Mouse Y");
			YForce = YForce > 1 ? 1 : YForce;
			YForce = YForce < -1 ? -1 : YForce;
			YForce = YForce * collisionForce;
			Rigidbody2D rigidbody = collision.collider.GetComponent<Rigidbody2D>();
			rigidbody.AddForce(rigidbody.transform.right * XForce, ForceMode2D.Force);
			rigidbody.AddForce(rigidbody.transform.up * YForce, ForceMode2D.Force);
		}
	}

	void TrackPlayerMovements(){
		playerPosition = Input.mousePosition;
		playerPosition = Camera.main.ScreenToWorldPoint(playerPosition);
		playerPosition.z = transform.position.z;
	}

	void CheckBoundaries(){
		if(playerPosition.y > YBoundary){
			playerPosition.y = YBoundary;
		}
		if(playerPosition.y < -1 * YBoundary){
			playerPosition.y = -1 * YBoundary;
		}
		if(playerPosition.x < LBoundary){
			playerPosition.x = LBoundary;
		}
		if(playerPosition.x > RBoundary){
			playerPosition.x = RBoundary;
		}
	}
}
