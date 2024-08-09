using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Door : MonoBehaviour
{
    Key Key;
    public SpriteRenderer Renderer;
    public Sprite Sprite;
    private void Update()
    {
        if(Key.unlocked == true)
        {
            Renderer.sprite = Sprite;
            gameObject.tag = "Gate";
        }
    }
}
