   M S B A M L   `   `   `  ���� V  RRecommenderAttacksAnalytics, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:RecommenderAttacksAnalytics.UIRecommenderAttacksAnalytics.UI  _4clr-namespace:RecommenderAttacksAnalytics.Converters&RecommenderAttacksAnalytics.Converters  2    ,RecommenderAttacksAnalytics.UI.SelectUsersUC   4src,clr-namespace:RecommenderAttacksAnalytics.UI  C
converters4clr-namespace:RecommenderAttacksAnalytics.Converters  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       � DataContext  ��  �� RelativeSource �� *Self+ � 	Resources  �� 
TargetType �� Property �� ValueB   <RecommenderAttacksAnalytics.Converters.IsNullToBoolConverter   IsNullToBoolConverter   
IsInverted��%c   '��       &	  C     �� " ��.���  � ��$ 8,2,8,2q���  � ��$ 0,5,0,0q�   . .��� $��5q�.+��  � RowDefinitions �� �� $
��Auto � � ColumnDefinitions �� �� $
��Auto ��� $
��Auto �.+�� $��0��$��0��$��8q� �� $
��Auto ��� .+��� $:��4Choose a user whose items' ratings will be predicted��$��14(��� -   	 ��Name$	 m_leftUserSelector��$��1������ 
 �� Path$
 Users� ��%   '��       �� " ��.�-   � $��1��$��3��$��0�� �� $
��Auto ��� �� $
��Auto �.+��� -    ��Name$ previousPageBtn��$��0��$��Previous��$��Right=��� -   $ nextPageBtn��$��2��$
��Next��$��Right=�{���  �� ElementName$ m_leftUserSelector��$
 SelectedItem� �� 	Converter# [  