   M S B A M L   `   `   `  ���� V  RRecommenderAttacksAnalytics, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:RecommenderAttacksAnalytics.UIRecommenderAttacksAnalytics.UI  _4clr-namespace:RecommenderAttacksAnalytics.Converters&RecommenderAttacksAnalytics.Converters  }Cclr-namespace:RecommenderAttacksAnalytics.Entities.LocalPersistence5RecommenderAttacksAnalytics.Entities.LocalPersistence  <    6RecommenderAttacksAnalytics.UI.GeneratePromotedItemsUC   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :src,clr-namespace:RecommenderAttacksAnalytics.UI    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     K
converters4clr-namespace:RecommenderAttacksAnalytics.Converters     `localPersistenceCclr-namespace:RecommenderAttacksAnalytics.Entities.LocalPersistence       � DataContext  ��  �� RelativeSource �� *Self+ � 	Resources @   :RecommenderAttacksAnalytics.Converters.EnumToBoolConverter   EnumToBoolConverterJ   DRecommenderAttacksAnalytics.Converters.ArgToFormattedStringConverter  ItemCountToStringConverter��%   &	        &	          .��� $��5q� � RowDefinitions �� $��2* ��� $
��Auto �.+�� $��0��$��5q� � ColumnDefinitions �� �� .+�� $��0�� �� $
��Auto ��� �� $
��Auto ��� $
��Auto �.+�� $��0�� �� $
��Auto ��� �� $
��Auto �.+��� $��Select items to promote��$��14(��� $��2�� J� Opacity$	 0.5Q�$��Center=�����  �� ElementName$ m_itemSelectionListBox�� �� Path$ SelectedItems.Count� �� 	Converter# [ 	 �� ConverterParameter$	 {0} selected���� -   
 ��Name$
 m_itemSelectionListBox��$��1�� �� SelectionMode$ Multiple=����� $ AllItems�����  �� DataType@   :RecommenderAttacksAnalytics.Entities.LocalPersistence.Item"  .R���  d� 	IsChecked �� $ 
IsSelected� ��  �� AncestorType" ������ �� $��2�����	#04000000._�� $��0,2,0,0q� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� �� $
��Auto �.+��� $��0��$��Select��$��Bottom=��� -    ��Name$  m_selectRandomItemsTextBox��$��1��$��30��$��1��$��Bottom=�$��Center=�$��0q�$��Bottom=�$��5,0,5,0q��� $��2��$��random items ��$��Bottom=��� -    ��Name$ m_selectRandomItemsBtn��$��4��$��Go��$��8,2,8,2q�� $��1��$��5q� �� $
��Auto ��� $
��Auto ��� .+��� $��Options��.���  �� $
��Auto ��� $
��Auto � �� $
��Auto ���   �� 
TargetType �� Property �� Value��%�   '��       '�� @     �� " ��.���  � ��$ Right=���  � ��$ Center=��� " ��.���  � ��$ 40����  � ��$
 Left=���  � ��$ 5,0,0,0q�.+��� $��0��$��0��$%��Number of profiles to generate:���� -   $ m_fakeProfilesCountInput��$��0��$��1������ $  GeneratedFakeProfilesCount� �� Mode$ TwoWay=��� $��1��$��0��$��0,5,0,0q�$��2��.+��� $*��$Fake profiles ratings filling method��$
��Left=�	� -    	�Name$ m_randomizedFillingBtn��$"��Fill with randomized ratings�� � ToolTip$F @The fake profiles' unpromoted ratings will be selected at random�� �� $ FillingMethod�# [  N   HRecommenderAttacksAnalytics.UI.GeneratePromotedItemsUC+FillingMethodEnum   RANDOM#	 Z 	� -   $ m_targetedFillingBtn��$ ��Fill with targeted ratings��$� �The fake profiles' unpromoted ratings will be selected to match some of the current users' ratings, increasing the influence of the promoted item on the final rating�� �� $ FillingMethod�# [     TARGETED#	 Z �� $��1��$��Saving��$��0,5,0,0q�.���  �� $
��Auto ��� $
��Auto � �� �� $
��Auto �.+��� $:��4Save your generated fake profiles for subsequent use��$��0,10,0,5q��� -   $ m_saveFilenameTextBox��$��0��$��1���� $��1��$��1��$
��Save��$��8,2,8,2q��� -   $ m_generateBtn��$��1��$��Generate��$��8,2,8,2q�$��Right=�