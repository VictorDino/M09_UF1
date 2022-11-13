using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthDamage : MonoBehaviour
{
    public int maxHealth = 100;

    public int currentHealth;

    public HealthBar healthBar;

    public bool invencible = false;

    public float timeInvencible = 1f;

    public float waitTime = 0.5f;

    private Animator animator;

    public int starQuantity = 0;

    public TextMeshProUGUI stars;
    


    private void Start()
    {
        animator = GetComponent<Animator>();

        currentHealth = maxHealth;

        healthBar.setMaxHealth(maxHealth);

        
    }

    private void Update()
    {
        winGame();

        stars.text = starQuantity.ToString();
    }

    public void getDamage(int quantity)
    {
        if (!invencible && currentHealth > 0)
        {
            currentHealth -= quantity;
            animator.Play("Damage");
            StartCoroutine(Invulnaberatility());
            StartCoroutine(EffectMove());
            healthBar.setHealth(currentHealth);

            if (currentHealth == 0) 
            {
               gameOver();
            }
        }
        
    }

    void winGame()
    {
        if (starQuantity == 10)
        {

            Debug.Log("YOU WIN");
            
            Time.timeScale = 0;
        }
    }

    void gameOver()
    {
        animator.Play("Die");
        
        SceneManager.LoadScene("SampleScene");
    }


    IEnumerator WaitTIme()
    {
        
        yield return new WaitForSeconds(5);
        
    }
    IEnumerator Invulnaberatility()
    {
        invencible = true;
        yield return new WaitForSeconds(timeInvencible);
        invencible = false;
    }

    IEnumerator EffectMove()
    {
        var currentSpeed = GetComponent<PlayerMove>().speed;
        GetComponent<PlayerMove>().speed = 0;
        yield return new WaitForSeconds(waitTime);
        GetComponent<PlayerMove>().speed = currentSpeed;
    }


}
