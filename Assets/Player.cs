using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] int _healthPoints = 3;
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] float _speed = 10f;
    [SerializeField] Transform _left, _mid, _right, _transform;

    int _currentLane;
    HealthView _healthview;

    void Awake()
    {
        this._rigidbody = GetComponent<Rigidbody>();
        this._transform = transform;
        this._healthview = FindObjectOfType<HealthView>();
    }

    void Start()
    {
        this._currentLane = 1;
        this._rigidbody.position = this._transform.position;
        this._healthview.SetLive(this._healthPoints);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            this._healthPoints--;
            this._healthview.SetLive(this._healthPoints);
            if (this._healthPoints <= 0)
                SceneManager.LoadScene("Lose");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            this.MoveLeft();
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            this.MoveRight();
    }

    private void FixedUpdate()
    {
        Vector3 target = this._rigidbody.position;
        target.x += Time.fixedDeltaTime * this._speed;
        this._rigidbody.MovePosition(target);
    }

    void MoveLeft()
    {
        Vector3 newPos;
        switch (this._currentLane)
        {
            case 0: 
                break;
            case 1:
                this._currentLane--;
                newPos = this._transform.position;
                newPos.z = this._left.position.z;
                this._transform.position = newPos;
                break;
            case 2:
                this._currentLane--;
                newPos = this._transform.position;
                newPos.z = this._mid.position.z;
                this._transform.position = newPos;
                break;
        }
    }

    void MoveRight()
    {
        Vector3 newPos;
        switch (this._currentLane)
        {
            case 0:
                this._currentLane++;
                newPos = this._transform.position;
                newPos.z = this._mid.position.z;
                this._transform.position = newPos;
                break;
            case 1:
                this._currentLane++;
                newPos = this._transform.position;
                newPos.z = this._right.position.z;
                this._transform.position = newPos;
                break;
            case 2:
                break;
        }
    }
}