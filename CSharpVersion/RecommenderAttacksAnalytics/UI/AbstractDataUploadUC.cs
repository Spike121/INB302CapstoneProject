using System;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Data;
using RecommenderAttacksAnalytics.Converters;
using RecommenderAttacksAnalytics.InputOutput;

namespace RecommenderAttacksAnalytics.UI
{
    public abstract class AbstractDataUploadUC : UserControl
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

        protected  AbstractDataIO m_normalDataIoModule;
        protected  AbstractDataIO m_fakeProfilesDataIoModule;       

         public static readonly DependencyProperty IsDataValidProperty =
             DependencyProperty.Register("IsDataValid", typeof(bool), typeof(AbstractDataUploadUC), new UIPropertyMetadata(false));


        public static readonly DependencyProperty HasFakeProfilesProperty =
            DependencyProperty.Register("HasFakeProfiles", typeof(bool), typeof(AbstractDataUploadUC));

        public static readonly DependencyProperty IsProcessingProperty =
            DependencyProperty.Register("IsProcessing", typeof(bool), typeof(AbstractDataUploadUC), new UIPropertyMetadata(false));

        protected AbstractDataUploadUC(AbstractDataIO normalDataIoModule, AbstractDataIO fakeProfilesDataIoModule)
        {
            m_normalDataIoModule = normalDataIoModule;
            m_fakeProfilesDataIoModule = fakeProfilesDataIoModule;
        }

        protected void initializeBindings()
        {
            initializeHasFakeProfilesBindings();
            initializeIsDataValidBindings();
            initializeIsProcessingBindings();
        }

        protected void initializeHasFakeProfilesBindings()
        {
            var fakeProfilesBinding = new Binding()
            {
                RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(DataSourceUploadContainerUC), 1),
                Path = new PropertyPath("AreFakeProfilesFromSameSource"),
                Mode = BindingMode.OneWay
            };

            SetBinding(HasFakeProfilesProperty, fakeProfilesBinding);
        }

        protected virtual void initializeIsProcessingBindings()
        {
            var isProcessingMultiBinding = new MultiBinding()
            {
                Converter = new BooleanOrToBoolConverter(),
                Bindings =
                {
                    new Binding {Source = m_normalDataIoModule, Path = new PropertyPath(AbstractDataIO.IsProcessingProperty.Name)},
                    new Binding {Source = m_fakeProfilesDataIoModule, Path = new PropertyPath(AbstractDataIO.IsProcessingProperty.Name)}
                }
            };

            SetBinding(IsProcessingProperty, isProcessingMultiBinding);
        }

        protected abstract void initializeIsDataValidBindings();

    }
}
