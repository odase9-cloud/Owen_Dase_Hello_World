
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public Image healthImage;
    public int scoreToAdd;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        if (healthImage == null)
        {
            Canvas canvas = GetComponentInChildren<Canvas>(true);

            if (canvas != null)
            {
                healthImage = canvas.GetComponentInChildren<Image>(true);
            }
        }

        if (healthImage != null)
        {
            healthImage.enabled = true;
            healthImage.gameObject.SetActive(true);

            if (maxHealth > 0)
            {
                healthImage.fillAmount = currentHealth / maxHealth;
            }
        }
        else
        {
            Debug.LogWarning(
                gameObject.name + " has no health bar Image assigned!",
                gameObject
            );
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if (healthImage != null)
        {
            healthImage.fillAmount = currentHealth / maxHealth;
        }
    }
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if (healthImage != null)
        {
            healthImage.fillAmount = currentHealth / maxHealth;
        }
        if (currentHealth <= 0)
        {
            Die();
        }
        if (GameManager.instance != null)
        {
            GameManager.instance.AddToScore(scoreToAdd);
        }
    }
    public void Die()
    {
        Death death = GetComponent<Death>();
        if (death != null)
        {
            death.Die();
        }
    }
}

