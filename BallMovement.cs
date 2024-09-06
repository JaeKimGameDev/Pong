using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BallMovement : MonoBehaviour
{
    public GameManager gameManager;
    public Rigidbody2D ballFrame;
    public Renderer ballColorRenderer;
    public AudioSource audioSource;
    public TrailRenderer trailRenderer;
    public ParticleSystem ballParticleSystem;

    public float movementSpeed=600f;
    public float extraSpeedPerHit=1.1f;

    public float minInitialAngle=0.25f;
    public float maxInitialAngle=0.75f;
    public float maxStartY=4f;
    public float startX=0f;
    
    public float colorRedIntensity = 1f;
    public float shakeIntensity = 3f;

    void Start()
    {
        ballColorRenderer = GetComponent<Renderer>();
        audioSource = GetComponent<AudioSource>();
        colorRedIntensity = 1f;
        trailRenderer.GetComponent<TrailRenderer>().enabled = false;
    }

    private void Update()
    {
        if (colorRedIntensity > 0)
        {
            colorRedIntensity -= 0.02f * Time.deltaTime;
            Color customColor = new Color(1f, colorRedIntensity, colorRedIntensity, 1f);
            ballColorRenderer.material.SetColor("_Color", customColor);
        }
    }

    public void StartBall(int leftOrRight)
    {
        shakeIntensity = 4f;
        colorRedIntensity = 1f;
        trailRenderer.GetComponent<TrailRenderer>().enabled = false;
        ballFrame.velocity = Vector2.zero;
        float posY = Random.Range(-maxStartY, maxStartY);
        Vector2 position = new Vector2(startX, posY);
        transform.position = position;

        EmitParticle(32);
        Vector2 dir = Vector2.right;
        if (leftOrRight == 1)
        {
            dir = Vector2.left;
        }
        dir.y = Random.Range(-maxInitialAngle, maxInitialAngle);
        if (dir.y < minInitialAngle & dir.y >= 0)
        {
            dir.y += 0.25f;
        }
        else if (dir.y > -minInitialAngle & dir.y < 0)
        {
            dir.y -= 0.25f;
        }
        ballFrame.velocity = dir * movementSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioSource.Play();
        ScoreZone scoreZone = collision.GetComponent<ScoreZone>();
        if (scoreZone) 
        {
            gameManager.screenShake.StartShake(shakeIntensity, 0.05f);
            gameManager.ScoredPointOnPlayer(scoreZone.id);
            this.StartBall(scoreZone.id);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.Play();
        Racket paddle = collision.collider.GetComponent<Racket>();
        if (paddle){
            EmitParticle(16);
            gameManager.screenShake.StartShake(shakeIntensity, 0.05f);
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            Vector2 vel = rb.velocity;
            if (vel.x > 850)
            {
                shakeIntensity = 8f;
                trailRenderer.GetComponent<TrailRenderer>().enabled = true;
            }
            ballFrame.velocity = vel * extraSpeedPerHit;
        }
        else
        {
            EmitParticle(8);
            gameManager.screenShake.StartShake(shakeIntensity, 0.05f);
        }
    }
    private void EmitParticle(int amount)
    {
        ballParticleSystem.Emit(amount);
    }
}