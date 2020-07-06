using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Hedge.Scenes;

namespace Hedge
{
    public class SceneManager
    {
        #region Fields
        private static SceneManager _instance;
        private Dictionary<string, Scene> _scenes;
        private Scene _activeScene;
        private ContentManager _contentManager;
        #endregion

        #region Properties
        public static SceneManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SceneManager();
                }

                return _instance;
            }
        }
        #endregion

        #region Constructor
        public SceneManager()
        {
            _scenes = new Dictionary<string, Scene>();
            _scenes.Add("TestScene", new TestScene());
        }
        #endregion

        #region Methods
        public void Initialise()
        {
            foreach (KeyValuePair<string, Scene> scene in _scenes)
            {
                scene.Value.Initialise();
            }

            _activeScene = _scenes["TestScene"];
        }

        public void Load(ContentManager Content)
        {
            _contentManager = Content;
            _activeScene.Load(Content);
        }

        public void Update(GameTime gt)
        {
            _activeScene.Update(gt);
        }

        public void Draw(SpriteBatch sb)
        {
            _activeScene.Draw(sb);
        }

        public void ChangeScene(string scene)
        {
            _activeScene.Unload(_contentManager);
            _activeScene = _scenes[scene];
            _activeScene.Initialise();
            _activeScene.Load(_contentManager);
        }
        #endregion
    }
}
