using UnityEngine;
using System.Collections;

public static class FileReader {

    /// <summary>
    /// Reads a file from the resources and returns it as a text file
    /// </summary>
    /// <param name="name">Name of the file to read</param>
    /// <returns></returns>
	public static string ReadFile(string name)
    {
        TextAsset txt = (TextAsset)Resources.Load(name, typeof(TextAsset));
        return txt.text;
    }
}