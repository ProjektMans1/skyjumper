using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteract : MonoBehaviour
{
    public bool see;
    public TextMeshProUGUI dialogue;
    public Image image;

    void Start()
    {
        dialogue.enabled = false;    
        image.enabled = false;    
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dialogue.enabled = true;
            image.enabled = true;
            
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogue.enabled = false;
        image.enabled = false;
    }

}
