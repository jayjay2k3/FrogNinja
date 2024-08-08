using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    //Có thể nhận sát thương từ trap
    [SerializeField] bool Vulnerable;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="Trap" && Vulnerable)
        {
            Destroy(gameObject);
        }
    }
}
