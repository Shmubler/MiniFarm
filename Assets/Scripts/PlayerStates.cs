using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enum variable used to track player states:
// Free - Player is currently free to move
// Dialogue - Player is currently in a dialogue interaction
// Menu - Player currently has a menu open that restricts movement
public enum PlayerStates
{
    Free, Dialogue, Menu
}
