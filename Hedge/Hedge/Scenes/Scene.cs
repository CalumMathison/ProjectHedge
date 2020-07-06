/// Scene Class
/// Dev: Calum Mathison
/// Created on: 04/07/20
/// Change Log:
/// 07/07/2020 - Added Instansiation for entity manager list

using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Engine.ECM;

namespace Hedge.Scenes
{
    /// <summary>
    /// This class acts as the base scene for all other scenes in the game.
    /// </summary>
    public class Scene
    {
        #region Fields
        protected EntityManager _em;
        #endregion

        #region Properties

        #endregion

        #region Constructor
        public Scene()
        {
            _em = new EntityManager();
            _em.List = new List<Entity>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Initialise Method
        /// Calls initialise method from entity manager.
        /// </summary>
        public virtual void Initialise()
        {
            _em.Initialise();
        }

        /// <summary>
        /// Load Method
        /// Loads entities in entity manager
        /// </summary>
        /// <param name="Content"></param>
        public virtual void Load(ContentManager Content)
        {
            _em.Load(Content);
        }

        /// <summary>
        /// Unload Method
        /// Wipes everything loaded into the content pipeline.
        /// </summary>
        /// <param name="Content"></param>
        public virtual void Unload(ContentManager Content)
        {
            Content.Unload();
        }

        /// <summary>
        /// Update Method
        /// Calls update method from entity manager.
        /// </summary>
        /// <param name="gt"></param>
        public virtual void Update(GameTime gt)
        {
            _em.Update(gt);
        }

        /// <summary>
        /// Draw Method.
        /// Calls draw method from entity manager.
        /// </summary>
        /// <param name="sb"></param>
        public virtual void Draw(SpriteBatch sb)
        {
            _em.Draw(sb);
        }
        #endregion
    }
}
