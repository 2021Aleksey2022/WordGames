using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //скорость камеры
    public float rotateSpeed = 10.0f, speed = 10.0f, zoomSpeed = 10.0f;

    //увеличение скорости
    private float _mult = 1f;

    private void Update()
    {
        //отслеживание кнопок A, D, стрелки налево и право
        float hor = Input.GetAxis("Horizontal");

        //отслеживание кнопок W, S, также стрелок вверх и вниз
        float ver = Input.GetAxis("Vertical");


        //Нажатие кнопок
        float rotate = 0f;
        if (Input.GetKey(KeyCode.Q))
            rotate = -1f;
        else if (Input.GetKey(KeyCode.E))
            rotate = 1f;

        //увеличиваем скрость если нажали на кнопку
        _mult = Input.GetKey(KeyCode.LeftShift) ? 2f : 1f;

        //Rotate - вращение, переумножаем для получения результата
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * rotate * _mult, Space.World);

        //Translate - передвижение
        transform.Translate(new Vector3(hor, 0, ver) * Time.deltaTime * _mult * speed, Space.Self);

        //передвижение колёсиком вверх вниз по оси Y
        transform.position += transform.up * zoomSpeed * Input.GetAxis("Mouse ScrollWheel");
        transform.position = new Vector3(
            transform.position.x,
            Mathf.Clamp(transform.position.y, -20f, 180f),
            transform.position.z);
    }
}
