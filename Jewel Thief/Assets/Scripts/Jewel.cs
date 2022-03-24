using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jewel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        playerInventory PlayerInventory = other.GetComponent<playerInventory>();

        if(PlayerInventory != null)
        {
            PlayerInventory.jewelsCollected();
            gameObject.SetActive(false);
            loadLevel();
        }

    }

    public void loadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
