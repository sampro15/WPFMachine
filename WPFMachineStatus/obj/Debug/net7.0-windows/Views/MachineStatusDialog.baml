   M S B A M L   `   `   `  ����K  GWPFMachineStatus, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WPFMachineStatusWPFMachineStatus  5   	   0    *WPFMachineStatus.Views.MachineStatusDialog   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:WPFMachineStatus     5   	     � Title$  MachineStatusDialog��5   	   $	��450��6%   $	��800��62   .��5	      � -   5         �Name$ 	main_grid��5	      $��10q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��Create / Edit  Machine��6   $��25(�62   $��Center=�6@   $��0��6]   $��5q�6j   � 5   
   -   5        $ feilds��5      $��1��6    � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $
��auto �6#   .+�5      �� -   5         ��Name$ 	sp_labels��5       �� Orientation$ Vertical=�6,   $��0��6C   .+�5      �� $��Name:��6   $��5q�6(   �� 5      $��Description:��6   $��5q�6/   �� 5      $��Status:��6   $��5q�6+   �� 5      $��Notes:��6   $��5q�6*   5      �� 5!      -   5        $ sp_textBoxes��5!      $��1��6/   .+�5"      �� -   5        $��tb_name��5"      $	��650��60   $��10q�6?   �� 5#      -   5        $��tb_decription��5#      $	��650��60   $��10q�6?   �� 5$      -   5        $��	tb_status��5$      $	��650��60   $��10q�6?   �� 5%      -   5        $��tb_notes��5%      $	��650��60   $��10q�6?   5(      5)      �� 5,   
   $ 
Horizontal=�6   $��Center=�6.   $��0,10,0,0q�6K   $��3��6]   .+�5-      �� -	   5         ��Name$ btn_OK��5-      $��OK��6%   $��5q�6I   �� 5.      -
   5        $ 
btn_CANCEL��5.      $��Cancel��6)   $��5q�6U   5/      50      51      