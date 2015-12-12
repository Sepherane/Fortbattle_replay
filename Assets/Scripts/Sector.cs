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

    //Private variables


    /// <summary>
    /// Initialize with an empty tilelist;
    /// </summary>
    public Sector()
    {
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
}