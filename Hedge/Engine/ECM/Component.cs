/// Component Class
/// Dev: Calum Mathison 
/// Created on: 25/06/2020
/// Change Log:
/// 

#region Externs
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace Engine.ECM
{
    /// <summary>
    /// This class acts as the parent class for all components.
    /// </summary>
    public class Component
    {
        #region Fields
        //Holds reference to the Entity the component is attached to
        protected Entity _parent;
        protected Vector2 _position;
        #endregion

        #region Properties
        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }
        #endregion

        #region Constructor
        public Component(Entity p)
        {
            // Set Parent
            _parent = p;
            _position = _parent.Position;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Initialise Method
        /// </summary>
        public virtual void Initialise()
        {

        }

        /// <summary>
        /// Load Method.
        /// </summary>
        /// <param name="content"></param>
        public virtual void Load(ContentManager content)
        {

        }

        /// <summary>
        /// Update Method.
        /// </summary>
        /// <param name="gt"></param>
        public virtual void Update(GameTime gt)
        {
            if (_position != _parent.Position)
            {
                _position = _parent.Position;
            }
        }

        /// <summary>
        /// Draw Method.
        /// </summary>
        /// <param name="sb"></param>
        public virtual void Draw(SpriteBatch sb)
        {

        }
        #endregion
    }
}
