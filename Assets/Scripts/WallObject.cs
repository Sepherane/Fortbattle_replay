using UnityEngine;
using System.Collections;

public class WallObject : MonoBehaviour {

    public GameObject wall;
    public GameObject[] crenelation;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetHeight(float height)
    {
        wall.transform.localScale = new Vector3(1, height, 1);
        transform.position = new Vector3(transform.position.x, height / 2f, transform.position.z);

        foreach(GameObject c in crenelation)
        {
            c.transform.localPosition = new Vector3(c.transform.localPosition.x, height / 2f + 0.1f, c.transform.localPosition.z);
        }
    }
}
