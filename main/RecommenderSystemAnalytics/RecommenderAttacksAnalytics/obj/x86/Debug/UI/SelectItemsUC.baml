   M S B A M L   `   `   `  ����V  RRecommenderAttacksAnalytics, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:RecommenderAttacksAnalytics.UIRecommenderAttacksAnalytics.UI  5      _4clr-namespace:RecommenderAttacksAnalytics.Converters&RecommenderAttacksAnalytics.Converters  5      }Cclr-namespace:RecommenderAttacksAnalytics.Entities.LocalPersistence5RecommenderAttacksAnalytics.Entities.LocalPersistence  5      2    ,RecommenderAttacksAnalytics.UI.SelectItemsUC   5      4src,clr-namespace:RecommenderAttacksAnalytics.UI  5      C
converters4clr-namespace:RecommenderAttacksAnalytics.Converters  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      `localPersistenceCclr-namespace:RecommenderAttacksAnalytics.Entities.LocalPersistence     5        � DataContext  5      ��  �� RelativeSource �� *Self+ � 	Resources 5       �� 
TargetType �� Property �� ValueJ   DRecommenderAttacksAnalytics.Converters.ArgToFormattedStringConverter    ArgToFormatedStringConverterA   ;RecommenderAttacksAnalytics.Converters.BoolToValueConverter  BoolToForegroundConverter   
ReturnType   	TrueValue   
FalseValue��%�   '��       &	  v     &	 �     �� 5   
   " ��6   .�5      ��  � ��$ 8,2,8,2q�6(   �� 5       � ��$ 0,5,0,0q�6'   5        5   
   63     5   
   " ��6L   $	 Red��6r   $ Black��6�   5      .��5      � 	 � RowDefinitions	 5   
   �� 5      �� 5      $
��Auto �6   .+�5   
   � $��0��6   $��8q�6   	 5      �� 5      $
��Auto �6    �� 5      
 � ColumnDefinitions
 5      �� 5       $
��Auto �6#   �� 5!      �� 5"      $
��Auto �6#   .+�5$      �� $��0q�6   $��Bottom=�6    $5��/Select the items whose rating will be predicted��6;   $��14(�6u   �� 5%      $��0��6   $��2��6!    J� Opacity$	 0.5Q�5&      $��0q�5'      $��Bottom=�5(      ��5)      ��  �� ElementName$ m_itemsSelector�� �� Path$ SelectedItems.Count� �� 	Converter# [   �� ConverterParameter$ {0} selected���� 5F      -   5         ��Name$ m_itemsSelector��5F   G   $��0��6   $��1��6&   $��3��63    �� SelectionMode$ Multiple=�6`   ��5G      �� $ CombinedItems���5H      �� 5I       �� DataType@   :RecommenderAttacksAnalytics.Entities.LocalPersistence.Item"  6#   .R�5J      ��  �� Orientation$ 
Horizontal=�6%   .+�5K      ��  d� 	IsChecked 5L   !   �� $ 
IsSelected� �� *FindAncestor+ �� AncestorType" ���� 5M      $��5,0,0,0q�69   ��6(   �� ��5N   (   �� $ 
IsPromoted�# [ 5O      5P      5R      5S      � 5V   
   $��2��6   $��3��6   
 5W      �� 5X      $
��Auto �6#   �� 5Y      �� 5Z      $
��Auto �6#   .+�5]      �� -   5         ��Name$ previousPageBtn��5]   %   $��0��6   $��Previous��6>   $��Right=�5^      5_      �� 5a      -   5        $ nextPageBtn��5a   %   $��2��6   $
��Next��6:   $��Right=�5b      5c      5d      5e      5f      