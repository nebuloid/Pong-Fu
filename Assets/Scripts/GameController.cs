using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public Camera mainCamera;

	public BoxCollider2D topWall;
	public BoxCollider2D bottomWall;
	public BoxCollider2D leftWall;
	public BoxCollider2D rightWall;

	public GameObject Player1;
	public GameObject Player2;
	
	private static int player1Score = 0;
	private static int player2Score = 0;
	
	//Font for GUI
	public GUIStyle fontStyle;
	private Vector2 fontWidth;

	// Use this for initialization
	void Start () {
		
		//ADJUST BOUNDS TO FIT ANY SCREEN
		topWall.size = new Vector2(mainCamera.ScreenToWorldPoint (new Vector3(Screen.width * 2f, 0f, 0f)).x, 1f);
		topWall.center = new Vector2(0f, mainCamera.ScreenToWorldPoint (new Vector3(0f, Screen.height, 0f)).y + 0.5f);

		bottomWall.size = new Vector2(mainCamera.ScreenToWorldPoint (new Vector3(Screen.width * 2f, 0f, 0f)).x, 1f);
		bottomWall.center = new Vector2(0f, mainCamera.ScreenToWorldPoint (new Vector3(0f, 0f, 0f)).y - 0.5f);

		leftWall.size = new Vector2(1f, mainCamera.ScreenToWorldPoint (new Vector3(0f, Screen.height * 2f, 0f)).y);
		leftWall.center = new Vector2(mainCamera.ScreenToWorldPoint (new Vector3(0f, 0f, 0f)).x - 0.5f, 0f);

		rightWall.size = new Vector2(1f, mainCamera.ScreenToWorldPoint (new Vector3(0f, Screen.height * 2f, 0f)).y);
		rightWall.center = new Vector2(mainCamera.ScreenToWorldPoint (new Vector3(Screen.width, 0f, 0f)).x + 0.5f, 0f);

		Player1.transform.position = new Vector2(mainCamera.ScreenToWorldPoint (new Vector3(75f, 0f, 0f)).x, 0f);
		Player2.transform.position = new Vector2(mainCamera.ScreenToWorldPoint (new Vector3(Screen.width - 75f, 0f, 0f)).x, 0f);
	
		fontWidth = fontStyle.CalcSize(new GUIContent("0"));
		
	}

	public static void Score(string wallName){
		if(wallName == "rightWall"){
			player1Score += 1;
		}else{
			player2Score += 1;
		}
		Debug.Log("Player score: "+wallName);
	}

	
	void OnGUI(){
		//Display Score
		GUI.Label(new Rect(Screen.width/2 - 100 - fontWidth.y, 20, 100, 100), ""+player1Score, fontStyle);
		GUI.Label(new Rect(Screen.width/2 + 100, 20, 100, 100), ""+player2Score, fontStyle);
	}

	//void Update(){
	    //just testing
		//Player1.transform.position = new Vector2(mainCamera.ScreenToWorldPoint (new Vector3(75f, 0f, 0f)).x, Player1.transform.position.y);
		//Player2.transform.position = new Vector2(mainCamera.ScreenToWorldPoint (new Vector3(Screen.width - 75f, 0f, 0f)).x, Player2.transform.position.y);
	//}
}
