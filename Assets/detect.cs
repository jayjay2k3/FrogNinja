using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class detect : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {       
        if (collision.gameObject.tag == "Gate")
        {          
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if(collision.gameObject.tag == "Trap")
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
