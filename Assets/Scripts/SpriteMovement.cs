using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Windows;

public class SpriteMovement : MonoBehaviour
{
    public Rigidbody2D body;
    public float speed;
    public SpriteRenderer spriteRenderer;

    public List<Sprite> iSprites;
    public List<Sprite> nSprites;
    public List<Sprite> eSprites;
    public List<Sprite> wSprites;
    public List<Sprite> sSprites;

    public float frameRate;
    Vector2 direction;

    float idleTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = UnityEngine.Input.GetAxis("Horizontal");
        float yInput = UnityEngine.Input.GetAxis("Vertical");
                
        direction = new Vector2(xInput, yInput).normalized;
        body.linearVelocity = direction * speed;

        if(!spriteRenderer.flipX && direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (spriteRenderer.flipX && direction.x > 0)
        {
            spriteRenderer.flipX = false;
        }

        List<Sprite> directionSprites = GetSpriteDirection();

        if(directionSprites != null)
        {
            float playTime = Time.time - idleTime;
            int frame = (int)((playTime * frameRate)% directionSprites.Count);
            
            spriteRenderer.sprite = directionSprites[frame];
        } else
        {
            idleTime = Time.time;
        }
    }

    List<Sprite> GetSpriteDirection()
    {
        List<Sprite> selectedSprites = null;

        if (direction.y > 0)
        {
            selectedSprites = nSprites;
            
        } else if(direction.y < 0)
        {
            selectedSprites = sSprites;
        } else if(direction.x > 0)
        {
            selectedSprites = eSprites;
        }
        else if (direction.x < 0)
        {
            
        }
        return selectedSprites;
    }
}
