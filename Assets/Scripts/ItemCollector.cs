using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ItemsCollection : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI CollectedTXT;
    HandleTextFile file = new HandleTextFile();

    //Zmienna do zliczania podniesionych itemkow
    public int collectedItems = 0;
    //public string haveItems;


    //Triger gdy player wejdzie w Tag collectable
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("collectable"))
        {
            
            Destroy(collision.gameObject);
            
            collectedItems++;
            //file.WriteString(collectedItems);

            //haveItems = file.ReadString();
            //Debug.Log(haveItems);

            //Zmiana tekstu w Canvas -> collectedTXT (odwo³anie ustawione w Unity)
            CollectedTXT.text = "Zebrane itemki: " + collectedItems;
        }
    }
}

public class HandleTextFile
{
    public void WriteString(int collectedItems)
    {
        string path = "Assets/Resources/test.txt";
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, false);
        writer.Write(collectedItems);
        writer.Close();
    }
    private string loadValue;
    public string ReadString()
    {
        string path = "Assets/Resources/test.txt";
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        loadValue = reader.ReadToEnd();
        reader.Close();
        return loadValue;
    }
   
}
