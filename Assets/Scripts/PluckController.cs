using UnityEngine;
using System.Collections;

public class PluckController : MonoBehaviour {
	
	public int blueScore = 0;
	public int redScore = 0;

	private GameObject playerBlue;
	private GameObject playerRed;
	private Vector3 positionBlue;
	private Vector3 positionRed;
	private Vector3 pluckPosition;

	void Start(){
		blueScore = 0;
		redScore = 0;
		playerBlue = GameObject.Find("PlayerBlue");
		playerRed = GameObject.Find("PlayerRed");
		positionBlue = playerBlue.transform.position;
		positionRed = playerRed.transform.position;
		pluckPosition = transform.position;
	}

	void OnTriggerEnter2D(Collider2D trigger){
		if (trigger.name == "RedNet"){
			redScore += 1;
			pluckPosition.x = -2.4f;
			transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		}
		else if (trigger.name == "BlueNet"){
			blueScore += 1;
			pluckPosition.x = 2.4f;
			transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		}
		transform.position = pluckPosition;
	}
}
