using UnityEngine;
using System.Collections;

public class control_menu : MonoBehaviour {
	public int x, y;
	public int sizeX, sizeY;
	public Texture2D instructions;
	public Texture2D credits;
	public Texture2D exit;
	private bool drawInstructions;
	private bool drawCredits;

	// Use this for initialization
	void Start () {
		sizeX = 100;
		sizeY = 50;
		y = 75;
		x = Screen.width/2 - sizeX / 2;

		drawInstructions = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI () {
		//not sure why the numbers are doubled when the game runs though..
		if (!drawInstructions && !drawCredits) 
		{
			if (GUI.Button (new Rect (x, y, sizeX, sizeY), "Play")) 
			{
				Application.LoadLevel (Application.loadedLevel + 1);
				//print ("reset!!");
			}
			if (GUI.Button (new Rect (x, y + sizeY + 10, sizeX, sizeY), "Instructions")) 
			{
				drawInstructions = true;
			}
			if (GUI.Button (new Rect (x, y + 2*(sizeY) + 20, sizeX, sizeY), "Credits"))
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
