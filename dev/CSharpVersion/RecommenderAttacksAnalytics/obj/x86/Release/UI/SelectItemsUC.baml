   M S B A M L   `   `   `  ���� V  RRecommenderAttacksAnalytics, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:RecommenderAttacksAnalytics.UIRecommenderAttacksAnalytics.UI  _4clr-namespace:RecommenderAttacksAnalytics.Converters&RecommenderAttacksAnalytics.Converters  }Cclr-namespace:RecommenderAttacksAnalytics.Entities.LocalPersistence5RecommenderAttacksAnalytics.Entities.LocalPersistence  2    ,RecommenderAttacksAnalytics.UI.SelectItemsUC   4src,clr-namespace:RecommenderAttacksAnalytics.UI  C
converters4clr-namespace:RecommenderAttacksAnalytics.Converters  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     `localPersistenceCclr-namespace:RecommenderAttacksAnalytics.Entities.LocalPersistence       � DataContext  ��  �� RelativeSource �� *Self+ � 	Resources  �� 
TargetType �� Property �� ValueJ   DRecommenderAttacksAnalytics.Converters.ArgToFormattedStringConverter    ArgToFormatedStringConverterA   ;RecommenderAttacksAnalytics.Converters.BoolToValueConverter  BoolToForegroundConverter   
ReturnType   	TrueValue   
FalseValue��%�   '��       &	  C     &	 H     �� " ��.���  � ��$ 8,2,8,2q���  � ��$ 0,5,0,0q�    " ��$	 Red��$ Black��.��� 	 � RowDefinitions	 �� �� $
��Auto �.+�� $��0��$��8q�	 �� $
��Auto ��� 
 � ColumnDefinitions
 �� $
��Auto ��� �� $
��Auto �.+��� $��0q�$��Bottom=�$5��/Select the items whose rating will be predicted��$��14(��� $��0��$��2�� J� Opacity$	 0.5Q�$��0q�$��Bottom=�����  �� ElementName$ m_itemsSelector�� �� Path$ SelectedItems.Count� �� 	Converter# [   �� ConverterParameter$ {0} selected���� -    ��Name$ m_itemsSelector��$��0��$��1��$��3�� �� SelectionMode$ Multiple=����� $ CombinedItems�����  �� DataType@   :RecommenderAttacksAnalytics.Entities.LocalPersistence.Item"  .R���  �� Orientation$ 
Horizontal=�.+���  d� 	IsChecked �� $ 
IsSelected� �� *FindAncestor+ �� AncestorType" ���� $��5,0,0,0q����� ���� $ 
IsPromoted�# [ � $��2��$��3��
 �� $
��Auto ��� �� $
��Auto �.+��� -    ��Name$ previousPageBtn��$��0��$��Previous��$��Right=��� -   $ nextPageBtn��$��2��$
��Next��$��Right=�