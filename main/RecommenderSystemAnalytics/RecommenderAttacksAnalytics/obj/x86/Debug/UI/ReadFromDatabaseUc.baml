   M S B A M L   `   `   `  ����V  RRecommenderAttacksAnalytics, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:RecommenderAttacksAnalytics.UIRecommenderAttacksAnalytics.UI  5      _4clr-namespace:RecommenderAttacksAnalytics.Converters&RecommenderAttacksAnalytics.Converters  5      7    1RecommenderAttacksAnalytics.UI.ReadFromDatabaseUc   5      4src,clr-namespace:RecommenderAttacksAnalytics.UI  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      K
converters4clr-namespace:RecommenderAttacksAnalytics.Converters     5      :xctk)http://schemas.xceed.com/wpf/xaml/toolkit     5        � DataContext  5      ��  �� RelativeSource �� *Self+ � 	Resources 5       �� 
TargetType �� Property �� ValueA   ;RecommenderAttacksAnalytics.Converters.BoolToValueConverter   BoolToVisibilityConverter   	TrueValue   
FalseValue   
ReturnType  System.Windows.Visibility��%v  '��       'G� M     '�� �     &	      �� 5   
   " ��6   .�5      ��  � ��$ 0,5,0,0q�6'   5      �� 5   
   " G�6   .�5      ��  � ��$ 0,5,0,0q�6'   5      �� 5   
   " ��6   .�5      ��  � ��$ 8,2,8,2q�6(   �� 5       � ��$ 5,2,0,10q�6'   5        5   
   $ Visible��6L   $ Hidden��6`   "  6t   5      .��5      � 	 � RowDefinitions	 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5       .+�5$   
   �� $��0��6   $��Database info��6    $��5q�68   .��5%      � 	 5&      �� 5'      $
��Auto �6    �� 5(      $
��Auto �6    �� 5)      $
��Auto �6    �� 5*      $
��Auto �6    �� 5+      $
��Auto �6    �� 5,      $
��Auto �6$   
 � ColumnDefinitions
 5.      �� 5/      $
��Auto �6#   �� 50      $��75 �6#   �� 51      .+�55      �� $��0��6   $��0��6%   $��Hostname/IP:��65   $��Center=�6I   $
��Left=�6d   �� 56      -   5         ��Name$ hostname��56      $��0��6,   $��2��69   $��	localhost��6I   �� 59      $��1��6   $��0��6%   $��User:��65   $��Center=�6B   $
��Left=�6]   �� 5:      -   5        $ m_usernameInputField��5:      $��1��68   $��2��6E   ��6U   ��  �� Path$ DatabaseInfos.Username� �� Mode$ TwoWay=��� 5=      $��2��6   $��0��6%   $��	Password:��65   $��Center=�6F   $
��Left=�6a   G� 5>      -   5         G�Name$ m_passwordInputField��5>      $��2��6<   $��2��6I   �� 5A      $��3��6   $��0��6%   $��Port:��65   $��Center=�6B   $
��Left=�6]   �� 5B      -   5        $ m_portInputField��5B      $��3��65   $��2��6B   $��75��6R   $
��Left=�6]    �� 	MaxLength$ 0��6x   ��6�   �� $ DatabaseInfos.Port�$ TwoWay=��� 5E      $��4��6   $��0��6%   $��Schema:��65   $��Center=�6D   $
��Left=�6_   �� 5F      -   5        $ m_schemaInputfield��5F      $��4��67   $��2��6D   ��6T   �� $ DatabaseInfos.Schema�$ TwoWay=�5H      5I      �� 5L   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   .+�5N      �� -   5         ��Name$ m_loadFromFileBtn��5N      $
��Load��60   $��25��6?   6K   �� 5O      -   5        $ m_saveAsFileBtn��5O      $��Save as��6.   $��25��6@   6L   �� 5P      -   5        $ m_fetchDataBtn��5P      $��
Fetch data��6-   $��25��6B   6N   5Q      � 5U   
   -	   5         �Name$ m_completionProgressBar��5U   #   $��2��6   $��20��6E    � Value$ 0Q�6Q   �� 5X   
   -
   5         ��Name$ m_outputTextBoxScroller��5X   $   $��3��6   $��0,5,0,0q�6E   $��Hidden=�5Y      $
��Auto=�6F   .��5Z      �� -   5        $ m_outputTextBox��5Z      
������� �� 
IsReadOnly . 6H   5[      5\      5]      