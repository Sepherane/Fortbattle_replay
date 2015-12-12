using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public float scalingFactor;

    public GameObject wall;
    public GameObject flag;
    public GameObject flagAdjacent;
    public GameObject tower;
    public GameObject building;
    public GameObject gate;

	// Use this for initialization
	void Start () {
        Battle b = new Battle(JSONReader.ConvertJSON("ExampleJSON"));
        BuildWalls(b);
	}

    void BuildWalls(Battle b)
    {
        foreach(Sector s in b.sectors)
        {
            if (s.sectorType != SectorType.Wall)
                continue;

            foreach(Vector2 tile in s.tiles)
            {
                GameObject w = Instantiate(wall, new Vector3(tile.x-b.width/2+0.5f, 0.5f, tile.y-b.height/2+0.5f), Quaternion.identity) as GameObject;
                if (w.GetComponent<WallObject>() != null)
                    w.GetComponent<WallObject>().SetHeight(s.height*scalingFactor);

                if (s.orientation == Orientation.Vertical)
                    w.transform.localRotation = Quaternion.Euler(0, 90, 0);
            }
        }
    }
	
}