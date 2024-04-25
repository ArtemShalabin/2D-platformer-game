using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject winCanvas;
    [SerializeField]
    private bool isActiveWinCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.CompareTag("Player"))
        {
            if(isActiveWinCanvas == false)
            {
                Instantiate(winCanvas);
                isActiveWinCanvas = true;
            }

        }
    }
}
