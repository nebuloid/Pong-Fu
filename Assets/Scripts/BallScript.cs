using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {
	
	public Camera mainCamera;
	
	public float ballSpeed = 80f;
	
	// Use this for initialization
	void Start () {
		//POSITION ball
		transform.position = new Vector2(mainCamera.ScreenToWorldPoint (new Vector3(Screen.width / 2f, 0f, 0f)).x, 0f);
		
		StartCoroutine(shootBall());
	}

	//COROUTINE. Is called when method is called but runs in parallel so the game does not wait for it
	IEnumerator shootBall() {
		yield return new WaitForSeconds(2);

		//Shoot ball
		rigidbody2D.AddForce(new Vector2(ballSpeed, 10f));
	}
	
	void ResetBall(){
		transform.position = new Vector2(0f, 0f);
		rigidbody2D.velocity = new Vector2(0f, 0f);

		StartCoroutine(shootBall());
	}

	// Update is called once per frame
	void Update () {
	
	}

	//when ball hits something
	void OnCollisionEnter2D(Collision2D colInfo){
		if(colInfo.collider.tag == "Player" || colInfo.collider.tag == "Player2"){

			//add velocity of player to the ball
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, rigidbody2D.velocity.y/2f + colInfo.collider.rigidbody2D.velocity.y/3);
			//TODO: figure out a good way to modulate the pitch of ball based on relative velocity to paddle
			float ranDumb = Random.Range(0.8f, 0.8f * (1f + Mathf.Abs(rigidbody2D.velocity.x) / 10));
			Debug.Log(ranDumb);
			audio.pitch = ranDumb;
			audio.Play();
		}
	}
}
