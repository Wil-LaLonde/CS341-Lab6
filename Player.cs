namespace Lab6Starter;

/**
* 
* Name: Wil LaLonde & Jared Larson
* Date: 11/1/2022
* Description: Lab6
* Bugs: There was an issue where the game would bug out after one player won.
*       This has been resolved by resetting both the front end and back end 
*       portion of the game.
* Reflection: ->
* Wil LaLonde: I thought it was interesting getting some more experience with Git.
*              I've never really forked a repo before so this was something new to me.
*              Working with the code was interesting as well. It was also a challenge
*              to try and understand what was going on and try to fix various bugs
*              as well.
*              
* Jared Larson: I thought this was a good lab to get more adjusted to Git as well as
*               working with a team member. I haven't used Git very much as another
*               lab to get more experience with it was helpful. There were some
*               challenging aspects like fixing a couple bugs.
* 
*/

/// <summary>
/// A Player is either an X, O, Nobody, or Both
/// </summary>
enum Player :int {
    X = 1, O = 0, Nobody = 100, Both = 500
}
