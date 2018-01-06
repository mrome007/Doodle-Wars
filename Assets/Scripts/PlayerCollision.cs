using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour 
{
    [SerializeField]
    private List<SpriteRenderer> playerSprites;

    private float health = 100f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            DecreaseHealth(5f);
        }

        if(other.tag == "Boss")
        {

        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    private void DecreaseHealth(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            RestartGame();
        }

        var playerColor = playerSprites[0].color;
        for(int index = 0; index < playerSprites.Count; index++)
        {
            playerColor.a = health / 100f;
            playerSprites[index].color = playerColor;
        }
    }

    public void IncreaseHealth(float hp)
    {
        health += hp;
        if(health >= 100f)
        {
            health = 100f;
        }

        var playerColor = playerSprites[0].color;
        for(int index = 0; index < playerSprites.Count; index++)
        {
            playerColor.a = health / 100f;
            playerSprites[index].color = playerColor;
        }
    }
}
