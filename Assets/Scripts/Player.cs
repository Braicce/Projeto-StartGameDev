using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float runSpeed = 3;

    private Rigidbody2D rig;
    private PlayerItens playerItens;

    private float initialSpeed;
    private Vector2 _direction;
    private bool _isRunning;
    private bool _isRolling;
    private bool _isCutting;
    private bool _isDigging;
    private bool _isWatering;

    [HideInInspector] public int handlingObj;

    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

    public bool isRunning
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }

    public bool isRolling
    {
        get { return _isRolling; }
        set { _isRolling = value; }
    }

    public bool isCutting
    {
        get { return _isCutting; }
        set { _isCutting = value; }
    }

    public bool isDigging
    {
        get { return _isDigging; }
        set { _isDigging = value; }
    }

    public bool isWatering
    {
        get { return _isWatering; }
        set { _isWatering = value; }
    }


    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
        playerItens = GetComponent<PlayerItens>();
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            handlingObj = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            handlingObj = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            handlingObj = 2;
        }

        OnInput();
        OnRun();
        OnRolling();
        OnCutting();
        OnDigging();
        OnWatering();

    }

    private void FixedUpdate()
    {
        OnMove();
    }

    #region Movement
    void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    }
    
    void OnMove()
    {
       rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime); //Moveposition é a posição do personagem na cena + a direcao vezes a velocidade

    }
    
    void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            _isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
            _isRunning = false;
        }
    }
    void OnRolling()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            speed = runSpeed;
            _isRolling = true;
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            speed = initialSpeed;
            _isRolling = false;
        }
    }

    void OnCutting()
    {
        if (handlingObj == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                speed = 0f;
                _isCutting = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                speed = initialSpeed;
                _isCutting = false;

            }
        }
    }

    void OnDigging()
    {
        if (handlingObj == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                speed = 0f;
                _isDigging = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                speed = initialSpeed;
                _isDigging = false;

            }
        }
    }

    void OnWatering()
    {
        if (handlingObj == 2)
        {
            if (Input.GetMouseButtonDown(0) && playerItens.currentWater > 0)
            {                
                speed = 0f;
                _isWatering = true;
            }

            if (Input.GetMouseButtonUp(0) || playerItens.currentWater < 0)
            {
                speed = initialSpeed;
                _isWatering = false;

            }

            if (isWatering)
            {
                playerItens.currentWater -= 0.01F;
            }
        }
    }
    #endregion
}
