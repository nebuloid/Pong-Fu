using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	//collect keyboard inputs
	public KeyCode moveUp;
	public KeyCode moveDown;

	public float speed;
	
	
	// Update is called once per frame
	void Update () {
		//TODO: Will need to accept touch inputs for mobile. Until game is developed easier to use keyboard.
		//detect vertical movement
		//float moveVertical = Input.GetAxis ("Vertical");
		//apply that force to the player velocity
		//rigidbody2D.velocity = new Vector2(0.0f, moveVertical * speed);

		if(Input.GetKey(moveUp)){
			rigidbody2D.velocity = new Vector2(0f, speed);
		}else if(Input.GetKey(moveDown)){
			rigidbody2D.velocity = new Vector2(0f, -speed);
		} else {
			rigidbody2D.velocity = new Vector2(0f, 0f);
		}
		
//make sure the x position stays the same
		rigidbody2D.velocity = new Vector2(0f, rigidbody2D.velocity.y );
	}
}
