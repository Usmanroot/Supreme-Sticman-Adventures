using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
     public float speed = 2f; // Скорость движения врага
    public float detectionRange = 5f; // Дистанция, на которой враг обнаруживает игрока
    public float attackRange = 1f; // Дистанция для атаки
    public float attackCooldown = 1f; // Время между атаками

    public Transform[] patrolPoints; // Точки патрулирования
    private int currentPointIndex = 0;

    private Transform player;
    private bool isAttacking = false;
    private float attackTimer = 0f;

    private void Start()
    {
        if (patrolPoints.Length > 0)
        {
            transform.position = patrolPoints[0].position;
        }

        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    private void Update()
    {
        if (player == null)
        {
            Patrol();
        }
        else
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if (distanceToPlayer <= attackRange)
            {
                Attack();
            }
            else if (distanceToPlayer <= detectionRange)
            {
                ChasePlayer();
            }
            else
            {
                Patrol();
            }
        }
    }

    private void Patrol()
    {
        if (patrolPoints.Length == 0) return;

        Transform targetPoint = patrolPoints[currentPointIndex];
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
        }
    }

    private void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    private void Attack()
    {
        if (isAttacking) return;

        isAttacking = true;
        attackTimer = attackCooldown;
    }

    private void FixedUpdate()
    {
        if (isAttacking)
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0f)
            {
                isAttacking = false;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}