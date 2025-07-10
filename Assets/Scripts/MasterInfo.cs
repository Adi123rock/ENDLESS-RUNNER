using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MasterInfo : MonoBehaviour
{
    public static int cointCount;//using static other scripts can access this variable
    [SerializeField] GameObject coinDisplay;
    void Update()
    {
        coinDisplay.GetComponent<TMPro.TMP_Text>().text = "COINS "+cointCount;
    }
}
