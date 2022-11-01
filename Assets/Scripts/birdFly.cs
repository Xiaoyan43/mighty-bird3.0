using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class birdFly : MonoBehaviour
{

    public Rigidbody2D rb2d;

    public Animator animator;

    public GameMananger gameMananger;

    public float chengdu = 1f;

    public Transform birdImg;

    public float birdSpeed = 6;
    
    void Start()
    {
        //animator.SetInteger("state", 1);
        animator = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        GameContainer.Instance.OnValueChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        GameContainer.Instance.OnValueChanged -= OnValueChanged;
    }

    private void OnValueChanged()
    {
        animator = GetComponentInChildren<Animator>();
        ChangeState(_isFly, _isSim);
    }


    void LateUpdate()
    {
        //Debug.Log(rb2d.velocity);
        if (!gameMananger.isGameStart) return;
        if (Input.GetMouseButtonDown(0) && Time.timeScale == 1)
        {
            Fly();
        }


        birdImg.transform.DORotateQuaternion(Quaternion.Euler(0, 0, rb2d.velocity.y * chengdu), 0.3f);
    }

    public void Fly()
    {
        rb2d.velocity = new Vector2(0, birdSpeed);
    }

    private bool _isFly;
    private bool _isSim;

    public void ChangeState(bool isFly,bool isSim = false)
    {
        _isFly = isFly;
        _isSim = isSim;
        if (isFly)
        {
            animator.SetInteger("state", 0);
        }
        else
        {
            animator.SetInteger("state", 1);
        }
        rb2d.simulated = isSim;
    }
}
