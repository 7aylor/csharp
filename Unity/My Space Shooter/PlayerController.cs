using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject laser;
    public static int health;
    public static int score;
    public static int damage = 10;
    public GameObject explosion;
    public AudioClip explosionSound;
    public AudioClip playerLaser;
    public AudioClip playerHit;
    LevelManager LevelManager;

    Rigidbody2D rb;

    public float minX = -8.25f;
    public float maxX  = 8.25f;
    public float speed = 8;
    Vector3 startPos;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        startPos = gameObject.transform.position;
        score = 0;
        health = 100;

    }
	
	// Update is called once per frame
	void Update () {

        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0, 0);
        rb.velocity = movement * speed;

        Vector3 temp = this.transform.position;
        temp.x = Mathf.Clamp(rb.position.x, minX, maxX);

        this.transform.position = temp;

        //FIRE
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireLaser();
        }

    }

    void FireLaser()
    {
        Instantiate(laser, this.transform.position , Quaternion.identity);
        AudioSource.PlayClipAtPoint(playerLaser, new Vector3(0, 0, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.layer == LayerMask.NameToLayer("EnemyLaser"))
        {
            AudioSource.PlayClipAtPoint(playerHit, new Vector3(0, 0, 0));

            health -= EnemyController.damage;
            GameUI.UI_Instance.UpdateHealth(health);
            if (health <= 0)
            {
                //end the game
                Instantiate(explosion, transform.position, Quaternion.identity);

                //play the explosion sound effect
                AudioSource.PlayClipAtPoint(explosionSound, new Vector3(0, 0, 0));

                //destroy the player
                Destroy(gameObject);

                //find the level manager in the scene
                LevelManager = FindObjectOfType<LevelManager>();

                //load the end scene
                LevelManager.LoadLevel("End");

                //find the active formation and destroy the rest of the enemies
                Formation activeFormation = FindObjectOfType<Formation>();
                activeFormation.destroyAllEnemies();
            }

            LaserCatcher.DestroyLasers(collision.gameObject);
        }
    }
}
