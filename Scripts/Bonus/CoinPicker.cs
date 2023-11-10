using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinPicker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) 
    {       
        if (collision.TryGetComponent<Coin>(out Coin coin))      
           Destroy(collision.gameObject);       
    }
}
