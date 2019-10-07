using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Adulator : Machine
{

    TextMeshPro rulesDescription;

    // Start is called before the first frame update
    void Start()
    {
        rulesDescription = transform.Find("Da Rulz").Find("Description").GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        rulesDescription.text = "FUCK";
    }
}
