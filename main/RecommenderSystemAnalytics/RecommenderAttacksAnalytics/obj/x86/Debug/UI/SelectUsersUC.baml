   M S B A M L   `   `   `  ����V  RRecommenderAttacksAnalytics, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:RecommenderAttacksAnalytics.UIRecommenderAttacksAnalytics.UI  5      _4clr-namespace:RecommenderAttacksAnalytics.Converters&RecommenderAttacksAnalytics.Converters  5      2    ,RecommenderAttacksAnalytics.UI.SelectUsersUC   5      4src,clr-namespace:RecommenderAttacksAnalytics.UI  5      C
converters4clr-namespace:RecommenderAttacksAnalytics.Converters  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � DataContext  5
      ��  �� RelativeSource �� *Self+ � 	Resources 5       �� 
TargetType �� Property �� ValueB   <RecommenderAttacksAnalytics.Converters.IsNullToBoolConverter   IsNullToBoolConverter   
IsInverted��%�   '��       &	  v     �� 5   
   " ��6   .�5      ��  � ��$ 8,2,8,2q�6(   �� 5       � ��$ 0,5,0,0q�6'   5        5   
    . 6I   5      .��5      � $��5q�6   .+�5   
   �  � RowDefinitions 5      �� 5      �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6$   .+�5      � $��0��6   $��0��6    $��8q�61    5      �� 5       $
��Auto �6$   �� 5!      .+�5#      �� $:��4Choose a user whose items' ratings will be predicted��6   $��14(�6X   �� 5%      -   5        	 ��Name$	 m_leftUserSelector��5%   '   $��1��6   ��6C   �� 
 �� Path$
 Users� 5&      ��%E   '��       �� 5'      " ��6    .�5(      -   5        5)      5*      5+      5,      � 5/      $��1��6   $��3��6    $��0��64    50      �� 51      $
��Auto �6'   �� 52      �� 53      $
��Auto �6'   .+�56      �� -   5         ��Name$ previousPageBtn��56   )   $��0��6   $��Previous��6B   $��Right=�57      58      �� 5:      -   5        $ nextPageBtn��5:   )   $��2��6   $
��Next��6>   $��Right=�5;      {�5:   M   ��  �� ElementName$ m_leftUserSelector��$
 SelectedItem� �� 	Converter# [  5<      5=      5>      5A      5B      