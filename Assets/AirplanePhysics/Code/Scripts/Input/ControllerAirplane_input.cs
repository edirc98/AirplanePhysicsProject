using UnityEngine;


namespace AirplanePhysics.AirplaneInputs
{
    public class ControllerAirplane_Input : BaseAirplane_Input
    {
        #region CUSTOM METHODS
        protected override void HandleInput()
        {

            base.HandleInput();

            ////THROTTLE
            //HandleThrottle();

            ////Main Input Handling
            //f_pitch = Input.GetAxis("Vertical");
            //f_roll = Input.GetAxis("Horizontal");
            //f_yaw = Input.GetAxis("Controlller_RHorizontal_Stick");
            ////f_throttle = Input.GetAxis("Controlller_RVertical_Stick");

            ////Brake Handling
            //f_brake = Input.GetAxis("Fire1");

            ////Flaps Handling
            //if (Input.GetButtonDown("R_Bumper"))
            //{
            //    i_flaps++;
            //}
            //if (Input.GetButtonDown("L_Bumper"))
            //{
            //    i_flaps--;
            //}

            //i_flaps = Mathf.Clamp(i_flaps, 0, i_maxFlapsIncrements);
        }

        protected override void HandleThrottle()
        {
            //THROTTLE
            if (Input.GetButton("R_Bumper"))
            {
                f_throttle += ThrottleSensitivity;
            }
            else if (Input.GetButton("L_Bumper"))
            {
                f_throttle -= ThrottleSensitivity;
            }
            f_throttle = Mathf.Clamp01(f_throttle);
        }
        #endregion
    }
}

