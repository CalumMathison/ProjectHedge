using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Hedge.Scenes
{
    public class TestScene : Scene
    {
        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public TestScene() : base()
        {

        }
        #endregion

        #region Methods
        public override void Initialise()
        {
            base.Initialise();
        }

        public override void Load(ContentManager Content)
        {
            base.Load(Content);
        }

        public override void Update(GameTime gt)
        {
            base.Update(gt);
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Begin();
            base.Draw(sb);
            sb.End();
        }
        #endregion
    }
}
