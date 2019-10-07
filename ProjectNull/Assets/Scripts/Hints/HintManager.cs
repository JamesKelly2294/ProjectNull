using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HintManager : MonoBehaviour
{
    public TextMeshProUGUI hintText;

    private IEnumerable<Hint> AllHints
    {
        get
        {
            return FindObjectsOfType<Hint>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        hintText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var hint in AllHints)
        {
            if (hint.ShouldShowHint && !hint.IsPresenting)
            {
                hint.IsPresenting = true;

                if (!hintText.gameObject.activeSelf) {
                    hintText.gameObject.SetActive(true);
                    hintText.text = hint.HintText;
                }

                hint.WasPresented();
            }
        }
    }
}
