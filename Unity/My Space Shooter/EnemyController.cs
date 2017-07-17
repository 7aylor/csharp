using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public GameObject lasers;
    public int difficulty = 1;
    public int health = 20;
    public int pointValue = 10;
    public static int damage = 10;
    public float fireRate = 0;
    public Formation currentFormation;
    public GameObject explosion;
    public AudioClip enemyLaser;
    public AudioClip hitEnemy;
    public AudioClip[] explosionSounds;

    private void Start()
    {
        currentFormation = FindObjectOfType<Formation>();
    }

    // Update is called once per frame
    void Update () {

        float random = Random.value;

        if(random < fireRate)
        {
            Instantiate(lasers, this.transform.position + lasers.transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(enemyLaser, new Vector3(0, 0, 0));
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("PlayerLaser"))
        {
            AudioSource.PlayClipAtPoint(hitEnemy, new Vector3(0, 0, 0));

            if (health <= 0)
            {
                //create explosion animation
                Instantiate(explosion, transform.position, Quaternion.identity);

                int randomIndex = Random.Range(0, explosionSounds.Length);

                //play the explosion sound effect
                AudioSource.PlayClipAtPoint(explosionSounds[randomIndex], new Vector3(0,0,0));

                //destroy the enemy
                Destroy(gameObject);

                //decrement enemy count by 1
                currentFormation.decreaseEnemyCountByOne();

                //increase player's points by enemy's point value
                PlayerController.score += pointValue;

                //update the UI with the new score
                GameUI.UI_Instance.UpdateScore(PlayerController.score);

                //number of enemies left
                Debug.Log("Enemies Left: " + currentFormation.getEnemyCount());
            }
            else
            {
                health -= PlayerController.damage;
            }
            LaserCatcher.DestroyLasers(collision.gameObject);
        }
    }

    private void PlayExplosion()
    {

    }

}