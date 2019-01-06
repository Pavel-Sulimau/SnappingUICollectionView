using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace SnappingUICollectionView.iOS.SnappingCollection
{
    public class HorizontallySnappingCollectionViewDelegateFlowLayout : UICollectionViewDelegateFlowLayout
    {
        private readonly nfloat _itemSpacing;
        private readonly nfloat _collectionMargin;
        private nfloat _itemWidth;
        private int _currentPageIndex;

        public HorizontallySnappingCollectionViewDelegateFlowLayout()
        {
            _currentPageIndex = 0;
            _itemSpacing = 8;
            _collectionMargin = 20;
        }

        public override CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
        {
            _itemWidth = collectionView.Bounds.Size.Width - 2 * _collectionMargin;
            return new CGSize(_itemWidth, collectionView.Bounds.Size.Height);
        }

        public override UIEdgeInsets GetInsetForSection(UICollectionView collectionView, UICollectionViewLayout layout, nint section)
        {
            return new UIEdgeInsets(0, _collectionMargin, 0, _collectionMargin);
        }

        public override nfloat GetMinimumLineSpacingForSection(UICollectionView collectionView, UICollectionViewLayout layout, nint section)
        {
            return _itemSpacing;
        }

        public override void WillEndDragging(UIScrollView scrollView, CGPoint velocity, ref CGPoint targetContentOffset)
        {
            nfloat pageWidth = _itemWidth + _itemSpacing;
            int newPageIndex;

            if (velocity.X > 0)
            {
                nfloat contentWidthWithoutCollectionMargins = scrollView.ContentSize.Width - 2 * _collectionMargin;
                var maxPageIndex = (int)Math.Ceiling(contentWidthWithoutCollectionMargins / pageWidth) - 1;
                newPageIndex = Math.Min(_currentPageIndex + 1, maxPageIndex);
            }
            else if (velocity.X == 0)
            {
                newPageIndex = (int)Math.Floor((targetContentOffset.X - pageWidth / 2) / pageWidth) + 1;
            }
            else
            {
                var minPageIndex = 0;
                newPageIndex = Math.Max(_currentPageIndex - 1, minPageIndex);
            }

            _currentPageIndex = newPageIndex;
            targetContentOffset = new CGPoint(newPageIndex * pageWidth, targetContentOffset.Y);
        }
    }
}
