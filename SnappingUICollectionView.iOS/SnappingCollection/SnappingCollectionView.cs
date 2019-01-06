using Cirrious.FluentLayouts.Touch;
using CoreGraphics;
using UIKit;

namespace SnappingUICollectionView.iOS.SnappingCollection
{
    public class SnappingCollectionView : UIView
    {
        public UICollectionView ItemsCollectionView { get; private set; }

        public SnappingCollectionView()
        {
            SetupSubviews();
            SetupLayout();
            SetupLayoutConstraints();
        }

        private void SetupSubviews()
        {
            BackgroundColor = UIColor.Gray;

            ItemsCollectionView = new UICollectionView(CGRect.Empty, new HorizontalCollectionViewFlowLayout())
            {
                BackgroundColor = UIColor.White,
                ShowsHorizontalScrollIndicator = false,
                DecelerationRate = UIScrollView.DecelerationRateFast,
                ContentInsetAdjustmentBehavior = UIScrollViewContentInsetAdjustmentBehavior.Always
            };

            ItemsCollectionView.RegisterClassForCell(typeof(SnappingCollectionItemViewCell), SnappingCollectionItemViewCell.CellId);
        }

        private void SetupLayout()
        {
            AddSubview(ItemsCollectionView);
        }

        private void SetupLayoutConstraints()
        {
            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(
                ItemsCollectionView.AtTopOfSafeArea(this),
                ItemsCollectionView.AtRightOfSafeArea(this),
                ItemsCollectionView.AtBottomOfSafeArea(this),
                ItemsCollectionView.AtLeftOfSafeArea(this));
        }
    }
}
