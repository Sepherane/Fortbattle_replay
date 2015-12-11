using UnityEngine;
using System.Collections;

public static class FileReader {

	public static string ReadFile(string name)
    {
        TextAsset txt = (TextAsset)Resources.Load(name, typeof(TextAsset));
        return txt.text;
    }
}