   M S B A M L   `   `   `  ����  
ProjektWPF    ProjektWPF.FilterWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Filtruj zadania��5   	   $	��350��6!   $	��300��6.    � WindowStartupLocation$ CenterOwner=�5   	   .��5      � $��10q�6   .+�5   
   �� .+�5      �� $��
Kategoria:��6   �� 5	       �� DisplayMemberPath$
 Name��5      ��5	      �� *
Categories+ �� SelectedItem 5
      �� *SelectedCategory+5      �� 5      $��Pilnosc:��6   $��0,10,0,0q�6(   �� 5       �� SelectedValue 6   �� *SelectedPriority+.@�5      �� $��(wszystkie)��6   
 � Tag 65   Z� �� 5      $��Niski��6   $ 0��6/   �� 5      $��Sredni��6   $ 1��60   �� 5      $��Wysoki��6   $ 2��60   5      �� 5      $��Status:��6   $��0,10,0,0q�6'   �� 5       6   �� *SelectedStatus+.@�5      �� $��(wszystkie)��6    65   Z� �� 5      $��	Ukonczone��6   $
 true��63   �� 5      $��Nieukonczone��6   $ false��66   5      �� 5      $��Termin do dnia:��6   $��0,10,0,0q�6/   (  "System.Windows.Controls.DatePicker  5         SelectedDate 6   �� *	DueBefore+�� 5       �� Orientation$ 
Horizontal=�6   $��Right=�62   $��0,15,0,0q�6N   .+�5       �� $��Zastosuj��6   $��80��6,   $��5q�67    �� 	IsDefault$
 True��6B   ��6S   �� *ApplyCommand+�� 5!      $��Anuluj��6   $��80��6*   $��5q�65   	 �� IsCancel$
	 True��6@   5"      5#      5$      5%      