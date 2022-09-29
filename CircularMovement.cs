using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovement : MonoBehaviour
{
    public Transform centerTransform;
    public float distance;
    public float rotationFrequency;
    public float acceleration;

    private Vector3 _originPos;
    private float _exceedTime;
    private int _rotationNumber;
    private float _lenght;
    private float _speed;
    private float _period;
    private float _currentDistance;
    private float _currentRotFreq;
    private float _turnAngle;
    private bool _inAction;

    void Start()
    {
        gameObject.transform.position = new Vector3 (distance, 0f, 0f);
        _originPos = gameObject.transform.position;
        _currentDistance = distance;
        _currentRotFreq = rotationFrequency;
        _period = 1 / rotationFrequency;
        _speed = 2 * Mathf.PI * distance / _period;
        StartCoroutine(WaitAndSetNextLoop());
        _exceedTime = 0f;
        _lenght = 0f;
    }

    void Update()
    {
        if (_currentDistance != distance)
        {
            var delta = _currentDistance - distance;
            _currentDistance = distance;
            _speed = 2 * Mathf.PI * distance * rotationFrequency;
            gameObject.transform.Translate(Vector3.forward * -1 * delta);
            _originPos = gameObject.transform.position;
        }
        if (_currentRotFreq != rotationFrequency)
        {
            var rotFreqOnSpeed = _speed / 2 / Mathf.PI / distance; 
            _currentRotFreq = rotationFrequency;
            _period = 1 / rotationFrequency;
            _speed = 2 * Mathf.PI * distance / _period;
        }
        Debug.Log(Vector3.Distance(_originPos, gameObject.transform.position));
        if (Vector3.Distance(_originPos, gameObject.transform.position) <= 1 && _inAction)
        {
            _rotationNumber ++;
            _inAction = false;
            StartCoroutine(WaitAndSetNextLoop());
        }
        _turnAngle = _speed * Time.deltaTime / (2 * Mathf.PI * distance) * 360;
        _speed += Time.deltaTime * acceleration;
        gameObject.transform.RotateAround(centerTransform.position, Vector3.up, _speed / Mathf.Sqrt(distance) * Time.deltaTime * 180 / (0.4f * Mathf.PI * distance));
        _lenght += Mathf.Abs(_speed * Time.deltaTime);
        _exceedTime += Time.deltaTime;
        Debug.Log("Времени прошло: " + _exceedTime + " с");
        Debug.Log("Пройденный путь: " + _lenght + " м");
        Debug.Log("Угол поворота: " + rotationFrequency * 2 * Mathf.PI + " рад/с");
        Debug.Log("Линейная скорость: " + _speed * distance + " м/с");
        Debug.Log("Число оборотов: " + _rotationNumber);
        Debug.Log("Угловая скорость: " + _speed + " м/с");
        Debug.Log("Координата тела: " + gameObject.transform.position);
    }

    IEnumerator WaitAndSetNextLoop(){
        yield return new WaitForSeconds(_period / 10);
        _inAction = true;
    }
}
 

