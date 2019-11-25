using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (PlayerCharacter))]
    public class PlayerController : MonoBehaviour
    {
        private PlayerCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
        private Transform m_Cam;                  // A reference to the main camera in the scenes transform
        private Vector3 m_CamForward;             // The current forward direction of the camera
        private Vector3 m_Move;
        private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.
        [SerializeField]
        private Camera player_cam;
        
        private void Awake()
        {
            m_Cam = player_cam.transform;
            // get the third person character ( this should never be null due to require component )
            m_Character = GetComponent<PlayerCharacter>();
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

            // calculate move direction to pass to character
            if (m_Cam != null)
            {
                // calculate camera relative direction to move:
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                m_Move = v*m_CamForward + h*m_Cam.right;
            }
            else
            {
                // we use world-relative directions in the case of no main camera
                m_Move = v*Vector3.forward + h*Vector3.right;
            }
#if !MOBILE_INPUT
			// walk speed multiplier
	        if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;
#endif

            // pass all parameters to the character control script
            m_Character.Move(m_Move, crouch, m_Jump, block, attackOne, attackTwo, run, oneEighty);
            m_Jump = false;

        }
        public float GetVelocity()
        {
            return m_Move.magnitude;
        }
    }
}
