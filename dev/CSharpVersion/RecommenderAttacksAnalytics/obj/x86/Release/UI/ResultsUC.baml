   M S B A M L   `   `   `  ���� V  RRecommenderAttacksAnalytics, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:RecommenderAttacksAnalytics.UIRecommenderAttacksAnalytics.UI  O,clr-namespace:RecommenderAttacksAnalytics.UIRecommenderAttacksAnalytics.UI  O,clr-namespace:RecommenderAttacksAnalytics.UIRecommenderAttacksAnalytics.UI  e7clr-namespace:RecommenderAttacksAnalytics.UI.Containers)RecommenderAttacksAnalytics.UI.Containers  _4clr-namespace:RecommenderAttacksAnalytics.Converters&RecommenderAttacksAnalytics.Converters  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem .    (RecommenderAttacksAnalytics.UI.ResultsUC   4src,clr-namespace:RecommenderAttacksAnalytics.UI  8results,clr-namespace:RecommenderAttacksAnalytics.UI  I EWpfAnimatedGif, Version=1.4.4.0, Culture=neutral, PublicKeyToken=null,gif"http://wpfanimatedgif.codeplex.com  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ;ui,clr-namespace:RecommenderAttacksAnalytics.UI     N
containers7clr-namespace:RecommenderAttacksAnalytics.UI.Containers     K
converters4clr-namespace:RecommenderAttacksAnalytics.Converters     9system&clr-namespace:System;assembly=mscorlib       � DataContext  ��  �� RelativeSource �� *Self+ � 	Resources A   ;RecommenderAttacksAnalytics.Converters.BoolToValueConverter &  "BoolToVisibilityCollapsedConverter   	TrueValue   
FalseValue   
ReturnType  System.Windows.Visibility ) %NotBoolToVisibilityCollapsedConverter  BoolToYesNoStringConverter  SquareBackgroundBorder �� 
TargetType �� Property �� Value��%  &	        &	 (     &	 P     &	 j       $ Visible��$ 	Collapsed��"    $ 	Collapsed��$ Visible��"    $ Y��$ N��" ���� " ��.���  � ��$
 55px����  � ��$
 55px����  �@��Padding$ 5,5,5,5q���  � �� �#676767.��� .+�� 	 � RowDefinitions	 �� �� $
��Auto �.+��� ���� 
 �� Path$
 PredictionsResults�����  �� DataTypeI   CRecommenderAttacksAnalytics.UI.Containers.PredictionResultContainer"  .R���  ��Name$
 bbbb��.����  �� Padding$ 5q�$��0,0,0,2q�
����������	#FFF8F8F8._��  � ColumnDefinitions �� $
��Auto ��� $
��Auto ��� �� $
��Auto ��� $
��Auto �.+��� $��0��.+��� $��Center=�$��Item #��$��14(� J� Opacity$	 0.6Q��� #��[ ._��� $��Center=�$��Center=�$��26(�
����������� $
 EntityId��� $��1��$��6,0,0,0q�.+��� $��Center=�$��Is promoted��$��14(�$	 0.6Q��� #��[ ._��� $��Center=�$��Center=�$��26(�
����������� $
 
IsPromoted� �� 	Converter# [ �� $��3��.+��� $��Center=�$��Original prediction��$��12(�$	 0.6Q�$��WrapWithOverflow=��� #��[ $��Center=�._��� $��Center=�$��Center=�$��26(�
����������� $
 OriginalScore� �� StringFormat$
 0.##���� $��4��$��6,0,0,0q�.+��� $��Center=�$��Final prediction��$��12(�$	 0.6Q�$��WrapWithOverflow=��� #��[ $��Center=�._��� $��Center=�$��Center=�$��26(�
����������� $
 
FinalScore�$
 0.##������ " ��.���  � ��$ Stretch=��� $��Center=�y��� $
 IsProcessing�# [  .+��� "  WpfAnimatedGif.ImageBehavior   AnimatedSource$) #../Resources/Images/ajax-loader.gif��   RepeatBehavior$ Forever��$��25���� $��Loading results...��$��Center=�