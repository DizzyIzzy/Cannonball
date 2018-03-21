using UnityEngine;
using UnityEditor;
using System.IO;

public static class TextfileHandler
{
    [MenuItem("Tools/Write file")]
    public static void WriteString(string message)
    {
        string path = "Assets/TextFiles/commuter.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(message);
        writer.Close();

        //Re-import the file to update the reference in the editor
        AssetDatabase.ImportAsset(path);
        TextAsset asset = (TextAsset)Resources.Load("commuter");

        //Print the text from the file
    }

    public static void PhoneLog(string message, string sender)
    {
        string path = "Assets/TextFiles/phoneRecord.txt";
        string path2 = "Assets/TextFiles/"+sender+ "PhoneRecord.txt";
        //Write some text to the test.txt file
        StreamWriter callWriter = new StreamWriter(path, true);
        callWriter.WriteLine(message);
        callWriter.Close();
        StreamWriter callWriter2 = new StreamWriter(path2, true);
        callWriter2.WriteLine(message);
        callWriter2.Close();

        //Re-import the file to update the reference in the editor
        AssetDatabase.ImportAsset(path);
       // TextAsset asset = (TextAsset)Resources.Load("credit");

        //Print the text from the file
    }





    [MenuItem("Tools/Read file")]
    public static void ReadString()
    {
        string path = "Assets/TextFiles/credit.txt";
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        Debug.Log(reader.ReadToEnd());
        reader.Close();
    }

}