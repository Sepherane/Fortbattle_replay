using UnityEngine;
using System.Collections;
using LitJson;

public static class JSONReader {

	public static JsonData ConvertJSON(string name)
    {
        return JsonMapper.ToObject(FileReader.ReadFile(name));
    }
}