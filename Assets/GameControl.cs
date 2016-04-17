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
using System.Text;

public class GameControl : MonoBehaviour {
    public Text[] board; //array to hold text elements that can have their text component changed to reflect moves
    public Text player, computer, tie; //text components that display win counts
    private int turnId; //0 = player's 1 turn, 1 = computer's turn(player 2)
    private bool isGameWon = false; //bool for when game is won
    private int tieCount = 0, playerCount = 0, computerCount = 0; //win counters
    private int computerMoveChoice = 0;
    private bool computerThinking = false;

    class Move
    {
        public Move(string board, int moveIndex)
        {
            this.board = board;
            this.moveIndex = moveIndex;
        }
        public string board { get; set; }
        public int moveIndex { get; set; }
    }

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
                string boardNode = "";
                foreach(Text cell in board)
                {
                    boardNode += cell;
                }
                int depth = boardNode.Split(' ').Length - 1;
                MiniMax(boardNode, depth, "O", "O");
                board[computerMoveChoice].text = "O"; 
                TestBoard(0, 'X'); //test if the board is full and switch turns
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

    //Get index of best score from score list
    int getBestScoreIndex(List<int> scores)
    {
        int bestScore = scores[0];
        foreach(int score in scores)
        {
            bestScore = (score > bestScore) ? score : bestScore;
        }
        return scores.IndexOf(bestScore);
    }

    //Get index of worst score from score list
    int getWorstScoreIndex(List<int> scores)
    {
        int worstScore = scores[0];
        foreach (int score in scores)
        {
            worstScore = (score < worstScore) ? score : worstScore;
        }
        return scores.IndexOf(worstScore);
    }

    //Generate a list of possible children given current board and current player
    List<Move> generateChildren(string node, string player)
    {
        List<Move> children = new List<Move>();

        //Get indices of blank spaces (These have not yet be placed)
        var foundIndexes = new List<int>();
        for (int i = node.IndexOf(' '); i > -1; i = node.IndexOf(' ', i + 1))
        {
            foundIndexes.Add(i);
        }

        //Generate children by replacing blank spaces with the player's token (X or O)
        foreach(int index in foundIndexes)
        {
            string board = node;
            //child[indice] = player;
            StringBuilder boardSB = new StringBuilder(board);
            boardSB[index] = player[0];
            board = boardSB.ToString();
            Move child = new Move(board, index);
            children.Add(child);
        }
        return children;

    }

    //Check for a win from either player
    //True if win found false otherwise
    bool Win(string node)
    {
        //Check all possible wins from either player
        char[] players = { 'O', 'X' };
        foreach (char player in players)
        {
            if (CheckDiagonalWin(node, player) || CheckVerticalWin(node, player) || CheckHorizontalWin(node, player))
                return true;
        }
        return false;
    }

    //Check for a diagonal win
    bool CheckDiagonalWin(string node, char player)
    {
        return ((node[0] == player && node[4] == player && node[8] == player) ||
            (node[2] == player && node[4] == player && node[6] == player));

    }

    //Check for a vertical win
    bool CheckVerticalWin(string node, char player)
    {
        return ((node[0] == player && node[3] == player && node[6] == player) ||
             (node[1] == player && node[4] == player && node[7] == player) ||
             (node[2] == player && node[5] == player && node[8] == player));
    }

    //Check for a horizontal win
    bool CheckHorizontalWin(string node, char player)
    {
        return ((node[0] == player && node[1] == player && node[2] == player) ||
            (node[3] == player && node[4] == player && node[5] == player) ||
            (node[6] == player && node[7] == player && node[8] == player));
    }

    //Run minimax algorithm
    //Sets computerMoveChoice to the index of the best move the computer can make
    int MiniMax(string node, int depth, string currentPlayer, string maximizingPlayer)
    {
        //List of possible scores from children
        List<int> scores = new List<int>();

        //Check for win if the current player is the maximizing player they lost and vice versa
        if (Win(node))
        {
            if (currentPlayer == maximizingPlayer)
                return -1;  
            else
                return 1;
        }

        //If depth is 0 and noone one, the game is a tie with 0 score
        else if (depth == 0)
        {
            return 0;
        }

        //If we are the maximizing player we want the best option
        else if (currentPlayer == maximizingPlayer)
        {
            string minimizingPlayer = (maximizingPlayer == "X") ? "X" : "O";

            //Find all child boards possible and get their scores
            List<Move> children = generateChildren(node, currentPlayer);
            foreach(Move child in children)
            {
                scores.Add(MiniMax(child.board, depth-1, minimizingPlayer, maximizingPlayer));
            }

            //Find the best move and return it's score also set computer to make that move
            var maxIndex = getBestScoreIndex(scores);
            computerMoveChoice = children[maxIndex].moveIndex;
            return scores[maxIndex];
        }

        //If we are the minimizing player we want the worst option for the max player
        else
        {
            //Find all child boards possible and get their scores
            List<Move> children = generateChildren(node, currentPlayer);
            foreach (Move child in children)
            {
                scores.Add(MiniMax(child.board, depth - 1, maximizingPlayer, maximizingPlayer));
            }

            //Find the worst score the maximizing player will assume this is the minimizing players choice
            var minIndex = getWorstScoreIndex(scores);
            return scores[minIndex];
        }
    }
}
