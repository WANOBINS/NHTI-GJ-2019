using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RenderPipeline = UnityEngine.Experimental.Rendering.RenderPipeline;

namespace WANOBINS.NHTI_GJ_2019
{
    [ExecuteInEditMode]
    public class LensHelper : MonoBehaviour
    {
        public Camera lensCamera;
        public Transform otherLens;

        private void OnEnable()
        {
            RenderPipeline.beginCameraRendering += UpdateCamera;
        }

        private void OnDisable()
        {
            RenderPipeline.beginCameraRendering -= UpdateCamera;
        }

        void UpdateCamera(Camera camera)
        {
            if ((camera.cameraType == CameraType.Game || camera.cameraType == CameraType.SceneView) &&
                camera.tag != "Lens Camera")
            {
                lensCamera.projectionMatrix = camera.projectionMatrix;

                Vector3 relativePos = transform.InverseTransformPoint(camera.transform.position);
                relativePos = Vector3.Scale(relativePos, new Vector3(1, 1, 1));
                lensCamera.transform.position = otherLens.TransformPoint(relativePos);

                Vector3 relativeRot = transform.InverseTransformDirection(camera.transform.forward);
                relativeRot = Vector3.Scale(relativeRot, new Vector3(-1, 1, -1));
                lensCamera.transform.forward = otherLens.TransformDirection(relativeRot);
            }
        }
    }
}
