   M S B A M L   `   `   `  ����V  RRecommenderAttacksAnalytics, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:RecommenderAttacksAnalytics.Converters&RecommenderAttacksAnalytics.Converters  5      O,clr-namespace:RecommenderAttacksAnalytics.UIRecommenderAttacksAnalytics.UI  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      @    :RecommenderAttacksAnalytics.UI.DataSourceUploadContainerUC   5      C
converters4clr-namespace:RecommenderAttacksAnalytics.Converters  5      4src,clr-namespace:RecommenderAttacksAnalytics.UI  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      9system&clr-namespace:System;assembly=mscorlib     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � DataContext  5      ��  �� RelativeSource �� *Self+ � 	Resources 5       �� 
TargetType �� Property �� Value   redColor  
greenColor@   :RecommenderAttacksAnalytics.Converters.EnumToBoolConverter  EnumToBoolConverterF   @RecommenderAttacksAnalytics.Converters.BooleanAndToBoolConverter  BooleanAndToBoolConverterC   =RecommenderAttacksAnalytics.Converters.BoolToInverseConverter  BoolToInverseConverterA   ;RecommenderAttacksAnalytics.Converters.BoolToValueConverter  BoolToYesNoConverter   	TrueValue   
FalseValue   
ReturnType  BoolToRedOrGreenConverter��%�  '��       '	� v     &	  �     &	 �     &	 �     &	     &	 %    &	 8    &	 m    7  7   �� 5   
   " ��6   .�5      ��  � ��$ 8,2,8,2q�6(   �� 5       � ��$ 0,5,0,0q�6'   5      �� 5   
   " 	�6   .�5      ��  � ��$ 0,3,0,0q�6'   5      ��5   
   Red��6&   ��5   
   	LimeGreen��6.     5   
   6)     5   
   6/     5   
   6,     5   
   $	 Yes��6G   $ No��6W   " ��6g     5   
   8   8  " ��6�   5      .��5      � $��5q�6   	 � RowDefinitions	 5    
   �� 5!      $
��Auto �6   �� 5"      �� 5#      $
��Auto �6   .+�5'   
   �� $��Data source��6   .��5(      �� $��4q�6   .+�5*      �� $��Choose the input method��6   	� 5+      -   5        
 	�Name$!
 m_textFileOptionRadioButton��5+      $��	Text file��6C    	� 	GroupName$ dataSourceSelectorGroup��6W   6{   	� 5,      -   5        $!
 m_databaseOptionRadioButton��5,      $��Database��6C   $ dataSourceSelectorGroup��6V   6z   �� 5.       �� Orientation$ 
Horizontal=�6   $��0,10,0,0q�66   .+�5/      �� -   5         ��Name$- 'm_areFakeProfilesFromSameSourceCheckbox��5/      $��Center=�51      $.��(Take fake profiles data from same source��6:    d� 	IsChecked 50      ��  �� Path$# AreFakeProfilesFromSameSource� �� Mode$ TwoWay=�51   :   53      �� 55      $ 
Horizontal=�6   $��0,5,0,0q�66   .+�56      �� $��Valid data: ��6   $��0q�64   $��Center=�6@   �� 57      $��5,0,0,0q�5:      ��57      �� $, &SelectedDataSourceUploadUc.IsDataValid� �� 	Converter# [ ��59      �� $, &SelectedDataSourceUploadUc.IsDataValid�# [ 5:      5;      5<      5=      �� 5@   
   $��1��6   ��6&   �� $  SelectedDataSourceUploadUc�� 5C   
   $��3��6   $��3��6    � ColumnDefinitions 5D      �� 5E      $
��Auto �6#   �� 5F      �� 5G      $
��Auto �6#   .+�5J      �� -   5         ��Name$ saveToDbButton��5J   %   $��0��6   $��Save to database��6=   $��Right=�5K      5L      �� 5N      -   5        $ nextPageBtn��5N   %   $��2��6   $
��Next��6:   $��Right=�5O      $��8,2,8,2q�65   $��0q�6G   $��22��5P   3   $��Bottom=�6?   {�5Q      `� 5R       `� 	Converter# [ 6#   .1�5S      �� $, &SelectedDataSourceUploadUc.IsDataValid�6"   �� 5T      $- 'SelectedDataSourceUploadUc.IsProcessing�6"   # [ 6Q   5U      5W      5X      5Y      5Z      