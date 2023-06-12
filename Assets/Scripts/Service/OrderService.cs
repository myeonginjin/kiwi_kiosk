using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class OrderService : MonoBehaviour
{
    public TextMeshProUGUI readyTMPro;
    public TextMeshProUGUI doneTMPro;
    public UnityEvent onMove;

    OrderData orderData;

    void Awake()
    {
        orderData = GetComponent<OrderData>();
    }

    public void ReadyOrderNum(int num)
    {
        readyTMPro.text = num.ToString();
    }

    public IEnumerator MoveCustomer(bool isTakeOut)
    {
        yield return new WaitForSeconds(7);

        CompleteOrderNum();
        PutItem(isTakeOut);

        float moveRate = 0f;
        Vector3 startPosition = orderData.customer.transform.position;

        while (moveRate < 1f)
        {
            moveRate += Time.deltaTime * 0.7f;
            orderData.customer.transform.position = Vector3.Lerp(
                startPosition, orderData.customerDest.position, moveRate);

            yield return new WaitForEndOfFrame();
        }

        onMove.Invoke();
    }

    void CompleteOrderNum()
    {
        doneTMPro.text = readyTMPro.text;
        readyTMPro.text = "";
    }

    void PutItem(bool isTakeOut)
    {
        if (isTakeOut)
            Instantiate(orderData.bagPrefab, orderData.itemPos);
        else
            Instantiate(orderData.burgerPrefab, orderData.itemPos);
    }
}
