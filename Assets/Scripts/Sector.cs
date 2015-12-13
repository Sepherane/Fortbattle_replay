using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LitJson;
using UnityEngine;

public class Sector
{
    //Public variables
    public int height { get; set; }
    public SectorType sectorType { get; set; }
    public List<Vector2> tiles { get; set; }
    public Orientation orientation = Orientation.Horizontal;

    //Private variables


    /// <summary>
    /// Initialize with an empty tilelist;
    /// </summary>
    public Sector()
    {
        tiles = new List<Vector2>();
    }

    public Sector(int height, SectorType sectorType)
    {
        this.height = height;
        this.sectorType = sectorType;
        tiles = new List<Vector2>();
    }

    /// <summary>
    /// Add a tile to this sector
    /// </summary>
    /// <param name="tile">Coordinates of the tile to add</param>
    public void AddTile(Vector2 tile)
    {
        tiles.Add(tile);
    }

    public void DetermineSectorType(JsonData json)
    {
        if (json.Keys.Contains("classBonus"))
        {
            this.sectorType = SectorType.Tower;
        }
        else if (json.Keys.Contains("defenderBonus") && Int32.Parse(json["height"].ToString()) == 0)
        {
            this.sectorType = SectorType.Gate;
        }
        else if (Int32.Parse(json["height"].ToString()) == 0)
        {
            this.sectorType = SectorType.Ground;
        }
        else if (json.Keys.Contains("flag"))
        {
            this.sectorType = SectorType.Flag;
        }
        else if (json.Keys.Contains("defenderBonus") && Int32.Parse(json["defenderBonus"].ToString()) < 0)
        {
            this.sectorType = SectorType.FlagAdjacent;
        }
        else if(json.Keys.Contains("defenderBonus") && IsWall(tiles))
        {
            this.sectorType = SectorType.Wall;
        }
        else if(json.Keys.Contains("defenderBonus") && !IsWall(tiles))
        {
            this.sectorType = SectorType.Building;
        }
        else
        {
            this.sectorType = SectorType.Ground;
        }

    }

    private bool IsWall(List<Vector2> tiles)
    {
        if (tiles.Count < 2)
            return false;

        Vector2 diff = tiles[0] - tiles[1];
        Orientation toCheck = Orientation.Horizontal;

        if (diff.y != 0 && diff.x != 0)
            return false;
        else if (diff.y != 0)
            toCheck = Orientation.Vertical;
        else if (diff.x != 0)
            toCheck = Orientation.Horizontal;

        foreach(Vector2 tile in tiles)
        {
            if (Orientation.Vertical == toCheck && (tiles[0] - tile).x == 0)
                continue;
            else if (Orientation.Horizontal == toCheck && (tiles[0] - tile).y == 0)
                continue;
            else
                return false;
        }
        orientation = toCheck;
        return true;
    }
}