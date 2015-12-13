using UnityEngine;
using System.Collections;

public class FlagAdjacentObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetHeight(float height)
    {
        transform.localScale = new Vector3(1, height, 1);
        transform.position = new Vector3(transform.position.x, height / 2f, transform.position.z);

    }
}
