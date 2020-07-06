using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Engine.ECM;
using Engine.Input;

namespace Engine.Entities.Camera
{
    public class FreeCamera : Camera
    {
        #region Fields
        private Vector2 _newPos;
        private float _speed, _zoom;
        #endregion

        #region Properties
        public float Zoom
        {
            get { return _zoom; }
        }

        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
        #endregion

        #region Constructor
        public FreeCamera(Viewport v) : base(v)
        {

        }
        #endregion

        #region Methods
        public override void Initialise()
        {
            _speed = 10f;
            _zoom = 1f;
            base.Initialise();
        }

        public override void Update(GameTime gt)
        {
            ControlCameraMovement();
            ControlCameraZoom();
            UpdateMovement();
            base.Update(gt);
        }

        #endregion

        #region Functions
        /// <summary>
        /// Update Movement Function
        /// Calculates position after input.
        /// </summary>
        private void UpdateMovement()
        {
            // Calculate new position
            Vector2 pos = Position + _newPos;
            // Set parents position
            Position = pos;
            // Reset input
            _newPos = Vector2.Zero;
        }

        /// <summary>
        /// Control Camera Movement Function
        /// Detects input from the player and applies speed temp position.
        /// </summary>
        private void ControlCameraMovement()
        {
            // Up & Down
            if (InputManager.Instance.IsKeyDown(Keys.W) || 
                InputManager.Instance.IsButtonDown(Buttons.DPadUp))
            {
                _position.Y += -_speed;
            }
            else if (InputManager.Instance.IsKeyDown(Keys.S) ||
                InputManager.Instance.IsButtonDown(Buttons.DPadDown))
            {
                _position.Y += _speed;
            }

            // Right & Left
            if (InputManager.Instance.IsKeyDown(Keys.D) ||
                InputManager.Instance.IsButtonDown(Buttons.DPadRight))
            {
                _position.X += _speed;
            }
            else if (InputManager.Instance.IsKeyDown(Keys.A) ||
                InputManager.Instance.IsButtonDown(Buttons.DPadLeft))
            {
                _position.X += -_speed;
            }
        }

        /// <summary>
        /// Control Camera Zoom Function
        /// Detects input from the scroll wheel and calls function to 
        /// calculate the zoom value.
        /// </summary>
        private void ControlCameraZoom()
        {
            if (InputManager.Instance.GetMouseScrollUp())
            {
                AdjustZoom(0.05f);
            }
            else if (InputManager.Instance.GetMouseScrollDown())
            {
                AdjustZoom(-0.05f);
            }
        }

        /// <summary>
        /// Adjust Zoom Function.
        /// Calculates zoom value and clamps value
        /// </summary>
        /// <param name="zoom">Float for zoom speed</param>
        private void AdjustZoom(float zoom)
        {
            _zoom += zoom;
            if (_zoom < .35f)
            {
                _zoom = .35f;
            }
            if (_zoom > 2f)
            {
                _zoom = 2f;
            }
        }
        #endregion
    }
}
