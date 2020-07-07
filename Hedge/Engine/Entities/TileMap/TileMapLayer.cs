using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Engine.ECM;
using Engine.Components.Graphics;
using Engine.Components.Physics;


namespace Engine.Entities.TileMap
{
    public class TileMapLayer : Entity
    {
        #region Fields
        
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public TileMapLayer() : base()
        {

        }
        #endregion

        #region Methods
        public override void Initialise()
        {
            base.Initialise();
        }

        public override void Load(ContentManager content)
        {
            base.Load(content);
        }

        public override void Update(GameTime gt)
        {
            base.Update(gt);
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
        }
        #endregion
    }
}
