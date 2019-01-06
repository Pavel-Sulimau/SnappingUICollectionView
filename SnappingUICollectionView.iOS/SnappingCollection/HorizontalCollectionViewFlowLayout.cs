using CoreGraphics;
using UIKit;

namespace SnappingUICollectionView.iOS.SnappingCollection
{
    public class HorizontalCollectionViewFlowLayout : UICollectionViewFlowLayout
    {
        public HorizontalCollectionViewFlowLayout()
        {
            ScrollDirection = UICollectionViewScrollDirection.Horizontal;
        }

        public override UICollectionViewLayoutInvalidationContext GetInvalidationContextForBoundsChange(CGRect newBounds)
        {
            var context = (UICollectionViewFlowLayoutInvalidationContext)base.GetInvalidationContextForBoundsChange(newBounds);

            context.InvalidateFlowLayoutDelegateMetrics = newBounds != CollectionView.Bounds;

            return context;
        }
    }
}
