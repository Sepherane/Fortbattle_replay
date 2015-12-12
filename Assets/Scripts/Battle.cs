using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class Battle {

    int totalRounds;
    int attackerCount;
    int defenderCount;

    public List<Sector> sectors;
    public List<Player> attackers;
    public List<Player> defenders;

    string fortName;
    string log;

    /// <summary>
    /// Initialize a new battle
    /// </summary>
	public Battle()
    {

    }

    /// <summary>
    /// Initialize a new battle from JSON data
    /// </summary>
    /// <param name="json">JSON data to use</param>
    public Battle(JsonData json)
    {
        FromJSON(json);
    }

    /// <summary>
    /// Sets the battle info using JSON data
    /// </summary>
    /// <param name="json">JSON data to use</param>
    public void FromJSON(JsonData json)
    {

    }
}
