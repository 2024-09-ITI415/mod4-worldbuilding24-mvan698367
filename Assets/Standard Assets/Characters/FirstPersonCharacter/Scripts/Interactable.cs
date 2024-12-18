using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string itemName = "Mug";

    public void OnInteract()
{
    Debug.Log("Picked up: " + itemName);


    GameTimer gameTimer = FindObjectOfType<GameTimer>();
    if (gameTimer != null)
    {
        gameTimer.MugCollected();
    }
    else
    {
        Debug.LogError("GameTimer script not found in the scene! Make sure GameManager exists.");
    }

    gameObject.SetActive(false); 
}

}
