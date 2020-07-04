/// Sprite Component Class
/// Dev: Calum Mathison
/// Created on: 04/07/20
/// Change Log:
/// 

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Engine.ECM;

namespace Engine.Components.Graphics
{
    /// <summary>
    /// This class acts as the base graphics component for all sprites.
    /// </summary>
    public class SpriteComponent : Component
    {
        #region Fields
        private string _loc;
        private Texture2D _texture;
        private Vector2 _origin;
        private float _alpha, _rotation, _scale, _layer;
        private Color _color;
        #endregion

        #region Properties
        public string Loc
        {
            set { _loc = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="e"></param>
        public SpriteComponent(Entity e) : base(e)
        {
            
        }
        #endregion

        #region Methods
        /// <summary>
        /// Initialise Method. 
        /// Sets default values.
        /// </summary>
        public override void Initialise()
        {
            _alpha = 0;
            _rotation = 0;
            _scale = 1;
            _color = Color.White;
            base.Initialise();
        }

        /// <summary>
        /// Load Method
        /// Loads Texture
        /// </summary>
        /// <param name="content"></param>
        public override void Load(ContentManager content)
        {
            if (_loc == null)
            {
                throw new Exception("Error: Texture Location is null");
            }
            else
            {
                _texture = content.Load<Texture2D>(@_loc);
                if (_texture == null)
                {
                    throw new Exception("Error: Can't find texture at " + _loc);
                }
                _origin = new Vector2(_texture.Width / 2, _texture.Height / 2);
            }                 
            base.Load(content);
        }

        /// <summary>
        /// Update Method
        /// </summary>
        /// <param name="gt"></param>
        public override void Update(GameTime gt)
        {
            base.Update(gt);
        }

        /// <summary>
        /// Draw Method
        /// </summary>
        /// <param name="sb"></param>
        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
            sb.Draw(_texture, _position, null, _color * _alpha, _rotation, _origin, _scale, SpriteEffects.None, 0);
        }
        #endregion
    }
}
