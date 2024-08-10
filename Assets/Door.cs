using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Door : MonoBehaviour
{
    [SerializeField] Key Key;
    public SpriteRenderer Renderer;
    public Sprite Sprite;
    private void Start() {
       
    }
    private void Update()
    {
        if(Key.unlocked == true)
        {
            Renderer.sprite = Sprite;
            gameObject.tag = "Gate";
        }
    }
}
