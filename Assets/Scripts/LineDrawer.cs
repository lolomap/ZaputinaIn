﻿using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class LineDrawer
    {
        private LineRenderer lineRenderer;
        private float lineSize;

        public LineDrawer(Transform parent, float lineSize = 0.2f)
        {
            GameObject lineObj = new GameObject("LineObj");
            lineObj.transform.parent = parent;
            lineObj.transform.position = parent.position;
            lineRenderer = lineObj.AddComponent<LineRenderer>();
            //Particles/Additive
            lineRenderer.material = new Material(Shader.Find("Hidden/Internal-Colored"));
            //lineRenderer.probeAnchor = parent;
            lineRenderer.useWorldSpace = false;
            this.lineSize = lineSize;
        }

        private void init(float lineSize = 0.2f)
        {
            if (lineRenderer == null)
            {
                GameObject lineObj = new GameObject("LineObj");
                lineRenderer = lineObj.AddComponent<LineRenderer>();
                //Particles/Additive
                lineRenderer.material = new Material(Shader.Find("Hidden/Internal-Colored"));

                this.lineSize = lineSize;
            }
        }

        //Draws lines through the provided vertices
        public void DrawLineInGameView(Vector3 start, Vector3 end, Color color)
        {
            if (lineRenderer == null)
            {
                init(0.2f);
            }

            //Set color
            lineRenderer.startColor = color;
            lineRenderer.endColor = color;

            //Set width
            lineRenderer.startWidth = lineSize;
            lineRenderer.endWidth = lineSize;

            //Set line count which is 2
            lineRenderer.positionCount = 2;

            //Set the postion of both two lines
            lineRenderer.SetPosition(0, start);
            lineRenderer.SetPosition(1, end);
        }

        public void Destroy()
        {
            if (lineRenderer != null)
            {
                UnityEngine.Object.Destroy(lineRenderer.gameObject);
            }
        }
    }
}