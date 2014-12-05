using System;

using CoreGraphics;
using Foundation;
using SpriteKit;
using UIKit;
using System.Linq;

namespace GimmeATexture
{
	public class MyScene : SKScene
	{
		SKTextureAtlas telephones;

		public MyScene (CGSize size) : base (size)
		{
			BackgroundColor = new UIColor (0.15f, 0.15f, 0.3f, 1.0f);
			telephones = SKTextureAtlas.FromName ("Telephone");
		}

		public override void TouchesBegan (NSSet touches, UIEvent evt)
		{ 
			foreach (var touch in touches) {

				var touchLocation = ((UITouch)touch).LocationInNode (this);
				var telephoneSprite = new SKSpriteNode ("Telephone_1");
				telephoneSprite.Position = touchLocation;
				 
				var telephoneList = telephones.TextureNames
					.Select (x => telephones.TextureNamed (x))
					.ToArray();
				 
				var animationAction = SKAction.AnimateWithTextures (telephoneList, 0.05);

				telephoneSprite.RunAction(SKAction.RepeatActionForever(animationAction));

				AddChild (telephoneSprite);
				  
			}
		}

		public override void Update (double currentTime)
		{
			// Run before each frame is rendered
			base.Update (currentTime);
		}
	}
}
