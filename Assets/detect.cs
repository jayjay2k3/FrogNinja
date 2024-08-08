using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class detect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {       
        if (collision.gameObject.name == "gate")
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if(collision.gameObject.name == "trap")
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
