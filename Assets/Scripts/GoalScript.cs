using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour {
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D hitInfo) {
		if(hitInfo.name == "Ball"){
			//ADD points to whoever scored
			GameController.Score(transform.name);
			audio.Play();
			hitInfo.gameObject.SendMessage("ResetBall");
			
		}
	}
}
