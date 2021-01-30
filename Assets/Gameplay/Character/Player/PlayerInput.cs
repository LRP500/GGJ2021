using UnityEngine;

namespace GGJ2021
{
    public static class PlayerInput
    {
        #region Constants

        public const string HorizontalAxisName = "Horizontal";
        public const string VerticalAxisName = "Vertical";

        public const KeyCode InteractKey = KeyCode.E;
        public const KeyCode CrouchKey = KeyCode.LeftControl;
        public const KeyCode JumpKey = KeyCode.Space;
        public const KeyCode RunKey = KeyCode.LeftShift;

        #endregion Constants

        #region Getters

        public static float HorizontalAxis => Input.GetAxis(HorizontalAxisName);
        public static float VerticalAxis => Input.GetAxis(VerticalAxisName);

        public static bool Interact => Input.GetKeyDown(InteractKey);
        public static bool Crouch => Input.GetKey(CrouchKey);
        public static bool Jump => Input.GetKeyDown(JumpKey);
        public static bool Run => Input.GetKey(RunKey);

        #endregion Getters
    }
}
