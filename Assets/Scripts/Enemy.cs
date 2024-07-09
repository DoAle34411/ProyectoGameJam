using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent enemyAgent;
    public GameObject PlayerTarget; // Ensure this is assigned either via the Unity Editor or programmatically
    public float attackRange = 3.0f;
    public float attackCooldown = 1.0f;
    public Image redTintPanel;
    public Image healthBar; // Add this to assign the health bar image in the Unity Editor

    private float nextAttackTime = 0f;
    private float tintDuration = 2.0f;
    private bool isTinting = false;

    private Animator animator; // Add this line

    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();

        // Debugging: Check if NavMeshAgent is correctly initialized
        if (enemyAgent == null)
        {
            Debug.LogError("NavMeshAgent component is missing from the enemy!");
        }

        animator = GetComponentInChildren<Animator>(); // Initialize the Animator component

        // Debugging: Check if Animator is correctly initialized
        if (animator == null)
        {
            Debug.LogError("Animator component is missing from the enemy!");
        }
    }

    void Update()
    {
        // Ensure PlayerTarget is not null before accessing its transform
        if (PlayerTarget != null)
        {
            Transform playerTransform = PlayerTarget.transform;

            enemyAgent.SetDestination(playerTransform.position);

            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

            if (distanceToPlayer <= attackRange && Time.time >= nextAttackTime)
            {
                Attack();
                nextAttackTime = Time.time + attackCooldown;
            }
        }

        if (isTinting)
        {
            tintDuration -= Time.deltaTime;
            if (tintDuration <= 0)
            {
                ClearTint();
            }
        }
    }

    void Attack()
    {
        TintScreen();
        ReduceHealthBar();
        animator.SetTrigger("Attack");
    }

    void TintScreen()
    {
        redTintPanel.color = new Color(redTintPanel.color.r, redTintPanel.color.g, redTintPanel.color.b, 0.5f);
        isTinting = true;
        tintDuration = 0.5f;
    }

    void ClearTint()
    {
        redTintPanel.color = new Color(redTintPanel.color.r, redTintPanel.color.g, redTintPanel.color.b, 0.0f);
        isTinting = false;
    }

    void ReduceHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount -= 0.1f;
            healthBar.fillAmount = Mathf.Clamp(healthBar.fillAmount, 0f, 1f); // Ensure it stays within 0 to 1 range

            if (healthBar.fillAmount == 0f)
            {
                SceneManager.LoadScene("GameOverMenu");
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            ClearTint();
        }
    }
}
