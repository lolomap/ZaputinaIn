using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ConnectUps : MonoBehaviour
    {
        public static Dictionary<string, Vector2> ButtonsPosition
            = new Dictionary<string, Vector2>();

        // Use this for initialization
        void Start()
        {
            foreach(var pair in Constants.UP_CONNECTIONS)
            {
                Vector2 start = ButtonsPosition[pair.Key];
                foreach(var name in pair.Value)
                {
                    Vector2 end = ButtonsPosition[name];
                    GameObject line = new GameObject("line");
                    line.layer = 5;
                    var rect = line.AddComponent<RectTransform>();
                    line.transform.SetParent(transform.parent);
                    rect.localPosition = new Vector3(start.x, start.y + 
                        ((end.y - Constants.UP_BUTTON_SIZE/2) - (start.y - Constants.UP_BUTTON_SIZE/2))/2);
                    rect.localScale = new Vector3(1, 1, 1);
                    rect.sizeDelta = new Vector2(2, Mathf.Abs(end.y - start.y));
                    line.AddComponent<Image>().color = Color.black;

                    line.transform.SetSiblingIndex(line.transform.GetSiblingIndex() - ButtonsPosition.Keys.Count);

                    Vector2 newstart = new Vector2(rect.localPosition.x,
                        rect.localPosition.y + rect.sizeDelta.y / 2);
                    GameObject lineH = new GameObject("line");
                    lineH.layer = 5;
                    var rectH = lineH.AddComponent<RectTransform>();
                    lineH.transform.SetParent(transform.parent);
                    rectH.localPosition = new Vector3(newstart.x + (end.x - newstart.x)/2, end.y);
                    rectH.localScale = new Vector3(1, 1, 1);
                    rectH.sizeDelta = new Vector2(Mathf.Abs(end.x - newstart.x), 2);
                    lineH.AddComponent<Image>().color = Color.black;

                    lineH.transform.SetSiblingIndex(lineH.transform.GetSiblingIndex() - ButtonsPosition.Keys.Count);
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}