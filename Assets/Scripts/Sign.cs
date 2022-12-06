using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sign : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogBoxText;
    public string signText;
    private bool isInSign;
    void Start()
    {
        dialogBoxText.text = signText;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)&&isInSign)
        {
            dialogBox.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            isInSign = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            isInSign = false;
            dialogBox.SetActive(false);
        }
    }
}
