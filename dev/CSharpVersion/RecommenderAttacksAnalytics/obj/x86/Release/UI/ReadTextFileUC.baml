   M S B A M L   `   `   `  ���� V  RRecommenderAttacksAnalytics, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:RecommenderAttacksAnalytics.UIRecommenderAttacksAnalytics.UI  _4clr-namespace:RecommenderAttacksAnalytics.Converters&RecommenderAttacksAnalytics.Converters  3    -RecommenderAttacksAnalytics.UI.ReadTextFileUC   4src,clr-namespace:RecommenderAttacksAnalytics.UI  C
converters4clr-namespace:RecommenderAttacksAnalytics.Converters  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       � DataContext  ��  �� RelativeSource �� *Self+ � 	Resources  �� 
TargetType �� Property �� ValueC   =RecommenderAttacksAnalytics.Converters.BoolToInverseConverter   BoolToInverseConverterF   @RecommenderAttacksAnalytics.Converters.BooleanAndToBoolConverter  BooleanAndToBoolConverter@   :RecommenderAttacksAnalytics.Converters.EnumToBoolConverter  EnumToBoolConverterE   ?RecommenderAttacksAnalytics.Converters.BooleanOrToBoolConverter  BooleanOrToBoolConverterB   <RecommenderAttacksAnalytics.Converters.EqualsToBoolConverter  NotEqualsToBoolConverter   
IsInverted  EqualsToBoolConverter��%�   '��       &	  (     &	 -     &	 2     &	 7     &	 <     &	 H     �� " ��.���  � ��$ 8,2,8,2q�           .   .��� -   $��mainGrid��.+�]� .+�� $��Right=� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* �.+��� $��Select files��$��0,5,0,0q�.��� $��1��$��0,5,0,5q� � ColumnDefinitions �� �� $��5 ��� $��75 � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$3��-Choose a text file containing the rating data���� -   	 ��Name$	 m_fileNameTextBox��$��1��$��0��$��RightToLeft=�
 �� 
IsReadOnly
 . ����  �� Path$ FilePath� �� Mode$ TwoWay=��� -    ��Name$ m_openFileSelectDialogBtn��$��1��$��2��$��Select��{�`�  `� 	Converter# [ .1��� $ IsProcessing� �� 	Converter# [  ��  �� ElementName$ m_fileNameTextBox��$
 Text�# [  �� ConverterParameter$  ���� $��2��$��0��$5��/Choose a text file containing the fake profiles��$��0,5,0,0q��� -   $	 m_fakeProfilesTextBox��$��3��$��0��$��RightToLeft=�
 . ���� $ FakeProfilesFilePath�$ TwoWay=�.��{�`� # [ .1��� $# AreFakeProfilesFromSameSource� ��  �� AncestorType@   :RecommenderAttacksAnalytics.UI.DataSourceUploadContainerUC"  �� $ IsProcessing�# [  .���� -   $$ m_openFakeProfileFileDialogBtn��$��3��$��2��$��Select��{�`� # [ .1��� $# AreFakeProfilesFromSameSource� �� "  �� $ IsProcessing�# [  �� -   $��2��$��Right=�$��Ok��$��	20,2,20,2q�$��0,5,0,10q�{��� $ IsProcessing�# [  � -    �Name$ m_completionProgressBar��$��3��$��20�� � Value$ 0Q��� -    ��Name$ m_outputTextBoxScroller��$��4��$��0,5,0,0q�$��Hidden=�$
��Auto=�.���� -	   $	 m_outputTextBox��
�������
 . 