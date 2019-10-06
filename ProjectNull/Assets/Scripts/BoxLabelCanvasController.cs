using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLabelCanvasController : MonoBehaviour
{
    public BoxLabel boxLabel;

    public bool showBoxLabel = false;

    public float boxLabelFlipTime = 1f;

    float currentBoxLabelFlipTime = 0f;

    public AnimationCurve flipCurve = AnimationCurve.EaseInOut(0,0,1,1);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (showBoxLabel) {
            currentBoxLabelFlipTime = Mathf.Min(currentBoxLabelFlipTime + (Time.deltaTime / boxLabelFlipTime), 1f);
        } else {
            currentBoxLabelFlipTime = Mathf.Max(currentBoxLabelFlipTime - (Time.deltaTime / boxLabelFlipTime), 0f);
        }

        var sampledTime = flipCurve.Evaluate(currentBoxLabelFlipTime);
        boxLabel.transform.localEulerAngles = new Vector3(0, (-90f * sampledTime) - 90f, 0);


        var camera = this.GetComponent<Canvas>().worldCamera;
        
        RaycastHit hitInfo;
        showBoxLabel = false;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hitInfo, 4, 1 << 9 | 1 << 13)) {
            Box box = hitInfo.collider.GetComponent<Box>();
            if (box != null) {
                var theBoxesLabel = box.boxLabel.GetComponent<BoxLabel>();
                if (theBoxesLabel != null) {
                    boxLabel.task = theBoxesLabel.task;
                    boxLabel.UpdateLabel();
                    showBoxLabel = true;
                }
            }
        }
    }
}
