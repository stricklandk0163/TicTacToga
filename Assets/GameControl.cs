/* 
 * File Name: GameControl.cs
 * Author Name: William Brereton & Karl Strickland
 *
 * Last Modified: 4/7/2016 by William Brereton
 * 
 * Description:
 * GameControl.cs holds all of the relevant logic and UI stuff needed to play tic tac toe. It 
 * determines when a player or computer wins, keeps track of win/tie count and currently only 
 * plays against a crappy random AI.
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameControl : MonoBehaviour {
    public Text[] board; //array to hold text elements that can have their text component changed to reflect moves
    public Text player, computer, tie; //text components that display win counts
    private int turnId; //0 = player's 1 turn, 1 = computer's turn(player 2)
    private bool isGameWon = false; //bool for when game is won
    private int tieCount = 0, playerCount = 0, computerCount = 0; //win counters

    private bool computerThinking = false;

	// Use this for initialization
	void Awake () {
        NewGame(); //this is a new game
    }
	
	// Update is called once per frame
	void Update () {
        if (turnId == 1){ //computer's turn
            if(!computerThinking)
            {
                //computerThinking = true;
                ComputerAI();
            }
            
        }
	}

    /*
     * Button0Clicked() is called top left button is clicked
     */
    public void Button0Clicked(){
        if (turnId == 0 && board[0].text == ""){ //if it is the player's turn and the board section is empty, place an X
            board[0].text = "X";
            TestBoard(1, 'X'); //test if the board is full and switch turns
        }
    }

    /*
     * Button1Clicked() is called top center button is clicked
     */
    public void Button1Clicked(){
        if (turnId == 0 && board[1].text == ""){ //if it is the player's turn and the board section is empty, place an X
            board[1].text = "X";
            TestBoard(1, 'X'); //test if the board is full and switch turns
        }
    }

    /*
     * Button2Clicked() is called top right button is clicked
     */
    public void Button2Clicked(){
        if (turnId == 0 && board[2].text == ""){ //if it is the player's turn and the board section is empty, place an X
            board[2].text = "X";
            TestBoard(1, 'X'); //test if the board is full and switch turns
        }
    }

    /*
     * Button3Clicked() is called center left button is clicked
     */
    public void Button3Clicked(){
        if (turnId == 0 && board[3].text == ""){ //if it is the player's turn and the board section is empty, place an X
            board[3].text = "X";
            TestBoard(1, 'X'); //test if the board is full and switch turns
        }
    }

    /*
     * Button4Clicked() is called center button is clicked
     */
    public void Button4Clicked(){
        if (turnId == 0 && board[4].text == ""){ //if it is the player's turn and the board section is empty, place an X
            board[4].text = "X";
            TestBoard(1, 'X'); //test if the board is full and switch turns
        }
    }

    /*
     * Button5Clicked() is called center right button is clicked
     */
    public void Button5Clicked(){
        if (turnId == 0 && board[5].text == ""){ //if it is the player's turn and the board section is empty, place an X
            board[5].text = "X";
            TestBoard(1, 'X'); //test if the board is full and switch turns
        }
    }

    /*
     * Button6Clicked() is called bottom left button is clicked
     */
    public void Button6Clicked(){
        if (turnId == 0 && board[6].text == ""){ //if it is the player's turn and the board section is empty, place an X
            board[6].text = "X";
            TestBoard(1, 'X'); //test if the board is full and switch turns
        }
    }

    /*
     * Button7Clicked() is called bottom center button is clicked
     */
    public void Button7Clicked(){
        if (turnId == 0 && board[7].text == ""){ //if it is the player's turn and the board section is empty, place an X
            board[7].text = "X";
            TestBoard(1, 'X'); //test if the board is full and switch turns
        }
    }

    /*
     * Button8Clicked() is called bottom right button is clicked
     */
    public void Button8Clicked(){
        if (turnId == 0 && board[8].text == ""){ //if it is the player's turn and the board section is empty, place an X
            board[8].text = "X";
            TestBoard(1, 'X'); //test if the board is full and switch turns
        }
    }

    /*
     * NewGame() sets all of the text elements to the empty string, new game stuff to go here later 
     */ 
    public void NewGame()
    {
        turnId = 0; //reset turn to player's turn
        isGameWon = false; // no winners yet

        for (int intel=0; intel<board.Length; intel++) //loop through board array and set text to ""
            board[intel].text = "";
    }

    /*
     * TestBoard() tests if the board is full and changes the turn to the right player
     */
    void TestBoard(int nextTurnId, char placedPiece)
    {
        TestWin(); //check if someone won

        if (isGameWon) {
            if (placedPiece == 'X'){
                turnId = 2; //set this to 2 since someone won the game
                playerCount++; //add a win to player
                player.text = "Player: " + playerCount; //update player win UI count
            }
            else if (placedPiece == 'O'){
                turnId = 2; //set this to 2 since someone won the game
                computerCount++; //add a win to computer
                computer.text = "Computer: " + computerCount; //update computer win UI count
            }
        }
        else{
            for (int i = 0; i < board.Length; i++){ //loop through board to test if the game is finished
                if (Equals(board[i].text, "")){ //if there is a board spot open, break out & change turn
                    turnId = nextTurnId; //switch to next player's turn
                    break;
                }
                else if (!Equals(board[i].text, "") && i == board.Length-1){ //if at end of board and it's not empty
                    turnId = 2; //set this to 2 since it's a tie
                    tieCount++; //add a tie to count
                    tie.text = "Tie: " + tieCount; //update tie UI count
                }
            }
        }
    }

    /*
     * TestWin() determines if someone has won the game for any combination
     */ 
    void TestWin(){
        //Test row for a win
        if (board[0].text != "" && board[0].text == board[3].text && board[0].text == board[6].text)
            isGameWon = true;
        else if (board[1].text != "" && board[1].text == board[4].text && board[1].text == board[7].text)
            isGameWon = true;
        else if (board[2].text != "" && board[2].text == board[5].text && board[2].text == board[8].text)
            isGameWon = true;

        //Test columns for a win
        if (board[0].text != "" && board[0].text == board[1].text && board[0].text == board[2].text)
            isGameWon = true;
        else if (board[3].text != "" && board[3].text == board[4].text && board[3].text == board[5].text)
            isGameWon = true;
        else if (board[6].text != "" && board[6].text == board[7].text && board[6].text == board[8].text)
            isGameWon = true;

        //Test Diagonals for a win
        if (board[0].text != "" && board[0].text == board[4].text && board[0].text == board[8].text)
            isGameWon = true;
        else if (board[2].text != "" && board[2].text == board[4].text && board[2].text == board[6].text)
            isGameWon = true;
    }

    void ComputerAI()
    {
        bool placed = false;
        int diag = AITestDiagonals();
        int cols = AITestColumns();
        int rows = AITestRows();

        if(diag != 11 && !placed)
        {
            if(board[diag].text == "")
            {
                board[diag].text = "O";

                TestBoard(0, 'O'); //test if the board is full and switch turns
                placed = true;
            }
        }
        if(cols != 11 && !placed)
        {
            if (board[cols].text == "")
            {
                board[cols].text = "O";

                TestBoard(0, 'O'); //test if the board is full and switch turns
                placed = true;
            }
        }
        if(rows != 11 && !placed)
        {
            if (board[rows].text == "")
            {
                board[rows].text = "O";

                TestBoard(0, 'O'); //test if the board is full and switch turns
                placed = true;
            }
        }
        if(!placed)
        {
            int spot = Random.Range(0, board.Length); //make a random spot to place an O

            if (board[spot].text == "")
            { //if the spot is empty
                board[spot].text = "O"; //place an O

                TestBoard(0, 'O'); //test if the board is full and switch turns
                placed = true;
            }
            else
            { //if the spot is taken, find a new one randomly
                spot = Random.Range(0, board.Length);
            }
        }
    }

    int AITestColumns()
    {
        int num_0 = 0;
        int num_1 = 0;
        int num_2 = 0;

        int placeNum_0 = 11;
        int placeNum_1 = 11;
        int placeNum_2 = 11;
        

        for(int i = 0; i < board.Length; i=i+3)
        {
            if(board[i].text == "X")
            {
                num_0++;
            }
            else
            {
                placeNum_0 = i;
            }
        }

        for (int i = 1; i < board.Length; i = i + 3)
        {
            if (board[i].text == "X")
            {
                num_1++;
            }
            else
            {
                placeNum_1 = i;
            }
        }

        for (int i = 2; i < board.Length; i = i + 3)
        {
            if (board[i].text == "X")
            {
                num_2++;
            }
            else
            {
                placeNum_2 = i;
            }
        }

        if (num_0 == 2)
        {
            if(placeNum_0 != 11)
            {
                return placeNum_0;
            }
        }

        if (num_1 == 2)
        {
            if (placeNum_1 != 11)
            {
                return placeNum_1;
            }
        }

        if (num_2 == 2)
        {
            if (placeNum_2 != 11)
            {
                return placeNum_2;
            }
        }

        return 11;
    }

    int AITestRows()
    {
        int num_0 = 0;
        int num_1 = 0;
        int num_2 = 0;

        int placeNum_0 = 11;
        int placeNum_1 = 11;
        int placeNum_2 = 11;


        for (int i = 0; i < 3; i++)
        {
            if (board[i].text == "X")
            {
                num_0++;
            }
            else
            {
                placeNum_0 = i;
            }
        }

        for (int i = 3; i < 6; i++)
        {
            if (board[i].text == "X")
            {
                num_1++;
            }
            else
            {
                placeNum_1 = i;
            }
        }

        for (int i = 6; i < 9; i++)
        {
            if (board[i].text == "X")
            {
                num_2++;
            }
            else
            {
                placeNum_2 = i;
            }
        }

        if (num_0 == 2)
        {
            if (placeNum_0 != 11)
            {
                return placeNum_0;
            }
        }

        if (num_1 == 2)
        {
            if (placeNum_1 != 11)
            {
                return placeNum_1;
            }
        }

        if (num_2 == 2)
        {
            if (placeNum_2 != 11)
            {
                return placeNum_2;
            }
        }

        return 11;
    }

    int AITestDiagonals()
    {
        int num_0 = 0;
        int num_1 = 0;

        int placeNum_0 = 11;
        int placeNum_1 = 11;

        for (int i = 0; i < board.Length; i = i + 4)
        {
            if (board[i].text == "X")
            {
                num_0++;
            }
            else
            {
                placeNum_0 = i;
            }
        }

        for (int i = 2; i < 7; i = i + 2)
        {
            if (board[i].text == "X")
            {
                num_1++;
            }
            else
            {
                placeNum_1 = i;
            }
        }

        if (num_0 == 2)
        {
            if (placeNum_0 != 11)
            {
                return placeNum_0;
            }
        }

        if (num_1 == 2)
        {
            if (placeNum_1 != 11)
            {
                return placeNum_1;
            }
        }

        return 11;
    }
}
