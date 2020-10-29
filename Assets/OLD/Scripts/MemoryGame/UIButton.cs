using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    [SerializeField] private string targetMessage;
    public Color hightColor = Color.cyan;

    public void OnMouseEnter()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        if (sprite != null)
            sprite.color = hightColor;
    }

    public void OnMouseExit()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        
        if (sprite != null)
            sprite.color = Color.white;
    }

    public void OnMouseDown()
    {
        transform.localScale = Vector3.one;

        if (targetObject != null)
            targetObject.SendMessage(targetMessage);
    }
}
