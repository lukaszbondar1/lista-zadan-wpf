   M S B A M L   `   `   `  ����  
ProjektWPF&     ProjektWPF.CategoryManagerWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  	Kategorie��5   	   $	��300��6   $	��350��6(    � WindowStartupLocation$ CenterOwner=�5   	   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5	      $
��Auto �6   .+�5   
   ��  �� DisplayMemberPath$
 Name��5      ��5      �� *
Categories+ �� SelectedItem 5      �� *SelectedCategory+5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��0,10,0,0q�6W   .+�5      �� $��Dodaj��6   $��80��6%   $��5q�60   ��6;   �� *
AddCommand+�� 5      $��Edytuj��6   $��80��6&   $��5q�61   ��6<   �� *EditCommand+�� 5      $
��Usun��6   $��80��6$   $��5q�6/   ��6:   �� *DeleteCommand+5      5      5      