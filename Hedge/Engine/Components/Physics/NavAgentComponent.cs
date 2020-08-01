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
    public class NavAgentComponent : Component
    {
        #region Fields

        #endregion

        #region Properties
        #endregion

        #region Constructor
        public NavAgentComponent(Entity e) : base(e)
        {

        }
        #endregion

        #region Methods
        public override void Initialise()
        {
            base.Initialise();
        }

        public override void Update(GameTime gt)
        {
            base.Update(gt);
        }
        #endregion
    }
}
