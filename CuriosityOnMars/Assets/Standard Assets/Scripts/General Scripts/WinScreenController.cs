using UnityEngine;
using System.Collections;

public class WinScreenController : MonoBehaviour
{
	public Texture resetButton;
	
	
	void OnGUI () {
		//not sure why the numbers are doubled when the game runs though..
		if(GUI.Button(new Rect(0,0,resetButton.width,resetButton.height), resetButton)) {
			Application.LoadLevel("Main Menu");
			//print ("reset!!");
		}
	}
	
}

