using UnityEngine;
using System.Collections;
using LitJson;

public static class JSONReader {

    /// <summary>
    /// Converts json data from a file to a json object
    /// </summary>
    /// <param name="name">name of the resource file</param>
    /// <returns></returns>
	public static JsonData ConvertJSON(string name)
    {
        return JsonMapper.ToObject(FileReader.ReadFile(name));
    }
}