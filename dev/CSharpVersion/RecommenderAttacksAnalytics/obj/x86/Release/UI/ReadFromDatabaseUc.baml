   M S B A M L   `   `   `  ���� V  RRecommenderAttacksAnalytics, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:RecommenderAttacksAnalytics.UIRecommenderAttacksAnalytics.UI  _4clr-namespace:RecommenderAttacksAnalytics.Converters&RecommenderAttacksAnalytics.Converters  7    1RecommenderAttacksAnalytics.UI.ReadFromDatabaseUc   4src,clr-namespace:RecommenderAttacksAnalytics.UI  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     K
converters4clr-namespace:RecommenderAttacksAnalytics.Converters     :xctk)http://schemas.xceed.com/wpf/xaml/toolkit       � DataContext  ��  �� RelativeSource �� *Self+ � 	Resources  �� 
TargetType �� Property �� ValueA   ;RecommenderAttacksAnalytics.Converters.BoolToValueConverter   BoolToVisibilityConverter   	TrueValue   
FalseValue   
ReturnType  System.Windows.Visibility��%�   '��       'G� (     '�� P     &	  �     �� " ��.���  � ��$ 0,5,0,0q��� " G�.���  � ��$ 0,5,0,0q��� " ��.���  � ��$ 8,2,8,2q���  � ��$ 5,2,0,10q�  $ Visible��$ Hidden��"  .��� 	 � RowDefinitions	 �� $
��Auto ��� $
��Auto ��� $
��Auto ��� .+��� $��0��$��Database info��$��5q�.��� 	 �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �
 � ColumnDefinitions
 �� $
��Auto ��� $��75 ��� .+��� $��0��$��0��$��Hostname/IP:��$��Center=�$
��Left=��� -    ��Name$ hostname��$��0��$��2��$��	localhost���� $��1��$��0��$��User:��$��Center=�$
��Left=��� -   $ m_usernameInputField��$��1��$��2������  �� Path$ DatabaseInfos.Username� �� Mode$ TwoWay=��� $��2��$��0��$��	Password:��$��Center=�$
��Left=�G� -    G�Name$ m_passwordInputField��$��2��$��2���� $��3��$��0��$��Port:��$��Center=�$
��Left=��� -   $ m_portInputField��$��3��$��2��$��75��$
��Left=� �� 	MaxLength$ 0������ $ DatabaseInfos.Port�$ TwoWay=��� $��4��$��0��$��Schema:��$��Center=�$
��Left=��� -   $ m_schemaInputfield��$��4��$��2������ $ DatabaseInfos.Schema�$ TwoWay=��� $��1�� �� Orientation$ 
Horizontal=�$��Right=�.+��� -    ��Name$ m_loadFromFileBtn��$
��Load��$��25���� -   $ m_saveAsFileBtn��$��Save as��$��25���� -   $ m_fetchDataBtn��$��
Fetch data��$��25��� -	    �Name$ m_completionProgressBar��$��2��$��20�� � Value$ 0Q��� -
    ��Name$ m_outputTextBoxScroller��$��3��$��0,5,0,0q�$��Hidden=�$
��Auto=�.���� -   $ m_outputTextBox��
������� �� 
IsReadOnly . 