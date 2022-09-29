using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskThreeFirst : MonoBehaviour
{
    public float speed;
    public float acceleration;
    //public Vector3 startPosition;

    private Transform _originTransform;
    private float _exceedTime;
    private float _lenght;
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.transform.position = startPosition;
        _exceedTime = 0f;
        _lenght = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        speed += Time.deltaTime * acceleration;
        gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        _lenght += Mathf.Abs(speed * Time.deltaTime);
        _exceedTime += Time.deltaTime;
        Debug.Log("Времени прошло: " + _exceedTime + " с");
        Debug.Log("Пройденный путь: " + _lenght + " м");
        Debug.Log("Текущая скорость: " + speed + " м/с");
        Debug.Log("Координата тела: " + gameObject.transform.position);
    }
}
 
