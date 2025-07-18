using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MasterInfo : MonoBehaviour
{
    public static int cointCount;//using static other scripts can access this variable
    [SerializeField] GameObject coinDisplay;
    [SerializeField] GameObject distDisplay;
    [SerializeField] GameObject player;
    void Update()
    {
        coinDisplay.GetComponent<TMPro.TMP_Text>().text =""+cointCount;
        float dist = player.GetComponent<Transform>().position.z +29;
        // int cnt = (int)dist;
        distDisplay.GetComponent<TMPro.TMP_Text>().text ="Dist"+(int)dist;
    }
}
