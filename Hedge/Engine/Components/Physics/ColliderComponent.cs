using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Engine.ECM;

namespace Engine.Components.Physics
{
    public class ColliderComponent : Component
    {
        #region Fields
        private Rectangle _rect;
        private Texture2D _debugTex;
        private int _width, _height;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public ColliderComponent(Entity e, int w, int h) : base(e)
        {
            _width = w;
            _height = h;
        }
        #endregion

        #region Methods
        public override void Initialise()
        {
            _rect = new Rectangle((int)_position.X, (int)_position.Y, _width, _height);
            base.Initialise();
        }

        public override void Load(ContentManager content)
        {
            _debugTex = content.Load<Texture2D>("Graphics/Debug/DebugCollider");
            base.Load(content);
        }

        public override void Update(GameTime gt)
        {
            base.Update(gt);
            if (_position.X != _rect.X || _position.Y != _rect.Y)
            {
                _rect.X = (int)_position.X;
                _rect.Y = (int)_position.Y;
            }
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);

            if (Globals.DebugMode)
            {
                sb.Draw(_debugTex, _rect, null, Color.White);
            }
        }
        #endregion
    }
}
