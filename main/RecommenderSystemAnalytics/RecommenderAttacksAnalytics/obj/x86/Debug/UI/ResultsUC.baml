   M S B A M L   `   `   `  ����V  RRecommenderAttacksAnalytics, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:RecommenderAttacksAnalytics.UIRecommenderAttacksAnalytics.UI  5      O,clr-namespace:RecommenderAttacksAnalytics.UIRecommenderAttacksAnalytics.UI  5      O,clr-namespace:RecommenderAttacksAnalytics.UIRecommenderAttacksAnalytics.UI  5	      e7clr-namespace:RecommenderAttacksAnalytics.UI.Containers)RecommenderAttacksAnalytics.UI.Containers  5
      _4clr-namespace:RecommenderAttacksAnalytics.Converters&RecommenderAttacksAnalytics.Converters  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      .    (RecommenderAttacksAnalytics.UI.ResultsUC   5      4src,clr-namespace:RecommenderAttacksAnalytics.UI  5      8results,clr-namespace:RecommenderAttacksAnalytics.UI  5      I EWpfAnimatedGif, Version=1.4.4.0, Culture=neutral, PublicKeyToken=null,gif"http://wpfanimatedgif.codeplex.com  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;ui,clr-namespace:RecommenderAttacksAnalytics.UI     5	      N
containers7clr-namespace:RecommenderAttacksAnalytics.UI.Containers     5
      K
converters4clr-namespace:RecommenderAttacksAnalytics.Converters     5      9system&clr-namespace:System;assembly=mscorlib     5        � DataContext  5      ��  �� RelativeSource �� *Self+ � 	Resources 5      A   ;RecommenderAttacksAnalytics.Converters.BoolToValueConverter &  "BoolToVisibilityCollapsedConverter   	TrueValue   
FalseValue   
ReturnType  System.Windows.Visibility ) %NotBoolToVisibilityCollapsedConverter  BoolToYesNoStringConverter  SquareBackgroundBorder �� 
TargetType �� Property �� Value��%�  &	        &	 @     &	 �     &	 �       5   
   $ Visible��6U   $ 	Collapsed��6i   "  6�     5   
   $ 	Collapsed��6X   $ Visible��6n   "  6�     5   
   $ Y��6M   $ N��6[   " ��6j   �� 5   
   " ��6/   .�5      ��  � ��$
 55px��6*   �� 5       � ��$
 55px��6)   �� 5       �@��Padding$ 5,5,5,5q�6(   �� 5       � �� �#6767676+   5      5      .��5      � .+�5   
   � 	 � RowDefinitions	 5      �� 5      �� 5      $
��Auto �6    .+�5!      �� ��6   �� 
 �� Path$
 PredictionsResults���5"      �� 5#       �� DataTypeI   CRecommenderAttacksAnalytics.UI.Containers.PredictionResultContainer"  6'   .R�5$      ��  ��Name$
 bbbb��6-   .��5&   "   ��  �� Padding$ 5q�6)   $��0,0,0,2q�65   
����������	#FFF8F8F8._�5'   &   �  � ColumnDefinitions 5(   *   �� 5)   .   $
��Auto �6?   �� 5*   .   $
��Auto �6?   �� 5+   .   �� 5,   .   $
��Auto �6?   �� 5-   .   $
��Auto �6?   .+�51   *   �� $��0��65   .+�52   .   �� $��Center=�68   $��Item #��6U   $��14(�6c    J� Opacity$	 0.6Q�53   8   �� 54   .   #��[ 65   ._�55   2   �� $��Center=�6[   $��Center=�56   <   $��26(�6W   
���������55   <   �� $
 EntityId�56   e   57   /   58   +   �� 5;   *   $��1��65   $��6,0,0,0q�6E   .+�5<   .   �� $��Center=�68   $��Is promoted��6U   $��14(�6h   $	 0.6Q�5=   8   �� 5>   .   #��[ 65   ._�5?   2   �� $��Center=�5A   5   $��Center=�6R   $��26(�6m   
���������5@   5   �� $
 
IsPromoted� �� 	Converter# [ 5B   5   5C   /   5D   +   �� 5G   *   $��3��65   .+�5H   .   �� $��Center=�68   $��Original prediction��6U   $��12(�5I   8   $	 0.6Q�6F   $��WrapWithOverflow=�6T   �� 5J   .   #��[ 65   $��Center=�5K   5   ._�5L   2   �� $��Center=�5M   <   $��Center=�6Y   $��26(�5N   <   
���������5L   <   �� $
 OriginalScore� �� StringFormat$
 0.##��5N   J   5O   /   5Q   +   �� 5T   *   $��4��65   $��6,0,0,0q�6E   .+�5U   .   �� $��Center=�68   $��Final prediction��6U   $��12(�6m   $	 0.6Q�5V   8   $��WrapWithOverflow=�6F   �� 5W   .   #��[ 65   $��Center=�5X   5   ._�5Y   2   �� $��Center=�5Z   <   $��Center=�6Y   $��26(�5[   <   
���������5Y   <   �� $
 
FinalScore�$
 0.##��5[   J   5\   /   5^   +   5`   '   5a   #   5g      5h      ��5j      �� 5k      " ��6    .�5l      ��  � ��$ Stretch=�6K   6]   5m      5o      5t      �� 5u   
   $��Center=�6   y�60   �� $
 IsProcessing�# [  .+�5v      �� "  WpfAnimatedGif.ImageBehavior   AnimatedSource$) #../Resources/Images/ajax-loader.gif��6      RepeatBehavior$ Forever��5w      $��25��5x      �� 5y      $��Loading results...��6   $��Center=�62   5z      5{      5|      