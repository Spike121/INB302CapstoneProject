   M S B A M L   `   `   `  ����   RecommenderAttacksAnalytics/    )RecommenderAttacksAnalytics.UI.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  
MainWindow��$	��440��$	��525��$	��715��$	��850�� � SizeToContent$ Manual=�.���  � RowDefinitions �� $
��Auto ���  � ColumnDefinitions �� $
��Auto ��� .+��� $��0,0,2,0q�
�������$��0��$��1��._��  �� $
��Auto ��� �� $
��Auto �.+��� $��0��$	��150�� � 	Resources    baseSelectedPageBtnStyle �� 
TargetType �� Property �� Value �� BasedOn ! highlightSelectedPageBtnStyle  pageSelectionBtnTemplate	 �� TextAlignment��%9  &	        '�� �     7   &	 �     7   &	 �     �� " ��.���  � ��$ 1,1,0,1q���  � ��
 �������  � ��$ 50����  �@�Cursor$
 Hand����  � ��
 ������� unselectedPageStyle��8   " ���� 8   " ���� .R��� -   ._��� $��1- Get data��$��Center=�$	 Center=�.+��� -   
 ��Name$
 
getDataBtn��._��� $��1- Get data��$��Center=�$
	 Left=�$��30,0,0,0q��� -   $
 m_selectUsersBtn��._��� $��2- Select users��$��Center=�$
	 Left=�$��30,0,0,0q��� -   $
 m_selectItemsBtn��._��� $��3- Select items��$��Center=�$
	 Left=�$��30,0,0,0q��� -   $
 m_resultsBtn��._��� $��
4- Results��$��Center=�$
	 Left=�$��30,0,0,0q��� �� -   $
 testPageBtn��$��2��$��1,1,0,1q�
�������$��50�� � Cursor$
 Hand��
�������._��� $��Tests��$��Center=�$	 Center=��� $��1��$��1��$��0,1,0,0q�
�������._��� -    ��Name$ leftPanelContent��$��5q�