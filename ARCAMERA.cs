using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARCAMERA : MonoBehaviour
{
    public GameObject PlaneObject;
    public AudioClip theme;

    void Start()
    {
        //GetComponent<AudioSource>().clip = theme;        //if(!audio.isPlaying)
        //GetComponent<AudioSource>().volume = (0.5f);
        //GetComponent<AudioSource>().Play();
        //this is checking for device!
        if (Application.isMobilePlatform)
        {
            GameObject cameraParent = new GameObject("camParent");
            cameraParent.transform.position = this.transform.position;
            this.transform.parent = cameraParent.transform;
            cameraParent.transform.Rotate(Vector3.right, 90); //This is for rotation of camera.
        }


        Input.gyro.enabled = true; // enabling the gyro sensor of your device make sure that your device has a gyro sensor!

        //In this part we are place camera texture on the plane object that we create!

        WebCamTexture webCameraTexture = new WebCamTexture();
        PlaneObject.GetComponent<MeshRenderer>().material.mainTexture = webCameraTexture;
        webCameraTexture.Play();
    }

    // Update is called once per frame

    void Update()
    {
        //It is for camera rotation of gyro sensor!
        Quaternion cameraRotation = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y,
            -Input.gyro.attitude.z, -Input.gyro.attitude.w);
        this.transform.localRotation = cameraRotation;
    }
}
