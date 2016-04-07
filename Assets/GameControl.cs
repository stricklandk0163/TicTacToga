using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {
    public Text[] board; //array to hold text elements that can have their text component changed to reflect moves

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    /*
     * ButtonClicked() is called when any of the 9 buttons is clicked, do stuff here to determine if the button text is set
     */
    public void ButtonClicked()
    {

    }

    /*
     * NewGame() sets all of the text elements to the empty string, new game stuff to go here later 
     */ 
    public void NewGame()
    {
        for (int intel=0; intel<board.Length; intel++) //loop through board array and set text to ""
            board[intel].text = "";
    }
}
