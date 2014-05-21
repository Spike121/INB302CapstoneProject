using System;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Data;

namespace RecommenderAttacksAnalytics.UI
{
    public partial class AbstractDataUploadUC : UserControl
    {
        private bool m_isPageActive = false;

        public bool HasFakeProfiles
        {
            get { return (bool)GetValue(HasFakeProfilesProperty); }
            set { SetValue(HasFakeProfilesProperty, value); }
        }

         public bool IsProcessing
        {
            get { return (bool)GetValue(IsProcessingProperty); }
            set { SetValue(IsProcessingProperty, value); }
        }

         public bool IsDataValid
         {
             get { return (bool)GetValue(IsDataValidProperty); }
             set { SetValue(IsDataValidProperty, value); }
         }

         public static readonly DependencyProperty IsDataValidProperty =
             DependencyProperty.Register("IsDataValid", typeof(bool), typeof(AbstractDataUploadUC), new UIPropertyMetadata(false));


        public static readonly DependencyProperty HasFakeProfilesProperty =
            DependencyProperty.Register("HasFakeProfiles", typeof(bool), typeof(AbstractDataUploadUC));

        public static readonly DependencyProperty IsProcessingProperty =
            DependencyProperty.Register("IsProcessing", typeof(bool), typeof(AbstractDataUploadUC), new UIPropertyMetadata(false));

        protected void initializeBindings()
        {
            var fakeProfilesBinding = new Binding()
            {
                RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(DataSourceUploadContainerUC), 1),
                Path = new PropertyPath("AreFakeProfilesFromSameSource"),
                Mode = BindingMode.OneWay
            };

            SetBinding(HasFakeProfilesProperty, fakeProfilesBinding);
        }



    }
}
