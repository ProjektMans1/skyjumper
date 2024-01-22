using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemsCollection : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI CollectedTXT;

    //Zmienna do zliczania podniesionych itemkow
    private int collectedItems = 0;


    //Triger gdy player wejdzie w Tag collectable
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("collectable"))
        {
            Destroy(collision.gameObject);

            collectedItems++;
            //Zmiana tekstu w Canvas -> collectedTXT (odwo³anie ustawione w Unity)
            CollectedTXT.text = "Zebrane itemki: " + collectedItems.ToString();
        }
    }
}
