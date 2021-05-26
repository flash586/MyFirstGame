using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    /// кількість зібраних кубів
    private int count;
    /// Початкова кількість кубів
    private int countCoub;
    /// текстові поля
    public Text countText, winText, countTextrev;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0; /// по замовчуванням зібрано 0 кубів
        winText.text = ""; /// текст перемоги по замовчуванням прихований
                           /// отримуємо кількість елементів з тегом cubes
        countCoub = GameObject.FindGameObjectsWithTag("cubes").Length;
        setCount();
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "cubes")
        {
            Destroy(other.gameObject);
            count++;
            setCount();
        }
    }
    /// Функція зміни текстів
    private void setCount()
    {
        countText.text = " Кількість :" + count.ToString();
        countTextrev.text = " Залишилось :" + (countCoub - count).ToString();
        if (count >= countCoub)
            winText.text = " Перемога !!!";
    }
}
