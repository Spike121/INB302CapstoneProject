   M S B A M L   `   `   `  ����  RecommenderAttacksAnalytics/    )RecommenderAttacksAnalytics.UI.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
MainWindow��5   	   $	��440��6   $	��525��6,   $	��715��69   $	��850��6H    � SizeToContent$ Manual=�6T   .��5      �  � RowDefinitions 5   
   �� 5	      $
��Auto �6   �� 5
       � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   �� $��0,0,2,0q�6   
�������$��0��5      $��1��6!   ._�5      �  5      �� 5      $
��Auto �6$   �� 5      �� 5      $
��Auto �6$   .+�5      �� $��0��6   $	��150��6*    � 	Resources 5         baseSelectedPageBtnStyle �� 
TargetType �� Property �� Value �� BasedOn ! highlightSelectedPageBtnStyle  pageSelectionBtnTemplate	 �� TextAlignment��%�  &	        '�� �     7   &	     7   &	 <    �� 5       " ��6A   .�5!      ��  � ��$ 1,1,0,1q�6@   �� 5"       � ��
 �����6;   �� 5#       � ��$ 50��67   �� 5$       �@�Cursor$
 Hand��67   �� 5%       � ��
 �����6<   5&      �� 5(      unselectedPageStyle��8   " ��6q   �� 5)      8   " ��6z   �� 5*      .R�5+      �� -   5        ._�5,   "   �� $��1- Get data��6,   $��Center=�6@   $	 Center=�6[   5-      5.      5/      .+�50      �� -   5        
 ��Name$
 
getDataBtn��50      ._�51      �� $��1- Get data��6$   $��Center=�68   $
	 Left=�6S   $��30,0,0,0q�6h   52      �� 53      -   5        $
 m_selectUsersBtn��53      ._�54      �� $��2- Select users��6$   $��Center=�6<   $
	 Left=�6W   $��30,0,0,0q�6l   55      �� 56      -   5        $
 m_selectItemsBtn��56      ._�57      �� $��3- Select items��6$   $��Center=�6<   $
	 Left=�6W   $��30,0,0,0q�6l   58      �� 59      -   5        $
 m_resultsBtn��59      ._�5:      �� $��
4- Results��6$   $��Center=�67   $
	 Left=�6R   $��30,0,0,0q�6g   5;      �� 5<      5=      �� 5@      -   5        $
 testPageBtn��5@   &   $��2��6   $��1,1,0,1q�6;   
�������$��50��6m    � Cursor$
 Hand��6y   
�������._�5A      �� $��Tests��6    $��Center=�6.   $	 Center=�6I   5B      5C      5D      �� 5G   
   $��1��6   $��1��6!   $��0,1,0,0q�6.   
�������._�5H      �� -   5         ��Name$ leftPanelContent��5H      $��5q�68   5I      5J      5L      