   M S B A M L   `   `   `  ����V  RRecommenderAttacksAnalytics, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:RecommenderAttacksAnalytics.UIRecommenderAttacksAnalytics.UI  5      _4clr-namespace:RecommenderAttacksAnalytics.Converters&RecommenderAttacksAnalytics.Converters  5      3    -RecommenderAttacksAnalytics.UI.ReadTextFileUC   5      4src,clr-namespace:RecommenderAttacksAnalytics.UI  5      C
converters4clr-namespace:RecommenderAttacksAnalytics.Converters  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � DataContext  5
      ��  �� RelativeSource �� *Self+ � 	Resources 5       �� 
TargetType �� Property �� ValueC   =RecommenderAttacksAnalytics.Converters.BoolToInverseConverter   BoolToInverseConverterF   @RecommenderAttacksAnalytics.Converters.BooleanAndToBoolConverter  BooleanAndToBoolConverter@   :RecommenderAttacksAnalytics.Converters.EnumToBoolConverter  EnumToBoolConverterE   ?RecommenderAttacksAnalytics.Converters.BooleanOrToBoolConverter  BooleanOrToBoolConverterB   <RecommenderAttacksAnalytics.Converters.EqualsToBoolConverter  NotEqualsToBoolConverter   
IsInverted  EqualsToBoolConverter��%  '��       &	  M     &	 `     &	 s     &	 �     &	 �     &	 �     �� 5   
   " ��6   .�5      ��  � ��$ 8,2,8,2q�6(   5        5   
   6,     5   
   6/     5   
   6)     5   
   6.     5   
    . 6L     5   
   6+   5      .��5      � -   5        $��mainGrid��5      .+�5   
   ]� .+�5      � $��Right=�6    � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $��* �6$   .+�5$      �� $��Select files��6   $��0,5,0,0q�61   .��5%      � $��1��6   $��0,5,0,5q�6(    � ColumnDefinitions 5&      �� 5'      �� 5(      $��5 �6/   �� 5)      $��75 �6/    5-      �� 5.      $
��Auto �6,   �� 5/      $
��Auto �6,   �� 50      $
��Auto �6,   �� 51      $
��Auto �6,   .+�55      �� $��0��6$   $3��-Choose a text file containing the rating data��61   �� 58      -   5        	 ��Name$	 m_fileNameTextBox��58   ?   $��1��6"   $��0��6/   $��RightToLeft=�59   J   
 �� 
IsReadOnly
 . ��6   ��  �� Path$ FilePath� �� Mode$ TwoWay=�6f   �� 5:      -   5         ��Name$ m_openFileSelectDialogBtn��5:   >   $��1��6!   $��2��6.   $��Select��6a   {�5<      `� 5=   "    `� 	Converter# [ 6/   .1�5>   &   �� $ IsProcessing�6.    �� 	Converter# [  6B   �� 5?   &    �� ElementName$ m_fileNameTextBox��6.   $
 Text�6N   # [ 6[    �� ConverterParameter$  ��6�   5@   #   5B      �� 5G      $��2��6$   $��0��61   $5��/Choose a text file containing the fake profiles��6A   $��0,5,0,0q�5H       �� 5K      -   5        $	 m_fakeProfilesTextBox��5K   ?   $��3��6"   $��0��6/   $��RightToLeft=�5M      
 . ��5L      �� $ FakeProfilesFilePath�$ TwoWay=�.��5N   0   {�5O      `� 5P   "   # [ 6/   .1�5Q   &   �� $# AreFakeProfilesFromSameSource�6.    5R   *   ��  �� AncestorType@   :RecommenderAttacksAnalytics.UI.DataSourceUploadContainerUC"  �� 5S   &   $ IsProcessing�6.   # [  6B   5T   #   .��5U   1   5V      �� 5W      -   5        $$ m_openFakeProfileFileDialogBtn��5W   >   $��3��6!   $��2��6.   $��Select��6f   {�5Y      `� 5Z   "   # [ 6/   .1�5[   &   �� $# AreFakeProfilesFromSameSource�6.    6S   �� "  �� 5\   &   $ IsProcessing�6.   # [  6B   5^   #   5`      5a      5b      �� 5e      -   5        $��2��5e      $��Right=�6&   $��Ok��6B   $��	20,2,20,2q�6O   $��0,5,0,10q�6d   {�5f      �� $ IsProcessing�# [  � 5i      -   5         �Name$ m_completionProgressBar��5i   +   $��3��6   $��20��6L    � Value$ 0Q�6X   �� 5l      -   5         ��Name$ m_outputTextBoxScroller��5l   ,   $��4��6   $��0,5,0,0q�6M   $��Hidden=�5m      $
��Auto=�6D   .��5n      �� -	   5        $	 m_outputTextBox��5n      
�������
 . 6P   5o      5p      5q      5r      5s      