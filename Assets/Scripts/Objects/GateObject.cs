using UnityEngine;
using System.Collections;

public class GateObject : MonoBehaviour {

    public GameObject gate;
    public GameObject[] crenelation;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetHeight(float height, float scalingFactor)
    {
        gate.transform.localScale = new Vector3(1, scalingFactor, 1);
        transform.position = new Vector3(transform.position.x, height-gate.transform.localScale.y/2f, transform.position.z);

        foreach (GameObject c in crenelation)
        {
            c.transform.localPosition = new Vector3(c.transform.localPosition.x, 0.1f+scalingFactor/2f, c.transform.localPosition.z);
        }
    }
}