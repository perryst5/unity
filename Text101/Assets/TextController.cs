using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	
	private enum States {
		cell, mirror, lock_0, sheets_0, cell_mirror, sheets_1, lock_1, corridor_0, stairs_0, floor, 
		closet_door, stairs_1, corridor_1, in_closet, stairs_2, corridor_2, corridor_3, courtyard
	};
	private States myState;

	// Use this for initialization
	void Start () {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		if (myState == States.cell) 				{cell();} 
		else if (myState == States.sheets_0) 		{sheets_0();} 
		else if (myState == States.sheets_1) 		{sheets_1();} 
		else if (myState == States.lock_0) 			{lock_0();} 
		else if (myState == States.lock_1) 			{lock_1();} 
		else if (myState == States.mirror) 			{mirror();} 
		else if (myState == States.cell_mirror) 	{cell_mirror();}
		else if (myState == States.corridor_0) 		{corridor_0();}
		else if (myState == States.corridor_1) 		{corridor_1();}
		else if (myState == States.corridor_2) 		{corridor_2();}
		else if (myState == States.corridor_3) 		{corridor_3();}
		else if (myState == States.stairs_0) 		{stairs_0();}
		else if (myState == States.stairs_1) 		{stairs_1();}
		else if (myState == States.stairs_2) 		{stairs_2();}
		else if (myState == States.floor) 			{floor();}
		else if (myState == States.closet_door) 	{closet_door();}
		else if (myState == States.in_closet) 		{in_closet();}
		else if (myState == States.courtyard) 		{courtyard();}
	}
	
	#region State Handler Methods
	void cell () {
		text.text = "You're in a prison. Way to go, fuckface. Get the hell out of there. There's some sheets on a bed, " +
					"a mirror that shows your dumbass face, and a door. It's locked because that's how prison works. Moron.\n\n" +
					"Press S to view sheets, M to stare at your face in the mirror, and L to contemplate how locks work.";
		if(Input.GetKeyDown(KeyCode.S)){
			myState = States.sheets_0;
		} else if (Input.GetKeyDown(KeyCode.M)){
			myState = States.mirror;
		} else if (Input.GetKeyDown(KeyCode.L)){
			myState = States.lock_0;
		}
	}
	void sheets_0 () {
		text.text = "Dude. This is freaking gross. You sleep in this shit? Ew. Press R to return to roaming your cell. Please.";
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.cell;
		}
	}
	void sheets_1 () {
		text.text = "So you have a mirror and decide to sleep? Not likely. Press r to return to looking around your cell.";
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.cell_mirror;
		}
	}
	void lock_0 () {
		text.text = "It's locked. Duh. There's a combination to get you out of here. Do you know it? \n\n Press r to return to roaming.";
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.cell;
		}
	}
	void lock_1 () {
		text.text = "You put the mirror through the bars and look out the fingerprints on the keypad. Some are dirty. You press those. Click. \n\n Press O to Open, or R to admit defeat.";
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.cell_mirror;
		} else if (Input.GetKeyDown(KeyCode.O)){
			myState = States.corridor_0;
		}
	}
	void mirror () {
		text.text = "Man, your face is ugly. Maybe that's why they put you in here. You take the mirror to remind yourself of this whenever you want. Press r to return to looking around.";
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.cell_mirror;
		}
	}
	void cell_mirror () {
		text.text = "So you've got a mirror. What's your next move? \n\n S to look at the sheets, L to look at the lock ";
		if(Input.GetKeyDown(KeyCode.S)){
			myState = States.sheets_1;
		} else if(Input.GetKeyDown(KeyCode.L)){
			myState = States.lock_1;
		}
	}
	void corridor_0 () {
		text.text = "The door opens. You see a corridor. You may have escaped the cell, but you're not out of this yet. You see a set of stairs and a closet. Press S to go up the stairs, C to investigate the closet, or F to look at your feet.";
		if(Input.GetKeyDown(KeyCode.S)){
			myState = States.stairs_0;
		} else if(Input.GetKeyDown(KeyCode.F)){
			myState = States.floor;
		} else if(Input.GetKeyDown(KeyCode.C)){
			myState = States.closet_door;
		}
	}
	void corridor_1 () {
		text.text = "You're still in the corridor, but now you have a hair clip! Congratulations! Press S to go to the stairs, or P to go to the closet and try to pick the lock.";
		if(Input.GetKeyDown(KeyCode.S)){
			myState = States.stairs_1;
		} else if(Input.GetKeyDown(KeyCode.P)){
			myState = States.in_closet;
		}
	}
	void corridor_2 () {
		text.text = "You're in the corridor again in your gross prison getup. Press S for Stairs or B to return to the closet.";
		if(Input.GetKeyDown(KeyCode.S)){
			myState = States.stairs_2;
		} else if(Input.GetKeyDown(KeyCode.B)){
			myState = States.in_closet;
		}
	}
	void corridor_3 () {
		text.text = "You look pretty convincing in your new janitor's outfit. Press S to try to sneak past the guards up the stairs.";
		if(Input.GetKeyDown(KeyCode.S)){
			myState = States.courtyard;
		}
	}
	void stairs_0 () {
		text.text = "Sounds like there are guards up there. Better turn back. Press R to return to the corridor";
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.corridor_0;
		}
	}
	void stairs_1 () {
		text.text = "You think you're going to fight the guards at the top of the stairs with a hairclip? I'm not letting you do that. Press R to return to the corridor.";
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.corridor_1;
		}
	}
	void stairs_2 () {
		text.text = "You really think the hair clip is going to be a good enough weapon to fight the guards? Weak. Press r to return to the corridor.";
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.corridor_2;
		}
	}
	void stairs_3 () {
		text.text = "Seriously? There are guards up there. Figure something else out by pressing R.";
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.corridor_2;
		}
	}
	void floor () {
		text.text = "You look down at your feet. They need to be washed pretty badly. You inspect the bottom of your left foot and find a hairclip. That could come in handy. Press H to pick up the hair clip.";
		if(Input.GetKeyDown(KeyCode.H)){
			myState = States.corridor_1;
		}
	}
	void closet_door () {
		text.text = "There's a closet door! Too bad it's locked. Why is everything locked down here? Press R to return.";
		if(Input.GetKeyDown(KeyCode.R)){
			myState = States.corridor_0;
		}
	}
	void in_closet () {
		text.text = "You picked the closet door lock! Way to go! Where did you learn to do that? Anyway. There's a janitor's outfit in here. Looks to be your size. What a crazy random happenstance. Press D to put it on or R to return to the corridor in your dingy awful prison garb.";
		if(Input.GetKeyDown(KeyCode.D)){
			myState = States.corridor_3;
		} else if (Input.GetKeyDown(KeyCode.R)){
			myState = States.corridor_2;
		}
	}
	void courtyard () {
		text.text = "HA! What a bunch of morons! They totally bought your disguise. You're a free person now. Feel free to feel satisfied with your escape and close this game. Alternatively, press I to feel remorse and turn yourself in.";
		if(Input.GetKeyDown(KeyCode.I)){
			myState = States.cell;
		}
	}
	#endregion
}
