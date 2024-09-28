using System;
using UnityEngine;

[RequireComponent(typeof(BirdMover))]
[RequireComponent(typeof(BirdCollisionHandler))]
public class Bird : MonoBehaviour
{
    private BirdMover _birdMover;
    //private BirdController _birdController;  
    private BirdCollisionHandler _handler;

    public event Action GameOvered;

    private void Awake()
    {
        _handler = GetComponent<BirdCollisionHandler>();
        _birdMover = GetComponent<BirdMover>();
        //_birdController = GetComponent<BirdController>();
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
    }

    public void Reset()
    {
        _birdMover.Reset();
        //_birdController.Reset();
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Ground)
        {
            GameOvered?.Invoke();
        }

        if (interactable is Bullet)
        {
            GameOvered?.Invoke();
        }
    }
}