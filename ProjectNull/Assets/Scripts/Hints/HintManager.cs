using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HintManager : MonoBehaviour
{
    public TextMeshProUGUI hintText;
    private Hint activeHint = null;
    private bool dismissHint = false;

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
        if (dismissHint && activeHint != null)
        {
            HideHint();
            activeHint = null;
            dismissHint = false;
        }

        foreach (var hint in AllHints)
        {
            if (hint.ShouldShowHint && !hint.IsPresenting)
            {
                hint.IsPresenting = true;
                ShowHint(hint);
                hint.WasPresented();
            }
        }
    }

    void ShowHint(Hint hint)
    {
        if (!hintText.gameObject.activeSelf)
        {
            hintText.gameObject.SetActive(true);
            hintText.text = hint.HintText;
        }
        activeHint = hint;
    }

    void HideHint()
    {
        if (hintText.gameObject.activeSelf)
        {
            hintText.gameObject.SetActive(false);
            hintText.text = "";
        }
    }

    public void DismissHint(Hint hint)
    {
        if (activeHint == hint)
        {
            dismissHint = true;
        }
    }
}
