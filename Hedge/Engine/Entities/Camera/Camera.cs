using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Engine.ECM;

namespace Engine.Entities.Camera
{
    public class Camera : Entity
    {
        #region Fields
        private float _zoom;
        private Rectangle _bounds;
        private Rectangle _visableArea;
        private Matrix _transform;
        #endregion

        #region Properties
        // Transform matrix. Plug into spritbatch to activate camera.
        public Matrix Transform
        {
            get { return _transform; }
        }
        #endregion

        #region Constructor
        public Camera(Viewport viewport) : base()
        {
            _bounds = viewport.Bounds;
            _zoom = 1f;
            Position = Vector2.Zero;

        }
        #endregion

        #region Methods
        /// <summary>
        /// Initialise Method.
        /// Adds any required components.
        /// </summary>
        public override void Initialise()
        {
            AddComponent(new CameraControllerComponent(this));
            base.Initialise();
        }

        /// <summary>
        /// Update Method.
        /// Handles matrix creation.
        /// </summary>
        /// <param name="gt"></param>
        public override void Update(GameTime gt)
        {
            // Get zoom from controller.
            _zoom = FindComponent<CameraControllerComponent>().Zoom;
            // Call matrix update.
            UpdateMatrix();

            base.Update(gt);
        }
        #endregion

        #region Functions
        /// <summary>
        /// Update Visible Area Function
        /// Handles matrix calculations
        /// </summary>
        private void UpdateVisibleArea()
        {
            Matrix inverseViewMatrix = Matrix.Invert(_transform);

            Vector2 tl = Vector2.Transform(Vector2.Zero, inverseViewMatrix);
            Vector2 tr = Vector2.Transform(new Vector2(_bounds.X, 0), inverseViewMatrix);
            Vector2 bl = Vector2.Transform(new Vector2(0, _bounds.Y), inverseViewMatrix);
            Vector2 br = Vector2.Transform(new Vector2(_bounds.Width, _bounds.Height), inverseViewMatrix);

            Vector2 min = new Vector2(
                MathHelper.Min(tl.X, MathHelper.Min(tr.X, MathHelper.Min(bl.X, br.X))),
                MathHelper.Min(tl.Y, MathHelper.Min(tr.Y, MathHelper.Min(bl.Y, br.Y))));

            Vector2 max = new Vector2(
                MathHelper.Max(tl.X, MathHelper.Max(tr.X, MathHelper.Max(bl.X, br.X))),
                MathHelper.Max(tl.Y, MathHelper.Max(tr.Y, MathHelper.Max(bl.Y, br.Y))));

            _visableArea = new Rectangle((int)min.X, (int)min.Y, (int)(max.X - min.X), (int)(max.Y - min.Y));
        }

        /// <summary>
        /// Update Matrix.
        /// Updates matrix and viewport in regards to position.
        /// </summary>
        private void UpdateMatrix()
        {
            _transform = Matrix.CreateTranslation(new Vector3(-Position.X, -Position.Y, 0)) *
                Matrix.CreateScale(_zoom) *
                Matrix.CreateTranslation(new Vector3(_bounds.Width * 0.5f, _bounds.Height * 0.5f, 0));
            UpdateVisibleArea();
        }
        #endregion
    }
}
