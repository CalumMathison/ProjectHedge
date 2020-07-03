using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Engine.ECM;
using Engine.Input;

namespace Engine.Entities.Camera
{
    public class FollowCamera : Camera
    {
        #region Fields
        private Entity _target;
        private Vector2 _offset;
        #endregion

        #region Properties
        public Entity Target
        {
            get { return _target; }
            set { _target = value; }
        }
        #endregion

        #region Constructor
        public FollowCamera(Viewport v) : base(v)
        {
            _offset = new Vector2(Width / 2, Height / 2);
        }
        #endregion

        #region Methods
        public override void Update(GameTime gt)
        {
            Position = new Vector2(_target.Position.X - _offset.X, _target.Position.Y - _offset.Y);
            base.Update(gt);
        }
        #endregion
    }
}
