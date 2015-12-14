using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System;

/// <summary>
/// Class that holds the general information about the battle
/// </summary>
public class Battle {

    int totalRounds;
    int attackerCount;
    int defenderCount;

    public int width;
    public int height;

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
        this.height = Int32.Parse(json["stats"]["result"]["map"]["height"].ToString());
        this.width = Int32.Parse(json["stats"]["result"]["map"]["width"].ToString());
        SetAttackers(json["stats"]["result"]["attackerlist"]);
        SetDefenders(json["stats"]["result"]["defenderlist"]);
        CreateSectors(json["stats"]["result"]["map"]["sectors"], json["stats"]["result"]["map"]["cells"]);
    }

    public void SetAttackers(JsonData json)
    {
        attackers = new List<Player>();
        for (int i = 0; i < json.Count; i++)
        {
            attackers.Add(CreatePlayer(json[i], Side.Attack));
        }
    }

    public void SetDefenders(JsonData json)
    {
        defenders = new List<Player>();
        for (int i = 0; i < json.Count; i++)
        {
            
            defenders.Add(CreatePlayer(json[i],Side.Defense));
        }
    }

    public void CreateSectors(JsonData sectorinfo, JsonData tiles)
    {
        sectors = new List<Sector>();
        for(int i = 0; i < sectorinfo.Count; i++)
        {
            Sector s = new Sector();
            s.height = Int32.Parse(sectorinfo[i]["height"].ToString());
            sectors.Add(s);
        }

        for(int i = 0; i < tiles.Count; i++)
        {
            sectors[Int32.Parse(tiles[i].ToString())].AddTile(ToVector(i,width));
        }

        for(int i = 0; i < sectors.Count; i++)
        {
            sectors[i].DetermineSectorType(sectorinfo[i]);
        }
    }

    /// <summary>
    /// Creates a vector out of the tile id and the width of the map
    /// </summary>
    /// <param name="id">Tile id</param>
    /// <param name="mapWidth">Width of the map</param>
    /// <returns></returns>
    private Vector2 ToVector(int id, int mapWidth)
    {
        return new Vector2(id % mapWidth, Mathf.Floor(id / mapWidth));
    }

    private Player CreatePlayer(JsonData json, Side side)
    {
        Player player = new Player(side, Int32.Parse(json["westid"].ToString()), json["name"].ToString());
        player.startpos = ToVector(Int32.Parse(json["firstroundpos"].ToString()), width);
        player.maximumHealth = Int32.Parse(json["maxhp"].ToString());
        player.currentHealth = player.maximumHealth;
        player.level = Int32.Parse(json["charlevel"].ToString());

        return player;
    }
}