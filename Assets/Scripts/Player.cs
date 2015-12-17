using UnityEngine;
using System.Collections;

/// <summary>
/// Represents a player on the field
/// </summary>
public class Player {

    public Side side { get; set; }
    public string name { get; set; }
    public int level { get; set; }
    public int id { get; set; }
    public int currentHealth { get; set; }
    public int maximumHealth { get; set; }
    public GameObject playerObject { get; set; }
    public Vector2 startpos { get; set; }
    public CharacterClass characterClass { get; set; }

    /// <summary>
    /// Initialize an empty player
    /// </summary>
    public Player()
    {

    }

    /// <summary>
    /// Initialize a player with a side, id and name
    /// </summary>
    /// <param name="side">Side he's on (attack or defense)</param>
    /// <param name="id">ID of the player</param>
    /// <param name="name">Name of the player</param>
    public Player(Side side, int id, string name)
    {
        this.name = name;
        this.side = side;
        this.id = id;
    }

    public void ShootAt(Player otherplayer)
    {

    }

    public void MoveTo(Vector3 newPos)
    {

    }
}