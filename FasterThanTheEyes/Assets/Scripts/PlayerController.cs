using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (PlayerCharacter))]
    public class PlayerController : MonoBehaviour
    {
        private PlayerCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
        private Vector3 m_CamForward;             // The current forward direction of the camera
        private Vector3 m_Move;
        private bool m_Jump;          
        
        private void Awake()
        {
            // get the third person character ( this should never be null due to require component )
            m_Character = GetComponent<PlayerCharacter>();
        }

        private void Update()
        {
            //Debug.Log("Velocity: " + m_Character.GetVelocity());
        }


        // Fixed update is called in sync with physics
        private void FixedUpdate()
        {
            // read inputs
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
            bool crouch = CrossPlatformInputManager.GetButton("Crouch");
            bool block = CrossPlatformInputManager.GetButton("Block");
            bool attackOne = CrossPlatformInputManager.GetButtonDown("AttackOne");
            bool attackTwo = CrossPlatformInputManager.GetButtonDown("AttackTwo");
            bool run = CrossPlatformInputManager.GetButton("Run");
            bool oneEighty = CrossPlatformInputManager.GetButtonDown("OneEighty");
            m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            Vector3 lookAt;

            // calculate move direction to pass to character
            
                // calculate camera relative direction to move:
            m_CamForward = Vector3.Scale(Vector3.forward, new Vector3(1, 0, 1)).normalized;
            m_Move = v * m_CamForward + h * Vector3.right;
            m_Move = Quaternion.Euler(transform.rotation.eulerAngles) * m_Move;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Vector3 dir = hit.point - ray.origin;
                    Debug.DrawRay(ray.origin, dir, Color.red, 0);
                    //Debug.Log(hit.point);
                    lookAt = hit.point;
                }
                else
                {
                    lookAt = Vector3.zero;
                }

                //lookAt = new Vector3(ray.origin.x, transform.position.y, ray.origin.x);
                //lookAt -= transform.position;
#if !MOBILE_INPUT
			// walk speed multiplier
	        //if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;
#endif

            // pass all parameters to the character control script
            m_Character.Move(m_Move, crouch, m_Jump, block, attackOne, attackTwo, run, oneEighty, lookAt);
            m_Jump = false;

        }
    }
}
