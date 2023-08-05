using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI interactText;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateText(string interatctMessage)
    {
        interactText.text = interatctMessage;
;
    }
}
