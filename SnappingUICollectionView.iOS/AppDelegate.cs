using Foundation;
using SnappingUICollectionView.iOS.SnappingCollection;
using UIKit;

namespace SnappingUICollectionView.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        public override UIWindow Window { get; set; }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            Window = new UIWindow(UIScreen.MainScreen.Bounds)
            {
                RootViewController = new UINavigationController(new SnappingCollectionViewController())
            };

            Window.MakeKeyAndVisible();

            return true;
        }
    }
}
