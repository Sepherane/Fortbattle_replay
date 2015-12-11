using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log(JSONReader.ConvertJSON("ExampleJSON")["stats"][1]);
	}
	
}
