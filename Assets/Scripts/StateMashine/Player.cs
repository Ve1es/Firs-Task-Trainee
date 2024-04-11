using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //StateMashine//
    private StateMachine _sm;
    private StateRun _stateRun;
    private StateIdle _stateIdle;
    private StateJump _stateJump;
    private StateSlide _stateSlide;
    //Game Logic//
    public Animator anim;
    public float jumpHeight = 2f;
    public float jumpForce = 0.1f;
    public float jumpDuration = 0.5f;
    public float speed = 5f;
    public Rigidbody rb;
    public JumpEndEvent _jumpEndEvent;
    public SlideEndEvent _slideEndEvent;
    public Mover mover;
    public Collider colliderRun; 
    public Collider colliderSlide;

    private void Start()
    {
        _sm = new StateMachine();
        _stateRun = new StateRun(this);
        _stateIdle = new StateIdle(this);
        _stateJump = new StateJump(this);
        _stateSlide = new StateSlide(this);
        _sm.Initialize(new StateIdle(this));
        _jumpEndEvent.EndJumpSignal += Run;
        _slideEndEvent.EndSlideSignal += Run;
        Run();
    }

    private void Update()
    {
        _sm.CurrentState.Update();

    }
    public void MoveRight()
    {
        mover.MoveRight();
    }
    public void MoveLeft()
    {
        mover.MoveLeft();
    }
    public void Jump()
    {
        _sm.ChangeState(_stateJump);
    }
    public void Slide()
    {
        _sm.ChangeState(_stateSlide);
    }
    public void Run()
    {
        _sm.ChangeState(_stateRun);
    }
}
