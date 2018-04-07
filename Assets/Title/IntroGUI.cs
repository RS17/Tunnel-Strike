using UnityEngine;
using System.Collections;

public class IntroGUI : MonoBehaviour {

	
	// OnGUI is called once per frame
	void OnGUI () {
	//	GUI.TextArea(new Rect(100, 50, 500, 350), "You are a famous spaceship pilot, and your mission is to blow up a core at the end of a long tunnel by shooting it with your cannons.  You need to blow up the core becuase it sucks and will destory humanity.  \n \n Along the way you will need to dodge lasers, missiles, pipes, and columns. You can control your ship using the W,A,S,D keys.  \n \n If you destroy the core, you will unlock a special game mode, in addition to saving all humanity.  But if you crash, you'll somehow survive and will get to upgrade your ship.  You have already gotten all of your friends to sign pledge forms to give you upgrade money based on how far you get, and you also can benefit by picking up coins that someone has absent-mindedly left in the tunnel.  \n \n Now go blow up the core! \n \n Controls: /n WASD - control ship.  \n Q,E - Vectored thrust L/R (upgrade) \n P - Pause \n R - Rear camera view (use this to see missiles chasing you) \n SPACE - Fire guns (upgrade) \n SHIFT - Rockets (upgrade) \n TAB - Activate reorientator (upgrade)");
		if(GUI.Button(new Rect(520,420,200,100), "BEGIN!")){
			Application.LoadLevel(2);
		}

	
	}
}
