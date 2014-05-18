using UnityEngine;
using System.Collections;

public class control_menu : MonoBehaviour {
	public int x, y;
	public int sizeX, sizeY;
	public Texture2D instructions;
	public Texture2D credits;
	public Texture2D exit;
	public Texture playButton;
	public Texture instructButton;
	public Texture creditsButton;
	private bool drawInstructions;
	private bool drawCredits;

	// Use this for initialization
	void Start () {
		sizeX = playButton.width;
		sizeY = playButton.height;
		y = Screen.height/3;
		x = Screen.width/2 - sizeX / 2;

		drawInstructions = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI () {
		GUI.backgroundColor = new Color(0,0,0,0);
		//not sure why the numbers are doubled when the game runs though..
		if (!drawInstructions && !drawCredits) 
		{
			if (GUI.Button (new Rect (x, y, 120, sizeY), playButton)) 
			{
				Application.LoadLevel (Application.loadedLevel + 1);
				//print ("reset!!");
			}
			if (GUI.Button (new Rect (x, y + sizeY + 10, sizeX, sizeY), instructButton)) 
			{
				drawInstructions = true;
			}
			if (GUI.Button (new Rect (x, y + 2*(sizeY) + 20, sizeX, sizeY), creditsButton))
			{
				drawCredits = true;
			}
		}
		else if(drawInstructions)
		{
			GUI.Label(new Rect(Screen.width / 2 - instructions.width / 2, 75, instructions.width, instructions.height), instructions);
			if(GUI.Button(new Rect(Screen.width /2 + instructions.width / 2 - 60,77,50,50), exit))
				drawInstructions = false;
		}
		else if(drawCredits)
		{
			GUI.Label(new Rect(Screen.width / 2 - credits.width / 2, 75, credits.width, credits.height), credits);
			if(GUI.Button(new Rect(Screen.width /2 + credits.width / 2 - 60,77,50,50), exit))
				drawCredits = false;
		}
	}
}
