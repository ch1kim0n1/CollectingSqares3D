using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	int score;
	public Text scoreText;
	float timer;
	public Text timerText;
	public Text winText;
	public GameObject vBall;

	// Use this for initialization
	void Start () {
		score = 0;
		scoreText.text = "Score: " + score.ToString ();
		rb = GetComponent<Rigidbody>();
		winText.gameObject.SetActive (false);

	}

	public float fallSpeed;
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		float jumpHeight = 0;
		jumpHeight = Mathf.Lerp (jumpHeight, 0, fallSpeed);
		if (Input.GetButtonDown ("Jump") && jumpHeight == 0)
			jumpHeight += 20;

		Vector3 movement = new Vector3 (moveHorizontal, jumpHeight, moveVertical);
		rb.AddForce (movement * speed);
		if (score < 13) {
		timer = timer + Time.deltaTime;

		timerText.text = "Time: " + timer.ToString ("F2");
		}

	}


	void OnTriggerEnter(Collider other){
		Destroy (other.gameObject);
		score = score + 1;
		scoreText.text = "Score: " + score.ToString ();
		if (score == 13){
			winText.gameObject.SetActive (true);
			FireWorks();
		}
		
		

	}
	void FireWorks(){
		for (int i = 0; i < 100; i++){
			Instantiate (vBall, new Vector3(0,10,0), Quaternion.identity );

			
		}
	}
}

