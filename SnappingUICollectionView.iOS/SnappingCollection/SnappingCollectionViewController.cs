using UIKit;

namespace SnappingUICollectionView.iOS.SnappingCollection
{
    public class SnappingCollectionViewController : UIViewController
    {
        public new SnappingCollectionView View
        {
            get => (SnappingCollectionView)base.View;
            set => base.View = value;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View = new SnappingCollectionView();
            View.ItemsCollectionView.Source = new SnappingCollectionViewDataSource();
            View.ItemsCollectionView.Delegate = new HorizontallySnappingCollectionViewDelegateFlowLayout();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            NavigationItem.Title = "Snapping UICollectionView";
        }
    }
}
