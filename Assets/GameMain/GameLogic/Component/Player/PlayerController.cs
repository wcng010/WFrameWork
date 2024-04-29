using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Cinemachine;
namespace Wcng
{
    public class PlayerController : NetworkBehaviour
    {
        [SyncVar(hook = nameof(ColorChanged))]
        Color PlayerColor = Color.white;

        [Command]
        void CmdChangeColor(Color color){
            PlayerColor = color;
        }

        Rigidbody rb;
        MaterialPropertyBlock prop;
        CinemachineVirtualCamera cv;

        void ColorChanged(Color oldColor, Color newColor){
            Debug.Log("Color Changed");
            prop.SetColor("_Color" ,newColor);
            GetComponent<Renderer>().SetPropertyBlock(prop);
        }

        private void Start() {
            rb = GetComponent<Rigidbody>();
            prop = new MaterialPropertyBlock();
            GetComponent<Renderer>().GetPropertyBlock(prop);
            if(isLocalPlayer){
                cv = GameObject.FindGameObjectWithTag("VCAM").GetComponent<CinemachineVirtualCamera>();
                cv.Follow = this.transform;
                cv.LookAt = this.transform;
            }
        }

        private void Update() {
            if(!isLocalPlayer) return;
            if(Input.GetKeyDown(KeyCode.Space)){
                CmdChangeColor(PlayerColor == Color.white?Color.black:Color.white);
            }
        }
    }
}