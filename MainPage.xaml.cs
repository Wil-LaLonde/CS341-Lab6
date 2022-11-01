namespace Lab6Starter;

/**
* 
* Name: Wil LaLonde &
* Date: 11/1/2022
* Description: Lab6
* Bugs:
* Reflection: ->
* Wil LaLonde: I thought it was interesting getting some more experience with Git.
*              I've never really forked a repo before so this was something new to me.
*              Working with the code was interesting as well. It was also a challenge
*              to try and understand what was going on and try to fix various bugs
*              as well.
* 
*/

/// <summary>
/// The MainPage, this is a 1-screen app
/// </summary>
public partial class MainPage : ContentPage {
    TicTacToeGame ticTacToe; // model class
    Button[,] grid;          // stores the buttons
    List<Color> colors;      // stores random colors used

    /// <summary>
    /// initializes the component
    /// </summary>
    public MainPage() {
        InitializeComponent();
        ticTacToe = new TicTacToeGame();
        grid = new Button[TicTacToeGame.GRID_SIZE, TicTacToeGame.GRID_SIZE] { { Tile00, Tile01, Tile02 }, { Tile10, Tile11, Tile12 }, { Tile20, Tile21, Tile22 } };
        colors = new List<Color>();
        colors.Add(Colors.Red);
        colors.Add(Colors.OrangeRed);
        colors.Add(Colors.Orange);
        colors.Add(Colors.YellowGreen);
        colors.Add(Colors.Green);
        colors.Add(Colors.SeaGreen);
        colors.Add(Colors.Blue);
        colors.Add(Colors.BlueViolet);
        colors.Add(Colors.Violet);
        ResetGame();
    }

    /// <summary>
    /// Handles button clicks - changes the button to an X or O (depending on whose turn it is)
    /// Checks to see if there is a victory - if so, invoke 
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void HandleButtonClick(object sender, EventArgs e) {
        if(VictorLabel.IsVisible) {
            VictorLabel.IsVisible = false;
        }
        Player victor;
        Player currentPlayer = ticTacToe.CurrentPlayer;

        Button button = (Button)sender;
        int row;
        int col;

        FindTappedButtonRowCol(button, out row, out col);
        if (button.Text.ToString() != "") { // if the button has an X or O, bail
            DisplayAlert("Illegal move", "This spot is already taken!", "OK");
            return;
        }
        button.Text = currentPlayer.ToString();
        Boolean gameOver = ticTacToe.ProcessTurn(row, col, out victor);

        if (gameOver) { CelebrateVictory(victor); }
    }

    /// <summary>
    /// Returns the row and col of the clicked row
    /// There used to be an easier way to do this ...
    /// </summary>
    /// <param name="button"></param>
    /// <param name="row"></param>
    /// <param name="col"></param>
    private void FindTappedButtonRowCol(Button button, out int row, out int col) {
        row = -1;
        col = -1;

        for (int r = 0; r < TicTacToeGame.GRID_SIZE; r++) {
            for (int c = 0; c < TicTacToeGame.GRID_SIZE; c++) {
                if(button == grid[r, c]) {
                    row = r;
                    col = c;
                    return;
                }
            }
        }
    }


    /// <summary>
    /// Celebrates victory, displaying a message box and resetting the game
    /// </summary>
    private void CelebrateVictory(Player victor)
    {
        if(victor == Player.X) {
            VictorLabel.IsVisible = true;
            VictorLabel.Text = "Player X wins!";
            ticTacToe.XScore += 1;
        } else if(victor == Player.O) {
            VictorLabel.IsVisible = true;
            VictorLabel.Text = "Player O wins!";
            ticTacToe.OScore += 1;
        }
        //Update scores
        XScoreLBL.Text = String.Format("X's Score: {0}", ticTacToe.XScore);
        OScoreLBL.Text = String.Format("O's Score: {0}", ticTacToe.OScore);
        //Reset both front and back end
        ResetGame();
        ticTacToe.ResetGame();
    }

    /// <summary>
    /// Resets the grid buttons so their content is all ""
    /// </summary>
    private void ResetGame() {
        //Randomly assigning a color and clearing board
        var random = new Random();
        int index;
        Tile00.Text = string.Empty;
        index = random.Next(colors.Count);
        Tile00.BackgroundColor = colors[index];
        Tile01.Text = string.Empty;
        index = random.Next(colors.Count);
        Tile01.BackgroundColor = colors[index];
        Tile02.Text = string.Empty;
        index = random.Next(colors.Count);
        Tile02.BackgroundColor = colors[index];
        Tile10.Text = string.Empty;
        index = random.Next(colors.Count);
        Tile10.BackgroundColor = colors[index];
        Tile11.Text = string.Empty;
        index = random.Next(colors.Count);
        Tile11.BackgroundColor = colors[index];
        Tile12.Text = string.Empty;
        index = random.Next(colors.Count);
        Tile12.BackgroundColor = colors[index];
        Tile20.Text = string.Empty;
        index = random.Next(colors.Count);
        Tile20.BackgroundColor = colors[index];
        Tile21.Text = string.Empty;
        index = random.Next(colors.Count);
        Tile21.BackgroundColor = colors[index];
        Tile22.Text = string.Empty;
        index = random.Next(colors.Count);
        Tile22.BackgroundColor = colors[index];
    }
}
